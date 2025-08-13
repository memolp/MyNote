using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNote.View
{
    public partial class OpenCloudNoteBookDialog : Form
    {
        public string CloudPath { get; set; }
        public string NoteBookName { get; set; }
        public string LocalPath { get; set; }

        public OpenCloudNoteBookDialog()
        {
            InitializeComponent();
        }

        private void OnSelectLocalPathEvt(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.ShowNewFolderButton = true;
            browserDialog.Description = "请选择笔记本存储的目录";
            if (browserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string path = browserDialog.SelectedPath;
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                MessageBox.Show("选择的目录不存在!");
                return;
            }
            if (Directory.EnumerateFileSystemEntries(path).Count() > 0)
            {
                if (MessageBox.Show("选择的目录不为空，确定要使用改目录吗?", "确认提醒", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            InputLocalPath.Text = path;
        }

        private void OnOpenCloudNetBookEvt(object sender, EventArgs e)
        {
            string cloud_path = InputCloudPath.Text.Trim(); 
            if(string.IsNullOrEmpty(cloud_path))
            {
                MessageBox.Show("未输入云存储路径!");
                return;
            }
            string name = InputNoteBook.Text.Trim();
            if(string.IsNullOrEmpty (name))
            {
                MessageBox.Show("未输入笔记本的名称!");
                return;
            }
            string path = InputLocalPath.Text.Trim();
            if(string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                MessageBox.Show("未输入笔记本的存储路径或路径不存在!");
                return;
            }
            this.CloudPath = cloud_path;
            this.NoteBookName = name;
            this.LocalPath = path;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
