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


namespace MyNote.View
{
	/// <summary>
	/// Description of NoteEditor.
	/// </summary>
	public partial class NoteEditor : UserControl
	{
		public delegate void NoteEditorSaveHandler(object sender, object node);
		/// <summary>
		/// Base64格式的头
		/// </summary>
		const string IMG_BASE64_HEAD = "data:image";
		/// <summary>
		/// 默认的HTML魔板
		/// </summary>
		string Default_HTML_TEMP = string.Empty;
		public NoteEditorSaveHandler onEditorSave;
		/// <summary>
		/// 获取默认的HTML模板
		/// </summary>
		public string HTMLTemplate
		{
			get
			{
				if(Default_HTML_TEMP == string.Empty)
				{
					Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream("my_note_html");
        			byte[] bs = new byte[sm.Length];
         			sm.Read(bs, 0, (int)sm.Length);
         			sm.Close();
         			UTF8Encoding con = new UTF8Encoding();
         			Default_HTML_TEMP = con.GetString(bs);
				}
				return Default_HTML_TEMP;
			}
		}
		/// <summary>
		/// 创建比较编辑器
		/// </summary>
		public NoteEditor()
		{
			//
			InitializeComponent();
			//
			OnInitWidgets();
		}
		/// <summary>
		/// 设置笔记内容-将调用js方法设置
		/// </summary>
		/// <param name="data"></param>
		public void SetContent(string data)
		{
			mWebBrowser.Document.InvokeScript("js_set_content", new string[1]{data});
		}
		/// <summary>
		/// 获取笔记内容-将调用js方法获取内容
		/// </summary>
		/// <returns></returns>
		public string GetContent()
		{
			DocumentImagesToBase64();// 在获取文档存储前也检查一次
			var data = mWebBrowser.Document.InvokeScript("js_get_content");
			return data.ToString();
		}
		/// <summary>
		/// 内容是否改变
		/// </summary>
		/// <returns></returns>
		public bool IsContentChange()
		{
			var data = (bool)mWebBrowser.Document.InvokeScript("js_is_content_change");
			return data;
		}
		/// <summary>
		/// 设置内容已经存储了
		/// </summary>
		public void SetContentSaved()
		{
			mWebBrowser.Document.InvokeScript("js_up_content_sise");
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
			mToolFontSize.Items.AddRange(FontSize.All.ToArray());
			// 设置属性
			mWebBrowser.DocumentText = this.HTMLTemplate;
			//mWebBrowser.Document.ExecCommand("EditMode", false, null);
            //mWebBrowser.Document.ExecCommand("LiveResize", false, null);
            mWebBrowser.Document.Focusing += OnDocumentFocusing;
            mWebBrowser.Document.Click += OnDocumentClick;

            mWebBrowser.AllowNavigation = false;            // 禁止内部导航
            mWebBrowser.AllowWebBrowserDrop = false;        // 拖文件进来
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
			try 
			{
				toolbarUpdate = true;
				mshtml.IHTMLDocument2 document = (mshtml.IHTMLDocument2)mWebBrowser.Document.DomDocument;
				var fontName = document.queryCommandValue("FontName");
				if(fontName != null)
				{
					mToolFontFamily.Text = fontName.ToString();
				}
				// 字体这个有点问题
				var font_size = document.queryCommandValue("FontSize");
				if(font_size != null && font_size is int)
				{
					mToolFontSize.SelectedItem = FontSize.Find((int)font_size);
				}
	            // 文字的加粗倾斜等状态
				mToolBold.Checked = document.queryCommandState("Bold");
	            mToolItalic.Checked = document.queryCommandState("Italic");
	            mToolUnderline.Checked = document.queryCommandState("Underline");
	            mToolStrikeThrough.Checked = document.queryCommandState("strikeThrough");
				// 对齐的状态
	            mToolAlignLeft.Checked = document.queryCommandState("JustifyLeft");
	            mToolAlignCenter.Checked = document.queryCommandState("JustifyCenter");
	            mToolAlignRight.Checked = document.queryCommandState("JustifyRight");
	            mToolAlignFull.Checked = document.queryCommandState("JustifyFull");
			} catch (Exception e) 
			{
				throw e;
			}finally
			{
				toolbarUpdate = false;
			}
		}
		/// <summary>
		/// 加粗
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnBoldClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("Bold", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 斜体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnItalicClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("Italic", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 下划线
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnUnderlineClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("Underline", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 删除线
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnStrikeThroughClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("strikeThrough", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 字体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFontFamilyChanged(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("FontName", false, mToolFontFamily.Text);
			RefreshToolBar();
		}
		/// <summary>
		/// 字号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFontSizeChanged(object sender, EventArgs e)
		{
			int size = (mToolFontSize.SelectedItem == null) ? 1 : (mToolFontSize.SelectedItem as FontSize).Value;
			mWebBrowser.Document.ExecCommand("FontSize", false, size);
			RefreshToolBar();
		}
		/// <summary>
		/// 前景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnForeColorClick(object sender, EventArgs e)
		{
			int fontcolor = (int)((mshtml.IHTMLDocument2)mWebBrowser.Document.DomDocument).queryCommandValue("ForeColor");
			ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.FromArgb(0xff, fontcolor & 0xff, (fontcolor >> 8) & 0xff, (fontcolor >> 16) & 0xff);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = dialog.Color.Name;
                if (!dialog.Color.IsNamedColor)
                {
                    color = "#" + color.Remove(0, 2);
                }

                mWebBrowser.Document.ExecCommand("ForeColor", false, color);
            }
		}
		/// <summary>
		/// 背景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnBackColorClick(object sender, EventArgs e)
		{
			int backcolor = (int)((mshtml.IHTMLDocument2)mWebBrowser.Document.DomDocument).queryCommandValue("BackColor");
			ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.FromArgb(0xff, backcolor & 0xff, (backcolor >> 8) & 0xff, (backcolor >> 16) & 0xff);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = dialog.Color.Name;
                if (!dialog.Color.IsNamedColor)
                {
                    color = "#" + color.Remove(0, 2);
                }

                mWebBrowser.Document.ExecCommand("BackColor", false, color);
            }
		}
		/// <summary>
		/// 左对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignLeftClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("JustifyLeft", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 居中对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignCenterClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("JustifyCenter", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 右对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignRightClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("JustifyRight", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 两端对齐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAlignFullClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("JustifyFull", false, null);
			RefreshToolBar();
		}
		/// <summary>
		/// 减少缩进
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnOutDentClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("Outdent", false, null);
		}
		/// <summary>
		/// 增加缩进
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnInDentClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("Indent", false, null);
		}
		/// <summary>
		/// 插入数字编号列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnOrderListClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("InsertOrderedList", false, null);
		}
		/// <summary>
		/// 插入无序列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnUnorderListClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("InsertUnorderedList", false, null);
		}
		
		void OnInsertCode(object sender, EventArgs e)
		{
			MarkDownInputDialog dlg = new MarkDownInputDialog();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				string data = dlg.GetMk2HtmlContent();
				mWebBrowser.Document.InvokeScript("js_append_html", new string[1]{data});
			}
			
		}
		/// <summary>
		/// 插入图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAddImageClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("InsertImage", true, null);
			// 每次在调用插入图片后，主动检查一次
			DocumentImagesToBase64();
		}
		/// <summary>
		/// 插入附件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnAddAttachmentClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("createLink", true, null);
		}
		/// <summary>
		/// 清除格式
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnFormatClearClick(object sender, EventArgs e)
		{
			mWebBrowser.Document.ExecCommand("removeFormat", false, null);
		}
		/// <summary>
		/// 页面内部使用快捷键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.IsInputKey)
			{
				return;
			}
			// 粘贴键
			if(e.Control && e.KeyCode == Keys.V)
			{
				IDataObject data = Clipboard.GetDataObject();
				if(Clipboard.ContainsImage()) // 仅支持图片
				{
					var img = Clipboard.GetImage();//(Bitmap)data.GetData(DataFormats.Bitmap);
					if(img != null)
					{
						ImageFormat fmt = img.RawFormat;
						if(fmt.Equals(ImageFormat.MemoryBmp))
						{
							fmt = ImageFormat.Png;
						}
						string base64 = this.ImageToBase64(img, fmt);
						// 部分粘贴不支持
						mWebBrowser.Document.ExecCommand("InsertImage", false, base64);
						//SendKeys.SendWait("{ENTER}"); // 这种方式不能百分百粘贴成功
						// 以下两种方式都可以，重设图片比清空剪贴板可能更符合行为习惯
						Clipboard.SetImage(img); // 
						//Clipboard.Clear();
					}
				}
			}
			// 快捷键Ctrl+S 保存
			if(e.Control && e.KeyCode == Keys.S)
			{
				if(onEditorSave != null)
				{
					this.onEditorSave(this, null);
				}
				return;
			}
			RefreshToolBar();
		}
		/// <summary>
		/// 焦点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDocumentFocusing(object sender, HtmlElementEventArgs e)
		{
			RefreshToolBar();
		}
		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDocumentClick(object sender, HtmlElementEventArgs e)
		{
			RefreshToolBar();
		}
		
		/// <summary>
		/// 将文档中所有的URL图片转成base64存储
		/// </summary>
		void DocumentImagesToBase64()
		{
			foreach (HtmlElement element in mWebBrowser.Document.Images) 
			{
				string url = element.GetAttribute("src");
				if(url.StartsWith(IMG_BASE64_HEAD)) continue; //已经是Base64的不处理
				// 把所有本地图片都转base64，网络图片也不转换
				if(url.StartsWith("file:"))
				{
					string base64 = GetBase64FromImage(url);
					element.SetAttribute("src", base64);
				}
			}
		}
		/// <summary>
		/// 将图片URL转成Base64
		/// </summary>
		/// <param name="imagefile"></param>
		/// <returns></returns>
		string GetBase64FromImage(string imagefile)
        {
            Uri url = new Uri(imagefile);
            Image img = Image.FromFile(url.LocalPath);
            return ImageToBase64(img);
        }
		/// <summary>
		/// 将图片转Base64
		/// </summary>
		/// <param name="bmp"></param>
		/// <returns></returns>
		public string ImageToBase64(Image bmp)
		{
			return ImageToBase64(bmp, bmp.RawFormat);
		}
		public string ImageToBase64(Image bmp, ImageFormat format)
		{
			string strbaser64 = "";
			using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, format);
                strbaser64 = Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks);
                string base64_h = string.Format("data:image/{0};base64,", GetImageFormat(format));
                strbaser64 = strbaser64.Insert(0, base64_h);
            }
            return strbaser64;
		}
		/// <summary>
		/// 根据图片格式获取后缀
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string GetImageFormat(ImageFormat format)
		{
			if (format.Equals(ImageFormat.MemoryBmp)) {
				return "bmp";
			}
			if (format.Equals(ImageFormat.Bmp)) {
				return "bmp";
			}
			if (format.Equals(ImageFormat.Emf)) {
				return "emf";
			}
			if (format.Equals(ImageFormat.Wmf)) {
				return "wmf";
			}
			if (format.Equals(ImageFormat.Gif)) {
				return "gif";
			}
			if (format.Equals(ImageFormat.Jpeg)) {
				return "jpeg";
			}
			if (format.Equals(ImageFormat.Png)) {
				return "png";
			}
			if (format.Equals(ImageFormat.Tiff)) {
				return "tiff";
			}
			if (format.Equals(ImageFormat.Exif)) {
				return "exif";
			}
			if (format.Equals(ImageFormat.Icon)) {
				return "icon";
			}
			return "png";
		}
		
		Image RTFDataToImage(string rtf_text)
		{
			// 读取全部的图片数据列表
			IList<string> _ImageList = new List<string>();
			while (true)
			{
				int _Index = rtf_text.IndexOf("pichgoal");
				if (_Index == -1) break;
				rtf_text = rtf_text.Remove(0, _Index + 8);

				_Index = rtf_text.IndexOf("\r\n");
				
				rtf_text = rtf_text.Remove(0, _Index);
				
				_Index = rtf_text.IndexOf("}");
				_ImageList.Add(rtf_text.Substring(0, _Index).Replace("\r\n", ""));

				rtf_text = rtf_text.Remove(0, _Index);
			}
			Byte[] buffer = null;
			for (int i = 0; i != _ImageList.Count; i++)
			{
				int _Count = _ImageList[i].Length / 2;
				buffer = new Byte[_ImageList[i].Length/2];

				for (int z = 0; z != _Count; z++)
				{
					string _TempText = _ImageList[i][z * 2].ToString() + _ImageList[i][(z * 2) + 1].ToString();
					buffer[z] = Convert.ToByte(_TempText, 16);
				}
			}
			MemoryStream ms = new MemoryStream(buffer);
			return Image.FromStream(ms);
		}
		
		#region 字号类
		/// <summary>
		/// 字号定义类
		/// </summary>
		class FontSize
        {
            static List<FontSize> allFontSize = null;
            public static List<FontSize> All
            {
                get
                {
                    if (allFontSize == null)
                    {
                        allFontSize = new List<FontSize>();
                        allFontSize.Add(new FontSize(8, 1));
                        allFontSize.Add(new FontSize(10, 2));
                        allFontSize.Add(new FontSize(12, 3));
                        allFontSize.Add(new FontSize(14, 4));
                        allFontSize.Add(new FontSize(18, 5));
                        allFontSize.Add(new FontSize(24, 6));
                        allFontSize.Add(new FontSize(36, 7));
                    }

                    return allFontSize;
                }
            }

            public static FontSize Find(int value)
            {
                if (value < 1)
                {
                    return All[2];
                }

                if (value > 7)
                {
                    return All[6];
                }

                return All[value - 1];
            }

            FontSize(int display, int value)
            {
                displaySize = display;
                valueSize = value;
            }

            private int valueSize;
            public int Value
            {
                get
                {
                    return valueSize;
                }
            }

            private int displaySize;
            public int Display
            {
                get
                {
                    return displaySize;
                }
            }

            public override string ToString()
            {
                return displaySize.ToString();
            }
        }
		#endregion		
		#region
		/// <summary>
		/// 定义IE版本的枚举
		/// </summary>
		class IeVersion
		{
			public const int F_ie10 = 0x2711;	//10001 (0x2711) Internet Explorer 10。网页以IE 10的标准模式展现，页面!DOCTYPE无效
			public const int S_e10 = 0x2710; 	//10000 (0x02710) Internet Explorer 10。在IE 10标准模式中按照网页上!DOCTYPE指令来显示网页。Internet Explorer 10 默认值。
			public const int F_ie9 = 0x270f;	//9999 (0x270F) Windows Internet Explorer 9. 强制IE9显示，忽略!DOCTYPE指令
			public const int S_ie9 = 0x2328;	//9000 (0x2328) Internet Explorer 9. Internet Explorer 9默认值，在IE9标准模式中按照网页上!DOCTYPE指令来显示网页。
			public const int F_ie8 = 0x22B8;	//8888 (0x22B8) Internet Explorer 8，强制IE8标准模式显示，忽略!DOCTYPE指令
			public const int S_ie8 = 0x1F40;	//8000 (0x1F40) Internet Explorer 8默认设置，在IE8标准模式中按照网页上!DOCTYPE指令展示网页
			public const int S_ie7 = 0x1B58;	//7000 (0x1B58) 使用WebBrowser Control控件的应用程序所使用的默认值，在IE7标准模式中按照网页上!DOCTYPE指令来展示网页
		}
		#endregion
	}
}
