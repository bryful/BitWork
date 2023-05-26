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
			tglSigned = new TogglePanel();
			label1 = new Label();
			label2 = new Label();
			tbDec = new TextBox();
			tbHex = new TextBox();
			btnRev = new Button();
			btnClear = new Button();
			btnShiftLeft = new Button();
			btnShiftRight = new Button();
			byteDisp8Byte1 = new ByteDisp8Byte();
			SuspendLayout();
			// 
			// tglByteSize
			// 
			tglByteSize.BackColor = Color.FromArgb(64, 64, 64);
			tglByteSize.BtnWidth = 30;
			tglByteSize.Count = 4;
			tglByteSize.ForeColor = Color.FromArgb(230, 230, 230);
			tglByteSize.Index = 0;
			tglByteSize.Location = new Point(12, 35);
			tglByteSize.MaximumSize = new Size(120, 23);
			tglByteSize.MinimumSize = new Size(120, 23);
			tglByteSize.Name = "tglByteSize";
			tglByteSize.Size = new Size(120, 23);
			tglByteSize.TabIndex = 1;
			tglByteSize.Tags = (new object[] { 64, 32, 16, 8, null, null, null, null, null, null });
			tglByteSize.Text = "togglePanel1";
			tglByteSize.Texts = (new string[] { "64", "32", "16", "8", "page5", "page6", "page7", "page8", "page9", "page10" });
			// 
			// bitDisp8byte1
			// 
			bitDisp8byte1.BitInter = 2;
			bitDisp8byte1.BitWidth = 8;
			bitDisp8byte1.ByteSize = ByteSize.Byte8;
			bitDisp8byte1.Location = new Point(12, 73);
			bitDisp8byte1.Name = "bitDisp8byte1";
			bitDisp8byte1.Size = new Size(722, 17);
			bitDisp8byte1.TabIndex = 3;
			bitDisp8byte1.Text = "bitDisp4byte1";
			bitDisp8byte1.TogglePanel = tglByteSize;
			bitDisp8byte1.Value = 252UL;
			// 
			// tglSigned
			// 
			tglSigned.BackColor = Color.FromArgb(64, 64, 64);
			tglSigned.BtnWidth = 70;
			tglSigned.Count = 2;
			tglSigned.ForeColor = Color.FromArgb(230, 230, 230);
			tglSigned.Index = 0;
			tglSigned.Location = new Point(152, 35);
			tglSigned.MaximumSize = new Size(140, 23);
			tglSigned.MinimumSize = new Size(140, 23);
			tglSigned.Name = "tglSigned";
			tglSigned.Size = new Size(140, 23);
			tglSigned.TabIndex = 4;
			tglSigned.Tags = (new object[] { null, null, null, null, null, null, null, null, null, null });
			tglSigned.Text = "togglePanel2";
			tglSigned.Texts = (new string[] { "signed", "unsigned", "16", "8", "page5", "page6", "page7", "page8", "page9", "page10" });
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(30, 104);
			label1.Name = "label1";
			label1.Size = new Size(36, 21);
			label1.TabIndex = 6;
			label1.Text = "Dec";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(370, 104);
			label2.Name = "label2";
			label2.Size = new Size(36, 21);
			label2.TabIndex = 8;
			label2.Text = "Hex";
			// 
			// tbDec
			// 
			tbDec.BackColor = Color.FromArgb(64, 64, 64);
			tbDec.BorderStyle = BorderStyle.FixedSingle;
			tbDec.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbDec.ForeColor = Color.FromArgb(230, 230, 230);
			tbDec.Location = new Point(72, 100);
			tbDec.Name = "tbDec";
			tbDec.Size = new Size(292, 29);
			tbDec.TabIndex = 9;
			// 
			// tbHex
			// 
			tbHex.BackColor = Color.FromArgb(64, 64, 64);
			tbHex.BorderStyle = BorderStyle.FixedSingle;
			tbHex.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbHex.ForeColor = Color.FromArgb(230, 230, 230);
			tbHex.Location = new Point(412, 100);
			tbHex.Name = "tbHex";
			tbHex.Size = new Size(80, 29);
			tbHex.TabIndex = 10;
			// 
			// btnRev
			// 
			btnRev.FlatStyle = FlatStyle.Flat;
			btnRev.Location = new Point(482, 35);
			btnRev.Name = "btnRev";
			btnRev.Size = new Size(75, 23);
			btnRev.TabIndex = 11;
			btnRev.Text = "Reverce";
			btnRev.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.FlatStyle = FlatStyle.Flat;
			btnClear.Location = new Point(381, 35);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(75, 23);
			btnClear.TabIndex = 12;
			btnClear.Text = "Zero";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// btnShiftLeft
			// 
			btnShiftLeft.FlatStyle = FlatStyle.Flat;
			btnShiftLeft.Location = new Point(563, 35);
			btnShiftLeft.Name = "btnShiftLeft";
			btnShiftLeft.Size = new Size(75, 23);
			btnShiftLeft.TabIndex = 13;
			btnShiftLeft.Text = "<<";
			btnShiftLeft.UseVisualStyleBackColor = true;
			// 
			// btnShiftRight
			// 
			btnShiftRight.FlatStyle = FlatStyle.Flat;
			btnShiftRight.Location = new Point(644, 35);
			btnShiftRight.Name = "btnShiftRight";
			btnShiftRight.Size = new Size(75, 23);
			btnShiftRight.TabIndex = 14;
			btnShiftRight.Text = ">>";
			btnShiftRight.UseVisualStyleBackColor = true;
			// 
			// byteDisp8Byte1
			// 
			byteDisp8Byte1.Font = new Font("小塚ゴシック Pr6N R", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
			byteDisp8Byte1.IsHex = false;
			byteDisp8Byte1.Location = new Point(72, 135);
			byteDisp8Byte1.MaximumSize = new Size(448, 48);
			byteDisp8Byte1.MinimumSize = new Size(448, 48);
			byteDisp8Byte1.Name = "byteDisp8Byte1";
			byteDisp8Byte1.NHeight = 32;
			byteDisp8Byte1.NWidth = 18;
			byteDisp8Byte1.Size = new Size(448, 48);
			byteDisp8Byte1.TabIndex = 15;
			byteDisp8Byte1.TBHeight = 8;
			byteDisp8Byte1.Text = "byteDisp8Byte1";
			byteDisp8Byte1.UnEnabledColor = Color.FromArgb(100, 100, 100);
			byteDisp8Byte1.Value = 65536UL;
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			CanResize = false;
			ClientSize = new Size(745, 211);
			Controls.Add(byteDisp8Byte1);
			Controls.Add(btnShiftRight);
			Controls.Add(btnShiftLeft);
			Controls.Add(btnClear);
			Controls.Add(btnRev);
			Controls.Add(tbHex);
			Controls.Add(tbDec);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(tglSigned);
			Controls.Add(bitDisp8byte1);
			Controls.Add(tglByteSize);
			Name = "MainForm";
			Text = "MainForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TogglePanel tglByteSize;
		private BitDisp8byte bitDisp8byte1;
		private TogglePanel tglSigned;
		private Label label1;
		private Label label2;
		private TextBox tbDec;
		private TextBox tbHex;
		private Button btnRev;
		private Button btnClear;
		private Button btnShiftLeft;
		private Button btnShiftRight;
		private ByteDisp8Byte byteDisp8Byte1;
	}
}