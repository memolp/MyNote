/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 15:04
 * 
 * 
 */
namespace MyNote.View
{
	partial class NoteBookCryptDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckBox mCryptFlag;
		private System.Windows.Forms.TextBox mCryptKey;
		private System.Windows.Forms.Button button1;
		
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
			this.mCryptFlag = new System.Windows.Forms.CheckBox();
			this.mCryptKey = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mCryptFlag
			// 
			this.mCryptFlag.Location = new System.Drawing.Point(12, 23);
			this.mCryptFlag.Name = "mCryptFlag";
			this.mCryptFlag.Size = new System.Drawing.Size(104, 24);
			this.mCryptFlag.TabIndex = 0;
			this.mCryptFlag.Text = "开启加密";
			this.mCryptFlag.UseVisualStyleBackColor = true;
			// 
			// mCryptKey
			// 
			this.mCryptKey.Location = new System.Drawing.Point(92, 26);
			this.mCryptKey.Name = "mCryptKey";
			this.mCryptKey.Size = new System.Drawing.Size(280, 21);
			this.mCryptKey.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(297, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "设置";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnNoteBookCryptEvt);
			// 
			// NoteBookCryptDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 99);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.mCryptKey);
			this.Controls.Add(this.mCryptFlag);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NoteBookCryptDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置笔记本加密";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
