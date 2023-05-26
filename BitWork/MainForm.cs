namespace BitWork
{
	public partial class MainForm : BaseForm
	{
		// ********************************************************************
		private F_Pipe m_Server = new F_Pipe();
		public void StartServer(string pipename)
		{
			m_Server.Server(pipename);
			m_Server.Reception += (sender, e) =>
			{
				this.Invoke((Action)(() =>
				{
					PipeData pd = new PipeData(e.Text);
					Command(pd.Args, PIPECALL.PipeExec);
					this.Activate();
				}));
			};
		}
		// ********************************************************************
		public void StopServer()
		{
			m_Server.StopServer();
		}
		public MainForm()
		{
			this.AllowDrop = true;
			InitializeComponent();
			this.FormClosed += (sender, e) => { LastSettings(); };
			StartSettings();

			tglByteSize.Tags[0] = 64;
			tglByteSize.Tags[1] = 32;
			tglByteSize.Tags[2] = 16;
			tglByteSize.Tags[3] = 8;

			if ((tglByteSize.Tags[tglByteSize.Index]) is int)
			{
				bitDisp8byte1.ByteSize = (ByteSize)(tglByteSize.Tags[tglByteSize.Index]);
			}

			tglSigned.IndexChanged += (sender, e) =>
			{
				BinToStr();
			};
			bitDisp8byte1.UlongChanged += (sender, e) =>
			{
				BinToStr();
			};
			btnClear.Click += (sender, e) => { bitDisp8byte1.Value = 0; };
			btnRev.Click += (sender, e) => { bitDisp8byte1.BitRev(); };
			btnShiftLeft.Click += (sender, e) => { bitDisp8byte1.BitShift(true); };
			btnShiftRight.Click += (sender, e) => { bitDisp8byte1.BitShift(false); };
			Command(Environment.GetCommandLineArgs().Skip(1).ToArray(), PIPECALL.StartupExec);
		}
		// **********************************************************
		private void StartSettings()
		{
			PrefFile pf = new PrefFile(this);
			pf.Load();
			Point? loc = pf.GetLocation();
		}
		// **********************************************************
		private void LastSettings()
		{
			PrefFile pf = new PrefFile(this);
			pf.SetLocation();
			pf.Save();
		}
		// **********************************************************
		/// <summary>
		/// コマンド解析
		/// </summary>
		/// <param name="args">コマンド配列</param>
		/// <param name="IsPipe">起動時かダブルクリック時か判別</param>
		public void Command(string[] args, PIPECALL IsPipe = PIPECALL.StartupExec)
		{
			string ret = "";
			if (args.Length > 0)
			{
				foreach (string arg in args)
				{
					if (ret != "") ret += ",\r\n";
					ret += arg;
				}
			}
			tbDec.Text = ret;
		}
		// **********************************************************
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if ((drgevent != null) && (drgevent.Data != null))
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{
					drgevent.Effect = DragDropEffects.Copy;
				}
			}
			else
			{
				base.OnDragEnter(drgevent);
			}
		}
		// **********************************************************
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if ((drgevent != null) && (drgevent.Data != null))
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{

					// ドラッグ中のファイルやディレクトリの取得
					string[] drags = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
					Command(drags);
					/*
					foreach (string d in drags)
					{
						if (!System.IO.File.Exists(d))
						{
						}
						else if (!System.IO.Directory.Exists(d))
						{
						}
					}
					*/
					drgevent.Effect = DragDropEffects.Copy;
				}
			}
			else
			{
				base.OnDragDrop(drgevent);
			}
		}
		// **********************************************************
		public void BinToStr()
		{
			ulong uv = bitDisp8byte1.Value;
			string vdec = "";
			string hdec = "";
			if (tglSigned.Index == 0)
			{
				string minus = "";
				switch (tglByteSize.Index)
				{
					case 3:
						sbyte sb = (sbyte)(uv & 0xFF);
						if (sb < 0) { minus = "-"; sb *= -1; }
						vdec = $"{minus}{sb}";
						hdec = $"{minus}0x{sb:X}";
						break;
					case 2:
						short sh = (short)(uv & 0xFFFF);
						if (sh < 0) { minus = "-"; sh *= -1; }
						vdec = $"{minus}{sh}";
						hdec = $"{minus}0x{sh:X}";
						break;
					case 1:
						int it = (int)(uv & 0xFFFF_FFFF);
						if (it < 0) { minus = "-"; it *= -1; }
						vdec = $"{minus}{it}";
						hdec = $"{minus}0x{it:X}";
						break;
					case 0:
					default:
						long v = (long)uv;
						if (v < 0) { minus = "-"; v *= -1; }
						vdec = $"{minus}{v}";
						hdec = $"{minus}0x{v:X}";
						break;
				}
			}
			else
			{
				switch (tglByteSize.Index)
				{
					case 3:
						byte sb = (byte)(uv & 0xFF);
						vdec = $"{sb}";
						hdec = $"0x{sb:X}";
						break;
					case 2:
						ushort sh = (ushort)(uv & 0xFFFF);
						vdec = $"{sh}";
						hdec = $"0x{sh:X}";
						break;
					case 1:
						uint it = (uint)(uv & 0xFFFF_FFFF);
						vdec = $"{it}";
						hdec = $"0x{it:X}";
						break;
					case 0:
					default:
						vdec = $"{uv}";
						hdec = $"0x{uv:X}";
						break;
				}
			}
			tbDec.Text = $"{vdec}";
			tbHex.Text = $"{hdec}";
		}
		// **********************************************************
		private ulong? StrToValue(string s)
		{
			ulong? ret = null;
			switch (tglByteSize.Index)
			{
				case 3:
					sbyte sb = 0;
					if (sbyte.TryParse(s, out sb))
					{
						long vv = (long)sb;
						ret = (ulong)vv;
					}
					break;
				case 2:
					short sh = 0;
					if (short.TryParse(s, out sh))
					{
						long vv = (long)sh;
						ret = (ulong)vv;
					}
					break;
				case 1:
					int it = 0;
					if (int.TryParse(s, out it))
					{
						long vv = (long)it;
						ret = (ulong)vv;
					}
					break;
				case 0:
				default:
					long lg = 0;
					if (long.TryParse(s, out lg))
					{
						long vv = (long)lg;
						ret = (ulong)vv;
					}
					break;
			}
			return ret;
		}
		// **********************************************************
	}
}