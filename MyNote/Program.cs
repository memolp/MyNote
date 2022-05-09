/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/16
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyNote
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// 检查是否已经运行了程序
			Process currentProcess = Process.GetCurrentProcess();
            var process_list = Process.GetProcessesByName(currentProcess.ProcessName);
            if(process_list != null && process_list.Length > 1)
            {
            	MessageBox.Show("程序已运行");
                return;
            }
			Application.Run(new MainForm());
		}
		
	}
}
