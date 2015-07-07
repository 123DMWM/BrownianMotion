namespace BrownianMotion {
	partial class ControlForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		public void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
			this.button1 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownG = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(106, 235);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(81, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "Generate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(12, 269);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(176, 23);
			this.progressBar1.TabIndex = 1;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 241);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 17);
			this.label1.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(106, 208);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(78, 21);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Watch?";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(106, 181);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(87, 21);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Overlay?";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(12, 29);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
			this.numericUpDown1.TabIndex = 5;
			this.numericUpDown1.Value = new decimal(new int[] {
            1234,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Iterations";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(12, 57);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(116, 21);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Text = "Starting Color";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "R";
			// 
			// numericUpDownR
			// 
			this.numericUpDownR.Enabled = false;
			this.numericUpDownR.Location = new System.Drawing.Point(36, 79);
			this.numericUpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownR.Name = "numericUpDownR";
			this.numericUpDownR.Size = new System.Drawing.Size(46, 22);
			this.numericUpDownR.TabIndex = 9;
			this.numericUpDownR.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
			this.numericUpDownR.ValueChanged += new System.EventHandler(this.numericUpDownR_ValueChanged);
			// 
			// numericUpDownG
			// 
			this.numericUpDownG.Enabled = false;
			this.numericUpDownG.Location = new System.Drawing.Point(36, 107);
			this.numericUpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownG.Name = "numericUpDownG";
			this.numericUpDownG.Size = new System.Drawing.Size(46, 22);
			this.numericUpDownG.TabIndex = 11;
			this.numericUpDownG.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
			this.numericUpDownG.ValueChanged += new System.EventHandler(this.numericUpDownG_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(19, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "G";
			// 
			// numericUpDownB
			// 
			this.numericUpDownB.Enabled = false;
			this.numericUpDownB.Location = new System.Drawing.Point(36, 135);
			this.numericUpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownB.Name = "numericUpDownB";
			this.numericUpDownB.Size = new System.Drawing.Size(46, 22);
			this.numericUpDownB.TabIndex = 13;
			this.numericUpDownB.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
			this.numericUpDownB.ValueChanged += new System.EventHandler(this.numericUpDownB_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 137);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "B";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(110, 79);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(78, 78);
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(148, 17);
			this.label6.TabIndex = 15;
			this.label6.Text = "Color change intensity";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(40, 180);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(42, 22);
			this.numericUpDown2.TabIndex = 16;
			this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 17);
			this.label7.TabIndex = 17;
			this.label7.Text = "+-";
			// 
			// ControlForm
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 304);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.numericUpDownB);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numericUpDownG);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericUpDownR);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(222, 353);
			this.Name = "ControlForm";
			this.Text = "Controls";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button button1;
		public System.Windows.Forms.ProgressBar progressBar1;
		public System.ComponentModel.BackgroundWorker backgroundWorker1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox checkBox1;
		public System.Windows.Forms.CheckBox checkBox2;
		public System.Windows.Forms.NumericUpDown numericUpDown1;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.CheckBox checkBox3;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.NumericUpDown numericUpDownR;
		public System.Windows.Forms.NumericUpDown numericUpDownG;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.NumericUpDown numericUpDownB;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label7;
	}
}