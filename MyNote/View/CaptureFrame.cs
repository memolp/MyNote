/*
 * User: 覃贵锋
 * Date: 2021/10/22
 * Time: 10:58
 * 
 * 截图工具
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNote.View
{
	/// <summary>
	/// 截图工具主界面，没有边框，直接截当前屏幕图 - 一定要支持多屏幕
	/// </summary>
	public partial class CaptureFrame : Form
	{
		private static CaptureFrame _instance = null;
		public static CaptureFrame Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new CaptureFrame();
				}
				return _instance;
			}
		}
		
		public CaptureFrame()
		{
			InitializeComponent();
			// 设置Form的样式和位置
			this.FormBorderStyle = FormBorderStyle.None;  //无边
			this.StartPosition = FormStartPosition.Manual; // 启动位置自定义
			this.TopMost = true;
			this.ShowInTaskbar = false;
			this.ShowIcon = false;
		}
		
		public void ShowCapture()
		{
			// 遍历当前的屏幕列表=因为可能存在多个屏幕
			foreach (Screen screen in Screen.AllScreens) 
			{
				// 当前鼠标所在的那个屏幕
				if(screen.Bounds.Contains(Control.MousePosition))
				{
					this.Location = screen.Bounds.Location;
					this.Size = screen.Bounds.Size;
					this.current_screen = this.GetScreen(screen.Bounds.Size);
					this.Show();
					return;
				}
			}
		}
		
		private Bitmap current_screen = null;
		private Bitmap GetScreen(Size size)
		{
			Bitmap bmp = new Bitmap(size.Width, size.Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
			}
			return bmp;
		}
		
		void OnFormLoadEvt(object sender, EventArgs e)
		{
			
		}
		
		void OnFormDeactivateEvt(object sender, EventArgs e)
		{
			this.Hide();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if(this.current_screen != null)
			{
				g.DrawImage(this.current_screen, 0, 0);
			}
			base.OnPaint(e);
		}
		
	}
}
