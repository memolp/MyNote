/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 15:04
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// Description of NoteBookCryptDialog.
	/// </summary>
	public partial class NoteBookCryptDialog : Form
	{
		public bool CryptFlag {set; get;}
		public string CryptKey {set; get;}
		
		public NoteBookCryptDialog()
		{
			InitializeComponent();
		}
		
		public void OnInitDialog(bool crypted, string key)
		{
			mCryptFlag.Checked = crypted;
			mCryptKey.Text = key;
			this.CryptFlag = crypted;
			this.CryptKey = key;
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
			this.DialogResult = DialogResult.OK;
		}
	}
}
