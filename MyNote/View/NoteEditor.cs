/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 17:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Note编辑器，支持富文本操作
	/// </summary>
	public partial class NoteEditor : UserControl
	{
		public delegate void NoteEditorSaveHandler(object sender, object node);
		public NoteEditorSaveHandler onEditorSave;
		NoteBookNode mCurrentNode;
		string mCurrentNodeFilePath;
		/// <summary>
		/// 创建Note编辑器
		/// </summary>
		public NoteEditor()
		{
			// 初始化组建
			InitializeComponent();
			// 初始化控件属性
			OnInitWidgets();
		}
	
		/// <summary>
		/// 初始化组件
		/// </summary>
		void OnInitWidgets()
		{
			toolbarUpdate = false;
			// 字体库
			foreach (FontFamily family in FontFamily.Families)
            {
				mToolFontFamily.Items.Add(family.Name);
            }
			// 字号
			mToolFontSize.Items.AddRange(new string[]{"8","9","10","11","12","13","14","15","16","17","18","19","20","32","64"});
			
			// 设置属性
			mRichTextBox.Click += OnDocumentClick;
			mRichTextBox.GotFocus += OnDocumentFocusing;
			mRichTextBox.SelectionHangingIndent = 20;
			mRichTextBox.SelectionRightIndent = 20;
			mRichTextBox.BulletIndent = 10;
			
		}

		public void LoadNoteBookNode(NoteBookNode bkNode, string filepath)
		{
			mCurrentNode = bkNode;
			mCurrentNodeFilePath = filepath;
			mNoteTile.Text = string.Format("{0} - ({1})", bkNode.NodeName, "修改时间: 2021/08/24 16:00:00");
			if(File.Exists(filepath))
			{
				mRichTextBox.LoadFile(filepath);
			}else
			{
				mRichTextBox.Clear();
			}
		}

		public void SaveNoteBookNode(NoteBookNode bkNode)
		{
			// 安全检查
			if(bkNode.NodeDocumentUID.Equals(mCurrentNode.NodeDocumentUID))
			{
				mRichTextBox.SaveFile(mCurrentNodeFilePath);
			}
		}
		/// <summary>
		/// 工具栏更新标记-方式递归式更新
		/// </summary>
		private bool toolbarUpdate{get;set;}
		/// <summary>
		/// 刷新工具栏状态
		/// </summary>
		void RefreshToolBar()
		{
			if(toolbarUpdate) return;
			toolbarUpdate = true;
			Font select_font = mRichTextBox.SelectionFont;
			if(select_font != null)
			{
				mToolFontFamily.Text = select_font.Name;
				mToolFontSize.Text = select_font.Size.ToString();
				// 文字的加粗倾斜等状态
				mToolBold.Checked = select_font.Bold;
	            mToolItalic.Checked = select_font.Italic;
	            mToolUnderline.Checked = select_font.Underline;
	            mToolStrikeThrough.Checked = select_font.Strikeout;
			}
			// 对齐的状态
			mToolAlignLeft.Checked = mRichTextBox.SelectionAlignment == HorizontalAlignment.Left;
			mToolAlignCenter.Checked = mRichTextBox.SelectionAlignment == HorizontalAlignment.Center;
            mToolAlignRight.Checked = mRichTextBox.SelectionAlignment == HorizontalAlignment.Right;
			toolbarUpdate = false;
		}
		/// <summary>
		/// 加粗
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnBoldClick(object sender, EventArgs e)
		{
			Font old_font = mRichTextBox.SelectionFont;
			Font new_font = null;
			if(old_font.Bold)
			{
				new_font = new Font(old_font, old_font.Style ^ FontStyle.Bold);
			}else
			{
				new_font = new Font(old_font, old_font.Style | FontStyle.Bold);
			}
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 斜体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnItalicClick(object sender, EventArgs e)
		{
			Font old_font = mRichTextBox.SelectionFont;
			Font new_font = null;
			if(old_font.Italic)
			{
				new_font = new Font(old_font, old_font.Style ^ FontStyle.Italic);
			}else
			{
				new_font = new Font(old_font, old_font.Style | FontStyle.Italic);
			}
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 下划线
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnUnderlineClick(object sender, EventArgs e)
		{
			Font old_font = mRichTextBox.SelectionFont;
			Font new_font = null;
			if(old_font.Underline)
			{
				new_font = new Font(old_font, old_font.Style ^ FontStyle.Underline);
			}else
			{
				new_font = new Font(old_font, old_font.Style | FontStyle.Underline);
			}
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 删除线
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnStrikeThroughClick(object sender, EventArgs e)
		{
			Font old_font = mRichTextBox.SelectionFont;
			Font new_font = null;
			if(old_font.Strikeout)
			{
				new_font = new Font(old_font, old_font.Style ^ FontStyle.Strikeout);
			}else
			{
				new_font = new Font(old_font, old_font.Style | FontStyle.Strikeout);
			}
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 字体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFontFamilyChanged(object sender, EventArgs e)
		{
			Font old_font = mRichTextBox.SelectionFont;
			if(old_font == null) return;
			Font new_font = new Font(mToolFontFamily.Text, old_font.Size, old_font.Style);
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 字号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFontSizeChanged(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(mToolFontSize.Text)) return;
			int size = int.Parse(mToolFontSize.Text);
			Font old_font = mRichTextBox.SelectionFont;
			if(old_font == null) return;
			Font new_font = new Font(old_font.Name, size, old_font.Style);
			mRichTextBox.SelectionFont = new_font;
			RefreshToolBar();
		}
		/// <summary>
		/// 前景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnForeColorClick(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = mRichTextBox.SelectionColor;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
            	mRichTextBox.SelectionColor = dialog.Color;
            }
		}
		/// <summary>
		/// 背景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnBackColorClick(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = mRichTextBox.SelectionBackColor;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
            	mRichTextBox.SelectionBackColor = dialog.Color;
            }
		}
		/// <summary>
		/// 这个只能将当前行底色修改，不能整行，只有有文字的部分。
		/// </summary>
		public void MarkSingleLine()
		 {
		     int firstCharOfLineIndex = mRichTextBox.GetFirstCharIndexOfCurrentLine();
		     int currentLine = mRichTextBox.GetLineFromCharIndex(firstCharOfLineIndex);
		     string currentlinetext = mRichTextBox.Lines[currentLine];
		     mRichTextBox.Select(firstCharOfLineIndex, currentlinetext.Length);
		     mRichTextBox.SelectionBackColor = Color.AliceBlue;
		     mRichTextBox.Select(0, 0);
		 }
		/// <summary>
		/// 左对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignLeftClick(object sender, EventArgs e)
		{
			mRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
			RefreshToolBar();
		}
		/// <summary>
		/// 居中对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignCenterClick(object sender, EventArgs e)
		{
			mRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
			RefreshToolBar();
		}
		/// <summary>
		/// 右对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignRightClick(object sender, EventArgs e)
		{
			mRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
			RefreshToolBar();
		}
		/// <summary>
		/// 减少缩进
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnOutDentClick(object sender, EventArgs e)
		{
			if(mRichTextBox.SelectionIndent >= 20)
				mRichTextBox.SelectionIndent -= 20;
		}
		/// <summary>
		/// 增加缩进
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnInDentClick(object sender, EventArgs e)
		{
			mRichTextBox.SelectionIndent += 20;
		}
		/// <summary>
		/// 插入数字编号列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnOrderListClick(object sender, EventArgs e)
		{
			mRichTextBox.CustomBullet = !mRichTextBox.CustomBullet;
			if(mRichTextBox.CustomBullet)
			{
				mRichTextBox.BulletType = RichTextBoxEx.AdvRichTextBulletType.Number;
				mRichTextBox.BulletStyle = RichTextBoxEx.AdvRichTextBulletStyle.Period;
			}else
			{
				mRichTextBox.BulletType = RichTextBoxEx.AdvRichTextBulletType.Normal;
				mRichTextBox.BulletStyle = RichTextBoxEx.AdvRichTextBulletStyle.NoNumber;
			}
		}
		/// <summary>
		/// 插入无序列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnUnorderListClick(object sender, EventArgs e)
		{
			mRichTextBox.CustomBullet = !mRichTextBox.CustomBullet;
			if(mRichTextBox.CustomBullet)
			{
				mRichTextBox.BulletType = RichTextBoxEx.AdvRichTextBulletType.Normal;
				mRichTextBox.BulletStyle = RichTextBoxEx.AdvRichTextBulletStyle.Plain;
			}else
			{
				mRichTextBox.BulletType = RichTextBoxEx.AdvRichTextBulletType.Normal;
				mRichTextBox.BulletStyle = RichTextBoxEx.AdvRichTextBulletStyle.NoNumber;
			}
		}
		
		void OnInsertCode(object sender, EventArgs e)
		{
			MarkDownInputDialog dlg = new MarkDownInputDialog();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				string data = dlg.GetMk2HtmlContent();
				mRichTextBox.AppendText(data);
			}
			
		}
		/// <summary>
		/// 清除格式
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFormatClearClick(object sender, EventArgs e)
		{
			// 前景色和字体默认设置编辑器默认的，但是背景色可能会被设置。
			mRichTextBox.SelectionFont = mRichTextBox.Font;
			mRichTextBox.SelectionColor = mRichTextBox.ForeColor;
			mRichTextBox.SelectionBackColor = Color.White; 
		}
		/// <summary>
		/// 焦点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDocumentFocusing(object sender, EventArgs e)
		{
			RefreshToolBar();
		}
		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDocumentClick(object sender, EventArgs e)
		{
			RefreshToolBar();
		}
		
		void OnKeyDown(object sender, KeyEventArgs e)
		{
			if(e.Control)
			{
				if(e.KeyCode == Keys.B) // Bold
				{
					this.OnBoldClick(sender, null);
					return;
				}
			}
		}
	}
}
