/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// 创建笔记本对话框
	/// </summary>
	public partial class CreateNoteBookDlg : Form
	{
		/// <summary>
		/// 获取用户创建的笔记本名称
		/// </summary>
		public string NoteBookName{set;get;}
		public CreateNoteBookDlg()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 点击创建笔记本
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCreateNoteBook(object sender, EventArgs e)
		{
			string name = mTextNoteBook.Text;
			if(name.Length < 1)
			{
				MessageBox.Show("请输入笔记本名称","提示", MessageBoxButtons.OK);
				return;
			}
			this.NoteBookName = name;
			this.Close();
		}
	}
}
