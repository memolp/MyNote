/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/9/17
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyNote.View
{
	partial class CodeDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label 选择高亮的语言;
		private System.Windows.Forms.ComboBox mLangCBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox mCodeData;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeDialog));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.选择高亮的语言 = new System.Windows.Forms.Label();
			this.mLangCBox = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.mCodeData = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.选择高亮的语言, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.mLangCBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.button1, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.mCodeData, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 335);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// 选择高亮的语言
			// 
			this.选择高亮的语言.Dock = System.Windows.Forms.DockStyle.Fill;
			this.选择高亮的语言.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.选择高亮的语言.Location = new System.Drawing.Point(3, 0);
			this.选择高亮的语言.Name = "选择高亮的语言";
			this.选择高亮的语言.Size = new System.Drawing.Size(94, 20);
			this.选择高亮的语言.TabIndex = 0;
			this.选择高亮的语言.Text = "选择高亮的语言";
			this.选择高亮的语言.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mLangCBox
			// 
			this.mLangCBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mLangCBox.FormattingEnabled = true;
			this.mLangCBox.Items.AddRange(new object[] {
			"markup",
			"html",
			"xml",
			"svg",
			"mathml",
			"ssml",
			"atom",
			"rss",
			"css",
			"clike",
			"c",
			"csharp",
			"cpp",
			"java",
			"python",
			"lua",
			"javascript"});
			this.mLangCBox.Location = new System.Drawing.Point(103, 3);
			this.mLangCBox.Name = "mLangCBox";
			this.mLangCBox.Size = new System.Drawing.Size(359, 20);
			this.mLangCBox.TabIndex = 1;
			this.mLangCBox.TabStop = false;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.Location = new System.Drawing.Point(387, 309);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.TabStop = false;
			this.button1.Text = "插入代码";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnCreateCodeEvent);
			// 
			// mCodeData
			// 
			this.mCodeData.AcceptsTab = true;
			this.tableLayoutPanel1.SetColumnSpan(this.mCodeData, 2);
			this.mCodeData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mCodeData.Location = new System.Drawing.Point(3, 23);
			this.mCodeData.Name = "mCodeData";
			this.mCodeData.Size = new System.Drawing.Size(459, 279);
			this.mCodeData.TabIndex = 3;
			this.mCodeData.TabStop = false;
			this.mCodeData.Text = "";
			// 
			// CodeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 335);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CodeDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "代码编辑";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
