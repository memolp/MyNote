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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mStatusBar = new System.Windows.Forms.StatusStrip();
			this.mStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolCreateNoteBook = new System.Windows.Forms.ToolStripButton();
			this.mToolOpenNoteBook = new System.Windows.Forms.ToolStripButton();
			this.mToolSaveNote = new System.Windows.Forms.ToolStripButton();
			this.mSplitCtrl = new System.Windows.Forms.SplitContainer();
			this.mNoteTree = new MyNote.View.NoteTreeView();
			this.mNodeEditor = new MyNote.View.NoteEditor();
			this.mSysMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mMenuCreateNoteBook = new System.Windows.Forms.ToolStripMenuItem();
			this.mMenuOpenNoteBook = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mMenuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mStatusBar.SuspendLayout();
			this.mToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mSplitCtrl)).BeginInit();
			this.mSplitCtrl.Panel1.SuspendLayout();
			this.mSplitCtrl.Panel2.SuspendLayout();
			this.mSplitCtrl.SuspendLayout();
			this.mSysMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mStatusBar
			// 
			this.mStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mStatusLabel});
			this.mStatusBar.Location = new System.Drawing.Point(0, 746);
			this.mStatusBar.Name = "mStatusBar";
			this.mStatusBar.Size = new System.Drawing.Size(1024, 22);
			this.mStatusBar.TabIndex = 1;
			this.mStatusBar.Text = "状态栏";
			// 
			// mStatusLabel
			// 
			this.mStatusLabel.Name = "mStatusLabel";
			this.mStatusLabel.Size = new System.Drawing.Size(149, 17);
			this.mStatusLabel.Text = "当前版本1.0 - 作者:覃贵锋";
			// 
			// mToolBar
			// 
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolCreateNoteBook,
			this.mToolOpenNoteBook,
			this.mToolSaveNote});
			this.mToolBar.Location = new System.Drawing.Point(0, 25);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.Size = new System.Drawing.Size(1024, 25);
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
			this.mSplitCtrl.Panel2.Controls.Add(this.mNodeEditor);
			this.mSplitCtrl.Size = new System.Drawing.Size(1024, 696);
			this.mSplitCtrl.SplitterDistance = 340;
			this.mSplitCtrl.TabIndex = 0;
			// 
			// mNoteTree
			// 
			this.mNoteTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mNoteTree.Location = new System.Drawing.Point(0, 0);
			this.mNoteTree.Name = "mNoteTree";
			this.mNoteTree.Size = new System.Drawing.Size(340, 696);
			this.mNoteTree.TabIndex = 0;
			// 
			// mNodeEditor
			// 
			this.mNodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mNodeEditor.Location = new System.Drawing.Point(0, 0);
			this.mNodeEditor.Name = "mNodeEditor";
			this.mNodeEditor.Size = new System.Drawing.Size(680, 696);
			this.mNodeEditor.TabIndex = 0;
			// 
			// mSysMenu
			// 
			this.mSysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.editToolStripMenuItem});
			this.mSysMenu.Location = new System.Drawing.Point(0, 0);
			this.mSysMenu.Name = "mSysMenu";
			this.mSysMenu.Size = new System.Drawing.Size(1024, 25);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 768);
			this.Controls.Add(this.mSplitCtrl);
			this.Controls.Add(this.mToolBar);
			this.Controls.Add(this.mStatusBar);
			this.Controls.Add(this.mSysMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mSysMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "MyNote - 笔记本";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnWindowClosing);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}