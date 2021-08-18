/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 11:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace MyNote.Data
{
	/// <summary>
	/// Description of Const.
	/// </summary>
	public static class Const
	{
		/// <summary>
		/// 记录笔记本根路径
		/// </summary>
		public static string NOTE_BOOK_PATH = "NoteBooks";
		/// <summary>
		/// 笔记本文件的后缀
		/// </summary>
		public static string NOTE_BOOK_EXT = ".mnote";
		/// <summary>
		/// 笔记本节点内容存储文件后缀
		/// </summary>
		public static string NOTE_BOOK_NODE_EXT = ".mnode";
		
		static string NOTE_RUNTIME_DATA_ = string.Empty;
		public static string NOTE_RUNTIME_DATA
		{
			get
			{
				if(NOTE_RUNTIME_DATA_ == string.Empty)
					NOTE_RUNTIME_DATA_ = Path.Combine(Application.StartupPath, "MyData");
				return NOTE_RUNTIME_DATA_;
			}
		}
	}
}
