/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 17:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

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
		/// 晚点从外面全部移进来
		/// </summary>
		/// <param name="info"></param>
		/// <param name="title"></param>
		public void SetDocumentInfo(string title,string info)
		{
			mDocumentTitleLabel.Text = title;
			mDocumentInfoLabel.Text = info;
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
			// 设置IE版本为11
			SetWebBrowserFeatures(11);
			mWebBrowser.Navigate("about:blank");
			toolbarUpdate = false;
			// 字体库
			foreach (FontFamily family in FontFamily.Families)
            {
				mToolFontFamily.Items.Add(family.Name);
            }
			// 字号
			mToolFontSize.Items.AddRange(FontSize.All.ToArray());
			string launch_path = Path.GetDirectoryName(Application.ExecutablePath).Replace("\\","/");
			string raw_html = this.HTMLTemplate.Replace("PRISM_ABS_PATH", launch_path);
			
			// 设置属性
			mWebBrowser.DocumentText = raw_html;
			//mWebBrowser.Document.ExecCommand("EditMode", false, null);
            //mWebBrowser.Document.ExecCommand("LiveResize", false, null);
            mWebBrowser.Document.Focusing += OnDocumentFocusing;
            mWebBrowser.Document.Click += OnDocumentClick;
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
				if(font_size == null || font_size is DBNull)
				{
					
				}else
				{
					int sb = Convert.ToInt32(font_size);
					mToolFontSize.SelectedItem = FontSize.Find(sb);
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
			/*MarkDownInputDialog dlg = new MarkDownInputDialog();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				string data = dlg.GetMk2HtmlContent();
				mWebBrowser.Document.InvokeScript("js_append_html", new string[1]{data});
			}*/
			CodeDialog dlg = new CodeDialog();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				string data = dlg.GetCodeContent();
				string lang = dlg.GetCodeLang();
				mWebBrowser.Document.InvokeScript("js_append_code", new string[]{data, lang});
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
		
		bool isFirstKeyDown = true;
		void OnKeyDown(PreviewKeyDownEventArgs e)
		{
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
				// 先简单支持RTF到Image
				else if(Clipboard.ContainsData(DataFormats.Rtf))
				{
					Image img = RTFDataToImage((string)Clipboard.GetData(DataFormats.Rtf));
					if(img != null)
					{
						string base64 = this.ImageToBase64(img, ImageFormat.Jpeg);
						// 部分粘贴不支持
						mWebBrowser.Document.ExecCommand("InsertImage", false, base64);
						return;
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
			//Tab缩进功能
			if(e.KeyCode == Keys.Tab)
			{
				if(e.Shift && !e.Control && !e.Alt)
				{
					this.OnOutDentClick(null, null);
					return;
				}
				if(!e.Shift && !e.Control && !e.Alt)
				{
					this.OnInDentClick(null, null);
					return;
				}
			}
			RefreshToolBar();
		}
		/// <summary>
		/// 页面内部使用快捷键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(isFirstKeyDown)
			{
				OnKeyDown(e);
			}
			isFirstKeyDown = !isFirstKeyDown;
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
			
			if(e.CtrlKeyPressed)
			{
				HtmlElement ele = mWebBrowser.Document.GetElementFromPoint(e.MousePosition);
				if(ele != null)
				{
					string url = ele.InnerText;
					if(url.StartsWith("http"))
					{
						Process p = new Process();
	                    p.StartInfo.FileName = "cmd.exe";
	                    p.StartInfo.UseShellExecute = false;    //不使用shell启动
	                    p.StartInfo.RedirectStandardInput = true;//喊cmd接受标准输入
	                    p.StartInfo.RedirectStandardOutput = false;//不想听cmd讲话所以不要他输出
	                    p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
	                    p.StartInfo.CreateNoWindow = true;//不显示窗口
	                    p.Start();
	
	                    //向cmd窗口发送输入信息 后面的&exit告诉cmd运行好之后就退出
	                    p.StandardInput.WriteLine("start " + url + "&exit");
	                    p.StandardInput.AutoFlush = true;
	                    p.WaitForExit();//等待程序执行完退出进程
	                    p.Close();
					}
				}
			}
		}
		
		void OnInsertEnterEvent(object sender, EventArgs e)
		{
			mWebBrowser.Document.InvokeScript("js_append_html", new string[]{"<br>"});
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
			if(string.IsNullOrEmpty(rtf_text)) return null;
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
                        /*
                         *  Browser font size 1 -> Safari: 10 px (Actual font size: 8 px)
							Browser font size 2 -> Safari: 13 px (Actual font size: 10 px)
							Browser font size 3 -> Safari: 16 px (Actual font size: 12 px)
							Browser font size 4 -> Safari: 18 px (Actual font size: 14 px)
							Browser font size 5 -> Safari: 24 px (Actual font size: 18 px)
							Browser font size 6 -> Safari: 32 px (Actual font size: 24 px)
							Browser font size 7 -> Safari: 48 px (Actual font size: 36 px)
                         */
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
		#region 设置内核版本
		/// <summary>  
        /// 修改注册表信息来兼容当前程序  
        ///   
        /// </summary>  
        static void SetWebBrowserFeatures(int ieVersion)
        {
            //获取程序及名称  
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //得到浏览器的模式的值  
            UInt32 ieMode = GeoEmulationModee(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            //设置浏览器对应用程序（appName）以什么模式（ieMode）运行  
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            // enable the features which are "On" for the full Internet Explorer browser  
            //不晓得设置有什么用  
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);
        }
        /// <summary>  
        /// 获取浏览器的版本  
        /// </summary>  
        /// <returns></returns>  
        static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            //如果小于9
            if (browserVersion < 9)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }
        /// <summary>  
        /// 通过版本得到浏览器模式的值  
        /// </summary>  
        /// <param name="browserVersion"></param>  
        /// <returns></returns>  
        static UInt32 GeoEmulationModee(int browserVersion)
        {
            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode.   
            switch (browserVersion)
            {
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                      
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.  
                    break;
                case 11:
                    mode = 11000; // Internet Explorer 11  
                    break;
            }
            return mode;
        }
		#endregion		
	}
}
