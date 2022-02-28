/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 10:16
 * 
 * 
 */
namespace MyNote.View
{
	partial class PreferenceDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox mOnSystemIcon;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox mCaptureFlag;
		private System.Windows.Forms.GroupBox groupBox3;
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.mOnSystemIcon = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.mCaptureFlag = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(206, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 1;
			this.button1.Text = "取消";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnCancelEvt);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(328, 248);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 31);
			this.button2.TabIndex = 2;
			this.button2.Text = "应用";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.OnApplyEvt);
			// 
			// mOnSystemIcon
			// 
			this.mOnSystemIcon.Checked = true;
			this.mOnSystemIcon.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mOnSystemIcon.Location = new System.Drawing.Point(16, 30);
			this.mOnSystemIcon.Name = "mOnSystemIcon";
			this.mOnSystemIcon.Size = new System.Drawing.Size(104, 24);
			this.mOnSystemIcon.TabIndex = 0;
			this.mOnSystemIcon.Text = "关闭到托盘";
			this.mOnSystemIcon.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.mCaptureFlag);
			this.groupBox1.Controls.Add(this.mOnSystemIcon);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(393, 111);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "通用设置";
			// 
			// mCaptureFlag
			// 
			this.mCaptureFlag.Checked = true;
			this.mCaptureFlag.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mCaptureFlag.Location = new System.Drawing.Point(127, 29);
			this.mCaptureFlag.Name = "mCaptureFlag";
			this.mCaptureFlag.Size = new System.Drawing.Size(104, 24);
			this.mCaptureFlag.TabIndex = 1;
			this.mCaptureFlag.Text = "注册截屏功能";
			this.mCaptureFlag.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(12, 129);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(390, 100);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "同步功能";
			// 
			// PreferenceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 287);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "PreferenceDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置界面";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
