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
	}
}
