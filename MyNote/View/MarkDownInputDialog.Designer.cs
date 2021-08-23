/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/20
 * Time: 10:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class MarkDownInputDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip mToolBar;
		private System.Windows.Forms.TextBox mMkDownView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button mBtnInsert;
		private System.Windows.Forms.ToolStripButton mToolOpenMkdown;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkDownInputDialog));
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolOpenMkdown = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mBtnInsert = new System.Windows.Forms.Button();
			this.mMkDownView = new System.Windows.Forms.TextBox();
			this.mToolBar.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mToolBar
			// 
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolOpenMkdown});
			this.mToolBar.Location = new System.Drawing.Point(0, 0);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.Size = new System.Drawing.Size(557, 25);
			this.mToolBar.TabIndex = 0;
			this.mToolBar.Text = "工具栏";
			// 
			// mToolOpenMkdown
			// 
			this.mToolOpenMkdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolOpenMkdown.Image = ((System.Drawing.Image)(resources.GetObject("mToolOpenMkdown.Image")));
			this.mToolOpenMkdown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolOpenMkdown.Name = "mToolOpenMkdown";
			this.mToolOpenMkdown.Size = new System.Drawing.Size(23, 22);
			this.mToolOpenMkdown.Text = "打开Mkdown文件";
			this.mToolOpenMkdown.Click += new System.EventHandler(this.OnOpenMkdownFile);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.mBtnInsert);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 342);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(557, 40);
			this.panel1.TabIndex = 2;
			// 
			// mBtnInsert
			// 
			this.mBtnInsert.Dock = System.Windows.Forms.DockStyle.Right;
			this.mBtnInsert.Location = new System.Drawing.Point(482, 0);
			this.mBtnInsert.Margin = new System.Windows.Forms.Padding(5);
			this.mBtnInsert.Name = "mBtnInsert";
			this.mBtnInsert.Size = new System.Drawing.Size(75, 40);
			this.mBtnInsert.TabIndex = 0;
			this.mBtnInsert.Text = "插入";
			this.mBtnInsert.UseVisualStyleBackColor = true;
			this.mBtnInsert.Click += new System.EventHandler(this.OnBtnInsertCode);
			// 
			// mMkDownView
			// 
			this.mMkDownView.AcceptsReturn = true;
			this.mMkDownView.AcceptsTab = true;
			this.mMkDownView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mMkDownView.Location = new System.Drawing.Point(0, 25);
			this.mMkDownView.Multiline = true;
			this.mMkDownView.Name = "mMkDownView";
			this.mMkDownView.Size = new System.Drawing.Size(557, 317);
			this.mMkDownView.TabIndex = 3;
			// 
			// MarkDownInputDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 382);
			this.Controls.Add(this.mMkDownView);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.mToolBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MarkDownInputDialog";
			this.Text = "MarkDown编辑";
			this.mToolBar.ResumeLayout(false);
			this.mToolBar.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
