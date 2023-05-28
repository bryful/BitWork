using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitWork
{
	public enum BitMode
	{
		Dec,
		DecSigned,
		Hex,
		Bin

	}
	public class TextBoxBit : Control
	{
		private TextBox m_TextBox = new TextBox();
		private Button m_Enter = new Button();
		public event EventHandler? ValueChanged;
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		// **********************************************
		private BitMode m_BitMode = BitMode.Dec;
		public BitMode BitMode
		{
			get { return m_BitMode; }
			set
			{
				m_BitMode=value;
				_refflag = true;
				ValueToStr();
				_refflag = false;
			}
		}
		public new string Text
		{
			get { return m_TextBox.Text;}
			set
			{
				m_TextBox.Text = value;
			}
		}
		public new Color BackColor
		{
			get { return base.BackColor; }
			set
			{
				base.BackColor = value;
				m_TextBox.BackColor = value;
				m_Enter.BackColor = value;
			}
		}
		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				m_TextBox.ForeColor = value;
				m_Enter.ForeColor = value;
			}
		}
		// **********************************************
		private ulong m_Value =0;
		public ulong Value
		{
			get { return m_Value; }
			set { SetValue(value); }
		}
		public void SetValue(ulong v)
		{
			ulong ul = ByteMask(v);
			if (m_Value != ul) {
				m_Value = ul;
				ValueToStr();
			}
		}
		private string ToBin(ulong b)
		{
			string s = "";
			byte bb = (byte)b;
			for(int i=0; i<8;i++)
			{
				if ((bb &0x01)==0x01)
				{
					s = "1" + s;
				}
				else
				{
					s = "0" + s;
				}
				bb >>= 1;
			}
			return s;
		}
		private string ToBin()
		{
			string s = "";
			switch(m_ByteSize)
			{
				case ByteSize.Byte1:
					s = ToBin(m_Value & 0xFF);
					break;
				case ByteSize.Byte2:
					s = ToBin((m_Value>>8) & 0xFF) +"_" +ToBin(m_Value & 0xFF);
					break;
				case ByteSize.Byte4:
					s = ToBin((m_Value >> 24) & 0xFF) + "_" + ToBin((m_Value >> 16) & 0xFF) + "_" +
						ToBin((m_Value >> 8) & 0xFF) + "_" + ToBin(m_Value & 0xFF);
					break;
				case ByteSize.Byte8:
					s = ToBin((m_Value >> 56) & 0xFF) + "_" + ToBin((m_Value >> 48) & 0xFF) + "_" +
						ToBin((m_Value >> 40) & 0xFF) + "_" + ToBin((m_Value >> 32) & 0xFF) + "_" +
						ToBin((m_Value >> 24) & 0xFF) + "_" + ToBin((m_Value >> 16) & 0xFF) + "_" +
						ToBin((m_Value >> 8) & 0xFF) + "_" + ToBin(m_Value & 0xFF);
					break;
			}
			return s;
		}
		private ulong ByteMask(ulong v)
		{
			ulong ret = v;
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					ret &= 0xFF;
					break;
				case ByteSize.Byte2:
					ret &= 0xFFFF;
					break;
				case ByteSize.Byte4:
					ret &= 0xFFFFFFFF;
					break;
			}
			return ret;

		}
		private string ToDecS()
		{
			string ret = "";
			switch (m_ByteSize)
			{
				case ByteSize.Byte1:
					sbyte c = (sbyte)m_Value;
					ret = $"{c}";
					break;
				case ByteSize.Byte2:
					short h = (short)m_Value;
					ret = $"{h}";
					break;
				case ByteSize.Byte4:
					int i = (int)m_Value;
					ret = $"{i}";
					break;
				case ByteSize.Byte8:
					long l = (long)m_Value;
					ret = $"{l}";
					break;
			}
			return ret;
		}
		private void ValueToStr()
		{
			string s = "";
			m_Value = ByteMask(m_Value);
			switch(m_BitMode)
			{
				case BitMode.Dec:
					s = $"{m_Value}";
					break;
				case BitMode.DecSigned:
					s = ToDecS();
					break;
				case BitMode.Hex:
					s = $"{m_Value:X}";
					break;
				case BitMode.Bin:
					s = ToBin();
					break;
			}
			this.Text = s;
		}
		// **********************************************
		private ByteSize m_ByteSize = ByteSize.Byte8;
		public ByteSize ByteSize
		{ 
			get { return m_ByteSize; }
			set 
			{ 
				m_ByteSize = value; 
				ValueToStr();
			}

		}
		// **********************************************
		private TogglePanel? m_TglBitSize = null;
		[Category("BitWork")]
		public TogglePanel? TglBitSize
		{
			get { return m_TglBitSize; }
			set
			{
				m_TglBitSize = value;
				if (m_TglBitSize != null)
				{
					m_TglBitSize.Tags[0] = 64;
					m_TglBitSize.Tags[1] = 32;
					m_TglBitSize.Tags[2] = 16;
					m_TglBitSize.Tags[3] = 8;
					m_TglBitSize.IndexChanged += (sender, e) =>
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
		// **********************************************
		private TogglePanel? m_TglBitMode = null;
		[Category("BitWork")]
		public TogglePanel? TglBitMode
		{
			get { return m_TglBitMode; }
			set
			{
				m_TglBitMode = value;
				if (m_TglBitMode != null)
				{
					m_TglBitMode.Tags[0] = BitMode.Dec;
					m_TglBitMode.Tags[1] = BitMode.DecSigned;
					m_TglBitMode.Tags[2] = BitMode.Hex;
					m_TglBitMode.Tags[3] = BitMode.Bin;
					m_TglBitMode.IndexChanged += (sender, e) =>
					{
						switch (e.Index)
						{
							case (int)BitMode.Dec:
								BitMode = BitMode.Dec;
								break;
							case (int)BitMode.DecSigned:
								BitMode = BitMode.DecSigned;
								break;
							case (int)BitMode.Hex:
								BitMode = BitMode.Hex;
								break;
							case (int)BitMode.Bin:
								BitMode = BitMode.Bin;
								break;
						}
					};
				}
			}
		}
		// **********************************************
		private ulong? TextToValue()
		{
			ulong? ret = null;
			switch(m_BitMode)
			{
				case BitMode.Dec:
					ulong d = 0;
					if(ulong.TryParse(this.Text,out d))
					{
						ret = (ulong)d;
					}
					break;
				case BitMode.DecSigned:
					long l = 0;
					if (long.TryParse(this.Text, out l))
					{
						ret = (ulong)l;
					}
					break;
				case BitMode.Hex:
					try
					{
						ulong n = Convert.ToUInt64(this.Text, 16);
						ret = (ulong)n;
					}
					catch
					{
						ret = null;
					}
					break;
				case BitMode.Bin:
					try
					{
						string s = "";
						if(this.Text.Length > 0)
						{
							for(int i=0;i< this.Text.Length; i++)
							{
								string ss = this.Text.Substring(i, 1);
								if ((ss=="0")||(ss=="1"))
								{
									s += ss;
								}
							}
							ulong n = Convert.ToUInt64(s, 2);
							ret = (ulong)n;
						}
					}
					catch
					{
						ret = null;
					}
					break;
			}
			return ret;
		}
		// **********************************************
		private bool _refflag = false;
		// **********************************************
		public TextBoxBit()
		{
			m_TextBox.BorderStyle = BorderStyle.FixedSingle;
			m_Enter.Text = "Ent";
			m_Enter.FlatStyle = FlatStyle.Flat;
			this.Controls.Add(m_TextBox);
			this.Controls.Add(m_Enter);
			ChkSize();
			m_Enter.Click += (sender, e) => { EnterValue(); };
			m_TextBox.KeyDown += (sender, e) => { if(e.KeyData==Keys.Return) EnterValue(); };
		}
		// **********************************************
		private void ChkSize()
		{
			m_TextBox.Location = new Point(0, 0);
			m_TextBox.Size = new Size(this.Width - m_TextBox.Height-20, m_TextBox.Height);
			m_Enter.Location = new Point(this.Width - m_TextBox.Height-20, 0);
			m_Enter.Size = new Size(m_TextBox.Height+20, m_TextBox.Height);
			if(this.Height != m_TextBox.Height)
			{
				this.Height = m_TextBox.Height;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			base.OnResize(e);
		}
		// **********************************************
		public void EnterValue()
		{
			ulong? ul = TextToValue();
			if (ul != null)
			{
				m_Value = (ulong)ul;
				OnValueChanged(EventArgs.Empty);
			}

		}
	}
}
