namespace Impelement_AndORNot_ANN
{
    partial class Classification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.w1NumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.w2NumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.threesholdNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gatesCmbBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.correctW2NumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.correctW1NumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.calcBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.trainRateNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.errorLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.w1NumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w2NumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threesholdNumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctW2NumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctW1NumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainRateNumUpDwn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter W1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter W2";
            // 
            // w1NumUpDwn
            // 
            this.w1NumUpDwn.DecimalPlaces = 2;
            this.w1NumUpDwn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.w1NumUpDwn.Location = new System.Drawing.Point(107, 29);
            this.w1NumUpDwn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.w1NumUpDwn.Name = "w1NumUpDwn";
            this.w1NumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.w1NumUpDwn.TabIndex = 2;
            this.w1NumUpDwn.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // w2NumUpDwn
            // 
            this.w2NumUpDwn.DecimalPlaces = 2;
            this.w2NumUpDwn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.w2NumUpDwn.Location = new System.Drawing.Point(107, 55);
            this.w2NumUpDwn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.w2NumUpDwn.Name = "w2NumUpDwn";
            this.w2NumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.w2NumUpDwn.TabIndex = 3;
            this.w2NumUpDwn.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // threesholdNumUpDwn
            // 
            this.threesholdNumUpDwn.DecimalPlaces = 2;
            this.threesholdNumUpDwn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.threesholdNumUpDwn.Location = new System.Drawing.Point(107, 80);
            this.threesholdNumUpDwn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.threesholdNumUpDwn.Name = "threesholdNumUpDwn";
            this.threesholdNumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.threesholdNumUpDwn.TabIndex = 5;
            this.threesholdNumUpDwn.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Threeshold";
            // 
            // gatesCmbBx
            // 
            this.gatesCmbBx.FormattingEnabled = true;
            this.gatesCmbBx.Location = new System.Drawing.Point(345, 28);
            this.gatesCmbBx.Name = "gatesCmbBx";
            this.gatesCmbBx.Size = new System.Drawing.Size(121, 21);
            this.gatesCmbBx.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Choose A Logic Gate";
            // 
            // correctW2NumUpDwn
            // 
            this.correctW2NumUpDwn.DecimalPlaces = 2;
            this.correctW2NumUpDwn.Location = new System.Drawing.Point(107, 142);
            this.correctW2NumUpDwn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.correctW2NumUpDwn.Name = "correctW2NumUpDwn";
            this.correctW2NumUpDwn.ReadOnly = true;
            this.correctW2NumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.correctW2NumUpDwn.TabIndex = 11;
            // 
            // correctW1NumUpDwn
            // 
            this.correctW1NumUpDwn.DecimalPlaces = 2;
            this.correctW1NumUpDwn.Location = new System.Drawing.Point(107, 116);
            this.correctW1NumUpDwn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.correctW1NumUpDwn.Name = "correctW1NumUpDwn";
            this.correctW1NumUpDwn.ReadOnly = true;
            this.correctW1NumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.correctW1NumUpDwn.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Correct W2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Correct W1";
            // 
            // calcBtn
            // 
            this.calcBtn.Location = new System.Drawing.Point(236, 118);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(118, 44);
            this.calcBtn.TabIndex = 14;
            this.calcBtn.Text = "Calcualte";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Training Rate";
            // 
            // trainRateNumUpDwn
            // 
            this.trainRateNumUpDwn.DecimalPlaces = 2;
            this.trainRateNumUpDwn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.trainRateNumUpDwn.Location = new System.Drawing.Point(345, 60);
            this.trainRateNumUpDwn.Name = "trainRateNumUpDwn";
            this.trainRateNumUpDwn.Size = new System.Drawing.Size(120, 20);
            this.trainRateNumUpDwn.TabIndex = 19;
            this.trainRateNumUpDwn.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.ForeColor = System.Drawing.Color.Red;
            this.errorLbl.Location = new System.Drawing.Point(49, 175);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(0, 13);
            this.errorLbl.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Italic);
            this.label7.Location = new System.Drawing.Point(427, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 10);
            this.label7.TabIndex = 21;
            this.label7.Text = "MASTERZ";
            // 
            // Classification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 197);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.trainRateNumUpDwn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.calcBtn);
            this.Controls.Add(this.correctW2NumUpDwn);
            this.Controls.Add(this.correctW1NumUpDwn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gatesCmbBx);
            this.Controls.Add(this.threesholdNumUpDwn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.w2NumUpDwn);
            this.Controls.Add(this.w1NumUpDwn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(495, 236);
            this.MinimumSize = new System.Drawing.Size(495, 236);
            this.Name = "Classification";
            this.Text = "Classification ANN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.w1NumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w2NumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threesholdNumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctW2NumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctW1NumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainRateNumUpDwn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown w1NumUpDwn;
        private System.Windows.Forms.NumericUpDown w2NumUpDwn;
        private System.Windows.Forms.NumericUpDown threesholdNumUpDwn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gatesCmbBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown correctW2NumUpDwn;
        private System.Windows.Forms.NumericUpDown correctW1NumUpDwn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown trainRateNumUpDwn;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.Label label7;
    }
}

