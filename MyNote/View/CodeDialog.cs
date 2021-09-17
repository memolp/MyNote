/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/9/17
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// Description of CodeDialog.
	/// </summary>
	public partial class CodeDialog : Form
	{
		public CodeDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private string raw_code_lang;
		private string raw_code_data;
		void OnCreateCodeEvent(object sender, EventArgs e)
		{
			raw_code_lang = mLangCBox.Text;
			if(raw_code_lang.Length <= 0)
			{
				MessageBox.Show("请选中高亮语法语言","提示", MessageBoxButtons.OK);
				return;
			}
			string content = mCodeData.Text;
			if(content.Length > 0)
			{
				raw_code_data = content;
				this.DialogResult = DialogResult.OK;
			}else
			{
				this.DialogResult = DialogResult.Cancel;
			}
			this.Close();
		}
		
		public string GetCodeContent()
		{
			return raw_code_data;
		}
		
		public string GetCodeLang()
		{
			return raw_code_lang;
		}
	}
}
