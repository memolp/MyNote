/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Description of NoteTreeView.
	/// </summary>
	public partial class NoteTreeView : UserControl
	{
		/// <summary>
		/// 节点选中的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="node"></param>
		public delegate void TreeNodeSelectedHandler(object sender, object node);
		/// <summary>
		/// 当前打开的笔记本
		/// </summary>
		NoteBook mCurrentBook = null;
		/// <summary>
		/// 记录当前的笔记本列表
		/// </summary>
		Dictionary<string,TreeView> mTabNoteData = new Dictionary<string, TreeView>();
		/// <summary>
		/// 为了快速进行查询，额外存储一个表
		/// </summary>
		Dictionary<string,NoteBookNode> mNoteNodes = new Dictionary<string, NoteBookNode>();
		/// <summary>
		/// 当前的TreeView对象
		/// </summary>
		TreeView mNoteTreeView = null;
		/// <summary>
		/// 节点选中的事件
		/// </summary>
		public TreeNodeSelectedHandler onNodeSelected;
		/// <summary>
		/// 构造 树形控件-带有工具栏
		/// </summary>
		public NoteTreeView()
		{
			InitializeComponent();
		}
		
		public void AddNoteBook(NoteBook book, string selectedUId)
		{
			if(mCurrentBook != null) 
			{
				MessageBox.Show("试用版本只支持打开一个笔记本", "提示");
				return;
			}
			// 已经存在
			if(mTabNoteData.ContainsKey(book.BookUID))
			{
				return;
			}
			// 创建TreeView并绑定数据
			TreeView treeView = new TreeView();
			treeView.LabelEdit = true;
			treeView.FullRowSelect = true;
			treeView.Indent = 20;
			treeView.Scrollable = true;
			treeView.ShowLines = true;
			treeView.ShowPlusMinus = true;
			treeView.ShowRootLines = true;
			treeView.ContextMenuStrip = mPopMenuBar;
			// 添加事件
			treeView.AfterSelect += this.OnAfterNodeSelect;
			treeView.AfterLabelEdit += this.OnAfterLabelEdit;
			
			mCurrentBook = book;		// 当前的book
			mNoteTreeView = treeView; //当前的TreeView
			// 添加全部数据
			foreach (var element in book.BookNotes) 
			{
				CreateTreeNodeWithNoteBookNode(element, treeView.Nodes, selectedUId);
			}
			// 添加Tab页
			TabPage page = new TabPage(book.BookName);
			page.Controls.Add(treeView);
			treeView.Dock = DockStyle.Fill;	//填充整个区域
			mTreeTabCtrl.TabPages.Add(page);
			// 记录到列表中
			mTabNoteData.Add(book.BookUID, treeView);
		}
		/// <summary>
		/// 设置笔记本
		/// </summary>
		/// <param name="book"></param>
		public void AddNoteBook(NoteBook book)
		{
			this.AddNoteBook(book, string.Empty);
		}
		/// <summary>
		/// 保存全部的笔记本
		/// </summary>
		public void SaveAllNoteBook()
		{
			if(mCurrentBook != null)
				mCurrentBook.Save();
		}
		/// <summary>
		/// 通过节点的UID选中Node
		/// </summary>
		/// <param name="uid"></param>
		public void SelectNodeWithUid(string uid)
		{
			TreeNode node = null;
			if(FindNodeWithUid(uid, mNoteTreeView.Nodes, out node))
			{
				SelectedAndCheckNode(node);
			}
		}
		/// <summary>
		/// 查找所有节点，包含指定内容
		/// </summary>
		/// <param name="text"></param>
		/// <param name="result"></param>
		public void FindNodesWithKeyword(string text, ref List<NoteBookNode> result)
		{
			foreach (var element in mNoteNodes.Values) 
			{	
				if(element.NodeName.IndexOf(text) >= 0)
				{
					result.Add(element);
				}
			}
		}
		/// <summary>
		/// 获取全部包含文本的节点或者内容的节点
		/// </summary>
		/// <param name="text"></param>
		/// <param name="result"></param>
		public void FindNodesWithContent(string text, ref List<NoteBookNode> result)
		{
			// 拿到节点的根路径，方便删除全部的节点文件
			string root_path;
			string book_name;
			if(!GetCurrentNoteBookPath(out root_path, out book_name))
			{
				return;
			}
			string fileRootpath = Path.Combine(root_path, book_name);
			string filename;
			string content;
			// 通过这个控件获取文本
			RichTextBox box = new RichTextBox();
			foreach (var element in mNoteNodes.Values) 
			{	
				//如果节点里面已经有了，就不打开文件了
				if(element.NodeName.IndexOf(text) >= 0) 
				{
					result.Add(element);
				}else
				{
					filename = Path.Combine(fileRootpath, element.FileName);
					if(!File.Exists(filename))
					{
						continue;
					}
					box.Rtf = File.ReadAllText(filename);
					content = box.Text;
					if(content.Contains(text))
					{
						result.Add(element);
					}
				}
			}
		}
		/// <summary>
		/// 目前不知性能如何
		/// https://stackoverflow.com/questions/286813/how-do-you-convert-html-to-plain-text
		/// </summary>
		/// <param name="html"></param>
		/// <returns></returns>
		private static string HtmlToPlainText(string html)
		{
		    const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
		    const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
		    const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
		    var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
		    var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
		    var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);
		
		    var text = html;
		    //Decode html specific characters
		    text = System.Net.WebUtility.HtmlDecode(text); 
		    //Remove tag whitespace/line breaks
		    text = tagWhiteSpaceRegex.Replace(text, "><");
		    //Replace <br /> with line breaks
		    text = lineBreakRegex.Replace(text, Environment.NewLine);
		    //Strip formatting
		    text = stripFormattingRegex.Replace(text, string.Empty);
		
		    return text;
		}
		/// <summary>
		/// 选中并选中
		/// </summary>
		/// <param name="node"></param>
		void SelectedAndCheckNode(TreeNode node)
		{
			mNoteTreeView.SelectedNode = node;
			node.Checked = true;
		}
		/// <summary>
		/// 内部查找
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="nodes"></param>
		/// <param name="result"></param>
		bool FindNodeWithUid(string uid, TreeNodeCollection nodes, out TreeNode result)
		{
			result = null;
			foreach (TreeNode element in nodes) 
			{
				if(element.Name.Equals(uid))
				{
					result = element;
					return true;
				}
				if(FindNodeWithUid(uid, element.Nodes, out result))
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 获取当前笔记本的根路径和名称
		/// </summary>
		/// <returns></returns>
		public bool GetCurrentNoteBookPath(out string root_path, out string name)
		{
			root_path = string.Empty;
			name = string.Empty;
			if(mCurrentBook == null) return false;
			string filename = Path.GetFileName(mCurrentBook.BookPath);
			root_path = mCurrentBook.BookPath.Replace(filename,"");
			name = mCurrentBook.BookUID;
			return true;
		}
		/// <summary>
		/// 创建全部的节点数据
		/// </summary>
		/// <param name="bkNode"></param>
		/// <param name="parent"></param>
		/// <param name="selectedUID"></param>
		TreeNode CreateTreeNodeWithNoteBookNode(NoteBookNode bkNode, TreeNodeCollection parent, string selectedUID)
		{
			// 添加到数据记录
			mNoteNodes.Add(bkNode.NodeDocumentUID, bkNode);
			
			TreeNode node = new TreeNode();
			node.Name = bkNode.NodeDocumentUID;
			node.Text = bkNode.NodeName;
			parent.Add(node);
			// 将子列表也添加进去
			if(bkNode.childrenList.Count > 0)
			{
				for(int i=0; i< bkNode.childrenList.Count; i++)
				{
					CreateTreeNodeWithNoteBookNode(bkNode.childrenList[i], node.Nodes, selectedUID);
				}
			}
			if(node.Name.Equals(selectedUID))
			{
				SelectedAndCheckNode(node);
			}
			return node;
		}
		/// <summary>
		/// 创建全部的节点数据
		/// </summary>
		/// <param name="bkNode"></param>
		/// <param name="parent"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		TreeNode CreateTreeNodeWithNoteBookNode(NoteBookNode bkNode, TreeNodeCollection parent, int index)
		{
			// 添加到数据记录
			mNoteNodes.Add(bkNode.NodeDocumentUID, bkNode);
			TreeNode node = new TreeNode();
			node.Name = bkNode.NodeDocumentUID;
			node.Text = bkNode.NodeName;
			// 带有编号时，需要选择是插入还是追加
			if(parent.Count <= index)
			{
				parent.Add(node);
			}else
			{
				parent.Insert(index, node);
			}
			// 如果有子列表 将子列表也添加进去
			if(bkNode.childrenList.Count > 1)
			{
				for(int i=0; i< bkNode.childrenList.Count; i++)
				{
					CreateTreeNodeWithNoteBookNode(bkNode.childrenList[i], node.Nodes, string.Empty);
				}
			}
			return node;
		}
		/// <summary>
		/// 节点选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAfterNodeSelect(object sender, TreeViewEventArgs e)
		{
			NoteBookNode bkNode;
			// 获取对应的BookNode
			if(mNoteNodes.TryGetValue(e.Node.Name, out bkNode))
			{
				if(this.onNodeSelected != null)
				{
					this.onNodeSelected(this, bkNode);
				}
			}
		}
		/// <summary>
		/// 节点名称修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if(e.Label == null) return;
			
			NoteBookNode bkNode;
			// 获取对应的BookNode
			if(mNoteNodes.TryGetValue(e.Node.Name, out bkNode))
			{
				if(e.Label.Length > 1 && !e.Label.Equals(bkNode.NodeName))
				{
					bkNode.NodeName = e.Label; //更新bk的命名
					mCurrentBook.Save();
				}else
				{
					e.CancelEdit = true;
				}
			}
		}
		/// <summary>
		/// 添加子节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAddChildNodeEvent(object sender, EventArgs e)
		{
			if(mNoteTreeView == null || mCurrentBook == null) return;
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			
			NoteBookNode parent = null;
			if(mNoteNodes.TryGetValue(node.Name, out parent))
			{
				NoteBookNode bkNode = new NoteBookNode("未命名标题");
				TreeNode new_node = CreateTreeNodeWithNoteBookNode(bkNode, node.Nodes, bkNode.NodeDocumentUID);
				parent.childrenList.Add(bkNode);
				mCurrentBook.Save();
			}else
			{
				MessageBox.Show(string.Format("{0} 不存在,无法添加子节点", node.Text), "错误");
			}
		}
		/// <summary>
		/// 前面添加节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAddPrevNodeEvent(object sender, EventArgs e)
		{
			if(mNoteTreeView == null || mCurrentBook == null) return;
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			
			NoteBookNode current = null;
			if(mNoteNodes.TryGetValue(node.Name, out current))
			{
				NoteBookNode bkNode = new NoteBookNode("未命名标题");
				//TODO 如何插入当前节点的前面
				if(!mCurrentBook.FindNodeAndAdd(current, bkNode, false))
				{
					MessageBox.Show("添加节点失败", "错误");
					return;
				}
				TreeNode new_node = CreateTreeNodeWithNoteBookNode(bkNode, node.Parent.Nodes, node.Index);
				SelectedAndCheckNode(new_node);
				mCurrentBook.Save();
			}else
			{
				MessageBox.Show(string.Format("{0} 不存在,无法执行操作", node.Text), "错误");
			}
		}
		/// <summary>
		/// 后面添加节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAddNextNodeEvent(object sender, EventArgs e)
		{
			if(mNoteTreeView == null || mCurrentBook == null) return;
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			
			NoteBookNode current = null;
			if(mNoteNodes.TryGetValue(node.Name, out current))
			{
				NoteBookNode bkNode = new NoteBookNode("未命名标题");
				//TODO 如何插入当前节点的后面
				if(!mCurrentBook.FindNodeAndAdd(current, bkNode, true))
				{
					MessageBox.Show("添加节点失败", "错误");
					return;
				}
				TreeNode new_node = CreateTreeNodeWithNoteBookNode(bkNode, node.Parent.Nodes, node.Index+1);
				SelectedAndCheckNode(new_node);
				mCurrentBook.Save();
			}else
			{
				MessageBox.Show(string.Format("{0} 不存在,无法执行操作", node.Text), "错误");
			}
		}
		/// <summary>
		/// 删除当前节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDeleteCurNode(object sender, EventArgs e)
		{
			if(mNoteTreeView == null || mCurrentBook == null) return;
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			// 删除节点- 需要同步删除数据
			NoteBookNode current = null;
			if(mNoteNodes.TryGetValue(node.Name, out current))
			{
				if(current.childrenList.Count > 0)
				{
					// 操作确认
					var res = MessageBox.Show("删除当前节点也会同时删除其子节点，确认删除?", "提示", MessageBoxButtons.YesNo);
					if(DialogResult.Yes != res)
						return;
				}
				// 拿到节点的根路径，方便删除全部的节点文件
				string root_path;
				string book_name;
				if(!GetCurrentNoteBookPath(out root_path, out book_name))
				{
					return;
				}
				string fileRootpath = Path.Combine(root_path, book_name);
				// 删除全部
				mCurrentBook.FindNodeAndRemove(current);
				current.RemoveAllChildren(fileRootpath);
				current.Remove(fileRootpath);
				//简单移除自身
				node.Remove();
				mCurrentBook.Save();
			}
		}
		void OnNodeExpand(object sender, EventArgs e)
		{
			if(mNoteTreeView == null || mCurrentBook == null) return;
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			if(!node.IsExpanded)
			{
				node.ExpandAll();
			}else
			{
				node.Collapse();
			}
		}
		/// <summary>
		/// 按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnKeyDownEvent(object sender, KeyEventArgs e)
		{
			if(mNoteTreeView == null) return;
			
			if(e.KeyCode != Keys.F2)  // 重命名快捷键
			{
				return;
			}
			if(e.Alt || e.Control || e.Shift) return;  //按了组合件就跳过
			
			TreeNode node = mNoteTreeView.SelectedNode;
			if(node == null) return;
			node.BeginEdit();  //开启编辑
		}
		/// <summary>
		/// Tab控件笔记本更换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnNoteBookChange(object sender, EventArgs e)
		{
			
		}
		
	}
}
