/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 15:04
 * 
 * 
 */
namespace MyNote.View
{
	partial class NoteBookSettingDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InputNetPath = new System.Windows.Forms.TextBox();
            this.LabelNetPath = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mCryptFlag
            // 
            this.mCryptFlag.Location = new System.Drawing.Point(11, 17);
            this.mCryptFlag.Name = "mCryptFlag";
            this.mCryptFlag.Size = new System.Drawing.Size(74, 24);
            this.mCryptFlag.TabIndex = 0;
            this.mCryptFlag.Text = "开启加密";
            this.mCryptFlag.UseVisualStyleBackColor = true;
            // 
            // mCryptKey
            // 
            this.mCryptKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mCryptKey.Location = new System.Drawing.Point(91, 18);
            this.mCryptKey.Name = "mCryptKey";
            this.mCryptKey.Size = new System.Drawing.Size(253, 21);
            this.mCryptKey.TabIndex = 1;
            this.mCryptKey.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnNoteBookCryptEvt);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mCryptKey);
            this.groupBox1.Controls.Add(this.mCryptFlag);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "存储内容加密";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InputNetPath);
            this.groupBox2.Controls.Add(this.LabelNetPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "云同步配置";
            // 
            // InputNetPath
            // 
            this.InputNetPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputNetPath.Location = new System.Drawing.Point(91, 20);
            this.InputNetPath.Name = "InputNetPath";
            this.InputNetPath.Size = new System.Drawing.Size(253, 21);
            this.InputNetPath.TabIndex = 5;
            // 
            // LabelNetPath
            // 
            this.LabelNetPath.AutoSize = true;
            this.LabelNetPath.Location = new System.Drawing.Point(9, 23);
            this.LabelNetPath.Name = "LabelNetPath";
            this.LabelNetPath.Size = new System.Drawing.Size(71, 12);
            this.LabelNetPath.TabIndex = 4;
            this.LabelNetPath.Text = "云存储路径:";
            // 
            // NoteBookSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 186);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteBookSettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "笔记本设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox InputNetPath;
        private System.Windows.Forms.Label LabelNetPath;
    }
}
