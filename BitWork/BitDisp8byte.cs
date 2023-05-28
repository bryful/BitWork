using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitWork
{
	public enum ByteSize
	{
		Byte1 = 8,
		Byte2 = 16,
		Byte4 = 32,
		Byte8 = 64,
	}
	public partial class BitDisp8byte : Control
	{
		public delegate void UlongChangedhandler(object sender, UlongChangedArgs e);
		public event UlongChangedhandler? UlongChanged;
		protected virtual void OnUlongChanged(UlongChangedArgs e)
		{
			if (UlongChanged != null)
			{
				UlongChanged(this, e);
			}
		}
		private BitDisp[] m_BitDisp = new BitDisp[8];
		private ulong m_Value = 0;
		[Category("BitWork")]
		public ulong Value
		{
			get { return m_Value; }
			set
			{
				if(m_Value != value)
				{
					ValueTo(value);
					this.Invalidate();
				}
			}
		}
		[Category("BitWork")]
		public long ValueS
		{
			get { return (long)m_Value; }
			set
			{
				ulong s = (ulong)value;
				if (m_Value != s)
				{
					ValueTo(s);
					this.Invalidate();
				}
			}
		}
		[Category("BitWork")]
		public byte ValueByte
		{
			get 
			{
				return (byte)m_Value; 
			}
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
					this.Invalidate();
				}
			}
		}
		[Category("BitWork")]
		public sbyte ValueSbyte
		{
			get { return (sbyte)m_Value; }
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
				}
				Invalidate();
			}
		}
		[Category("BitWork")]
		public short ValueShort
		{
			get { return (short)m_Value; }
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
				}
				Invalidate();
			}
		}
		[Category("BitWork")]
		public ushort ValueUshort
		{
			get { return (ushort)m_Value; }
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
				}
				Invalidate();
			}
		}
		[Category("BitWork")]
		public long ValueLong
		{
			get { return (long)m_Value; }
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
				}
				Invalidate();
			}
		}
		[Category("BitWork")]
		public ulong ValueUlong
		{
			get { return (ulong)m_Value; }
			set
			{
				ulong b = (ulong)value;
				if (m_Value != b)
				{
					ValueTo(b);
				}
				Invalidate();
			}
		}
		private void ValueTo(ulong value)
		{
			ulong v = 0;
			bool b = false;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					v = value & 0xFF;
					b = (m_Value != v);
					m_Value = v;
					m_BitDisp[0].Byte = (byte)(v);
					break;
				case ByteSize.Byte2:
					v = value & 0xFFFF;
					b = (m_Value != v);
					m_Value = v;
					m_BitDisp[0].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[1].Byte = (byte)(v  & 0xFF);
					break;
				case ByteSize.Byte4:
					v = value & 0xFFFF_FFFF;
					b = (m_Value != v);
					m_Value = v;
					m_BitDisp[0].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[1].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[2].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[3].Byte = (byte)(v & 0xFF);
					break;
				case ByteSize.Byte8:
					v = value & 0xFFFF_FFFF_FFFF_FFFF;
					b = (m_Value != v);
					m_Value = v;

					m_BitDisp[0].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[1].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[2].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[3].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[4].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[5].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[6].Byte = (byte)(v & 0xFF);
					v >>= 8;
					m_BitDisp[7].Byte = (byte)(v & 0xFF);
					break;
			}
			Debug.WriteLine("@" + BinToStr(m_Value));
			if (b) OnUlongChanged(new UlongChangedArgs(m_Value));
			Invalidate();

		}
		private string BinToStr(ulong v)
		{
			string ret = "";
			ulong v2 = v;
			for(int i = 0;i<8;i++)
			{
				byte b = (byte)(v2 & 0xFF);
				string ss = "";
				for(int j = 0;j<8;j++)
				{
					string sss = "0";
					if ((b & 0x01) == 0x01)
					{
						sss = "1";
					}
					b >>= 1;
					ss = sss + ss;
				}
				ret = ss +"_"+ ret;
				v2 >>= 8;
			}
			return ret;
		}

		private void ValueFromBin()
		{
			ulong v = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					v = (ulong)m_BitDisp[0].Byte;
					break;
				case ByteSize.Byte2:
					v |= (ulong)m_BitDisp[0].Byte;
					v |= (ulong)m_BitDisp[1].Byte << 8;
					break;
				case ByteSize.Byte4:
					v |= (ulong)m_BitDisp[0].Byte;
					v |= (ulong)m_BitDisp[1].Byte << 8;
					v |= (ulong)m_BitDisp[2].Byte << 16;
					v |= (ulong)m_BitDisp[3].Byte << 24;
					break;
				case ByteSize.Byte8:
					v |= (ulong)m_BitDisp[0].Byte;
					v |= (ulong)m_BitDisp[1].Byte << 8;
					v |= (ulong)m_BitDisp[2].Byte << 16;
					v |= (ulong)m_BitDisp[3].Byte << 24;
					v |= (ulong)m_BitDisp[4].Byte << 32;
					v |= (ulong)m_BitDisp[5].Byte << 40;
					v |= (ulong)m_BitDisp[6].Byte << 48;
					v |= (ulong)m_BitDisp[7].Byte << 56;
					break;
			}
			bool b = (m_Value != v);
			m_Value = v;
			if(b) OnUlongChanged(new UlongChangedArgs(m_Value));
		}
		[Category("BitWork")]
		public int BitWidth
		{
			get { return m_BitDisp[0].BitWidth; }
			set
			{
				for(int i=0; i<8; i++) m_BitDisp[i].BitWidth = value;
				ChkSize();
				ChkLocation();
			}
		}
		private int m_BitInter = 2;
		[Category("BitWork")]
		public int BitInter
		{
			get { return m_BitDisp[0].BitInter; }
			set
			{
				for (int i = 0; i < 8; i++) m_BitDisp[i].BitInter = value;
				ChkSize();
				ChkLocation();
			}
		}
		private ByteSize m_ByteSize =  ByteSize.Byte8;
		[Category("BitWork")]
		public ByteSize ByteSize
		{
			get { return m_ByteSize; }
			set
			{
				m_ByteSize = value;
				ChkSize();
			}
		}
		[Category("BitWork")]
		public string ValueDec
		{
			get { return $"{m_Value}"; }
		}
		[Category("BitWork")]
		public string ValueHex
		{
			get { return $"{m_Value:X}"; }
		}
		private TogglePanel? m_TogglePanel=null;
		[Category("BitWork")]
		public TogglePanel? TogglePanel
		{
			get { return m_TogglePanel; }
			set
			{
				m_TogglePanel = value;
				if(m_TogglePanel!=null)
				{
					m_TogglePanel.Tags[0] = 64;
					m_TogglePanel.Tags[1] = 32;
					m_TogglePanel.Tags[2] = 16;
					m_TogglePanel.Tags[3] = 8;
					m_TogglePanel.IndexChanged += (sender, e) =>
					{
						switch (e.Index)
						{
							case 3:
								ByteSize = ByteSize.Byte1;
								break;
							case 2:
								ByteSize = ByteSize.Byte2;
								break;
							case 1:
								ByteSize = ByteSize.Byte4;
								break;
							case 0:
							default:
								ByteSize = ByteSize.Byte8;
								break;
						}
					};
				}
			}
		}
		// ******************************************************************
		public void ChkSize()
		{
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					m_Value = m_Value & 0xFF;
					for (int i = 0; i < 1; i++) m_BitDisp[i].Enabled = true;
					for (int i = 1; i < 8; i++) m_BitDisp[i].Enabled = false;
					break;
				case ByteSize.Byte2:
					m_Value = m_Value & 0xFFFF;
					for (int i = 0; i < 2; i++) m_BitDisp[i].Enabled = true;
					for (int i = 2; i < 8; i++) m_BitDisp[i].Enabled = false;
					break;
				case ByteSize.Byte4:
					m_Value = m_Value & 0xFFFF_FFFF;
					for (int i = 0; i < 4; i++) m_BitDisp[i].Enabled = true;
					for (int i = 4; i < 8; i++) m_BitDisp[i].Enabled = false;
					break;
				case ByteSize.Byte8:
					m_Value = m_Value & 0xFFFF_FFFF_FFFF_FFFF;
					for (int i = 0; i < 8; i++) m_BitDisp[i].Enabled = true;
					break;
			}
			ValueTo(m_Value);
			/*
			int x = 0;
			*/
		}


		public BitDisp8byte()
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
			int x = 0;
			for(int i=0; i<8; i++)
			{
				m_BitDisp[i] = new BitDisp();
				this.Controls.Add(m_BitDisp[i]);
				m_BitDisp[i].ByteChanged += (sender, e) => { ValueFromBin(); };
			}
			ChkSize();
			ChkLocation();
		}
		public void ChkLocation()
		{
			int x = 0;
			for (int i = 7; i >= 0; i--)
			{
				m_BitDisp[i].Location = new Point(x, 0);
				x += m_BitDisp[i].Width + 4;
				if ((i % 2) == 0) x += 4;
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		public ulong BitMask(ulong value)
		{
			ulong v =0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					v = value & 0xFF;
					break;
				case ByteSize.Byte2:
					v = value & 0xFFFF;
					break;
				case ByteSize.Byte4:
					v = value & 0xFFFF_FFFF;
					break;
				case ByteSize.Byte8:
					v = value & 0xFFFF_FFFF_FFFF_FFFF;
					break;
			}
			return v;
		}
		public void BitShift(bool IsLeft)
		{
			ulong v = BitMask(m_Value);
			Debug.WriteLine("A"+BinToStr(v));
			if(IsLeft) { v <<= 1; } else { v >>= 1; }
			Debug.WriteLine("B" + BinToStr(v));
			v = BitMask(v);
			Debug.WriteLine("C" + BinToStr(v));
			ValueTo(v);
		}
		public void BitRev()
		{
			ValueTo(m_Value ^ 0xFFFF_FFFF_FFFF_FFFF);
		}
		public void Add(ulong value)
		{
			ulong ret = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte s = (sbyte)m_Value;
					sbyte d = (sbyte)value;
					s += d;
					ret = (ulong)s;
					break;
				case ByteSize.Byte2:
					short s2 = (short)m_Value;
					short d2 = (short)value;
					s2 += d2;
					ret = (ulong)s2;
					break;
				case ByteSize.Byte4:
					int s4 = (int)m_Value;
					int d4 = (int)value;
					s4 += d4;
					ret = (ulong)s4;
					break;
				case ByteSize.Byte8:
					long s8 = (long)m_Value;
					long d8 = (long)value;
					s8 += d8;
					ret = (ulong)s8;
					break;
			}
			ValueTo(ret);
		}
		public void Sub(ulong value)
		{
			ulong ret = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte s = (sbyte)m_Value;
					sbyte d = (sbyte)value;
					s -= d;
					ret = (ulong)s;
					break;
				case ByteSize.Byte2:
					short s2 = (short)m_Value;
					short d2 = (short)value;
					s2 -= d2;
					ret = (ulong)s2;
					break;
				case ByteSize.Byte4:
					int s4 = (int)m_Value;
					int d4 = (int)value;
					s4 -= d4;
					ret = (ulong)s4;
					break;
				case ByteSize.Byte8:
					long s8 = (long)m_Value;
					long d8 = (long)value;
					s8 -= d8;
					ret = (ulong)s8;
					break;
			}
			ValueTo(ret);
		}
		public void And(ulong value)
		{
			ulong ret = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte s = (sbyte)m_Value;
					sbyte d = (sbyte)value;
					s &= d;
					ret = (ulong)s;
					break;
				case ByteSize.Byte2:
					short s2 = (short)m_Value;
					short d2 = (short)value;
					s2 &= d2;
					ret = (ulong)s2;
					break;
				case ByteSize.Byte4:
					int s4 = (int)m_Value;
					int d4 = (int)value;
					s4 &= d4;
					ret = (ulong)s4;
					break;
				case ByteSize.Byte8:
					long s8 = (long)m_Value;
					long d8 = (long)value;
					s8 &= d8;
					ret = (ulong)s8;
					break;
			}
			ValueTo(ret);
		}
		public void Or(ulong value)
		{
			ulong ret = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte s = (sbyte)m_Value;
					sbyte d = (sbyte)value;
					s |= d;
					ret = (ulong)s;
					break;
				case ByteSize.Byte2:
					short s2 = (short)m_Value;
					short d2 = (short)value;
					s2 |= d2;
					ret = (ulong)s2;
					break;
				case ByteSize.Byte4:
					int s4 = (int)m_Value;
					int d4 = (int)value;
					s4 |= d4;
					ret = (ulong)s4;
					break;
				case ByteSize.Byte8:
					long s8 = (long)m_Value;
					long d8 = (long)value;
					s8 |= d8;
					ret = (ulong)s8;
					break;
			}
			ValueTo(ret);
		}
		public void Xor(ulong value)
		{
			ulong ret = 0;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte s = (sbyte)m_Value;
					sbyte d = (sbyte)value;
					s ^= d;
					ret = (ulong)s;
					break;
				case ByteSize.Byte2:
					short s2 = (short)m_Value;
					short d2 = (short)value;
					s2 ^= d2;
					ret = (ulong)s2;
					break;
				case ByteSize.Byte4:
					int s4 = (int)m_Value;
					int d4 = (int)value;
					s4 ^= d4;
					ret = (ulong)s4;
					break;
				case ByteSize.Byte8:
					long s8 = (long)m_Value;
					long d8 = (long)value;
					s8 ^= d8;
					ret = (ulong)s8;
					break;
			}
			ValueTo(ret);
		}
	}
	public class UlongChangedArgs : EventArgs
	{
		public ulong Ulong = 0;
		public UlongChangedArgs(ulong idx)
		{
			Ulong = idx;
		}
	}
}
