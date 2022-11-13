namespace Back_Propagation_Implementaion
{
    partial class BackPropagation
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
            this.inputLayertxt = new System.Windows.Forms.TextBox();
            this.outputLayertxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenLayertxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trainBtn = new System.Windows.Forms.Button();
            this.correctedWeightTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trainingInputTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trainingOutputTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.targetErrorTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.learnRateTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "How Many Input Layers";
            // 
            // inputLayertxt
            // 
            this.inputLayertxt.Location = new System.Drawing.Point(139, 31);
            this.inputLayertxt.Name = "inputLayertxt";
            this.inputLayertxt.Size = new System.Drawing.Size(100, 20);
            this.inputLayertxt.TabIndex = 1;
            this.inputLayertxt.Text = "2";
            // 
            // outputLayertxt
            // 
            this.outputLayertxt.Location = new System.Drawing.Point(380, 31);
            this.outputLayertxt.Name = "outputLayertxt";
            this.outputLayertxt.Size = new System.Drawing.Size(100, 20);
            this.outputLayertxt.TabIndex = 3;
            this.outputLayertxt.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "How Many Output Layers";
            // 
            // hiddenLayertxt
            // 
            this.hiddenLayertxt.Location = new System.Drawing.Point(17, 95);
            this.hiddenLayertxt.Multiline = true;
            this.hiddenLayertxt.Name = "hiddenLayertxt";
            this.hiddenLayertxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hiddenLayertxt.Size = new System.Drawing.Size(222, 73);
            this.hiddenLayertxt.TabIndex = 5;
            this.hiddenLayertxt.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "How Many Hidden Layers";
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(633, 330);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(106, 40);
            this.trainBtn.TabIndex = 6;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.TrainBtn_Click);
            // 
            // correctedWeightTxt
            // 
            this.correctedWeightTxt.Location = new System.Drawing.Point(17, 212);
            this.correctedWeightTxt.Multiline = true;
            this.correctedWeightTxt.Name = "correctedWeightTxt";
            this.correctedWeightTxt.ReadOnly = true;
            this.correctedWeightTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.correctedWeightTxt.Size = new System.Drawing.Size(244, 158);
            this.correctedWeightTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Corrected Weight";
            // 
            // trainingInputTxt
            // 
            this.trainingInputTxt.Location = new System.Drawing.Point(249, 95);
            this.trainingInputTxt.Multiline = true;
            this.trainingInputTxt.Name = "trainingInputTxt";
            this.trainingInputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trainingInputTxt.Size = new System.Drawing.Size(231, 73);
            this.trainingInputTxt.TabIndex = 10;
            this.trainingInputTxt.Text = "0,0/0,1/1,0/1,1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Training Inputs";
            // 
            // trainingOutputTxt
            // 
            this.trainingOutputTxt.Location = new System.Drawing.Point(486, 95);
            this.trainingOutputTxt.Multiline = true;
            this.trainingOutputTxt.Name = "trainingOutputTxt";
            this.trainingOutputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.trainingOutputTxt.Size = new System.Drawing.Size(231, 73);
            this.trainingOutputTxt.TabIndex = 12;
            this.trainingOutputTxt.Text = "0/1/1/0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Training Output";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(521, 330);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(106, 40);
            this.testBtn.TabIndex = 13;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // targetErrorTxt
            // 
            this.targetErrorTxt.Location = new System.Drawing.Point(558, 31);
            this.targetErrorTxt.Name = "targetErrorTxt";
            this.targetErrorTxt.ReadOnly = true;
            this.targetErrorTxt.Size = new System.Drawing.Size(100, 20);
            this.targetErrorTxt.TabIndex = 15;
            this.targetErrorTxt.Text = "0.000342";
            this.targetErrorTxt.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Target Error";
            this.label7.Visible = false;
            // 
            // learnRateTxt
            // 
            this.learnRateTxt.Location = new System.Drawing.Point(566, 178);
            this.learnRateTxt.Name = "learnRateTxt";
            this.learnRateTxt.Size = new System.Drawing.Size(100, 20);
            this.learnRateTxt.TabIndex = 17;
            this.learnRateTxt.Text = "0.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(486, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Learning Rate";
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(267, 212);
            this.outputTxt.Multiline = true;
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.ReadOnly = true;
            this.outputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTxt.Size = new System.Drawing.Size(244, 158);
            this.outputTxt.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "The Output";
            // 
            // BackPropagation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 382);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.outputTxt);
            this.Controls.Add(this.learnRateTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.targetErrorTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.trainingOutputTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trainingInputTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.correctedWeightTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.hiddenLayertxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputLayertxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputLayertxt);
            this.Controls.Add(this.label1);
            this.Name = "BackPropagation";
            this.Text = "BackPropagation ANN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputLayertxt;
        private System.Windows.Forms.TextBox outputLayertxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hiddenLayertxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.TextBox correctedWeightTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox trainingInputTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox trainingOutputTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox targetErrorTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox learnRateTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox outputTxt;
        private System.Windows.Forms.Label label9;
    }
}

