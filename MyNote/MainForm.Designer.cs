/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.StatusStrip mStatusBar;
		private System.Windows.Forms.ToolStrip mToolBar;
		private System.Windows.Forms.SplitContainer mSplitCtrl;
		private MyNote.View.NoteTreeView mNoteTree;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mSysMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private MyNote.View.NoteEditor mNodeEditor;
		private System.Windows.Forms.ToolStripMenuItem mMenuCreateNoteBook;
		private System.Windows.Forms.ToolStripMenuItem mMenuOpenNoteBook;
		private System.Windows.Forms.ToolStripMenuItem mMenuSave;
		private System.Windows.Forms.ToolStripMenuItem mMenuExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton mToolCreateNoteBook;
		private System.Windows.Forms.ToolStripButton mToolOpenNoteBook;
		private System.Windows.Forms.ToolStripButton mToolSaveNote;
		private System.Windows.Forms.ToolStripStatusLabel mStatusLabel;
		private System.Windows.Forms.ContextMenuStrip mNotifyMenu;
		private System.Windows.Forms.ToolStripMenuItem mToolShowWindow;
		private System.Windows.Forms.ToolStripMenuItem mTMQuitApp;
		private System.Windows.Forms.NotifyIcon mNotifyIcon;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripTextBox mToolSearchInput;
		private System.Windows.Forms.ToolStripSplitButton mToolSearch;
		private System.Windows.Forms.ToolStripMenuItem mToolFindInTree;
		private System.Windows.Forms.ToolStripMenuItem mToolFindAll;
		private MyNote.View.FindResultPanel mFindResultDlg;
		private System.Windows.Forms.ToolStripMenuItem mToolNotifyIcon;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.Panel mLockPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mUnlockPassword;
		private System.Windows.Forms.Button mUnlockButton;
		private System.Windows.Forms.Timer mCheckTimer;
		private System.Windows.Forms.ToolStripMenuItem mToolLockWindow;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mStatusBar = new System.Windows.Forms.StatusStrip();
			this.mStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolCreateNoteBook = new System.Windows.Forms.ToolStripButton();
			this.mToolOpenNoteBook = new System.Windows.Forms.ToolStripButton();
			this.mToolSaveNote = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolSearchInput = new System.Windows.Forms.ToolStripTextBox();
			this.mToolSearch = new System.Windows.Forms.ToolStripSplitButton();
			this.mToolFindInTree = new System.Windows.Forms.ToolStripMenuItem();
			this.mToolFindAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mSplitCtrl = new System.Windows.Forms.SplitContainer();
			this.mNoteTree = new MyNote.View.NoteTreeView();
			this.mFindResultDlg = new MyNote.View.FindResultPanel();
			this.mNodeEditor = new MyNote.View.NoteEditor();
			this.mSysMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mMenuCreateNoteBook = new System.Windows.Forms.ToolStripMenuItem();
			this.mMenuOpenNoteBook = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mMenuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolNotifyIcon = new System.Windows.Forms.ToolStripMenuItem();
			this.mMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mNotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mToolShowWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mToolLockWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mTMQuitApp = new System.Windows.Forms.ToolStripMenuItem();
			this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.mLockPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.mUnlockPassword = new System.Windows.Forms.TextBox();
			this.mUnlockButton = new System.Windows.Forms.Button();
			this.mCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.mStatusBar.SuspendLayout();
			this.mToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mSplitCtrl)).BeginInit();
			this.mSplitCtrl.Panel1.SuspendLayout();
			this.mSplitCtrl.Panel2.SuspendLayout();
			this.mSplitCtrl.SuspendLayout();
			this.mSysMenu.SuspendLayout();
			this.mNotifyMenu.SuspendLayout();
			this.mLockPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mStatusBar
			// 
			this.mStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mStatusLabel});
			this.mStatusBar.Location = new System.Drawing.Point(0, 746);
			this.mStatusBar.Name = "mStatusBar";
			this.mStatusBar.Size = new System.Drawing.Size(1038, 22);
			this.mStatusBar.TabIndex = 1;
			this.mStatusBar.Text = "状态栏";
			// 
			// mStatusLabel
			// 
			this.mStatusLabel.Name = "mStatusLabel";
			this.mStatusLabel.Size = new System.Drawing.Size(149, 17);
			this.mStatusLabel.Text = "当前版本2.2 - 作者:覃贵锋";
			// 
			// mToolBar
			// 
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolCreateNoteBook,
			this.mToolOpenNoteBook,
			this.mToolSaveNote,
			this.toolStripSeparator3,
			this.mToolSearchInput,
			this.mToolSearch});
			this.mToolBar.Location = new System.Drawing.Point(0, 25);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.Size = new System.Drawing.Size(1038, 25);
			this.mToolBar.TabIndex = 2;
			this.mToolBar.Text = "工具栏";
			// 
			// mToolCreateNoteBook
			// 
			this.mToolCreateNoteBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolCreateNoteBook.Image = ((System.Drawing.Image)(resources.GetObject("mToolCreateNoteBook.Image")));
			this.mToolCreateNoteBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolCreateNoteBook.Name = "mToolCreateNoteBook";
			this.mToolCreateNoteBook.Size = new System.Drawing.Size(23, 22);
			this.mToolCreateNoteBook.Text = "创建笔记本";
			this.mToolCreateNoteBook.Click += new System.EventHandler(this.OnCreateNoteBook);
			// 
			// mToolOpenNoteBook
			// 
			this.mToolOpenNoteBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolOpenNoteBook.Image = ((System.Drawing.Image)(resources.GetObject("mToolOpenNoteBook.Image")));
			this.mToolOpenNoteBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolOpenNoteBook.Name = "mToolOpenNoteBook";
			this.mToolOpenNoteBook.Size = new System.Drawing.Size(23, 22);
			this.mToolOpenNoteBook.Text = "打开笔记本";
			this.mToolOpenNoteBook.Click += new System.EventHandler(this.OnOpenNoteBook);
			// 
			// mToolSaveNote
			// 
			this.mToolSaveNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolSaveNote.Image = ((System.Drawing.Image)(resources.GetObject("mToolSaveNote.Image")));
			this.mToolSaveNote.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolSaveNote.Name = "mToolSaveNote";
			this.mToolSaveNote.Size = new System.Drawing.Size(23, 22);
			this.mToolSaveNote.Text = "保存笔记";
			this.mToolSaveNote.Click += new System.EventHandler(this.OnSaveNoteBookDocument);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolSearchInput
			// 
			this.mToolSearchInput.Name = "mToolSearchInput";
			this.mToolSearchInput.Size = new System.Drawing.Size(100, 25);
			// 
			// mToolSearch
			// 
			this.mToolSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolFindInTree,
			this.mToolFindAll});
			this.mToolSearch.Image = ((System.Drawing.Image)(resources.GetObject("mToolSearch.Image")));
			this.mToolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolSearch.Name = "mToolSearch";
			this.mToolSearch.Size = new System.Drawing.Size(32, 22);
			this.mToolSearch.Text = "查找";
			// 
			// mToolFindInTree
			// 
			this.mToolFindInTree.Name = "mToolFindInTree";
			this.mToolFindInTree.Size = new System.Drawing.Size(124, 22);
			this.mToolFindInTree.Text = "大纲查找";
			this.mToolFindInTree.Click += new System.EventHandler(this.OnFindInTree);
			// 
			// mToolFindAll
			// 
			this.mToolFindAll.Name = "mToolFindAll";
			this.mToolFindAll.Size = new System.Drawing.Size(124, 22);
			this.mToolFindAll.Text = "全部查找";
			this.mToolFindAll.Click += new System.EventHandler(this.OnFindInAll);
			// 
			// mSplitCtrl
			// 
			this.mSplitCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mSplitCtrl.Location = new System.Drawing.Point(0, 50);
			this.mSplitCtrl.Name = "mSplitCtrl";
			// 
			// mSplitCtrl.Panel1
			// 
			this.mSplitCtrl.Panel1.Controls.Add(this.mNoteTree);
			// 
			// mSplitCtrl.Panel2
			// 
			this.mSplitCtrl.Panel2.Controls.Add(this.mFindResultDlg);
			this.mSplitCtrl.Panel2.Controls.Add(this.mNodeEditor);
			this.mSplitCtrl.Size = new System.Drawing.Size(1038, 696);
			this.mSplitCtrl.SplitterDistance = 304;
			this.mSplitCtrl.TabIndex = 0;
			this.mSplitCtrl.TabStop = false;
			// 
			// mNoteTree
			// 
			this.mNoteTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mNoteTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mNoteTree.Location = new System.Drawing.Point(0, 0);
			this.mNoteTree.Name = "mNoteTree";
			this.mNoteTree.Size = new System.Drawing.Size(304, 696);
			this.mNoteTree.TabIndex = 0;
			this.mNoteTree.TabStop = false;
			// 
			// mFindResultDlg
			// 
			this.mFindResultDlg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mFindResultDlg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mFindResultDlg.Location = new System.Drawing.Point(0, 521);
			this.mFindResultDlg.Name = "mFindResultDlg";
			this.mFindResultDlg.Size = new System.Drawing.Size(730, 172);
			this.mFindResultDlg.TabIndex = 1;
			this.mFindResultDlg.TabStop = false;
			this.mFindResultDlg.Visible = false;
			this.mFindResultDlg.VisibleChanged += new System.EventHandler(this.OnFindResultWindow);
			// 
			// mNodeEditor
			// 
			this.mNodeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mNodeEditor.BackColor = System.Drawing.Color.AliceBlue;
			this.mNodeEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mNodeEditor.Location = new System.Drawing.Point(0, 0);
			this.mNodeEditor.Name = "mNodeEditor";
			this.mNodeEditor.Size = new System.Drawing.Size(730, 515);
			this.mNodeEditor.TabIndex = 0;
			this.mNodeEditor.TabStop = false;
			// 
			// mSysMenu
			// 
			this.mSysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.editToolStripMenuItem,
			this.toolsToolStripMenuItem});
			this.mSysMenu.Location = new System.Drawing.Point(0, 0);
			this.mSysMenu.Name = "mSysMenu";
			this.mSysMenu.Size = new System.Drawing.Size(1038, 25);
			this.mSysMenu.TabIndex = 4;
			this.mSysMenu.Text = "菜单栏";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mMenuCreateNoteBook,
			this.mMenuOpenNoteBook,
			this.toolStripSeparator1,
			this.mMenuSave,
			this.toolStripSeparator2,
			this.mToolNotifyIcon,
			this.mMenuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// mMenuCreateNoteBook
			// 
			this.mMenuCreateNoteBook.Name = "mMenuCreateNoteBook";
			this.mMenuCreateNoteBook.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mMenuCreateNoteBook.Size = new System.Drawing.Size(183, 22);
			this.mMenuCreateNoteBook.Text = "创建笔记本";
			this.mMenuCreateNoteBook.Click += new System.EventHandler(this.OnCreateNoteBook);
			// 
			// mMenuOpenNoteBook
			// 
			this.mMenuOpenNoteBook.Name = "mMenuOpenNoteBook";
			this.mMenuOpenNoteBook.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mMenuOpenNoteBook.Size = new System.Drawing.Size(183, 22);
			this.mMenuOpenNoteBook.Text = "打开笔记本";
			this.mMenuOpenNoteBook.Click += new System.EventHandler(this.OnOpenNoteBook);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
			// 
			// mMenuSave
			// 
			this.mMenuSave.Name = "mMenuSave";
			this.mMenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mMenuSave.Size = new System.Drawing.Size(183, 22);
			this.mMenuSave.Text = "保存";
			this.mMenuSave.Click += new System.EventHandler(this.OnSaveNoteBookDocument);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
			// 
			// mToolNotifyIcon
			// 
			this.mToolNotifyIcon.Name = "mToolNotifyIcon";
			this.mToolNotifyIcon.Size = new System.Drawing.Size(183, 22);
			this.mToolNotifyIcon.Text = "系统托盘";
			this.mToolNotifyIcon.Click += new System.EventHandler(this.OnNotifyIconHandler);
			// 
			// mMenuExit
			// 
			this.mMenuExit.Name = "mMenuExit";
			this.mMenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.mMenuExit.Size = new System.Drawing.Size(183, 22);
			this.mMenuExit.Text = "退出";
			this.mMenuExit.Click += new System.EventHandler(this.OnQuit);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.preferencesToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences...";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.OnPreferencesShowEvt);
			// 
			// mNotifyMenu
			// 
			this.mNotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolShowWindow,
			this.mToolLockWindow,
			this.mTMQuitApp});
			this.mNotifyMenu.Name = "mNotifyMenu";
			this.mNotifyMenu.Size = new System.Drawing.Size(125, 70);
			// 
			// mToolShowWindow
			// 
			this.mToolShowWindow.Name = "mToolShowWindow";
			this.mToolShowWindow.Size = new System.Drawing.Size(124, 22);
			this.mToolShowWindow.Text = "显示窗体";
			this.mToolShowWindow.Click += new System.EventHandler(this.OnNotifyIconHandler);
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
			this.mTMQuitApp.Click += new System.EventHandler(this.OnQuit);
			// 
			// mNotifyIcon
			// 
			this.mNotifyIcon.ContextMenuStrip = this.mNotifyMenu;
			this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
			this.mNotifyIcon.Text = "系统托盘";
			this.mNotifyIcon.Visible = true;
			// 
			// mLockPanel
			// 
			this.mLockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mLockPanel.BackColor = System.Drawing.Color.Black;
			this.mLockPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mLockPanel.BackgroundImage")));
			this.mLockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.mLockPanel.Controls.Add(this.label1);
			this.mLockPanel.Controls.Add(this.mUnlockPassword);
			this.mLockPanel.Controls.Add(this.mUnlockButton);
			this.mLockPanel.Location = new System.Drawing.Point(0, 0);
			this.mLockPanel.Name = "mLockPanel";
			this.mLockPanel.Size = new System.Drawing.Size(1038, 746);
			this.mLockPanel.TabIndex = 5;
			this.mLockPanel.Visible = false;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Aqua;
			this.label1.Location = new System.Drawing.Point(390, 278);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(254, 46);
			this.label1.TabIndex = 3;
			this.label1.Text = "当前窗口已锁定";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mUnlockPassword
			// 
			this.mUnlockPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.mUnlockPassword.Location = new System.Drawing.Point(421, 347);
			this.mUnlockPassword.Name = "mUnlockPassword";
			this.mUnlockPassword.Size = new System.Drawing.Size(197, 21);
			this.mUnlockPassword.TabIndex = 5;
			this.mUnlockPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.mUnlockPassword.UseSystemPasswordChar = true;
			// 
			// mUnlockButton
			// 
			this.mUnlockButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.mUnlockButton.BackColor = System.Drawing.Color.DodgerBlue;
			this.mUnlockButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mUnlockButton.ForeColor = System.Drawing.Color.Blue;
			this.mUnlockButton.Location = new System.Drawing.Point(462, 383);
			this.mUnlockButton.Name = "mUnlockButton";
			this.mUnlockButton.Size = new System.Drawing.Size(115, 38);
			this.mUnlockButton.TabIndex = 4;
			this.mUnlockButton.Text = "解锁";
			this.mUnlockButton.UseVisualStyleBackColor = false;
			this.mUnlockButton.Click += new System.EventHandler(this.OnUnlockEvt);
			// 
			// mCheckTimer
			// 
			this.mCheckTimer.Interval = 1000;
			this.mCheckTimer.Tick += new System.EventHandler(this.OnCheckLockTimer);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1038, 768);
			this.Controls.Add(this.mSplitCtrl);
			this.Controls.Add(this.mToolBar);
			this.Controls.Add(this.mStatusBar);
			this.Controls.Add(this.mSysMenu);
			this.Controls.Add(this.mLockPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mSysMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "MyNote - 笔记本";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnWindowClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnWindowClosed);
			this.Load += new System.EventHandler(this.WindowLoaded);
			this.Shown += new System.EventHandler(this.OnWindowShown);
			this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
			this.mStatusBar.ResumeLayout(false);
			this.mStatusBar.PerformLayout();
			this.mToolBar.ResumeLayout(false);
			this.mToolBar.PerformLayout();
			this.mSplitCtrl.Panel1.ResumeLayout(false);
			this.mSplitCtrl.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mSplitCtrl)).EndInit();
			this.mSplitCtrl.ResumeLayout(false);
			this.mSysMenu.ResumeLayout(false);
			this.mSysMenu.PerformLayout();
			this.mNotifyMenu.ResumeLayout(false);
			this.mLockPanel.ResumeLayout(false);
			this.mLockPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}