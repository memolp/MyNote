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
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TrackBar mLockTime;
		private System.Windows.Forms.CheckBox mAutoLockCheck;
		
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
            this.button3 = new System.Windows.Forms.Button();
            this.mLockTime = new System.Windows.Forms.TrackBar();
            this.mAutoLockCheck = new System.Windows.Forms.CheckBox();
            this.mCaptureFlag = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.InputNetSeverUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckServerSync = new System.Windows.Forms.CheckBox();
            this.InputNetToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mLockTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(206, 263);
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
            this.button2.Location = new System.Drawing.Point(328, 263);
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
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.mLockTime);
            this.groupBox1.Controls.Add(this.mAutoLockCheck);
            this.groupBox1.Controls.Add(this.mCaptureFlag);
            this.groupBox1.Controls.Add(this.mOnSystemIcon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通用设置";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "设置密码";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnSetUnLockPasswdEvt);
            // 
            // mLockTime
            // 
            this.mLockTime.Location = new System.Drawing.Point(112, 71);
            this.mLockTime.Minimum = 1;
            this.mLockTime.Name = "mLockTime";
            this.mLockTime.Size = new System.Drawing.Size(183, 45);
            this.mLockTime.TabIndex = 3;
            this.mLockTime.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.mLockTime.Value = 1;
            // 
            // mAutoLockCheck
            // 
            this.mAutoLockCheck.Location = new System.Drawing.Point(16, 71);
            this.mAutoLockCheck.Name = "mAutoLockCheck";
            this.mAutoLockCheck.Size = new System.Drawing.Size(104, 24);
            this.mAutoLockCheck.TabIndex = 2;
            this.mAutoLockCheck.Text = "自动锁定窗口";
            this.mAutoLockCheck.UseVisualStyleBackColor = true;
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
            this.groupBox3.Controls.Add(this.InputNetToken);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.InputNetSeverUrl);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CheckServerSync);
            this.groupBox3.Location = new System.Drawing.Point(12, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 128);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "同步功能";
            // 
            // InputNetSeverUrl
            // 
            this.InputNetSeverUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputNetSeverUrl.Location = new System.Drawing.Point(93, 64);
            this.InputNetSeverUrl.Name = "InputNetSeverUrl";
            this.InputNetSeverUrl.Size = new System.Drawing.Size(274, 21);
            this.InputNetSeverUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "同步服务器:";
            // 
            // CheckServerSync
            // 
            this.CheckServerSync.AutoSize = true;
            this.CheckServerSync.Location = new System.Drawing.Point(16, 37);
            this.CheckServerSync.Name = "CheckServerSync";
            this.CheckServerSync.Size = new System.Drawing.Size(72, 16);
            this.CheckServerSync.TabIndex = 0;
            this.CheckServerSync.Text = "开启同步";
            this.CheckServerSync.UseVisualStyleBackColor = true;
            // 
            // InputNetToken
            // 
            this.InputNetToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputNetToken.Location = new System.Drawing.Point(92, 96);
            this.InputNetToken.Name = "InputNetToken";
            this.InputNetToken.Size = new System.Drawing.Size(274, 21);
            this.InputNetToken.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "访问Token:";
            // 
            // PreferenceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 302);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PreferenceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置界面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mLockTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TextBox InputNetSeverUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckServerSync;
        private System.Windows.Forms.TextBox InputNetToken;
        private System.Windows.Forms.Label label2;
    }
}
