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
		/// 笔记本文件的后缀
		/// </summary>
		public static string NOTE_BOOK_EXT = ".mnote";
		/// <summary>
		/// 笔记本节点内容存储文件后缀
		/// </summary>
		public static string NOTE_BOOK_NODE_EXT = ".mnode";
		/// <summary>
		/// 笔记本软件自身的加密密钥-不要再修改，否则旧的笔记本打不开。
		/// </summary>
		public static string NOTE_APP_KEY = "xJJMGt4VeTpJFD42rJMjQ1GkC1qQ9Wmc3L8dARpt";
		
		public static byte[] CRYPT_HEAD = {95, 81, 73, 78, 71, 70, 75};
		
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
