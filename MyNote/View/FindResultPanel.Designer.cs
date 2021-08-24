/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/24
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class FindResultPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView mFindResultView;
		private System.Windows.Forms.ColumnHeader NodeColumn;
		private System.Windows.Forms.ColumnHeader DoucmentColumn;
		private System.Windows.Forms.ToolStrip mToolBar;
		private System.Windows.Forms.ToolStripButton mToolHide;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindResultPanel));
			this.mFindResultView = new System.Windows.Forms.ListView();
			this.NodeColumn = new System.Windows.Forms.ColumnHeader();
			this.DoucmentColumn = new System.Windows.Forms.ColumnHeader();
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolHide = new System.Windows.Forms.ToolStripButton();
			this.mToolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mFindResultView
			// 
			this.mFindResultView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mFindResultView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mFindResultView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.NodeColumn,
			this.DoucmentColumn});
			this.mFindResultView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.mFindResultView.Location = new System.Drawing.Point(0, 25);
			this.mFindResultView.MultiSelect = false;
			this.mFindResultView.Name = "mFindResultView";
			this.mFindResultView.Size = new System.Drawing.Size(322, 389);
			this.mFindResultView.TabIndex = 1;
			this.mFindResultView.UseCompatibleStateImageBehavior = false;
			this.mFindResultView.View = System.Windows.Forms.View.Details;
			this.mFindResultView.DoubleClick += new System.EventHandler(this.OnNodeClick);
			// 
			// NodeColumn
			// 
			this.NodeColumn.Text = "大纲节点";
			this.NodeColumn.Width = 170;
			// 
			// DoucmentColumn
			// 
			this.DoucmentColumn.Text = "文件路径";
			this.DoucmentColumn.Width = 216;
			// 
			// mToolBar
			// 
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolHide});
			this.mToolBar.Location = new System.Drawing.Point(0, 0);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.mToolBar.Size = new System.Drawing.Size(320, 25);
			this.mToolBar.TabIndex = 2;
			this.mToolBar.Text = "工具栏";
			// 
			// mToolHide
			// 
			this.mToolHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolHide.Image = ((System.Drawing.Image)(resources.GetObject("mToolHide.Image")));
			this.mToolHide.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolHide.Name = "mToolHide";
			this.mToolHide.Size = new System.Drawing.Size(23, 22);
			this.mToolHide.Text = "关闭";
			this.mToolHide.Click += new System.EventHandler(this.OnHideWindow);
			// 
			// FindResultPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.mToolBar);
			this.Controls.Add(this.mFindResultView);
			this.Name = "FindResultPanel";
			this.Size = new System.Drawing.Size(320, 411);
			this.mToolBar.ResumeLayout(false);
			this.mToolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
