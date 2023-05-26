using System;
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
	public partial class ByteDisp8Byte : Control
	{
		private ulong m_Value = 0;
		[Category("BitWork")]
		public ulong Value
		{
			get { return m_Value; }
			set
			{
				bool b = (m_Value != value);
				m_Value = value;
				ChkSize();
				ValueTo();
				if (b) {}
			}
		}
		private ByteDisp[] m_ByteDisp = new ByteDisp[20];
		private bool m_IsHex = false;
		[Category("BitWork")]
		public bool IsHex
		{
			get { return m_IsHex; }
			set
			{
				m_IsHex = value;
				long a = 1;
				if (m_IsHex)
				{

					for (int i = 0; i < 16; i++)
					{
						m_ByteDisp[i].SetAddValue(a);
						a *= 0x10;
					}
				}
				else
				{

					for (int i = 0; i < 20; i++)
					{
						m_ByteDisp[i].SetAddValue(a);
						a *= 10;
					}

				}
				ChkSize();
				ValueTo();

			}
		}
		[Category("BitWork")]
		public Color UnEnabledColor
		{
			get { return m_ByteDisp[0].UnEnabledColor; }
			set
			{
				for (int i = 0; i < 20; i++) m_ByteDisp[i].UnEnabledColor = value;

			}
		}
		[Category("BitWork")]
		public new Color ForeColor
		{
			get { return m_ByteDisp[0].ForeColor; }
			set
			{
				base.ForeColor = value;
				for (int i = 0; i < 20; i++) m_ByteDisp[i].ForeColor = value;
			}
		}
		[Category("BitWork")]
		public new Font Font
		{
			get { return m_ByteDisp[0].Font; }
			set
			{
				base.Font = value;
				for (int i = 0; i < 20; i++) m_ByteDisp[i].Font = value;
				ChkSize() ;
				this.Invalidate();
			}
		}
		[Category("BitWork")]
		public new Color BackColor
		{
			get { return m_ByteDisp[0].BackColor; }
			set
			{
				base.BackColor = value;
				for (int i = 0; i < 20; i++) m_ByteDisp[i].BackColor = value;
			}
		}
		[Category("ByteDisp")]
		public int NWidth
		{
			get { return m_ByteDisp[0].NWidth; }
			set
			{
				for (int i = 0; i < 20; i++) m_ByteDisp[i].NWidth = value;
				ChkSize();
			}
		}
		[Category("ByteDisp")]
		public int NHeight
		{
			get { return m_ByteDisp[0].NHeight; }
			set
			{
				for (int i = 0; i < 20; i++) m_ByteDisp[i].NHeight = value;
				ChkSize();
			}
		}
		[Category("ByteDisp")]
		public int TBHeight
		{
			get { return m_ByteDisp[0].TBHeight; }
			set
			{
				for (int i = 0; i < 20; i++) m_ByteDisp[i].TBHeight = value;
				ChkSize();
			}
		}
		public ByteDisp8Byte()
		{
			InitializeComponent();
			for(int i=0; i<m_ByteDisp.Length; i++) 
			{ 
				m_ByteDisp[i] = new ByteDisp(); 
			}
			ChkSize();
			IsHex=true;
			for (int i = 0; i < m_ByteDisp.Length; i++)
			{
				m_ByteDisp[i].Clicked += (sender, e) =>
				{
					long v1 = (long)m_Value;
					v1 += e.Value;
					m_Value = (ulong)v1;
					ValueTo();
				};
				this.Controls.Add(m_ByteDisp[i]);
			}

		}
		private void ValueTo()
		{
			ulong v = m_Value;
			if (m_IsHex)
			{
				for(int i=0; i<16;i++)
				{
					m_ByteDisp[i].Value = (int)(v & 0xF);
					v >>= 4;
				}
			}
			else
			{
				for (int i = 0; i < 20; i++)
				{
					m_ByteDisp[i].Value = (int)(v % 10);
					v /=10;
				}
			}
		}
		private void ChkSize()
		{
			int x = 20 + m_ByteDisp[0].NWidth * 20 + 6 * 8 + 20;

			if((this.Width != x)||(this.Height != m_ByteDisp[0].Height))
			{
				this.MinimumSize = new Size(0, 0);
				this.MaximumSize = new Size(0, 0);
				this.Size = new Size(x, m_ByteDisp[0].Height);
				this.MinimumSize = this.Size;
				this.MaximumSize = this.Size;
			}

			for (int i = 16; i < 20; i++) m_ByteDisp[i].Visible = !m_IsHex;

			x -= 20;
			if (m_IsHex==false)
			{
				for(int i = 0; i<20;i++)
				{
					x -= m_ByteDisp[i].Width;
					m_ByteDisp[i].Location = new Point(x, 0); 
					if ((i % 3) == 2) x -= 8;
				}
			}
			else
			{
				for (int i = 0; i < 16; i++)
				{
					x -= m_ByteDisp[i].Width;
					m_ByteDisp[i].Location = new Point(x, 0);
					if ((i % 4) == 3) x -= 8;
				}
			}
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			this.Invalidate();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			using (SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			{
				Graphics g = pe.Graphics;
				g.FillRectangle(sb, this.ClientRectangle);
				Rectangle r = new Rectangle(0, m_ByteDisp[0].TBHeight, this.Width - 20, m_ByteDisp[0].NHeight-1);
				g.DrawRectangle(p, r);

			}			
		}
	}
}
