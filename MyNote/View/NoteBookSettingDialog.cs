/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 15:04
 * 
 * 
 */
using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Description of NoteBookCryptDialog.
	/// </summary>
	public partial class NoteBookSettingDialog : Form
	{
		/// <summary>
		/// 是否开启加密
		/// </summary>
		public bool CryptFlag {set; get;}
		/// <summary>
		/// 加密Key
		/// </summary>
		public string CryptKey {set; get;}
		/// <summary>
		/// 网络笔记本位置
		/// </summary>
        public string NoteBookNetUUID { get; set; }

        public NoteBookSettingDialog()
		{
			InitializeComponent();
		}
		
		public void OnInitDialog(NoteBook note)
		{
            this.CryptFlag = note.CryptFlag;
            this.CryptKey = note.CryptKey;
            this.NoteBookNetUUID = note.sync_uuid;

			mCryptFlag.Checked = this.CryptFlag;
			mCryptKey.Text = this.CryptKey;
            InputNetPath.Text = this.NoteBookNetUUID;
        }
		
		void OnNoteBookCryptEvt(object sender, EventArgs e)
		{
			if(mCryptFlag.Checked)
			{
				if(string.IsNullOrWhiteSpace(mCryptKey.Text))
				{
					MessageBox.Show("加密需要输入密码", "提示");
					return;
				}
			}
			this.CryptFlag = mCryptFlag.Checked;
			this.CryptKey = mCryptKey.Text;
            this.NoteBookNetUUID = InputNetPath.Text;
            this.DialogResult = DialogResult.OK;
		}
	}
}
