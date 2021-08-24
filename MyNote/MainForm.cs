/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using MyNote.Data;
using MyNote.View;

namespace MyNote
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		MyNoteData mRuntimeData = null;
		NoteBookNode mCurrentNode = null;

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			// 默认先隐藏，只有选中了节点才显示
			mNodeEditor.Visible = false;
			mNoteTree.onNodeSelected = this.OnTreeViewNodeSelected;
			mNodeEditor.onEditorSave = this.OnEditorSaveEvent;
			mFindResultDlg.onResultItemClick = this.OnSelectTreeViewNode;
		}
		/// <summary>
		/// 窗体加载的时候调用
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void WindowLoaded(object sender, EventArgs e)
		{
			this.LoadRuntimeData();
			if(mRuntimeData.last_frame_width > 100 && mRuntimeData.last_frame_height > 100)
			this.SetBounds(this.Left, this.Top, mRuntimeData.last_frame_width, mRuntimeData.last_frame_height);
			
		}
		void LoadRuntimeData()
		{
			if(File.Exists(Const.NOTE_RUNTIME_DATA))
			{
				IFormatter formatter = new BinaryFormatter();
				using(FileStream fs = new FileStream(Const.NOTE_RUNTIME_DATA, FileMode.Open))
				{
					mRuntimeData = (MyNoteData)formatter.Deserialize(fs);
				}
			}else
			{
				mRuntimeData = new MyNoteData();
			}
		}
		/// <summary>
		/// 保存运行时数据
		/// </summary>
		void SaveRuntimeData()
		{
			IFormatter formatter = new BinaryFormatter();
			using(FileStream fs = new FileStream(Const.NOTE_RUNTIME_DATA, FileMode.Create))
			{
				formatter.Serialize(fs, mRuntimeData);
			}
		}
		/// <summary>
		/// 某个节点选中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="node"></param>
		void OnTreeViewNodeSelected(object sender, object node)
		{
			// 如果之前有选中某一个节点，则先保存
			if(mCurrentNode != null) 
			{
				this.SaveNoteBookNoteDocument(mCurrentNode);
			}
			NoteBookNode bkNode = node as NoteBookNode;
			mCurrentNode = bkNode;
			mRuntimeData.current_selected_node_uid = bkNode.NodeDocumentUID;
			this.LoadNoteBookNoteDocument(bkNode);
		}

		/// <summary>
		/// 创建笔记本
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCreateNoteBook(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter =  string.Format("笔记本（*{0}）|*{0}", Const.NOTE_BOOK_EXT);
			dlg.Title = "选择笔记本存储路径";
			dlg.RestoreDirectory = true;
			dlg.InitialDirectory = Application.StartupPath;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				string filepath = dlg.FileName;
				NoteBook book = NoteBook.CreateBookWithPath(filepath);
				if(book != null)
				{
					mNoteTree.AddNoteBook(book);
					mRuntimeData.opened_book = book.BookPath;
				}
			}
		}
		/// <summary>
		/// 打开笔记本
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnOpenNoteBook(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter =  string.Format("笔记本（*{0}）|*{0}", Const.NOTE_BOOK_EXT);
			dlg.Title = "选择笔记本存储路径";
			dlg.RestoreDirectory = true;
			dlg.InitialDirectory = Application.StartupPath;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				string filepath = dlg.FileName;
				if(!File.Exists(filepath)) return;
				NoteBook book = NoteBook.LoadBookFromDisk(filepath);
				if(book != null)
				{
					mNoteTree.AddNoteBook(book);
					mRuntimeData.opened_book = book.BookPath;
				}else
				{
					MessageBox.Show("打开笔记本失败", "提示", MessageBoxButtons.OK);
				}
			}
		}
		/// <summary>
		/// 保存文档数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnSaveNoteBookDocument(object sender, EventArgs e)
		{
			if(mCurrentNode == null) return;
			this.SaveNoteBookNoteDocument(mCurrentNode);
		}
		
		void LoadNoteBookNoteDocument(NoteBookNode bkNode)
		{
			string root_path;
			string book_name;
			if(!mNoteTree.GetCurrentNoteBookPath(out root_path, out book_name))
			{
				return;
			}
			mNodeEditor.Visible = true;
			string filename = string.Format("{0}{1}",bkNode.NodeDocumentUID, Const.NOTE_BOOK_NODE_EXT);
			string filepath = Path.Combine(root_path, book_name);
			if(!Directory.Exists(filepath))
			{
				Directory.CreateDirectory(filepath);
			}
			mNodeEditor.LoadNoteBookNode(mCurrentNode, Path.Combine(filepath,filename));
		}
		
		void SaveNoteBookNoteDocument(NoteBookNode bkNode)
		{
			mNodeEditor.SaveNoteBookNode(mCurrentNode);
		}
		
		void OnEditorSaveEvent(object sender, object node)
		{
			if(mCurrentNode == null) return;
			this.SaveNoteBookNoteDocument(mCurrentNode);
		}
		
		void OnQuit(object sender, EventArgs e)
		{
			if(mCurrentNode != null)
				this.SaveNoteBookNoteDocument(mCurrentNode);
			mNotifyIcon.Visible = false;
			// 退出前强制保存一下
			mNoteTree.SaveAllNoteBook();
			Application.Exit();
		}
		
		void OnSizeChanged(object sender, EventArgs e)
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
				return;
			}
			if(mRuntimeData != null && this.Width > 100 && this.Height > 100)
			{
				mRuntimeData.last_frame_width = this.Width;
				mRuntimeData.last_frame_height = this.Height;
			}
			if(mFindResultDlg.Visible)
			{
				mNodeEditor.Height = mSplitCtrl.Panel2.Height - mFindResultDlg.Height;
			}else
			{
				mNodeEditor.Height = mSplitCtrl.Panel2.Height;
			}
		}
		void OnWindowClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveRuntimeData();
		}
		
		void OnWindowShown(object sender, EventArgs e)
		{
			if(mRuntimeData.opened_book != string.Empty && File.Exists(mRuntimeData.opened_book))
			{
				// 添加全部已打开的笔记本
				NoteBook book = NoteBook.LoadBookFromDisk(mRuntimeData.opened_book);
				mNoteTree.AddNoteBook(book, mRuntimeData.current_selected_node_uid);
			}
		}

		void OnShowWindow(object sender, EventArgs e)
		{
			if(!this.Visible)
			{
				this.Visible = true;
				this.WindowState = FormWindowState.Normal;
			}
		}
		
		void OnFindInTree(object sender, EventArgs e)
		{
			string text = mToolSearchInput.Text;
			if(text.Length < 1)
			{
				return;
			}
			List<NoteBookNode> result = new List<NoteBookNode>();
			mNoteTree.FindNodesWithKeyword(text, ref result);
			mFindResultDlg.SetResultList(result);
			mFindResultDlg.Show();
		}
		
		void OnFindInAll(object sender, EventArgs e)
		{
			string text = mToolSearchInput.Text;
			if(text.Length < 1)
			{
				return;
			}
			List<NoteBookNode> result = new List<NoteBookNode>();
			mNoteTree.FindNodesWithContent(text, ref result);
			mFindResultDlg.SetResultList(result);
			mFindResultDlg.Show();
		}

		void OnSelectTreeViewNode(string nodeName, string uid)
		{
			mNoteTree.SelectNodeWithUid(uid);
			this.Focus();
		}
		/// <summary>
		/// 查找界面的显示消息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFindResultWindow(object sender, EventArgs e)
		{
			if(mFindResultDlg.Visible)
			{
				mNodeEditor.Height = mSplitCtrl.Panel2.Height - mFindResultDlg.Height;
			}else
			{
				mNodeEditor.Height = mSplitCtrl.Panel2.Height;
			}
		}
	}
}
