/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class CreateNoteBookDlg
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mTextNoteBook;
		private System.Windows.Forms.Button BtnCreate;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.mTextNoteBook = new System.Windows.Forms.TextBox();
			this.BtnCreate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入笔记本名称";
			// 
			// mTextNoteBook
			// 
			this.mTextNoteBook.Location = new System.Drawing.Point(105, 24);
			this.mTextNoteBook.Name = "mTextNoteBook";
			this.mTextNoteBook.Size = new System.Drawing.Size(305, 21);
			this.mTextNoteBook.TabIndex = 1;
			// 
			// BtnCreate
			// 
			this.BtnCreate.Location = new System.Drawing.Point(416, 24);
			this.BtnCreate.Name = "BtnCreate";
			this.BtnCreate.Size = new System.Drawing.Size(75, 23);
			this.BtnCreate.TabIndex = 2;
			this.BtnCreate.Text = "创建";
			this.BtnCreate.UseVisualStyleBackColor = true;
			this.BtnCreate.Click += new System.EventHandler(this.OnCreateNoteBook);
			// 
			// CreateNoteBookDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 65);
			this.Controls.Add(this.BtnCreate);
			this.Controls.Add(this.mTextNoteBook);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateNoteBookDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "创建笔记本";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
