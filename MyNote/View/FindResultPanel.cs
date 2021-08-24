/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/24
 * Time: 14:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MyNote.Data;

namespace MyNote.View
{
	/// <summary>
	/// Description of FindResultPanel.
	/// </summary>
	public partial class FindResultPanel : UserControl
	{
		public delegate void OnResultItemClickHandler(string nodeName, string uid);
		
		public OnResultItemClickHandler onResultItemClick;
		
		public FindResultPanel()
		{
			InitializeComponent();
			mFindResultView.GridLines = true;
			mFindResultView.FullRowSelect = true;
		}
		
		/// <summary>
		/// 设置搜索结果
		/// </summary>
		/// <param name="results"></param>
		public void SetResultList(List<NoteBookNode> results)
		{
			mFindResultView.Items.Clear();
			mFindResultView.BeginUpdate();
			foreach (var element in results) 
			{
				ListViewItem item = new ListViewItem();
				item.Text = element.NodeName;
				item.SubItems.Add(element.NodeDocumentUID);
				mFindResultView.Items.Add(item);
			}
			mFindResultView.EndUpdate();
		}
		/// <summary>
		/// 双击点击搜索结果
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnNodeClick(object sender, EventArgs e)
		{
			var items = mFindResultView.SelectedItems;
			if(items == null || items.Count < 1) return;
			
			string name = items[0].Text;
			string uid = items[0].SubItems[1].Text;
			if(this.onResultItemClick != null)
			{
				this.onResultItemClick(name, uid);
			}
		}
		/// <summary>
		/// 阻止关闭，只是隐藏
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnDialogClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Visible = false;
		}
		void OnHideWindow(object sender, EventArgs e)
		{
			this.Visible = false;
		}
	}
}
