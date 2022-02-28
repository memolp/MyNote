/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 16:34
 * 
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// 扩展TreeNode，用于关联NoteBookNode，减少代码编写
	/// </summary>
	public class TreeNodeEx : TreeNode
	{
		/// <summary>
		/// 关联NoteBookNode对象
		/// </summary>
		public NoteBookNode Item {set; get;}
	}
}
