/*
 * Created by SharpDevelop.
 * User: qingf
 * Date: 2021/8/24
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace MyNote.View
{
	/// <summary>
	/// 自定义富文本控件，为了扩展支持数字项目编号
	/// </summary>
	public class RichTextBoxEx : RichTextBox
	{
		#region PARAFORMAT2结构体（可以去Microsoft docs中查看定义。C++的结构体）
        [StructLayout(LayoutKind.Sequential)]
        private class PARAFORMAT2
        {
            public int cbSize;   //结构大小，以字节为单位
            public int dwMask;
            public short wNumbering;  //指定编号选项的值
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            public int[] rgxTabs;

            public int dySpaceBefore; 	// 段落上方间距的大小
            public int dySpaceAfter; 	// 指定段落下方间距的大小
            public int dyLineSpacing; 	// 行间距
            public short sStyle; 		// 文字样式
            public byte bLineSpacingRule; 	//行间距的类型
            public byte bOutlineLevel; 	// Outline Level 必须为零。
            public short wShadingWeight; 	//阴影中使用的前景色百分比
            public short wShadingStyle; 	// 用于背景阴影的样式和颜色
            public short wNumberingStart; 	// 用于编号段落的起始编号或 Unicode 值。将此成员与wNumbering成员结合使用
            public short wNumberingStyle; 	// 与编号段落一起使用的编号样式
            public short wNumberingTab; 	// 段落编号和段落文本之间的最小间距
            public short wBorderSpace; 	// 边框和段落文本之间的空间
            public short wBorderWidth; 	// 边框宽度
            public short wBorders; 		// 边框位置、样式和颜色

            public PARAFORMAT2()
            {
                this.cbSize = Marshal.SizeOf(typeof(PARAFORMAT2));
            }
        }
        #endregion

        #region PARAFORMAT MASK VALUES
        // PARAFORMAT mask values
        private const uint PFM_STARTINDENT = 0x00000001;     //该dxStartIndent成员是有效的。
        private const uint PFM_RIGHTINDENT = 0x00000002;    //该 dxRightIndent成员是有效的。
        private const uint PFM_OFFSET = 0x00000004;        //该 dxOffset成员是有效的。
        private const uint PFM_ALIGNMENT = 0x00000008;    //该 wAlignment成员是有效的。
        private const uint PFM_TABSTOPS = 0x00000010;       //该cTabStobs和rgxTabStops成员是有效的。
        private const uint PFM_NUMBERING = 0x00000020;     //该 wNumbering成员是有效的。
        private const uint PFM_OFFSETINDENT = 0x80000000;   //所述 dxStartIndent构件是有效的，并指定相对值。

        // PARAFORMAT 2.0 masks and effects
        private const uint PFM_SPACEBEFORE = 0x00000040;
        private const uint PFM_SPACEAFTER = 0x00000080;
        private const uint PFM_LINESPACING = 0x00000100;
        private const uint PFM_STYLE = 0x00000400;
        private const uint PFM_BORDER = 0x00000800; // (*)
        private const uint PFM_SHADING = 0x00001000; // (*)
        private const uint PFM_NUMBERINGSTYLE = 0x00002000; // RE 3.0
        private const uint PFM_NUMBERINGTAB = 0x00004000; // RE 3.0
        private const uint PFM_NUMBERINGSTART = 0x00008000; // RE 3.0

        private const uint PFM_RTLPARA = 0x00010000;
        private const uint PFM_KEEP = 0x00020000; 		// (*)
        private const uint PFM_KEEPNEXT = 0x00040000; 		// (*)
        private const uint PFM_PAGEBREAKBEFORE = 0x00080000; 	// (*)
        private const uint PFM_NOLINENUMBER = 0x00100000; 	// (*)
        private const uint PFM_NOWIDOWCONTROL = 0x00200000; 	// (*)
        private const uint PFM_DONOTHYPHEN = 0x00400000; 	// (*)
        private const uint PFM_SIDEBYSIDE = 0x00800000; 	// (*)
        private const uint PFM_TABLE = 0x40000000; 		// RE 3.0
        private const uint PFM_TEXTWRAPPINGBREAK = 0x20000000; 	// RE 3.0
        private const uint PFM_TABLEROWDELIMITER = 0x10000000; 	// RE 4.0

        // The following three properties are read only
        private const uint PFM_COLLAPSED = 0x01000000; 	// RE 3.0
        private const uint PFM_OUTLINELEVEL = 0x02000000; 	// RE 3.0
        private const uint PFM_BOX = 0x04000000; 		// RE 3.0
        private const uint PFM_RESERVED2 = 0x08000000; 	// RE 4.0
        #endregion

        public enum AdvRichTextBulletType
        {
        	None = 0,
            Normal = 1,
            Number = 2,
            LowerCaseLetter = 3,
            UpperCaseLetter = 4,
            LowerCaseRoman = 5,
            UpperCaseRoman = 6
        }

        public enum AdvRichTextBulletStyle
        {
            RightParenthesis = 0x000,  //在数字后面加上一个右括号。
            DoubleParenthesis = 0x100,  //将数字括在括号中。
            Period = 0x200,  //数字后跟一个句点。
            Plain = 0x300,  //只显示号码。
            NoNumber = 0x400  //继续编号列表而不应用下一个数字或项目符号。
        }
        

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] PARAFORMAT2 lParam);
		
        //默认的数字样式
        private AdvRichTextBulletType _BulletType = AdvRichTextBulletType.Number;
        private AdvRichTextBulletStyle _BulletStyle = AdvRichTextBulletStyle.Period;
        private const short _BulletNumberStart = 1;
		/// <summary>
		/// 是否开启自定义项目编号
		/// </summary>
        public bool CustomBullet {set;get; }
		/// <summary>
		/// 项目编号支持的类型
		/// </summary>
        public AdvRichTextBulletType BulletType
        {
            get { return _BulletType; }
            set
            {
                _BulletType = value;
                NumberedBullet(true);
            }
        }
        /// <summary>
        /// 项目编号的样式
        /// </summary>
        public AdvRichTextBulletStyle BulletStyle
        {
            get { return _BulletStyle; }
            set
            {
                _BulletStyle = value;
                NumberedBullet(true);
            }
        }
        /// <summary>
        /// 开启数字项目编号
        /// </summary>
        /// <param name="TurnOn"></param>
        public void NumberedBullet(bool TurnOn)
        {
            PARAFORMAT2 paraformat1 = new PARAFORMAT2();
            paraformat1.dwMask = (int)(PFM_NUMBERING | PFM_OFFSET | PFM_NUMBERINGSTART |
                PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB);
            if (!TurnOn)
            {
                paraformat1.wNumbering = 0;
                paraformat1.dxOffset = 0;
            }
            else
            {
                paraformat1.wNumbering = (short)_BulletType;
                paraformat1.dxOffset = this.BulletIndent;
                paraformat1.wNumberingStyle = (short)_BulletStyle;
                paraformat1.wNumberingStart = _BulletNumberStart;
                paraformat1.wNumberingTab = 20;
            }
            SendMessage(new System.Runtime.InteropServices.HandleRef(this, this.Handle), 0x447, 0, paraformat1);
        }
	}
}
