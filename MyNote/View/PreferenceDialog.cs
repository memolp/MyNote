/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 10:16
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Description of PreferenceDialog.
	/// </summary>
	public partial class PreferenceDialog : Form
	{
		/// <summary>
		/// 截屏
		/// </summary>
		public bool ScreenCapture {set; get;}
		/// <summary>
		/// 系统托盘
		/// </summary>
		public bool NotifyIcon {set; get;}
		/// <summary>
		/// 是否自动锁定窗口
		/// </summary>
		public bool AutoLockWindow {set; get;}
		/// <summary>
		/// 检查自动锁定的时间
		/// </summary>
		public int AutoLockTime {set; get;}
		/// <summary>
		/// 解锁密码
		/// </summary>
		public string UnlockPassword{set;get;}
		/// <summary>
		/// 是否开启服务器同步
		/// </summary>
		public bool SyncServer {set; get;}
		/// <summary>
		/// 服务器同步的URL地址
		/// </summary>
		public string SyncServerUrl {set; get;}
		/// <summary>
		/// 服务器同步的Token
		/// </summary>
		public string SyncServerToken { set; get;}
		
		public PreferenceDialog()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// 设置默认的勾选数据
		/// </summary>
		/// <param name="data"></param>
		public void InitDialogData(MyNoteData data)
		{
			mCaptureFlag.Checked = data.screen_capture;
			mOnSystemIcon.Checked = data.close_on_notify_icon;
			mAutoLockCheck.Checked = data.auto_lock_window;
			mLockTime.Value = data.auto_lock_time > 1? data.auto_lock_time : 1;
			CheckServerSync.Checked = data.sync_server;
			InputNetSeverUrl.Text = data.sync_url;
			InputNetToken.Text = data.sync_token;
			this.UnlockPassword = data.unlock_password;
		}
		
		/// <summary>
		/// 应用配置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnApplyEvt(object sender, EventArgs e)
		{
			this.ScreenCapture = mCaptureFlag.Checked;
			this.NotifyIcon = mOnSystemIcon.Checked;
			this.AutoLockWindow = mAutoLockCheck.Checked;
			this.AutoLockTime = mLockTime.Value;
			this.SyncServer = CheckServerSync.Checked;
			this.SyncServerUrl = InputNetSeverUrl.Text;
			this.SyncServerToken = InputNetToken.Text;
			this.DialogResult = DialogResult.OK;
		}
		/// <summary>
		/// 取消
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCancelEvt(object sender, EventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// 设置密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnSetUnLockPasswdEvt(object sender, EventArgs e)
		{
			InputPasswordDialog dlg = new InputPasswordDialog(this.UnlockPassword);
			dlg.Owner = this;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				this.UnlockPassword = dlg.NewPassword;
			}
		}
    }
}
