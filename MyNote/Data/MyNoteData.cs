/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 11:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyNote.Data
{
	[Serializable]
	/// <summary>
	/// Description of MyNoteData.
	/// </summary>
	public class MyNoteData
	{
		/// <summary>
		/// 打开的笔记本
		/// </summary>
		public string opened_book = string.Empty;
		public string current_selected_node_uid = string.Empty;
		public int last_frame_width = 0;
		public int last_frame_height = 0;

		public MyNoteData()
		{
		}
		
	}
}
