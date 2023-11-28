namespace LSystemsDemo
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            presetsTrackbar = new TrackBar();
            seedTrackbar = new TrackBar();
            variabilityTrackbar = new TrackBar();
            branchLengthTrackbar = new TrackBar();
            branchAngleTrackbar = new TrackBar();
            button1 = new Button();
            IterationsNumericUpDown = new NumericUpDown();
            pictureBox = new PictureBox();
            branchWidthTrackbar = new TrackBar();
            label7 = new Label();
            button2 = new Button();
            label8 = new Label();
            rootComboBox = new ComboBox();
            scaleComboBox = new ComboBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)presetsTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seedTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)variabilityTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)branchLengthTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)branchAngleTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IterationsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)branchWidthTrackbar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(872, 12);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 1;
            label1.Text = "Presets";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(872, 88);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 2;
            label2.Text = "Iterations";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(872, 316);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 3;
            label3.Text = "Branch Length";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(872, 164);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 4;
            label4.Text = "Seed";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(872, 240);
            label5.Name = "label5";
            label5.Size = new Size(96, 25);
            label5.TabIndex = 5;
            label5.Text = "Variability";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(872, 392);
            label6.Name = "label6";
            label6.Size = new Size(125, 25);
            label6.TabIndex = 6;
            label6.Text = "Branch Angle";
            // 
            // presetsTrackbar
            // 
            presetsTrackbar.Location = new Point(872, 40);
            presetsTrackbar.Name = "presetsTrackbar";
            presetsTrackbar.Size = new Size(104, 45);
            presetsTrackbar.TabIndex = 7;
            presetsTrackbar.Scroll += presetsTrackbar_Scroll;
            // 
            // seedTrackbar
            // 
            seedTrackbar.Enabled = false;
            seedTrackbar.Location = new Point(872, 192);
            seedTrackbar.Name = "seedTrackbar";
            seedTrackbar.Size = new Size(104, 45);
            seedTrackbar.TabIndex = 9;
            // 
            // variabilityTrackbar
            // 
            variabilityTrackbar.Enabled = false;
            variabilityTrackbar.Location = new Point(872, 268);
            variabilityTrackbar.Name = "variabilityTrackbar";
            variabilityTrackbar.Size = new Size(104, 45);
            variabilityTrackbar.TabIndex = 10;
            // 
            // branchLengthTrackbar
            // 
            branchLengthTrackbar.Location = new Point(872, 344);
            branchLengthTrackbar.Maximum = 100;
            branchLengthTrackbar.Minimum = 1;
            branchLengthTrackbar.Name = "branchLengthTrackbar";
            branchLengthTrackbar.Size = new Size(104, 45);
            branchLengthTrackbar.TabIndex = 11;
            branchLengthTrackbar.Value = 20;
            branchLengthTrackbar.Scroll += branchLengthTrackbar_Scroll;
            // 
            // branchAngleTrackbar
            // 
            branchAngleTrackbar.Location = new Point(872, 420);
            branchAngleTrackbar.Maximum = 360;
            branchAngleTrackbar.Minimum = -360;
            branchAngleTrackbar.Name = "branchAngleTrackbar";
            branchAngleTrackbar.Size = new Size(104, 45);
            branchAngleTrackbar.TabIndex = 12;
            branchAngleTrackbar.Value = 45;
            branchAngleTrackbar.Scroll += branchAngleTrackbar_Scroll;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(877, 573);
            button1.Name = "button1";
            button1.Size = new Size(107, 37);
            button1.TabIndex = 13;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += GenerateButton_Click;
            // 
            // IterationsNumericUpDown
            // 
            IterationsNumericUpDown.Location = new Point(877, 116);
            IterationsNumericUpDown.Name = "IterationsNumericUpDown";
            IterationsNumericUpDown.Size = new Size(120, 23);
            IterationsNumericUpDown.TabIndex = 14;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(-3, 1);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(851, 668);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseWheel += pictureBox_MouseWheel;
            // 
            // branchWidthTrackbar
            // 
            branchWidthTrackbar.Location = new Point(877, 492);
            branchWidthTrackbar.Name = "branchWidthTrackbar";
            branchWidthTrackbar.Size = new Size(104, 45);
            branchWidthTrackbar.TabIndex = 16;
            branchWidthTrackbar.Scroll += branchWidthTrackbar_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(877, 464);
            label7.Name = "label7";
            label7.Size = new Size(127, 25);
            label7.TabIndex = 15;
            label7.Text = "Branch Width";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(1124, 638);
            button2.Name = "button2";
            button2.Size = new Size(83, 23);
            button2.TabIndex = 17;
            button2.Text = "debug menu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(1066, 12);
            label8.Name = "label8";
            label8.Size = new Size(50, 25);
            label8.TabIndex = 18;
            label8.Text = "Root";
            // 
            // rootComboBox
            // 
            rootComboBox.FormattingEnabled = true;
            rootComboBox.Items.AddRange(new object[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" });
            rootComboBox.Location = new Point(1066, 40);
            rootComboBox.Name = "rootComboBox";
            rootComboBox.Size = new Size(121, 23);
            rootComboBox.TabIndex = 19;
            rootComboBox.SelectedValueChanged += rootComboBox_SelectedValueChanged;
            // 
            // scaleComboBox
            // 
            scaleComboBox.FormattingEnabled = true;
            scaleComboBox.Location = new Point(1066, 115);
            scaleComboBox.Name = "scaleComboBox";
            scaleComboBox.Size = new Size(121, 23);
            scaleComboBox.TabIndex = 21;
            scaleComboBox.SelectedIndexChanged += scaleComboBox_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(1066, 87);
            label9.Name = "label9";
            label9.Size = new Size(56, 25);
            label9.TabIndex = 20;
            label9.Text = "Scale";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 673);
            Controls.Add(scaleComboBox);
            Controls.Add(label9);
            Controls.Add(rootComboBox);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(branchWidthTrackbar);
            Controls.Add(label7);
            Controls.Add(pictureBox);
            Controls.Add(IterationsNumericUpDown);
            Controls.Add(button1);
            Controls.Add(branchAngleTrackbar);
            Controls.Add(branchLengthTrackbar);
            Controls.Add(variabilityTrackbar);
            Controls.Add(seedTrackbar);
            Controls.Add(presetsTrackbar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "MainForm";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)presetsTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)seedTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)variabilityTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)branchLengthTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)branchAngleTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)IterationsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)branchWidthTrackbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TrackBar presetsTrackbar;
        private TrackBar seedTrackbar;
        private TrackBar variabilityTrackbar;
        private TrackBar branchLengthTrackbar;
        private TrackBar branchAngleTrackbar;
        private Button button1;
        private NumericUpDown IterationsNumericUpDown;
        private PictureBox pictureBox;
        private TrackBar branchWidthTrackbar;
        private Label label7;
        private Button button2;
        private Label label8;
        private ComboBox rootComboBox;
        private ComboBox scaleComboBox;
        private Label label9;
    }
}