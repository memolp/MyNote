using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyNote.Data;
using MyNote.View;

namespace MyNote
{
    class NoteNodeInfo
    {
        public long Length;
        public string MD5;
    }
    /// <summary>
    /// 前提：
    ///     1. 本地创建了一个笔记本
    ///     2. 配置了同步的服务器地址和Token还有远程笔记本名字和guid
    /// 同步流程：
    ///     1. 拿服务器notebook的数据以及修改时间回来
    ///     2. 如果本地的比服务器的新，则将本地推送给服务器
    ///     3. 如果远程的新，则替换本地，并将本地的全部节点数据也拉取回来
    /// </summary>
    public class NoteBookSync
    {
        public delegate void OnSyncNoteBookCompletedHandler(NoteBook book);
        public delegate void OnSyncNoteBookFailedHandler(NoteBook book);

        private static readonly string NOTE_BOOK_STRUTCTURE = "/notebook/info";
        private static readonly string NOTE_BOOK_NODES = "/notebook/nodes";
        private static readonly string NOTE_BOOK_SAVE = "/notebook/save";
        private static readonly string NOTE_PAGE = "/note/get";
        private static readonly string NOTE_PAGE_SAVE = "/note/save";
        private static readonly string NOTE_PAGE_DEL = "/note/del";

        private readonly HttpClient client;
        private readonly string token;

        public NoteBookSync(string token, string url)
        {
            this.token = token;
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(url);
        }
        /// <summary>
        /// 下载服务器的NoteBook并同步本地的笔记本
        /// 同步的细节：
        ///  1. 下载整个NoteBook对象及全部NoteDoucment的md5信息。
        ///  2. 更新本地的NoteBook并对比本地已经存在的NoteDocument文件的MD5
        ///  3. 只有md5不一致才会从服务器下载。
        /// </summary>
        /// <param name="notebook"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<bool> DownloadFromServer(NoteBook notebook)
        {
            NoteBook netbook = await GetNoteBookAsync(notebook.sync_uuid, notebook.BookName, notebook.BookPath);
            if (netbook == null)  // 服务器上没有
            {
                return false;
            }
            notebook.CurrentNodeUID = netbook.CurrentNodeUID;
            notebook.BookUID = netbook.BookUID;     // 完全新的这个UID是需要设置的
            notebook.BookNotes.Clear();
            Dictionary<string, NoteNodeInfo> notes = await GetNoteBookNodesInfoAsync(notebook.sync_uuid, notebook.BookName, notebook.BookUID);
            if(notes == null)   // 获取全部的节点信息出问题了
            {
                return false;
            }
            var result = await CheckAndDownloadNoteNodes(notebook, notes);
            if (!result)        // 更新本地的节点信息出问题了
            {
                return false;
            }
            // 更新全部的节点信息
            UpdateNoteBookNoteNodes(notebook, null, netbook.BookNotes);
            // 立即保存
            notebook.Save();
            return true;
        }
        /// <summary>
        /// 上传服务器
        /// </summary>
        /// <param name="notebook"></param>
        /// <returns></returns>
        public async Task<bool> UploadToServer(NoteBook notebook)
        {
            Dictionary<string, NoteNodeInfo> notes = await GetNoteBookNodesInfoAsync(notebook.sync_uuid, notebook.BookName, notebook.BookUID);
            if (notes == null)   // 获取全部的节点信息出问题了
            {
                notes = new Dictionary<string, NoteNodeInfo>(); 
            }
            var result = await CheckAndUploadNoteNodes(notebook, notes);
            if(!result)
            {
                return false;
            }
            return await UpdateNoteBookAsync(notebook);
        }

        /// <summary>
        /// 生成请求参数的md5
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string buildToken(params string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string arg in args)
            {
                sb.Append(arg);
            }
            sb.Append(this.token);  // 需要结合加密key一起生成md5

            string raw = sb.ToString();
            var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(raw);
            var hashBytes = md5.ComputeHash(bytes);
            md5.Clear();
            // 转成小写十六进制字符串
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="net_local"></param>
        /// <param name="notebook_name"></param>
        /// <returns></returns>
        private FormUrlEncodedContent build_query_note_book(string net_local, string notebook_name)
        {
            var time = DateTime.Now.ToString();
            var md5 = this.buildToken(net_local, notebook_name, time);
            var arguments = new Dictionary<string, string>
            {
                {"name", notebook_name },
                {"path", net_local },
                {"time", time},
                {"token", md5},
            };
            return new FormUrlEncodedContent(arguments);
        }
        /// <summary>
        /// 获取服务器指定名字的笔记本 xx.mnote
        /// </summary>
        /// <param name="notebook_name"></param>
        /// <returns></returns>
        private async Task<NoteBook> GetNoteBookAsync(string net_local, string notebook_name, string local_path)
        {
            var content = this.build_query_note_book(net_local, notebook_name);
            var respone = await this.client.PostAsync(NOTE_BOOK_STRUTCTURE, content);
            respone.EnsureSuccessStatusCode();
            string jsonString = await respone.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                string msg = jsonDoc.RootElement.GetProperty("msg").GetString();
                //TODO throw exception
                return null;
            }
            var data = jsonDoc.RootElement.GetProperty("data").GetString();

            NoteBook notebook = NoteBook.LoadBookFromStream(Convert.FromBase64String(data), local_path);
            return notebook;
        }

        private FormUrlEncodedContent build_query_nodes_info(string sync_uuid, string bookName, string bookUID)
        {
            var time = DateTime.Now.ToString();
            var md5 = this.buildToken(sync_uuid, bookName, bookUID, time);
            var arguments = new Dictionary<string, string>
            {
                {"name", bookName },
                {"path", sync_uuid },
                {"guid", bookUID },
                {"time", time},
                {"token", md5},
            };
            return new FormUrlEncodedContent(arguments);
        }
        /// <summary>
        /// 从服务器下载笔记本的全部内容节点的大小和md5信息
        /// </summary>
        /// <param name="sync_uuid"></param>
        /// <param name="bookName"></param>
        /// <param name="bookUID"></param>
        /// <returns></returns>
        private async Task<Dictionary<string, NoteNodeInfo>> GetNoteBookNodesInfoAsync(string sync_uuid, string bookName, string bookUID)
        {
            var content = this.build_query_nodes_info(sync_uuid, bookName, bookUID);
            var respone = await this.client.PostAsync(NOTE_BOOK_NODES, content);
            respone.EnsureSuccessStatusCode();
            string jsonString = await respone.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                string msg = jsonDoc.RootElement.GetProperty("msg").GetString();
                return null; // TODO 对与这种需要下面处理
            }
            if(!jsonDoc.RootElement.TryGetProperty("data", out var data))
            {
                return null;
            }

            Dictionary<string, NoteNodeInfo> notes = new Dictionary<string, NoteNodeInfo>();
            foreach (var item in data.EnumerateObject())
            {
                NoteNodeInfo noteInfo = new NoteNodeInfo();
                noteInfo.Length = item.Value.GetProperty("size").GetInt32();
                noteInfo.MD5 = item.Value.GetProperty("md5").GetString();
                notes.Add(item.Name, noteInfo);
            }
            return notes;
        }

        private MultipartFormDataContent build_note_book_sync(string path, string name, string content)
        {
            var formdata = new MultipartFormDataContent();
            var time = DateTime.Now.ToString();
            var md5 = this.buildToken(path, name, time);
            formdata.Add(new StringContent(name), "name");
            formdata.Add(new StringContent(path), "path");
            formdata.Add(new StringContent(time), "time");
            formdata.Add(new StringContent(md5), "token");
            formdata.Add(new StringContent(content), "content");
            return formdata;
        }
        /// <summary>
        /// 保存笔记本
        /// </summary>
        /// <param name="noteBook"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNoteBookAsync(NoteBook noteBook)
        {
            var b64content = Convert.ToBase64String(noteBook.GetRawContent());
            var content = this.build_note_book_sync(noteBook.sync_uuid, noteBook.BookName, b64content);
            var response = await this.client.PostAsync(NOTE_BOOK_SAVE, content);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                return false;
            }
            return true;
        }

        private MultipartFormDataContent build_query_node_content(string path, string book_guid, string node_guid)
        {
            var formdata = new MultipartFormDataContent();
            var time = DateTime.Now.ToString();
            var md5 = this.buildToken(path, book_guid, node_guid, time);
            formdata.Add(new StringContent(path), "path");
            formdata.Add(new StringContent(book_guid), "guid");
            formdata.Add(new StringContent(node_guid), "nid");
            formdata.Add(new StringContent(time), "time");
            formdata.Add(new StringContent(md5), "token");
            return formdata;

        }
        /// <summary>
        /// 获取节点的内容
        /// </summary>
        /// <param name="book"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task<string> GetBookNodeContentAsync(NoteBook book, string key)
        {
            var content = this.build_query_node_content(book.sync_uuid, book.BookUID, key);
            var response = await this.client.PostAsync(NOTE_PAGE, content);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                return null;
            }
            var data = jsonDoc.RootElement.GetProperty("data").GetString();
            return UTF8Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }
        private MultipartFormDataContent build_send_node_content(string path, string book_guid, string node_guid, string content)
        {
            var formdata = new MultipartFormDataContent();
            var time = DateTime.Now.ToString();
            var md5 = this.buildToken(path, book_guid, node_guid, time);
            formdata.Add(new StringContent(path), "path");
            formdata.Add(new StringContent(book_guid), "guid");
            formdata.Add(new StringContent(node_guid), "nid");
            formdata.Add(new StringContent(time), "time");
            formdata.Add(new StringContent(md5), "token");
            formdata.Add(new StringContent(content), "content");

            return formdata;
        }
        /// <summary>
        /// 更新服务器节点的内容
        /// </summary>
        /// <param name="book"></param>
        /// <param name="key"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private async Task<bool> UpdateNoteBookNoteAsync(NoteBook book, string key, string filename)
        {
            string b64Content = Convert.ToBase64String(File.ReadAllBytes(filename));
            var content = this.build_send_node_content(book.sync_uuid, book.BookUID, key, b64Content);
            var response = await this.client.PostAsync(NOTE_PAGE_SAVE, content);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// 删除服务器的节点内容
        /// </summary>
        /// <param name="book"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task<bool> DeleteNoteBookNoteAsync(NoteBook book, string key)
        {
            var content = this.build_query_node_content(book.sync_uuid, book.BookUID, key);
            var response = await this.client.PostAsync(NOTE_PAGE_DEL, content);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(jsonString);
            int status = jsonDoc.RootElement.GetProperty("code").GetInt32();
            if (status != 0)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> CheckAndDownloadNoteNodes(NoteBook book, Dictionary<string, NoteNodeInfo> notes)
        {
            string note_node_root = book.GetNodesRoot();
            // 如果目录不存在，说明是全新的
            if (Directory.Exists(note_node_root))
            {
                foreach (var filename in Directory.EnumerateFiles(note_node_root, "*" + Const.NOTE_BOOK_NODE_EXT))
                {
                    string name = Path.GetFileNameWithoutExtension(filename);
                    if (!notes.TryGetValue(name, out NoteNodeInfo note_info)) // 本地文件不在服务器上面 - 说明需要删除
                    {
                        File.Delete(filename);
                        continue;
                    }

                }
            }else
            {
                Directory.CreateDirectory(note_node_root);  // 创建目录
            }
            // 下载服务器上不一致的
            foreach (var item in notes)
            {
                string filename = Path.Combine(note_node_root, item.Key + Const.NOTE_BOOK_NODE_EXT);
                var fileInfo = new FileInfo(filename);
                if (fileInfo.Exists)  // 文件存在，才需要对比
                {
                    if (fileInfo.Length == item.Value.Length)  // 文件长度一致，就需要检查md5
                    {
                        var local_md5 = Utils.GetFileMd5(filename);
                        if (local_md5.Equals(item.Value.MD5))   // 说明文件内容没变，不处理
                        {
                            continue;
                        }
                    }
                }
                var content = await GetBookNodeContentAsync(book, item.Key);
                if (content == null)
                {
                    return false;
                }
                NoteBookNode.WriteToFile(book, filename, content);
            }
            return true;
        }
        private void UpdateNoteBookNoteNodes(NoteBook notebook, NoteBookNode parent, List<NoteBookNode> bookNotes)
        {
            foreach (var node in bookNotes)
            {
                var save_node = new NoteBookNode(node);
                save_node.Parent = parent;
                if (parent == null)
                {
                    notebook.BookNotes.Add(save_node);
                }
                else
                {
                    parent.childrenList.Add(save_node);
                }
                // 如果还有子节点
                if (node.childrenList.Count > 0)
                {
                    UpdateNoteBookNoteNodes(notebook, save_node, node.childrenList);
                }
            }
        }

        private async Task<bool> CheckAndUploadNoteNodes(NoteBook book, Dictionary<string, NoteNodeInfo> notes)
        {
            string note_node_root = book.GetNodesRoot();
            foreach (var filename in Directory.EnumerateFiles(note_node_root, "*" + Const.NOTE_BOOK_NODE_EXT))
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                if (!notes.TryGetValue(name, out NoteNodeInfo note_info)) // 本地文件不在服务器上面 - 说明需要上传
                {
                    var result = await UpdateNoteBookNoteAsync(book, name, filename);
                    if(!result)
                    {
                        return false;   // 上传失败
                    }
                    continue;
                }
            }
            foreach (var item in notes)
            {
                string filename = Path.Combine(note_node_root, item.Key + Const.NOTE_BOOK_NODE_EXT);
                var fileInfo = new FileInfo(filename);
                if (!fileInfo.Exists)  // 文件本地没有，需要删除服务器的
                {
                    if(!await DeleteNoteBookNoteAsync(book, item.Key))
                    {
                        return false;   // 删除失败
                    }
                    continue ;
                }
                if (fileInfo.Length == item.Value.Length)  // 文件长度一致，就需要检查md5
                {
                    var local_md5 = Utils.GetFileMd5(filename);
                    if (local_md5.Equals(item.Value.MD5))   // 说明文件内容没变，不处理
                    {
                        continue;  // 服务器和本地的一致
                    }
                }
                var result = await UpdateNoteBookNoteAsync(book, item.Key, filename);
                if (!result)
                {
                    return false;   // 上传失败
                }
            }
            return true;
        }
    }

}
