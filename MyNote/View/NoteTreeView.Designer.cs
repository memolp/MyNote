/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class NoteTreeView
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip mToolBar;
		private System.Windows.Forms.ToolStripButton mToolAddChildNode;
		private System.Windows.Forms.ToolStripButton mToolAddBeforeNode;
		private System.Windows.Forms.ToolStripButton mToolAddAfterNode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton mToolNodeMovePrev;
		private System.Windows.Forms.ToolStripButton mToolNodeMoveNext;
		private System.Windows.Forms.ToolStripButton mToolNodeMoveLeft;
		private System.Windows.Forms.ToolStripButton mToolNodeMoveRight;
		private System.Windows.Forms.ContextMenuStrip mPopMenuBar;
		private System.Windows.Forms.ToolStripMenuItem mTMAddChildNode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mTMAddBeforeNode;
		private System.Windows.Forms.ToolStripMenuItem mTMAddAfterNode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mTMDeleteNote;
		private System.Windows.Forms.ToolStripMenuItem mTMExpendAll;
		private System.Windows.Forms.TabControl mTreeTabCtrl;
		private System.Windows.Forms.ToolStripLabel mToolLabel;
		private System.Windows.Forms.ToolStripButton NoteBookSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteTreeView));
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolLabel = new System.Windows.Forms.ToolStripLabel();
			this.mToolAddChildNode = new System.Windows.Forms.ToolStripButton();
			this.mToolAddBeforeNode = new System.Windows.Forms.ToolStripButton();
			this.mToolAddAfterNode = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolNodeMovePrev = new System.Windows.Forms.ToolStripButton();
			this.mToolNodeMoveNext = new System.Windows.Forms.ToolStripButton();
			this.mToolNodeMoveLeft = new System.Windows.Forms.ToolStripButton();
			this.mToolNodeMoveRight = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.NoteBookSettings = new System.Windows.Forms.ToolStripButton();
			this.mPopMenuBar = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mTMAddChildNode = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mTMAddBeforeNode = new System.Windows.Forms.ToolStripMenuItem();
			this.mTMAddAfterNode = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mTMDeleteNote = new System.Windows.Forms.ToolStripMenuItem();
			this.mTMExpendAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mTreeTabCtrl = new System.Windows.Forms.TabControl();
			this.mToolBar.SuspendLayout();
			this.mPopMenuBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mToolBar
			// 
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolLabel,
			this.mToolAddChildNode,
			this.mToolAddBeforeNode,
			this.mToolAddAfterNode,
			this.toolStripSeparator1,
			this.mToolNodeMovePrev,
			this.mToolNodeMoveNext,
			this.mToolNodeMoveLeft,
			this.mToolNodeMoveRight,
			this.toolStripSeparator4,
			this.NoteBookSettings});
			this.mToolBar.Location = new System.Drawing.Point(0, 0);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.Size = new System.Drawing.Size(279, 25);
			this.mToolBar.TabIndex = 0;
			this.mToolBar.Text = "工具栏";
			// 
			// mToolLabel
			// 
			this.mToolLabel.Image = ((System.Drawing.Image)(resources.GetObject("mToolLabel.Image")));
			this.mToolLabel.Name = "mToolLabel";
			this.mToolLabel.Size = new System.Drawing.Size(48, 22);
			this.mToolLabel.Text = "大纲";
			// 
			// mToolAddChildNode
			// 
			this.mToolAddChildNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAddChildNode.Image = ((System.Drawing.Image)(resources.GetObject("mToolAddChildNode.Image")));
			this.mToolAddChildNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAddChildNode.Name = "mToolAddChildNode";
			this.mToolAddChildNode.Size = new System.Drawing.Size(23, 22);
			this.mToolAddChildNode.Text = "添加子节点";
			this.mToolAddChildNode.Click += new System.EventHandler(this.OnAddChildNodeEvent);
			// 
			// mToolAddBeforeNode
			// 
			this.mToolAddBeforeNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAddBeforeNode.Image = ((System.Drawing.Image)(resources.GetObject("mToolAddBeforeNode.Image")));
			this.mToolAddBeforeNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAddBeforeNode.Name = "mToolAddBeforeNode";
			this.mToolAddBeforeNode.Size = new System.Drawing.Size(23, 22);
			this.mToolAddBeforeNode.Text = "前面插入节点";
			this.mToolAddBeforeNode.Click += new System.EventHandler(this.OnAddPrevNodeEvent);
			// 
			// mToolAddAfterNode
			// 
			this.mToolAddAfterNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAddAfterNode.Image = ((System.Drawing.Image)(resources.GetObject("mToolAddAfterNode.Image")));
			this.mToolAddAfterNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAddAfterNode.Name = "mToolAddAfterNode";
			this.mToolAddAfterNode.Size = new System.Drawing.Size(23, 22);
			this.mToolAddAfterNode.Text = "后面插入节点";
			this.mToolAddAfterNode.Click += new System.EventHandler(this.OnAddNextNodeEvent);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolNodeMovePrev
			// 
			this.mToolNodeMovePrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolNodeMovePrev.Image = ((System.Drawing.Image)(resources.GetObject("mToolNodeMovePrev.Image")));
			this.mToolNodeMovePrev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolNodeMovePrev.Name = "mToolNodeMovePrev";
			this.mToolNodeMovePrev.Size = new System.Drawing.Size(23, 22);
			this.mToolNodeMovePrev.Text = "节点前移";
			this.mToolNodeMovePrev.Click += new System.EventHandler(this.OnMoveToPrev);
			// 
			// mToolNodeMoveNext
			// 
			this.mToolNodeMoveNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolNodeMoveNext.Image = ((System.Drawing.Image)(resources.GetObject("mToolNodeMoveNext.Image")));
			this.mToolNodeMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolNodeMoveNext.Name = "mToolNodeMoveNext";
			this.mToolNodeMoveNext.Size = new System.Drawing.Size(23, 22);
			this.mToolNodeMoveNext.Text = "节点后移";
			this.mToolNodeMoveNext.Click += new System.EventHandler(this.OnMoveToNext);
			// 
			// mToolNodeMoveLeft
			// 
			this.mToolNodeMoveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolNodeMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("mToolNodeMoveLeft.Image")));
			this.mToolNodeMoveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolNodeMoveLeft.Name = "mToolNodeMoveLeft";
			this.mToolNodeMoveLeft.Size = new System.Drawing.Size(23, 22);
			this.mToolNodeMoveLeft.Text = "节点左移";
			this.mToolNodeMoveLeft.Click += new System.EventHandler(this.OnMoveToLeft);
			// 
			// mToolNodeMoveRight
			// 
			this.mToolNodeMoveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolNodeMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("mToolNodeMoveRight.Image")));
			this.mToolNodeMoveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolNodeMoveRight.Name = "mToolNodeMoveRight";
			this.mToolNodeMoveRight.Size = new System.Drawing.Size(23, 22);
			this.mToolNodeMoveRight.Text = "节点右移";
			this.mToolNodeMoveRight.Click += new System.EventHandler(this.OnMoveToRight);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// NoteBookSettings
			// 
			this.NoteBookSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.NoteBookSettings.Image = ((System.Drawing.Image)(resources.GetObject("NoteBookSettings.Image")));
			this.NoteBookSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NoteBookSettings.Name = "NoteBookSettings";
			this.NoteBookSettings.Size = new System.Drawing.Size(23, 22);
			this.NoteBookSettings.Text = "笔记本设置";
			this.NoteBookSettings.ToolTipText = "设置笔记本属性";
			this.NoteBookSettings.Click += new System.EventHandler(this.OnNoteBookSettingEvt);
			// 
			// mPopMenuBar
			// 
			this.mPopMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mTMAddChildNode,
			this.toolStripSeparator3,
			this.mTMAddBeforeNode,
			this.mTMAddAfterNode,
			this.toolStripSeparator2,
			this.mTMDeleteNote,
			this.mTMExpendAll});
			this.mPopMenuBar.Name = "mPopMenuBar";
			this.mPopMenuBar.Size = new System.Drawing.Size(157, 126);
			// 
			// mTMAddChildNode
			// 
			this.mTMAddChildNode.Name = "mTMAddChildNode";
			this.mTMAddChildNode.Size = new System.Drawing.Size(156, 22);
			this.mTMAddChildNode.Text = "添加子节点";
			this.mTMAddChildNode.Click += new System.EventHandler(this.OnAddChildNodeEvent);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
			// 
			// mTMAddBeforeNode
			// 
			this.mTMAddBeforeNode.Name = "mTMAddBeforeNode";
			this.mTMAddBeforeNode.Size = new System.Drawing.Size(156, 22);
			this.mTMAddBeforeNode.Text = "前面添加节点";
			this.mTMAddBeforeNode.Click += new System.EventHandler(this.OnAddPrevNodeEvent);
			// 
			// mTMAddAfterNode
			// 
			this.mTMAddAfterNode.Name = "mTMAddAfterNode";
			this.mTMAddAfterNode.Size = new System.Drawing.Size(156, 22);
			this.mTMAddAfterNode.Text = "后面添加节点";
			this.mTMAddAfterNode.Click += new System.EventHandler(this.OnAddNextNodeEvent);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
			// 
			// mTMDeleteNote
			// 
			this.mTMDeleteNote.Name = "mTMDeleteNote";
			this.mTMDeleteNote.Size = new System.Drawing.Size(156, 22);
			this.mTMDeleteNote.Text = "删除当前节点";
			this.mTMDeleteNote.Click += new System.EventHandler(this.OnDeleteCurNode);
			// 
			// mTMExpendAll
			// 
			this.mTMExpendAll.Name = "mTMExpendAll";
			this.mTMExpendAll.Size = new System.Drawing.Size(156, 22);
			this.mTMExpendAll.Text = "全部展开(收缩)";
			this.mTMExpendAll.Click += new System.EventHandler(this.OnNodeExpand);
			// 
			// mTreeTabCtrl
			// 
			this.mTreeTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTreeTabCtrl.Location = new System.Drawing.Point(0, 25);
			this.mTreeTabCtrl.Multiline = true;
			this.mTreeTabCtrl.Name = "mTreeTabCtrl";
			this.mTreeTabCtrl.SelectedIndex = 0;
			this.mTreeTabCtrl.Size = new System.Drawing.Size(279, 217);
			this.mTreeTabCtrl.TabIndex = 2;
			this.mTreeTabCtrl.TabStop = false;
			this.mTreeTabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnNoteBookChange);
			this.mTreeTabCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
			// 
			// NoteTreeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.mTreeTabCtrl);
			this.Controls.Add(this.mToolBar);
			this.Name = "NoteTreeView";
			this.Size = new System.Drawing.Size(279, 242);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
			this.mToolBar.ResumeLayout(false);
			this.mToolBar.PerformLayout();
			this.mPopMenuBar.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
