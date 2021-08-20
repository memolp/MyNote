﻿/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 17:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class NoteEditor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip mToolBar;
		private System.Windows.Forms.WebBrowser mWebBrowser;
		private System.Windows.Forms.ToolStripButton mToolBold;
		private System.Windows.Forms.ToolStripButton mToolItalic;
		private System.Windows.Forms.ToolStripComboBox mToolFontFamily;
		private System.Windows.Forms.ToolStripComboBox mToolFontSize;
		private System.Windows.Forms.ToolStripButton mToolUnderline;
		private System.Windows.Forms.ToolStripButton mToolStrikeThrough;
		private System.Windows.Forms.ToolStripButton mToolAlignLeft;
		private System.Windows.Forms.ToolStripButton mToolAlignCenter;
		private System.Windows.Forms.ToolStripButton mToolAlignRight;
		private System.Windows.Forms.ToolStripButton mToolOutDent;
		private System.Windows.Forms.ToolStripButton mToolInDent;
		private System.Windows.Forms.ToolStripButton mToolOrderList;
		private System.Windows.Forms.ToolStripButton mToolUnorderList;
		private System.Windows.Forms.ToolStripButton mToolForeColor;
		private System.Windows.Forms.ToolStripButton mToolBackColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton mToolAttachment;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton mToolAlignFull;
		private System.Windows.Forms.ToolStripButton mToolFormatClear;
		private System.Windows.Forms.ToolStripButton mToolAddImage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton mToolInsertCode;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditor));
			this.mToolBar = new System.Windows.Forms.ToolStrip();
			this.mToolBold = new System.Windows.Forms.ToolStripButton();
			this.mToolItalic = new System.Windows.Forms.ToolStripButton();
			this.mToolUnderline = new System.Windows.Forms.ToolStripButton();
			this.mToolStrikeThrough = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolFontFamily = new System.Windows.Forms.ToolStripComboBox();
			this.mToolFontSize = new System.Windows.Forms.ToolStripComboBox();
			this.mToolForeColor = new System.Windows.Forms.ToolStripButton();
			this.mToolBackColor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolAlignLeft = new System.Windows.Forms.ToolStripButton();
			this.mToolAlignCenter = new System.Windows.Forms.ToolStripButton();
			this.mToolAlignRight = new System.Windows.Forms.ToolStripButton();
			this.mToolAlignFull = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolOutDent = new System.Windows.Forms.ToolStripButton();
			this.mToolInDent = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolOrderList = new System.Windows.Forms.ToolStripButton();
			this.mToolUnorderList = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolAddImage = new System.Windows.Forms.ToolStripButton();
			this.mToolAttachment = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mToolFormatClear = new System.Windows.Forms.ToolStripButton();
			this.mWebBrowser = new System.Windows.Forms.WebBrowser();
			this.mToolInsertCode = new System.Windows.Forms.ToolStripButton();
			this.mToolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mToolBar
			// 
			this.mToolBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.mToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mToolBold,
			this.mToolItalic,
			this.mToolUnderline,
			this.mToolStrikeThrough,
			this.toolStripSeparator1,
			this.mToolFontFamily,
			this.mToolFontSize,
			this.mToolForeColor,
			this.mToolBackColor,
			this.toolStripSeparator2,
			this.mToolAlignLeft,
			this.mToolAlignCenter,
			this.mToolAlignRight,
			this.mToolAlignFull,
			this.toolStripSeparator3,
			this.mToolOutDent,
			this.mToolInDent,
			this.toolStripSeparator4,
			this.mToolOrderList,
			this.mToolUnorderList,
			this.toolStripSeparator5,
			this.mToolInsertCode,
			this.mToolAddImage,
			this.mToolAttachment,
			this.toolStripSeparator6,
			this.mToolFormatClear});
			this.mToolBar.Location = new System.Drawing.Point(0, 0);
			this.mToolBar.Name = "mToolBar";
			this.mToolBar.Size = new System.Drawing.Size(711, 25);
			this.mToolBar.TabIndex = 0;
			this.mToolBar.Text = "工具栏";
			// 
			// mToolBold
			// 
			this.mToolBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolBold.Image = ((System.Drawing.Image)(resources.GetObject("mToolBold.Image")));
			this.mToolBold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolBold.Name = "mToolBold";
			this.mToolBold.Size = new System.Drawing.Size(23, 22);
			this.mToolBold.Text = "加粗";
			this.mToolBold.Click += new System.EventHandler(this.OnBoldClick);
			// 
			// mToolItalic
			// 
			this.mToolItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolItalic.Image = ((System.Drawing.Image)(resources.GetObject("mToolItalic.Image")));
			this.mToolItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolItalic.Name = "mToolItalic";
			this.mToolItalic.Size = new System.Drawing.Size(23, 22);
			this.mToolItalic.Text = "倾斜";
			this.mToolItalic.Click += new System.EventHandler(this.OnItalicClick);
			// 
			// mToolUnderline
			// 
			this.mToolUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolUnderline.Image = ((System.Drawing.Image)(resources.GetObject("mToolUnderline.Image")));
			this.mToolUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolUnderline.Name = "mToolUnderline";
			this.mToolUnderline.Size = new System.Drawing.Size(23, 22);
			this.mToolUnderline.Text = "下划线";
			this.mToolUnderline.Click += new System.EventHandler(this.OnUnderlineClick);
			// 
			// mToolStrikeThrough
			// 
			this.mToolStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("mToolStrikeThrough.Image")));
			this.mToolStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolStrikeThrough.Name = "mToolStrikeThrough";
			this.mToolStrikeThrough.Size = new System.Drawing.Size(23, 22);
			this.mToolStrikeThrough.Text = "删除线";
			this.mToolStrikeThrough.Click += new System.EventHandler(this.OnStrikeThroughClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolFontFamily
			// 
			this.mToolFontFamily.Name = "mToolFontFamily";
			this.mToolFontFamily.Size = new System.Drawing.Size(121, 25);
			this.mToolFontFamily.SelectedIndexChanged += new System.EventHandler(this.OnFontFamilyChanged);
			// 
			// mToolFontSize
			// 
			this.mToolFontSize.Name = "mToolFontSize";
			this.mToolFontSize.Size = new System.Drawing.Size(80, 25);
			this.mToolFontSize.SelectedIndexChanged += new System.EventHandler(this.OnFontSizeChanged);
			// 
			// mToolForeColor
			// 
			this.mToolForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolForeColor.Image = ((System.Drawing.Image)(resources.GetObject("mToolForeColor.Image")));
			this.mToolForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolForeColor.Name = "mToolForeColor";
			this.mToolForeColor.Size = new System.Drawing.Size(23, 22);
			this.mToolForeColor.Text = "前景颜色";
			this.mToolForeColor.Click += new System.EventHandler(this.OnForeColorClick);
			// 
			// mToolBackColor
			// 
			this.mToolBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolBackColor.Image = ((System.Drawing.Image)(resources.GetObject("mToolBackColor.Image")));
			this.mToolBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolBackColor.Name = "mToolBackColor";
			this.mToolBackColor.Size = new System.Drawing.Size(23, 22);
			this.mToolBackColor.Text = "背景颜色";
			this.mToolBackColor.Click += new System.EventHandler(this.OnBackColorClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolAlignLeft
			// 
			this.mToolAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("mToolAlignLeft.Image")));
			this.mToolAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAlignLeft.Name = "mToolAlignLeft";
			this.mToolAlignLeft.Size = new System.Drawing.Size(23, 22);
			this.mToolAlignLeft.Text = "左对齐";
			this.mToolAlignLeft.Click += new System.EventHandler(this.OnAlignLeftClick);
			// 
			// mToolAlignCenter
			// 
			this.mToolAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("mToolAlignCenter.Image")));
			this.mToolAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAlignCenter.Name = "mToolAlignCenter";
			this.mToolAlignCenter.Size = new System.Drawing.Size(23, 22);
			this.mToolAlignCenter.Text = "居中对齐";
			this.mToolAlignCenter.Click += new System.EventHandler(this.OnAlignCenterClick);
			// 
			// mToolAlignRight
			// 
			this.mToolAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("mToolAlignRight.Image")));
			this.mToolAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAlignRight.Name = "mToolAlignRight";
			this.mToolAlignRight.Size = new System.Drawing.Size(23, 22);
			this.mToolAlignRight.Text = "右对齐";
			this.mToolAlignRight.Click += new System.EventHandler(this.OnAlignRightClick);
			// 
			// mToolAlignFull
			// 
			this.mToolAlignFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAlignFull.Image = ((System.Drawing.Image)(resources.GetObject("mToolAlignFull.Image")));
			this.mToolAlignFull.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAlignFull.Name = "mToolAlignFull";
			this.mToolAlignFull.Size = new System.Drawing.Size(23, 22);
			this.mToolAlignFull.Text = "两端对齐";
			this.mToolAlignFull.Click += new System.EventHandler(this.OnAlignFullClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolOutDent
			// 
			this.mToolOutDent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolOutDent.Image = ((System.Drawing.Image)(resources.GetObject("mToolOutDent.Image")));
			this.mToolOutDent.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolOutDent.Name = "mToolOutDent";
			this.mToolOutDent.Size = new System.Drawing.Size(23, 22);
			this.mToolOutDent.Text = "减少缩进";
			this.mToolOutDent.Click += new System.EventHandler(this.OnOutDentClick);
			// 
			// mToolInDent
			// 
			this.mToolInDent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolInDent.Image = ((System.Drawing.Image)(resources.GetObject("mToolInDent.Image")));
			this.mToolInDent.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolInDent.Name = "mToolInDent";
			this.mToolInDent.Size = new System.Drawing.Size(23, 22);
			this.mToolInDent.Text = "增加缩进";
			this.mToolInDent.Click += new System.EventHandler(this.OnInDentClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolOrderList
			// 
			this.mToolOrderList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolOrderList.Image = ((System.Drawing.Image)(resources.GetObject("mToolOrderList.Image")));
			this.mToolOrderList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolOrderList.Name = "mToolOrderList";
			this.mToolOrderList.Size = new System.Drawing.Size(23, 22);
			this.mToolOrderList.Text = "有序列表";
			this.mToolOrderList.Click += new System.EventHandler(this.OnOrderListClick);
			// 
			// mToolUnorderList
			// 
			this.mToolUnorderList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolUnorderList.Image = ((System.Drawing.Image)(resources.GetObject("mToolUnorderList.Image")));
			this.mToolUnorderList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolUnorderList.Name = "mToolUnorderList";
			this.mToolUnorderList.Size = new System.Drawing.Size(23, 22);
			this.mToolUnorderList.Text = "无序列表";
			this.mToolUnorderList.Click += new System.EventHandler(this.OnUnorderListClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolAddImage
			// 
			this.mToolAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAddImage.Image = ((System.Drawing.Image)(resources.GetObject("mToolAddImage.Image")));
			this.mToolAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAddImage.Name = "mToolAddImage";
			this.mToolAddImage.Size = new System.Drawing.Size(23, 22);
			this.mToolAddImage.Text = "添加图片";
			this.mToolAddImage.Click += new System.EventHandler(this.OnAddImageClick);
			// 
			// mToolAttachment
			// 
			this.mToolAttachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolAttachment.Image = ((System.Drawing.Image)(resources.GetObject("mToolAttachment.Image")));
			this.mToolAttachment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolAttachment.Name = "mToolAttachment";
			this.mToolAttachment.Size = new System.Drawing.Size(23, 22);
			this.mToolAttachment.Text = "添加附件";
			this.mToolAttachment.Click += new System.EventHandler(this.OnAddAttachmentClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// mToolFormatClear
			// 
			this.mToolFormatClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolFormatClear.Image = ((System.Drawing.Image)(resources.GetObject("mToolFormatClear.Image")));
			this.mToolFormatClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolFormatClear.Name = "mToolFormatClear";
			this.mToolFormatClear.Size = new System.Drawing.Size(23, 22);
			this.mToolFormatClear.Text = "清除格式";
			this.mToolFormatClear.Click += new System.EventHandler(this.OnFormatClearClick);
			// 
			// mWebBrowser
			// 
			this.mWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mWebBrowser.Location = new System.Drawing.Point(0, 25);
			this.mWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.mWebBrowser.Name = "mWebBrowser";
			this.mWebBrowser.Size = new System.Drawing.Size(711, 378);
			this.mWebBrowser.TabIndex = 1;
			this.mWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnPreviewKeyDown);
			// 
			// mToolInsertCode
			// 
			this.mToolInsertCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mToolInsertCode.Image = ((System.Drawing.Image)(resources.GetObject("mToolInsertCode.Image")));
			this.mToolInsertCode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mToolInsertCode.Name = "mToolInsertCode";
			this.mToolInsertCode.Size = new System.Drawing.Size(23, 22);
			this.mToolInsertCode.Text = "插入Code";
			this.mToolInsertCode.Click += new System.EventHandler(this.OnInsertCode);
			// 
			// NoteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mWebBrowser);
			this.Controls.Add(this.mToolBar);
			this.Name = "NoteEditor";
			this.Size = new System.Drawing.Size(711, 403);
			this.mToolBar.ResumeLayout(false);
			this.mToolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
