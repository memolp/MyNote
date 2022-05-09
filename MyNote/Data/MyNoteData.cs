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
	/// 笔记本运行时配置，这个是全局的配置用于对应用程序设置操作
	/// </summary>
	public class MyNoteData
	{
		/// <summary>
		/// 打开的笔记本
		/// </summary>
		public string opened_book = string.Empty;
		/// <summary>
		/// 【废弃，当前选中的节点应该在notebook中存储】
		/// </summary>
		public string current_selected_node_uid = string.Empty;
		/// <summary>
		/// 记录应用程序最后退出时的大小
		/// </summary>
		public int last_frame_width = 0;
		public int last_frame_height = 0;
		
		/// <summary>
		/// 是否开启关闭后不退出程序，而是托盘
		/// </summary>
		[OptionalFieldAttribute]
		public bool close_on_notify_icon = false;
		
		/// <summary>
		/// 是否注册截屏功能
		/// </summary>
		[OptionalFieldAttribute]
		public bool screen_capture = false;
		
		/// <summary>
		/// 是否自动锁定窗口
		/// </summary>
		[OptionalFieldAttribute]
		public bool auto_lock_window = false;
		/// <summary>
		/// 多久无操作就锁定 - 单位分钟
		/// </summary>
		[OptionalFieldAttribute]
		public int auto_lock_time = 5;
		/// <summary>
		/// 解锁密码
		/// </summary>
		[OptionalFieldAttribute]
		public string unlock_password = "";
		
		public MyNoteData()
		{
		}
		
	}
}
