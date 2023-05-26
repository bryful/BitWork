using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitWork
{
	public partial class ByteDisp : Control
	{
		public delegate void Clickedhandler(object sender, ClickdArgs e);
		public event Clickedhandler? Clicked;
		protected virtual void OnClicked(ClickdArgs e)
		{
			if (Clicked != null)
			{
				Clicked(this, e);
			}
		}
		private long m_AddValue = 1;
		public long AddValue { get { return m_AddValue; } }
		public void SetAddValue(long v) { m_AddValue = v; }
		private int m_Value = 0;
		public int Value
		{
			get { return m_Value; }
			set
			{
				int v = value;
				if (v < 0) v = -1;
				else if (v > 0xF) v = 0xF;
				bool b = (m_Value != v);
				m_Value = v;
				if (b)
				{
					
				}
				this.Invalidate();
			}
		}
		private Color m_UnEnabledColor = Color.FromArgb(100, 100, 100);
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
		private int m_NWidth = 20;
		[Category("ByteDisp")]
		public int NWidth
		{
			get { return m_NWidth; }
			set 
			{
				m_NWidth = value;
				Size sz = GetFontSize();
				if (sz.Width > m_NWidth)
				{
					m_NWidth = sz.Width;
				}
				ChkSize();
				this.Invalidate();
			}
		}
		private int m_NHeight = 25;
		[Category("ByteDisp")]
		public int NHeight
		{
			get { return m_NHeight; }
			set
			{
				m_NHeight = value;
				Size sz = GetFontSize();
				if (sz.Height > m_NHeight)
				{
					m_NHeight = sz.Height;
				}
				ChkSize();
				this.Invalidate();
			}
		}
		private int m_TBHeight = 10;
		[Category("ByteDisp")]
		public int TBHeight
		{
			get { return m_TBHeight; }
			set
			{
				m_TBHeight = value;
				if (m_TBHeight < 6) m_TBHeight = 6;
				ChkSize();
				this.Invalidate();
			}
		}
		private int m_DrawLine = 2;
		[Category("ByteDisp")]
		public int DrawLine
		{
			get { return m_DrawLine; }
			set
			{ 
				m_DrawLine = value;
				if(m_DrawLine < 0) { m_DrawLine = 0; }
				else if (m_DrawLine > 3) { m_DrawLine = 3; }
				this.Invalidate();
			}
		}
		[Category("ByteDisp")]
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				Size sz = GetFontSize();
				if((sz.Width> m_NWidth) ||(sz.Height>m_NHeight))
				{
					m_NWidth = sz.Width;
					m_NHeight = sz.Height;
					ChkSize();
				}
				this.Invalidate();
			}
		}
		private void ChkSize()
		{
			int w = m_NWidth;
			int h = m_NHeight + m_TBHeight * 2;
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = new Size(w, h);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}
		private Size GetFontSize()
		{
			using (Bitmap bmp = new Bitmap(100,100))
			using (StringFormat sf = new StringFormat( StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap))
			{
				Graphics g = Graphics.FromImage(bmp);
				SizeF sz = g.MeasureString("0", this.Font, bmp.Size,sf);
				return new Size((int)(sz.Width-8),(int)(sz.Height));
			}
		}
		public ByteDisp()
		{
			InitializeComponent();
			ChkSize();
		}
		private int m_MYPos = -1;
		private int GetPosY(int y)
		{
			int ret = -1;
			if ((y>=0)&&(y < m_TBHeight+8))
			{
				ret = 0;
			}
			else if (y < m_TBHeight + m_NHeight-8)
			{
				ret = 1;
			}
			else if (y < this.Height)
			{
				ret = 2;
			}
			else
			{
				ret = -1;
			}
			return ret;
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			
			using (Pen p = new Pen(ForeColor))
			using (SolidBrush sb = new SolidBrush(BackColor))
			{
				Graphics g = pe.Graphics;
				g.FillRectangle(sb, this.ClientRectangle);

				if (m_Value >= 0)
				{
					if (this.Enabled)
					{
						sb.Color = ForeColor;
					}
					else
					{
						sb.Color = m_UnEnabledColor;
					}
					PointF[] ps = new PointF[3];
					if (m_MYPos == 0)
					{
						ps[0] = new PointF((float)m_NWidth / 2, 0);
						ps[1] = new PointF((float)m_NWidth - 1, m_TBHeight-1);
						ps[2] = new PointF(0, ps[1].Y);
						g.FillPolygon(sb, ps);
					}
					else if (m_MYPos == 2)
					{
						ps[0] = new PointF(0, m_TBHeight + m_NHeight+1);
						ps[1] = new PointF((float)m_NWidth - 1, ps[0].Y);
						ps[2] = new PointF((float)m_NWidth / 2, this.Height - 1);
						g.FillPolygon(sb, ps);
					}
					using (StringFormat sf = new StringFormat(StringFormatFlags.NoWrap))
					{
						sf.LineAlignment = StringAlignment.Center;
						sf.Alignment = StringAlignment.Center;

						Rectangle r = new Rectangle(-10, m_TBHeight, m_NWidth+20, m_NHeight);
						g.DrawString($"{m_Value:X}", this.Font, sb, r, sf);
					}
				}
				if(m_DrawLine>0)
				{
					p.Color = ForeColor;
					int h = m_TBHeight;
					g.DrawLine(p, 0, h, this.Width - 1, h);
					h += m_NHeight - 1;
					g.DrawLine(p, 0, h, this.Width - 1, h);
					switch (m_DrawLine)
					{
						case 1:
							g.DrawLine(p, 0, m_TBHeight, 0, m_TBHeight+m_NHeight-1);
							break;
						case 3:
							g.DrawLine(p, this.Width-1, m_TBHeight, this.Width - 1, m_TBHeight + m_NHeight - 1);
							break;
					}
				}

			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			Point sp = System.Windows.Forms.Cursor.Position;
			Point cp = this.PointToClient(sp);
			int idx = GetPosY(cp.Y);
			if (idx>=0)
			{
				if (m_MYPos != idx)
				{
					m_MYPos = idx;
					this.Invalidate();
				}
			}
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			if(m_MYPos!=-1)
			{
				m_MYPos = -1;
				this.Invalidate();
			}
			base.OnMouseLeave(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			int idx = GetPosY(e.Y);
			if (idx>=0)
			{
				if (m_MYPos != idx)
				{
					m_MYPos = idx;
					this.Invalidate();
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int idx = GetPosY(e.Y);
			if (idx>=0)
			{
				if(idx == 0)
				{
					OnClicked(new ClickdArgs(m_AddValue));
				}
				else if (idx == 2)
				{
					OnClicked(new ClickdArgs(m_AddValue*-1));
				}
			}
			base.OnMouseDown(e);
		}
	}
	public class ClickdArgs : EventArgs
	{
		public long Value = 0;
		public ClickdArgs(long idx)
		{
			Value = idx;
		}
	}
}
