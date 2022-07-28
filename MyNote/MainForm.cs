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
			mLockPanel.BringToFront();
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
			// 注册全局快捷键
			this.OnRegisterHotKey();
			// 解锁界面
			if(mRuntimeData.auto_lock_window)
			{
				mLockPanel.Visible = true;
			}
			mCheckTimer.Start();
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
			mNoteTree.SaveAllNoteBook();
		}
		/// <summary>
		/// 加载文档内容数据
		/// </summary>
		/// <param name="bkNode"></param>
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
			string filepath = Path.Combine(root_path, book_name, filename);
			int content_size = 0;
			// 文件不存在说明还没创建保存，需要等Save
			if(File.Exists(filepath))
			{
				// 读取文件内容
				using (FileStream fs = new FileStream(filepath, FileMode.Open))
				{
					int size = (int)fs.Length;
					byte[] data = new byte[size];
					fs.Read(data, 0, size);
					// 这里不管有没有设置加密都这样走，就可以防止异常
					if(size > Const.CRYPT_HEAD.Length)
					{
						if(Utils.StartsWith(data, Const.CRYPT_HEAD))
						{
							data = Utils.Decode(data, Const.CRYPT_HEAD.Length, 
							                    data.Length-Const.CRYPT_HEAD.Length, 
							                    mNoteTree.CurrentBook.CryptKey);
						}
					}
					// TODO 这里后续要加解密步骤
					UTF8Encoding con = new UTF8Encoding();
	     			mNodeEditor.SetContent(con.GetString(data));
	     			content_size = data.Length;
				}
			}else
			{
				mNodeEditor.SetContent(""); //必须清理，否则会导致存储问题
			}
			string label = string.Format("大小:{0:0.00}KB 更新:{1}", content_size/1024.0, bkNode.NodeModifyTime.ToLocalTime());
			mNodeEditor.SetDocumentInfo(bkNode.NodeName, label);
		}
		
		void SaveNoteBookNoteDocument(NoteBookNode bkNode)
		{
			string root_path;
			string book_name;
			if(!mNoteTree.GetCurrentNoteBookPath(out root_path, out book_name))
			{
				return;
			}
			if(!mNodeEditor.IsContentChange())
			{
				return;
			}
			string filename = string.Format("{0}{1}",bkNode.NodeDocumentUID, Const.NOTE_BOOK_NODE_EXT);
			string fileRootpath = Path.Combine(root_path, book_name);
			// 创建笔记本目录
			if(!Directory.Exists(fileRootpath))
			{
				Directory.CreateDirectory(fileRootpath);
			}
			string filepath = Path.Combine(fileRootpath,filename);
			string content = mNodeEditor.GetContent();
			// 读取文件内容
			using (FileStream fs = new FileStream(filepath, FileMode.Create))
			{
				UTF8Encoding con = new UTF8Encoding();
				byte[] data = con.GetBytes(content);
				// 需要加密
				if(mNoteTree.CurrentBook.CryptFlag)
				{
					data = Utils.Encode(data, mNoteTree.CurrentBook.CryptKey);
					fs.Write(Const.CRYPT_HEAD, 0, Const.CRYPT_HEAD.Length);
				}
				fs.Write(data, 0, data.Length);
			}
			// 更新内容保存
			mNodeEditor.SetContentSaved();
			bkNode.NodeModifyTime = DateTime.Now;
			string label = string.Format("更新:{0}", bkNode.NodeModifyTime.ToLocalTime());
			mNodeEditor.SetDocumentInfo(bkNode.NodeName, label);
		}
		
		void OnEditorSaveEvent(object sender, object node)
		{
			if(mCurrentNode == null) return;
			this.SaveNoteBookNoteDocument(mCurrentNode);
		}
		
		void OnQuit(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void OnSizeChanged(object sender, EventArgs e)
		{
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
		/// <summary>
		/// 窗口正触发关闭时回调
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnWindowClosing(object sender, FormClosingEventArgs e)
		{
			// 所有的关闭事件都会来这里，需要判断一下，只有用户行为才托盘，其他情况都需要直接关闭例如关机。
			if(e.CloseReason == CloseReason.UserClosing)
			{
				if(mRuntimeData.close_on_notify_icon)
				{
					this.OnNotifyIconHandler(this, null);
					e.Cancel = true;
				}
			}
		}
		/// <summary>
		/// 窗口已经执行关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnWindowClosed(object sender, FormClosedEventArgs e)
		{
			// 非用户行为关闭程序，则直接关闭程序
			//if(e.CloseReason != CloseReason.UserClosing)
			{
				mCheckTimer.Stop();
				//数据存储
				this.SaveRuntimeData();
				if(mCurrentNode != null)
					this.SaveNoteBookNoteDocument(mCurrentNode);
				mNotifyIcon.Visible = false;
				// 退出前强制保存一下
				mNoteTree.SaveAllNoteBook();
				// 取消快捷键注册
				this.OnUnregisterHotKey();
			}
		}
		
		
		void OnWindowShown(object sender, EventArgs e)
		{
			if(mRuntimeData.opened_book != string.Empty && File.Exists(mRuntimeData.opened_book))
			{
				// 添加全部已打开的笔记本
				NoteBook book = NoteBook.LoadBookFromDisk(mRuntimeData.opened_book);
				mNoteTree.AddNoteBook(book);
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
			MessageBox.Show("暂时不支持，涉及解密文档", "提示");
			return;
			string text = mToolSearchInput.Text;
			if(text.Length < 1)
			{
				return;
			}
			List<NoteBookNode> result = new List<NoteBookNode>();
			mNoteTree.FindNodesWithContent(text, ref result);
			mFindResultDlg.SetResultList(result);
			mFindResultDlg.Show();
			mFindResultDlg.Focus();
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
		/// <summary>
		/// 系统托盘
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnNotifyIconHandler(object sender, EventArgs e)
		{
			this.Visible = !this.Visible;
			if(this.Visible && this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
			if(this.Visible)
			{
				mToolShowWindow.Text = "系统托盘";
			}else
			{
				mToolShowWindow.Text = "显示窗体";
			}
		}
		#region 截屏相关
		// 截图快捷键ID
		private const int HotCaptureKeyID = 1000;
		// 退出截图ID
		private const int HotExitCaptureID = 1001;
		/// <summary>
		/// 注册快捷键
		/// </summary>
		void OnRegisterHotKey()
		{
			// 如果不需要截屏，就不要注册
			if(!mRuntimeData.screen_capture) return;
			
			if(!Win32Api.RegisterHotKey(this.Handle, HotCaptureKeyID, KeyModifiers.Ctrl|KeyModifiers.Alt, Keys.A))
			{
				MessageBox.Show("注册截图热键失败", "提示");
			}
		}
		/// <summary>
		/// 取消注册
		/// </summary>
		void OnUnregisterHotKey()
		{
			Win32Api.UnregisterHotKey(this.Handle, HotCaptureKeyID);
		}
		
		private const int WM_HOTKEY = 0x0312;
		private DateTime _lastMsgDate = DateTime.Now;
		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				case WM_HOTKEY:
					// 按下截图键
					if(m.WParam.ToInt32()  == HotCaptureKeyID)
					{
						ScreenCapture.FormCapture capture = new ScreenCapture.FormCapture();
						capture.Show();
						//MessageBox.Show("截图键","d");
					}
					break;
			}
			_lastMsgDate = DateTime.Now;
			base.WndProc(ref m);
		}
		#endregion
		/// <summary>
		/// 打开设置界面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnPreferencesShowEvt(object sender, EventArgs e)
		{
			PreferenceDialog dialog = new PreferenceDialog();
			dialog.InitDialogData(mRuntimeData);
			if(dialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			mRuntimeData.close_on_notify_icon = dialog.NotifyIcon;
			// 截屏设置后需要对快捷键进行处理
			if(mRuntimeData.screen_capture != dialog.ScreenCapture)
			{
				mRuntimeData.screen_capture = dialog.ScreenCapture;
				if(mRuntimeData.screen_capture)
				{
					this.OnRegisterHotKey();
				}else
				{
					this.OnUnregisterHotKey();
				}
			}
			mRuntimeData.auto_lock_time = dialog.AutoLockTime;
			mRuntimeData.auto_lock_window = dialog.AutoLockWindow;
			mRuntimeData.unlock_password = dialog.UnlockPassword;
		}
		
		void OnUnlockEvt(object sender, EventArgs e)
		{
			if(mUnlockPassword.Text != mRuntimeData.unlock_password)
			{
				MessageBox.Show("解锁密码验证失败");
				return;
			}
			mUnlockPassword.Text = "";
			mLockPanel.Visible = false;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCheckLockTimer(object sender, EventArgs e)
		{
			if(!mRuntimeData.auto_lock_window) return;
            if(mLockPanel.Visible) return;
            if((DateTime.Now - _lastMsgDate).Minutes >= mRuntimeData.auto_lock_time)
            {
            	mLockPanel.Visible = true;
            }
		}
		/// <summary>
		/// 锁定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnLockWindowEvt(object sender, EventArgs e)
		{
			mLockPanel.Visible = true;
		}
		
		void OnUnLockKeyDownEvt(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.OnUnlockEvt(sender, e);
			}
		}
	}
}
