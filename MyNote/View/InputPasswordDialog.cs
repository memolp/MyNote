/*
 * User: 覃贵锋
 * Date: 2022/5/9
 * Time: 11:38
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// Description of InputPasswordDialog.
	/// </summary>
	public partial class InputPasswordDialog : Form
	{
		private string _oldPassword = null;
		public string NewPassword = "";
		public InputPasswordDialog(string oldpass)
		{
			_oldPassword = oldpass;
			InitializeComponent();
			if(string.IsNullOrEmpty(oldpass))
			{
				mOldPassword.UseSystemPasswordChar = false;
				mOldPassword.Text = "无密码";
				mOldPassword.Enabled = false;
			}
		}
		
		void OnCancleEvt(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		void OnApplyEvt(object sender, EventArgs e)
		{
			string newpass = mNewPassword.Text;
			string repeat = mRepeatPassword.Text;
			if(newpass != repeat)
			{
				MessageBox.Show("两次输入的密码不一致!");
				mNewPassword.BackColor = Color.Red;
				return;
			}
			if(!string.IsNullOrEmpty(_oldPassword) && mOldPassword.Text != _oldPassword)
			{
				MessageBox.Show("旧密码验证失败!");
				mOldPassword.BackColor = Color.Red;
				return;
			}
			NewPassword = newpass;
			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
