/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/17
 * Time: 11:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyNote.Data
{
	[Serializable]
	/// <summary>
	/// 笔记本类，记录笔记本的信息包含内容
	/// </summary>
	public class NoteBook
	{
		/// <summary>
		/// 笔记本名称
		/// </summary>
		public string BookName{set;get;}
		/// <summary>
		/// 唯一UUID
		/// </summary>
		public string BookUID{set;get;}
		/// <summary>
		/// 完整路径
		/// </summary>
		public string BookPath{set; get;}
		/// <summary>
		/// 内容根节点
		/// </summary>
		public List<NoteBookNode> BookNotes = new List<NoteBookNode>();
		
		public NoteBook()
		{
			
		}
		/// <summary>
		/// 遍历整个笔记本查找节点并添加
		/// </summary>
		/// <param name="current"></param>
		/// <param name="newNode"></param>
		/// <param name="afterInsert"></param>
		/// <returns></returns>
		public bool FindNodeAndAdd(NoteBookNode current, NoteBookNode newNode, bool afterInsert)
		{
			for(int i=0; i < BookNotes.Count; i++)
			{
				var node = BookNotes[i];
				// 如果匹配到根节点
				if(node.NodeDocumentUID == current.NodeDocumentUID)
				{
					if(afterInsert) // 后面插入
					{
						if(i >= BookNotes.Count)
						{
							BookNotes.Add(newNode);
						}else
						{
							BookNotes.Insert(i + 1, newNode);
						}
					}else  //前面插入
					{
						BookNotes.Insert(i, newNode);
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
		public bool FindNodeAndRemove(NoteBookNode current)
		{
			for(int i=0; i < BookNotes.Count; i++)
			{
				var node = BookNotes[i];
				// 如果匹配到根节点
				if(node.NodeDocumentUID == current.NodeDocumentUID)
				{
					BookNotes.Remove(current);
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
		/// 查找Node根据uid
		/// </summary>
		/// <param name="uid"></param>
		/// <returns></returns>
		public NoteBookNode FindNodeWithUUID(string uid)
		{
			NoteBookNode node;
			foreach (NoteBookNode element in BookNotes) 
			{
				if(element.FindNodeWithUUID(uid, out node))
				{
					return node;
				}
			}
			return null;
		}
		/// <summary>
		/// 保存数据
		/// </summary>
		public void Save()
		{
			IFormatter formatter = new BinaryFormatter();
			using(FileStream fs = new FileStream(this.BookPath, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, this);
			}
		}
		/// <summary>
		/// 创建笔记本
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static NoteBook CreateBookWithPath(string path)
		{
			NoteBook book = new NoteBook();
			book.BookPath = path;
			book.BookUID = System.Guid.NewGuid().ToString();
			book.BookName = Path.GetFileNameWithoutExtension(path);
			NoteBookNode temp_node = new NoteBookNode(book.BookName);
			book.BookNotes.Add(temp_node);
			book.Save(); // 先保存一下
			return book;
		}
		/// <summary>
		/// 加载笔记本
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static NoteBook LoadBookFromDisk(string path)
		{
			IFormatter formatter = new BinaryFormatter();
			using(FileStream fs = new FileStream(path, FileMode.Open))
			{
				NoteBook book = (NoteBook)formatter.Deserialize(fs);
				return book;
			}
		}
	}
}
