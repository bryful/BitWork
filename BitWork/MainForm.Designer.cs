namespace BitWork
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tglByteSize = new TogglePanel();
			bitDisp8byte1 = new BitDisp8byte();
			btnRev = new Button();
			btnClear = new Button();
			btnShiftLeft = new Button();
			btnShiftRight = new Button();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			tbDec = new TextBoxBit();
			tbDecS = new TextBoxBit();
			tbHex = new TextBoxBit();
			tbBin = new TextBoxBit();
			tbCalc = new TextBoxBit();
			tglMode = new TogglePanel();
			label5 = new Label();
			rbAdd = new RadioButton();
			rbSub = new RadioButton();
			rbAnd = new RadioButton();
			rbOr = new RadioButton();
			rbXor = new RadioButton();
			SuspendLayout();
			// 
			// tglByteSize
			// 
			tglByteSize.BackColor = Color.FromArgb(64, 64, 64);
			tglByteSize.BtnWidth = 24;
			tglByteSize.Count = 4;
			tglByteSize.ForeColor = Color.FromArgb(230, 230, 230);
			tglByteSize.Index = 0;
			tglByteSize.Location = new Point(17, 30);
			tglByteSize.Margin = new Padding(4);
			tglByteSize.MaximumSize = new Size(96, 24);
			tglByteSize.MinimumSize = new Size(96, 24);
			tglByteSize.Name = "tglByteSize";
			tglByteSize.Size = new Size(96, 24);
			tglByteSize.TabIndex = 1;
			tglByteSize.Tags = new object[] { 64, 32, 16, 8, null, null, null, null, null, null };
			tglByteSize.Text = "togglePanel1";
			tglByteSize.Texts = new string[] { "64", "32", "16", "8", "page5", "page6", "page7", "page8", "page9", "page10" };
			// 
			// bitDisp8byte1
			// 
			bitDisp8byte1.BitInter = 3;
			bitDisp8byte1.BitWidth = 8;
			bitDisp8byte1.ByteSize = ByteSize.Byte8;
			bitDisp8byte1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			bitDisp8byte1.Location = new Point(15, 62);
			bitDisp8byte1.Margin = new Padding(4);
			bitDisp8byte1.Name = "bitDisp8byte1";
			bitDisp8byte1.Size = new Size(772, 14);
			bitDisp8byte1.TabIndex = 3;
			bitDisp8byte1.Text = "bitDisp4byte1";
			bitDisp8byte1.TogglePanel = tglByteSize;
			bitDisp8byte1.Value = 0UL;
			bitDisp8byte1.ValueByte = 0;
			bitDisp8byte1.ValueLong = 0L;
			bitDisp8byte1.ValueS = 0L;
			bitDisp8byte1.ValueSbyte = 0;
			bitDisp8byte1.ValueShort = 0;
			bitDisp8byte1.ValueUlong = 0UL;
			bitDisp8byte1.ValueUshort = (ushort)0;
			// 
			// btnRev
			// 
			btnRev.FlatStyle = FlatStyle.Flat;
			btnRev.Location = new Point(151, 30);
			btnRev.Margin = new Padding(4);
			btnRev.Name = "btnRev";
			btnRev.Size = new Size(96, 30);
			btnRev.TabIndex = 11;
			btnRev.Text = "Reverce";
			btnRev.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.FlatStyle = FlatStyle.Flat;
			btnClear.Location = new Point(691, 30);
			btnClear.Margin = new Padding(4);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(96, 30);
			btnClear.TabIndex = 12;
			btnClear.Text = "Zero";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// btnShiftLeft
			// 
			btnShiftLeft.FlatStyle = FlatStyle.Flat;
			btnShiftLeft.Location = new Point(255, 30);
			btnShiftLeft.Margin = new Padding(4);
			btnShiftLeft.Name = "btnShiftLeft";
			btnShiftLeft.Size = new Size(96, 30);
			btnShiftLeft.TabIndex = 13;
			btnShiftLeft.Text = "<<";
			btnShiftLeft.UseVisualStyleBackColor = true;
			// 
			// btnShiftRight
			// 
			btnShiftRight.FlatStyle = FlatStyle.Flat;
			btnShiftRight.Location = new Point(359, 30);
			btnShiftRight.Margin = new Padding(4);
			btnShiftRight.Name = "btnShiftRight";
			btnShiftRight.Size = new Size(96, 30);
			btnShiftRight.TabIndex = 14;
			btnShiftRight.Text = ">>";
			btnShiftRight.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(15, 83);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(36, 21);
			label1.TabIndex = 16;
			label1.Text = "Dec";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(15, 164);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(36, 21);
			label2.TabIndex = 18;
			label2.Text = "Hex";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(15, 204);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(32, 21);
			label3.TabIndex = 20;
			label3.Text = "Bin";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(17, 122);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(92, 21);
			label4.TabIndex = 21;
			label4.Text = "Dec(signed)";
			// 
			// tbDec
			// 
			tbDec.BackColor = Color.FromArgb(64, 64, 64);
			tbDec.BitMode = BitMode.Dec;
			tbDec.ByteSize = ByteSize.Byte8;
			tbDec.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbDec.ForeColor = Color.FromArgb(230, 230, 230);
			tbDec.Location = new Point(117, 81);
			tbDec.Margin = new Padding(4);
			tbDec.Name = "tbDec";
			tbDec.Size = new Size(695, 29);
			tbDec.TabIndex = 22;
			tbDec.TglBitMode = null;
			tbDec.TglBitSize = tglByteSize;
			tbDec.Value = 0UL;
			// 
			// tbDecS
			// 
			tbDecS.BackColor = Color.FromArgb(64, 64, 64);
			tbDecS.BitMode = BitMode.DecSigned;
			tbDecS.ByteSize = ByteSize.Byte8;
			tbDecS.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbDecS.ForeColor = Color.FromArgb(230, 230, 230);
			tbDecS.Location = new Point(117, 120);
			tbDecS.Margin = new Padding(4);
			tbDecS.Name = "tbDecS";
			tbDecS.Size = new Size(695, 29);
			tbDecS.TabIndex = 23;
			tbDecS.TglBitMode = null;
			tbDecS.TglBitSize = tglByteSize;
			tbDecS.Value = 0UL;
			// 
			// tbHex
			// 
			tbHex.BackColor = Color.FromArgb(64, 64, 64);
			tbHex.BitMode = BitMode.Hex;
			tbHex.ByteSize = ByteSize.Byte8;
			tbHex.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbHex.ForeColor = Color.FromArgb(230, 230, 230);
			tbHex.Location = new Point(117, 162);
			tbHex.Margin = new Padding(4);
			tbHex.Name = "tbHex";
			tbHex.Size = new Size(695, 29);
			tbHex.TabIndex = 24;
			tbHex.TglBitMode = null;
			tbHex.TglBitSize = tglByteSize;
			tbHex.Value = 0UL;
			// 
			// tbBin
			// 
			tbBin.BackColor = Color.FromArgb(64, 64, 64);
			tbBin.BitMode = BitMode.Bin;
			tbBin.ByteSize = ByteSize.Byte8;
			tbBin.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbBin.ForeColor = Color.FromArgb(230, 230, 230);
			tbBin.Location = new Point(117, 204);
			tbBin.Margin = new Padding(4);
			tbBin.Name = "tbBin";
			tbBin.Size = new Size(695, 29);
			tbBin.TabIndex = 25;
			tbBin.TglBitMode = null;
			tbBin.TglBitSize = tglByteSize;
			tbBin.Value = 0UL;
			// 
			// tbCalc
			// 
			tbCalc.BackColor = Color.FromArgb(64, 64, 64);
			tbCalc.BitMode = BitMode.Hex;
			tbCalc.ByteSize = ByteSize.Byte8;
			tbCalc.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbCalc.ForeColor = Color.FromArgb(230, 230, 230);
			tbCalc.Location = new Point(117, 279);
			tbCalc.Margin = new Padding(4);
			tbCalc.Name = "tbCalc";
			tbCalc.Size = new Size(695, 29);
			tbCalc.TabIndex = 26;
			tbCalc.TglBitMode = tglMode;
			tbCalc.TglBitSize = tglByteSize;
			tbCalc.Value = 0UL;
			// 
			// tglMode
			// 
			tglMode.BackColor = Color.FromArgb(64, 64, 64);
			tglMode.BtnWidth = 50;
			tglMode.Count = 4;
			tglMode.ForeColor = Color.FromArgb(230, 230, 230);
			tglMode.Index = 0;
			tglMode.Location = new Point(117, 247);
			tglMode.Margin = new Padding(4);
			tglMode.MaximumSize = new Size(200, 24);
			tglMode.MinimumSize = new Size(200, 24);
			tglMode.Name = "tglMode";
			tglMode.Size = new Size(200, 24);
			tglMode.TabIndex = 31;
			tglMode.Tags = new object[] { BitMode.Dec, BitMode.DecSigned, BitMode.Hex, BitMode.Bin, null, null, null, null, null, null };
			tglMode.Text = "togglePanel1";
			tglMode.Texts = new string[] { "Dec", "DecSigned", "Hex", "Bin", "page5", "page6", "page7", "page8", "page9", "page10" };
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(17, 247);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(39, 21);
			label5.TabIndex = 32;
			label5.Text = "Calc";
			// 
			// rbAdd
			// 
			rbAdd.AutoSize = true;
			rbAdd.Checked = true;
			rbAdd.Location = new Point(336, 249);
			rbAdd.Name = "rbAdd";
			rbAdd.Size = new Size(39, 25);
			rbAdd.TabIndex = 33;
			rbAdd.TabStop = true;
			rbAdd.Text = "+";
			rbAdd.UseVisualStyleBackColor = true;
			// 
			// rbSub
			// 
			rbSub.AutoSize = true;
			rbSub.Location = new Point(381, 249);
			rbSub.Name = "rbSub";
			rbSub.Size = new Size(34, 25);
			rbSub.TabIndex = 34;
			rbSub.TabStop = true;
			rbSub.Text = "-";
			rbSub.UseVisualStyleBackColor = true;
			// 
			// rbAnd
			// 
			rbAnd.AutoSize = true;
			rbAnd.Location = new Point(421, 249);
			rbAnd.Name = "rbAnd";
			rbAnd.Size = new Size(41, 25);
			rbAnd.TabIndex = 35;
			rbAnd.TabStop = true;
			rbAnd.Text = "&&";
			rbAnd.UseVisualStyleBackColor = true;
			// 
			// rbOr
			// 
			rbOr.AutoSize = true;
			rbOr.Location = new Point(468, 249);
			rbOr.Name = "rbOr";
			rbOr.Size = new Size(32, 25);
			rbOr.TabIndex = 36;
			rbOr.TabStop = true;
			rbOr.Text = "|";
			rbOr.UseVisualStyleBackColor = true;
			// 
			// rbXor
			// 
			rbXor.AutoSize = true;
			rbXor.Location = new Point(506, 249);
			rbXor.Name = "rbXor";
			rbXor.Size = new Size(39, 25);
			rbXor.TabIndex = 37;
			rbXor.TabStop = true;
			rbXor.Text = "^";
			rbXor.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			CanResize = false;
			ClientSize = new Size(825, 322);
			Controls.Add(rbXor);
			Controls.Add(rbOr);
			Controls.Add(rbAnd);
			Controls.Add(rbSub);
			Controls.Add(rbAdd);
			Controls.Add(label5);
			Controls.Add(tglMode);
			Controls.Add(tbCalc);
			Controls.Add(tbBin);
			Controls.Add(tbHex);
			Controls.Add(tbDecS);
			Controls.Add(tbDec);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnShiftRight);
			Controls.Add(btnShiftLeft);
			Controls.Add(btnClear);
			Controls.Add(btnRev);
			Controls.Add(bitDisp8byte1);
			Controls.Add(tglByteSize);
			Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4);
			Name = "MainForm";
			Text = "BitWork";
			Load += MainForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TogglePanel tglByteSize;
		private BitDisp8byte bitDisp8byte1;
		private Button btnRev;
		private Button btnClear;
		private Button btnShiftLeft;
		private Button btnShiftRight;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBoxBit tbDec;
		private TextBoxBit tbDecS;
		private TextBoxBit tbHex;
		private TextBoxBit tbBin;
		private TextBoxBit tbCalc;
		private TogglePanel tglMode;
		private Label label5;
		private RadioButton rbAdd;
		private RadioButton rbSub;
		private RadioButton rbAnd;
		private RadioButton rbOr;
		private RadioButton rbXor;
	}
}