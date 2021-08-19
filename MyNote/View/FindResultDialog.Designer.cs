/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/19
 * Time: 11:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class FindResultDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListView mFindResultView;
		private System.Windows.Forms.ColumnHeader NodeColumn;
		private System.Windows.Forms.ColumnHeader DoucmentColumn;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindResultDialog));
			this.mFindResultView = new System.Windows.Forms.ListView();
			this.NodeColumn = new System.Windows.Forms.ColumnHeader();
			this.DoucmentColumn = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// mFindResultView
			// 
			this.mFindResultView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.NodeColumn,
			this.DoucmentColumn});
			this.mFindResultView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mFindResultView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.mFindResultView.Location = new System.Drawing.Point(0, 0);
			this.mFindResultView.MultiSelect = false;
			this.mFindResultView.Name = "mFindResultView";
			this.mFindResultView.Size = new System.Drawing.Size(390, 339);
			this.mFindResultView.TabIndex = 0;
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
			// FindResultDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 339);
			this.Controls.Add(this.mFindResultView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindResultDialog";
			this.Text = "查找结果";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnDialogClosing);
			this.ResumeLayout(false);

		}
	}
}
