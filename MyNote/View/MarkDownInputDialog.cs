/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/20
 * Time: 10:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// Description of MarkDownInputDialog.
	/// </summary>
	public partial class MarkDownInputDialog : Form
	{
		public MarkDownInputDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		void OnOpenMkdownFile(object sender, EventArgs e)
		{
	
		}
		
		private string mMk2HtmlContent;
		void OnBtnInsertCode(object sender, EventArgs e)
		{
			string content = mMkDownView.Text;
			if(content.Length > 0)
			{
				using (var reader = new StringReader(content))
				{
				    using (var writer = new StringWriter())
				    {
				        CommonMark.CommonMarkConverter.Convert(reader, writer);
				        mMk2HtmlContent = writer.ToString();
				    }
				}
				this.DialogResult = DialogResult.OK;
			}else
			{
				this.DialogResult = DialogResult.Cancel;
			}
			this.Close();
		}
		
		public string GetMk2HtmlContent()
		{
			return mMk2HtmlContent;
		}
	}
}
