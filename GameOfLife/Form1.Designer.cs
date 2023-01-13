namespace GameOfLife
{
    partial class Form1
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
            this.btnRandomize = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnManual = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGameSpeed = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.rbMoore = new System.Windows.Forms.RadioButton();
            this.rbVonNeumann = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCellColor = new System.Windows.Forms.ComboBox();
            this.cbGridColor = new System.Windows.Forms.ComboBox();
            this.authorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbGameSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(534, 116);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 0;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(534, 195);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(548, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "John Conway\'s Game of Life";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(534, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Placement";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(615, 116);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 4;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(534, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Control";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(697, 481);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(615, 195);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(696, 195);
            this.btnReset.Name = "btnReset";
            this.btnReset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Game speed";
            // 
            // tbGameSpeed
            // 
            this.tbGameSpeed.Location = new System.Drawing.Point(534, 251);
            this.tbGameSpeed.Minimum = 1;
            this.tbGameSpeed.Name = "tbGameSpeed";
            this.tbGameSpeed.Size = new System.Drawing.Size(223, 45);
            this.tbGameSpeed.TabIndex = 10;
            this.tbGameSpeed.Value = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Neighborhood Type";
            // 
            // rbMoore
            // 
            this.rbMoore.AutoSize = true;
            this.rbMoore.Location = new System.Drawing.Point(534, 317);
            this.rbMoore.Name = "rbMoore";
            this.rbMoore.Size = new System.Drawing.Size(77, 19);
            this.rbMoore.TabIndex = 12;
            this.rbMoore.TabStop = true;
            this.rbMoore.Text = "Moore (8)";
            this.rbMoore.UseVisualStyleBackColor = true;
            // 
            // rbVonNeumann
            // 
            this.rbVonNeumann.AutoSize = true;
            this.rbVonNeumann.Location = new System.Drawing.Point(617, 317);
            this.rbVonNeumann.Name = "rbVonNeumann";
            this.rbVonNeumann.Size = new System.Drawing.Size(118, 19);
            this.rbVonNeumann.TabIndex = 13;
            this.rbVonNeumann.TabStop = true;
            this.rbVonNeumann.Text = "Von Neumann (4)";
            this.rbVonNeumann.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(533, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Appearnace";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cell color";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(534, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Grid color";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbCellColor
            // 
            this.cbCellColor.FormattingEnabled = true;
            this.cbCellColor.Location = new System.Drawing.Point(597, 393);
            this.cbCellColor.Name = "cbCellColor";
            this.cbCellColor.Size = new System.Drawing.Size(121, 23);
            this.cbCellColor.TabIndex = 17;
            // 
            // cbGridColor
            // 
            this.cbGridColor.FormattingEnabled = true;
            this.cbGridColor.Location = new System.Drawing.Point(597, 426);
            this.cbGridColor.Name = "cbGridColor";
            this.cbGridColor.Size = new System.Drawing.Size(121, 23);
            this.cbGridColor.TabIndex = 18;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(617, 60);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(38, 15);
            this.authorLabel.TabIndex = 19;
            this.authorLabel.Text = "label9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 516);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.cbGridColor);
            this.Controls.Add(this.cbCellColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbVonNeumann);
            this.Controls.Add(this.rbMoore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbGameSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRandomize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbGameSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRandomize;
        private Button btnStart;
        private Label label1;
        private Label label2;
        private Button btnManual;
        private Label label3;
        private Button btnExit;
        private Button btnPause;
        private Button btnReset;
        private Label label4;
        private TrackBar tbGameSpeed;
        private Label label5;
        private RadioButton rbMoore;
        private RadioButton rbVonNeumann;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cbCellColor;
        private ComboBox cbGridColor;
        private Label authorLabel;
    }
}