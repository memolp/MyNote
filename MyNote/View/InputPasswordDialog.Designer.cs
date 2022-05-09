/*
 * User: 覃贵锋
 * Date: 2022/5/9
 * Time: 11:38
 * 
 * 
 */
namespace MyNote.View
{
	partial class InputPasswordDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mOldPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox mNewPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox mRepeatPassword;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		
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
			this.mOldPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.mNewPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.mRepeatPassword = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(35, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入旧密码:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mOldPassword
			// 
			this.mOldPassword.Location = new System.Drawing.Point(141, 32);
			this.mOldPassword.Name = "mOldPassword";
			this.mOldPassword.Size = new System.Drawing.Size(214, 21);
			this.mOldPassword.TabIndex = 1;
			this.mOldPassword.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(35, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "输入新密码:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mNewPassword
			// 
			this.mNewPassword.Location = new System.Drawing.Point(141, 78);
			this.mNewPassword.Name = "mNewPassword";
			this.mNewPassword.Size = new System.Drawing.Size(214, 21);
			this.mNewPassword.TabIndex = 3;
			this.mNewPassword.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(35, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "重复输入新密码:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mRepeatPassword
			// 
			this.mRepeatPassword.Location = new System.Drawing.Point(141, 124);
			this.mRepeatPassword.Name = "mRepeatPassword";
			this.mRepeatPassword.Size = new System.Drawing.Size(213, 21);
			this.mRepeatPassword.TabIndex = 5;
			this.mRepeatPassword.UseSystemPasswordChar = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(74, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "取消";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnCancleEvt);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(249, 192);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "确认";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.OnApplyEvt);
			// 
			// InputPasswordDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 234);
			this.ControlBox = false;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.mRepeatPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.mNewPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.mOldPassword);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InputPasswordDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "输入密码";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
