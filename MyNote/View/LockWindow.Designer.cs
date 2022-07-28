/*
 * User: 覃贵锋
 * Date: 2022/5/9
 * Time: 14:11
 * 
 * 
 */
namespace MyNote.View
{
	partial class LockWindow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel mLockPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mUnlockPassword;
		private System.Windows.Forms.Button mUnlockButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.NotifyIcon mNotifyIcon;
		private System.Windows.Forms.ContextMenuStrip mNotifyMenu;
		private System.Windows.Forms.ToolStripMenuItem mToolLockWindow;
		private System.Windows.Forms.ToolStripMenuItem mTMQuitApp;
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockWindow));
			this.mLockPanel = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.mUnlockPassword = new System.Windows.Forms.TextBox();
			this.mUnlockButton = new System.Windows.Forms.Button();
			this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.mNotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mToolLockWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mTMQuitApp = new System.Windows.Forms.ToolStripMenuItem();
			this.mLockPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.mNotifyMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mLockPanel
			// 
			this.mLockPanel.BackColor = System.Drawing.Color.DarkGreen;
			this.mLockPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mLockPanel.BackgroundImage")));
			this.mLockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.mLockPanel.Controls.Add(this.pictureBox1);
			this.mLockPanel.Controls.Add(this.label1);
			this.mLockPanel.Controls.Add(this.mUnlockPassword);
			this.mLockPanel.Controls.Add(this.mUnlockButton);
			this.mLockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mLockPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.mLockPanel.Location = new System.Drawing.Point(0, 0);
			this.mLockPanel.Name = "mLockPanel";
			this.mLockPanel.Size = new System.Drawing.Size(324, 515);
			this.mLockPanel.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(261, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(60, 62);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.OnCloseEvt);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Aqua;
			this.label1.Location = new System.Drawing.Point(37, 183);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(254, 46);
			this.label1.TabIndex = 0;
			this.label1.Text = "当前窗口已锁定";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mUnlockPassword
			// 
			this.mUnlockPassword.AcceptsReturn = true;
			this.mUnlockPassword.Location = new System.Drawing.Point(66, 280);
			this.mUnlockPassword.Name = "mUnlockPassword";
			this.mUnlockPassword.Size = new System.Drawing.Size(197, 21);
			this.mUnlockPassword.TabIndex = 2;
			this.mUnlockPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.mUnlockPassword.UseSystemPasswordChar = true;
			this.mUnlockPassword.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnKeyDownEvt);
			// 
			// mUnlockButton
			// 
			this.mUnlockButton.BackColor = System.Drawing.Color.DodgerBlue;
			this.mUnlockButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mUnlockButton.ForeColor = System.Drawing.Color.Blue;
			this.mUnlockButton.Location = new System.Drawing.Point(107, 316);
			this.mUnlockButton.Name = "mUnlockButton";
			this.mUnlockButton.Size = new System.Drawing.Size(115, 38);
			this.mUnlockButton.TabIndex = 1;
			this.mUnlockButton.Text = "解锁";
			this.mUnlockButton.UseVisualStyleBackColor = false;
			this.mUnlockButton.Click += new System.EventHandler(this.OnUnlockEvt);
			this.mUnlockButton.Resize += new System.EventHandler(this.OnButtonResizeEvt);
			// 
			// mNotifyIcon
			// 
			this.mNotifyIcon.ContextMenuStrip = this.mNotifyMenu;
			this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
			this.mNotifyIcon.Text = "系统托盘";
			this.mNotifyIcon.Visible = true;
			// 
			// mNotifyMenu
			// 
			this.mNotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolLockWindow,
			this.mTMQuitApp});
			this.mNotifyMenu.Name = "mNotifyMenu";
			this.mNotifyMenu.Size = new System.Drawing.Size(125, 48);
			// 
			// mToolLockWindow
			// 
			this.mToolLockWindow.Name = "mToolLockWindow";
			this.mToolLockWindow.Size = new System.Drawing.Size(124, 22);
			this.mToolLockWindow.Text = "锁定窗体";
			this.mToolLockWindow.Click += new System.EventHandler(this.OnLockWindowEvt);
			// 
			// mTMQuitApp
			// 
			this.mTMQuitApp.Name = "mTMQuitApp";
			this.mTMQuitApp.Size = new System.Drawing.Size(124, 22);
			this.mTMQuitApp.Text = "退出程序";
			this.mTMQuitApp.Click += new System.EventHandler(this.OnCloseEvt);
			// 
			// LockWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 515);
			this.Controls.Add(this.mLockPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LockWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LockWindow";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosedEvt);
			this.Load += new System.EventHandler(this.OnLoadEvt);
			this.Shown += new System.EventHandler(this.OnShowEvt);
			this.Resize += new System.EventHandler(this.OnWindowResize);
			this.mLockPanel.ResumeLayout(false);
			this.mLockPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.mNotifyMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
