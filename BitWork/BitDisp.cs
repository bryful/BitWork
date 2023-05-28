using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitWork
{
	public partial class BitDisp : Control
	{

		public delegate void ByteChangedhandler(object sender, ByteChangedArgs e);
		public event ByteChangedhandler? ByteChanged;
		protected virtual void OnByteChanged(ByteChangedArgs e)
		{
			if (ByteChanged != null)
			{
				ByteChanged(this, e);
			}
		}

		private int m_BitWidth = 8;
		[Category("BitWork")]
		public int BitWidth
		{
			get { return m_BitWidth; }
			set
			{
				m_BitWidth = value;
				ChkSize();
				this.Invalidate();
			}
		}
		private int m_BitInter = 2;
		[Category("BitWork")]
		public int BitInter
		{
			get { return m_BitInter; }
			set
			{
				m_BitInter = value;
				ChkSize();
				this.Invalidate();
			}
		}
		private byte m_Byte = 0;
		[Category("BitWork")]
		public byte Byte
		{
			get { return m_Byte; }
			set
			{
				bool b = (m_Byte != value);
				m_Byte = value;
				this.Invalidate();
				if (b) OnByteChanged(new ByteChangedArgs(m_Byte));
			}
		}
		private Color m_UnEnabledColor = Color.FromArgb(100,100,100);
		[Category("BitWork")]
		public Color UnEnabledColor
		{
			get { return m_UnEnabledColor; }
			set
			{
				bool b = (m_UnEnabledColor != value);
				m_UnEnabledColor = value;
				this.Invalidate();
			}
		}
		public void ChkSize()
		{
			int w = m_BitWidth*8 + m_BitInter*9;
			int h = m_BitWidth + m_BitInter * 2;
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = new Size(w, h);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}
		public BitDisp()
		{
			this.SetStyle(
			ControlStyles.DoubleBuffer |
			ControlStyles.UserPaint |
			ControlStyles.AllPaintingInWmPaint |
			ControlStyles.ResizeRedraw |
			ControlStyles.SupportsTransparentBackColor,
			true);
			this.UpdateStyles();
			InitializeComponent();
			ChkSize();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			using (Pen p = new Pen(ForeColor))
			using (SolidBrush sb= new SolidBrush(BackColor))
			{
				Graphics g = pe.Graphics;
				g.FillRectangle(sb, this.ClientRectangle);

				byte b = m_Byte;
				if (this.Enabled)
				{
					sb.Color = ForeColor;
					p.Color = ForeColor;
				}
				else
				{
					sb.Color = m_UnEnabledColor;
					p.Color = m_UnEnabledColor;
				}
				for (int i = 0; i < 8; i++)
				{
					Rectangle rct = new Rectangle(
						this.Width - (m_BitWidth + m_BitInter) * (i + 1),
						m_BitInter,
						m_BitWidth,
						m_BitWidth
						);
					if (((b & 0x1) ==0x1)&&(this.Enabled))
					{
						g.FillRectangle(sb, rct);
					}
					else
					{
						rct = new Rectangle(
							rct.Left,
							rct.Top,
							rct.Width-1,
							rct.Height-1
						);
						g.DrawRectangle(p, rct);
					}
					b >>= 1;
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.Enabled)
			{
				int idx = 7 - (e.X - m_BitInter / 2) / (m_BitWidth + m_BitInter);
				if (idx < 0) idx = 0; else if (idx > 7) idx = 7;
				byte v = (byte)(m_Byte ^ (0x01 << idx));
				bool b = (m_Byte != v);
				m_Byte = v;
				this.Invalidate();
				if (b) OnByteChanged(new ByteChangedArgs(m_Byte));
			}
			base.OnMouseDown(e);
		}
	}
	public class ByteChangedArgs : EventArgs
	{
		public byte Byte = 0;
		public ByteChangedArgs(byte idx)
		{
			Byte = idx;
		}
	}
}
