﻿/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 11:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace MyNote.Data
{
	[Serializable]
	/// <summary>
	/// 笔记本每个节点自身的数据，包括文档数据
	/// </summary>
	public class NoteBookNode
	{
		/// <summary>
		/// 节点名称
		/// </summary>
		public string NodeName{set;get;}
		/// <summary>
		/// 节点文档UUID
		/// </summary>
		public string NodeDocumentUID{set;get;}
		/// <summary>
		/// 节点列表
		/// </summary>
		public List<NoteBookNode> childrenList = new List<NoteBookNode>();
		/// <summary>
		/// 创建空的NoteBookNode节点
		/// </summary>
		public NoteBookNode()
		{

		}
		/// <summary>
		/// 创建指定名称的NoteBookNode节点，会自动生成UUID
		/// </summary>
		/// <param name="name"></param>
		public NoteBookNode(string name)
		{
			this.NodeName = name;
			this.NodeDocumentUID = System.Guid.NewGuid().ToString();
		}
		/// <summary>
		/// 查找并添加
		/// </summary>
		/// <param name="current"></param>
		/// <param name="newNode"></param>
		/// <param name="afterInsert"></param>
		/// <returns></returns>
		public bool FindNodeAndAdd(NoteBookNode current, NoteBookNode newNode, bool afterInsert)
		{
			for(int i =0; i< childrenList.Count; i++)
			{
				var node = childrenList[i];
				// 如果匹配到根节点
				if(node.NodeDocumentUID == current.NodeDocumentUID)
				{
					if(afterInsert) // 后面插入
					{
						if(i >= childrenList.Count)
						{
							childrenList.Add(newNode);
						}else
						{
							childrenList.Insert(i + 1, newNode);
						}
					}else  //前面插入
					{
						childrenList.Insert(i, newNode);
					}
					return true;
				}else
				{
					if(node.FindNodeAndAdd(current, newNode, afterInsert))
						return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 从节点中移除对象
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		public bool FindNodeAndRemove(NoteBookNode current)
		{
			for(int i =0; i< childrenList.Count; i++)
			{
				var node = childrenList[i];
				// 如果匹配到根节点
				if(node.NodeDocumentUID == current.NodeDocumentUID)
				{
					childrenList.Remove(node);
					return true;
				}else
				{
					if(node.FindNodeAndRemove(current))
						return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 查找节点根据UID
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool FindNodeWithUUID(string uid, out NoteBookNode node)
		{
			node = null;
			if(this.NodeDocumentUID == uid)
			{
				node = this;
				return true;
			}
			foreach (var element in childrenList) 
			{
				if(element.FindNodeWithUUID(uid, out node))
					return true;
			}
			return false;
		}
		/// <summary>
		/// 删除全部的子节点
		/// </summary>
		/// <param name="root_path"></param>
		public void RemoveAllChildren(string root_path)
		{
			foreach (var element in childrenList) 
			{
				element.Remove(root_path);
			}
			childrenList.Clear();
		}
		/// <summary>
		/// 删除节点的文件内容
		/// </summary>
		/// <param name="root_path"></param>
		public void Remove(string root_path)
		{
			string filename = string.Format("{0}{1}",NodeDocumentUID, Const.NOTE_BOOK_NODE_EXT);
			string filepath = Path.Combine(root_path, filename);
			if(File.Exists(filepath))
			{
				File.Delete(filepath);
			}
			// 继续删除当前节点的子节点列表
			this.RemoveAllChildren(root_path);
		}
	}
}