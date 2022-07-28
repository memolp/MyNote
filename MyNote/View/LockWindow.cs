/*
 * User: 覃贵锋
 * Date: 2022/5/9
 * Time: 14:11
 * 
 * 
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Description of LockWindow.
	/// </summary>
	public partial class LockWindow : Form
	{
		MyNoteData mRuntimeData = null;
		MainForm mNoteWindow = null;
		public LockWindow()
		{
			InitializeComponent();
			mNoteWindow = new MainForm();
			//mNoteWindow.OnLockEvent = this.OnLockEvt;
		}
		
		/// <summary>
		/// 在窗体尺寸改变的时候，重写窗体的Resize，绘制圆角窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void OnWindowResize(object sender, EventArgs e) 
        {
           	GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0,0,this.Width,this.Height);
            path = getRoundRectPath(rect,50);
            this.Region = new Region(path);
        }
        /// <summary>
        /// 圆角
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath getRoundRectPath(Rectangle rect, int radius) 
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle arcRect = new Rectangle(rect.Location,new Size(radius,radius));
            //角度规则：右下左上（0，90，180，270）
            //左上角
            path.AddArc(arcRect,180,90);//从180度开始，顺时针,滑过90度
            //右上角
            arcRect.X = rect.Right - radius;
            path.AddArc(arcRect,270,90); //
            //右下角
            arcRect.Y = rect.Bottom - radius;
            path.AddArc(arcRect,0,90);
            //左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect,90,90);
            path.CloseFigure();//闭合曲线
            return path;
        }
        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void OnButtonResizeEvt(object sender, EventArgs e)
		{
			GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0,0,mUnlockButton.Width,mUnlockButton.Height);
            path = getRoundRectPath(rect,50);
            mUnlockButton.Region = new Region(path);
		}
		/// <summary>
		/// 点击解锁按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnUnlockEvt(object sender, EventArgs e)
		{
			if(mUnlockPassword.Text != mRuntimeData.unlock_password)
			{
				MessageBox.Show("解锁密码校验失败!");
				return;
			}
			this.OnNotify();
			mNoteWindow.Show();
		}
		
		void OnLockEvt()
		{
			mNoteWindow.Hide();
			this.OnNotify();
		}
		
		/// <summary>
		/// 加载运行时数据
		/// </summary>
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
		/// 加载程序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnLoadEvt(object sender, EventArgs e)
		{
			this.LoadRuntimeData();
			//mNoteWindow.SetRuntimeData(mRuntimeData);
			if(!mRuntimeData.auto_lock_window)
			{
				mNoteWindow.Show();
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
		/// 关闭程序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnClosedEvt(object sender, FormClosedEventArgs e)
		{
			SaveRuntimeData();
			if(mNoteWindow != null)
			{
				//mNoteWindow.OnSaveData();
				mNoteWindow.Close();
			}
			mNotifyIcon.Visible = false;
		}
		/// <summary>
		/// 关闭程序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCloseEvt(object sender, EventArgs e)
		{
			Application.Exit();
		}
		/// <summary>
		/// 显示界面时如果未开启锁定，直接打开笔记本窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnShowEvt(object sender, EventArgs e)
		{
			if(mNoteWindow != null && mNoteWindow.Visible)
			{
				this.OnNotify();
			}
		}
		/// <summary>
		/// 系统托盘
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnNotifyIconHandler(object sender, EventArgs e)
		{
			this.OnNotify();
		}
		/// <summary>
		/// 界面
		/// </summary>
		void OnNotify()
		{
			this.Visible = !this.Visible;
			if(this.Visible && this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
			}
			if(this.Visible)
			{
				mToolLockWindow.Enabled = false;
			}else
			{
				mToolLockWindow.Enabled = true;
			}
		}
		
		void OnLockWindowEvt(object sender, EventArgs e)
		{
			this.OnLockEvt();
		}
		
		void OnKeyDownEvt(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.OnUnlockEvt(sender, e);
			}
		}
		void OnKeyPressEvt(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == '\n')
			{
				this.OnUnlockEvt(sender, e);
			}
		}
		void OnKeyUpEvt(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.OnUnlockEvt(sender, e);
			}
		}
		
	}
}
