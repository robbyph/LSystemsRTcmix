﻿namespace LSystemsDemo
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
            label1.Location = new Point(997, 16);
            label1.Name = "label1";
            label1.Size = new Size(89, 32);
            label1.TabIndex = 1;
            label1.Text = "Presets";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(997, 117);
            label2.Name = "label2";
            label2.Size = new Size(113, 32);
            label2.TabIndex = 2;
            label2.Text = "Iterations";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(997, 421);
            label3.Name = "label3";
            label3.Size = new Size(168, 32);
            label3.TabIndex = 3;
            label3.Text = "Branch Length";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(997, 219);
            label4.Name = "label4";
            label4.Size = new Size(67, 32);
            label4.TabIndex = 4;
            label4.Text = "Seed";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(997, 320);
            label5.Name = "label5";
            label5.Size = new Size(117, 32);
            label5.TabIndex = 5;
            label5.Text = "Variability";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(997, 523);
            label6.Name = "label6";
            label6.Size = new Size(156, 32);
            label6.TabIndex = 6;
            label6.Text = "Branch Angle";
            // 
            // presetsTrackbar
            // 
            presetsTrackbar.Location = new Point(997, 53);
            presetsTrackbar.Margin = new Padding(3, 4, 3, 4);
            presetsTrackbar.Name = "presetsTrackbar";
            presetsTrackbar.Size = new Size(119, 56);
            presetsTrackbar.TabIndex = 7;
            presetsTrackbar.Scroll += presetsTrackbar_Scroll;
            // 
            // seedTrackbar
            // 
            seedTrackbar.Location = new Point(997, 256);
            seedTrackbar.Margin = new Padding(3, 4, 3, 4);
            seedTrackbar.Name = "seedTrackbar";
            seedTrackbar.Size = new Size(119, 56);
            seedTrackbar.TabIndex = 9;
            // 
            // variabilityTrackbar
            // 
            variabilityTrackbar.Location = new Point(997, 357);
            variabilityTrackbar.Margin = new Padding(3, 4, 3, 4);
            variabilityTrackbar.Name = "variabilityTrackbar";
            variabilityTrackbar.Size = new Size(119, 56);
            variabilityTrackbar.TabIndex = 10;
            // 
            // branchLengthTrackbar
            // 
            branchLengthTrackbar.Location = new Point(997, 459);
            branchLengthTrackbar.Margin = new Padding(3, 4, 3, 4);
            branchLengthTrackbar.Maximum = 100;
            branchLengthTrackbar.Minimum = 1;
            branchLengthTrackbar.Name = "branchLengthTrackbar";
            branchLengthTrackbar.Size = new Size(119, 56);
            branchLengthTrackbar.TabIndex = 11;
            branchLengthTrackbar.Value = 20;
            branchLengthTrackbar.Scroll += branchLengthTrackbar_Scroll;
            // 
            // branchAngleTrackbar
            // 
            branchAngleTrackbar.Location = new Point(997, 560);
            branchAngleTrackbar.Margin = new Padding(3, 4, 3, 4);
            branchAngleTrackbar.Maximum = 360;
            branchAngleTrackbar.Minimum = -360;
            branchAngleTrackbar.Name = "branchAngleTrackbar";
            branchAngleTrackbar.Size = new Size(119, 56);
            branchAngleTrackbar.TabIndex = 12;
            branchAngleTrackbar.Value = 45;
            branchAngleTrackbar.Scroll += branchAngleTrackbar_Scroll;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1002, 764);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(122, 49);
            button1.TabIndex = 13;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += GenerateButton_Click;
            // 
            // IterationsNumericUpDown
            // 
            IterationsNumericUpDown.Location = new Point(1002, 155);
            IterationsNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            IterationsNumericUpDown.Name = "IterationsNumericUpDown";
            IterationsNumericUpDown.Size = new Size(137, 27);
            IterationsNumericUpDown.TabIndex = 14;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(-3, 1);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(973, 891);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseWheel += pictureBox_MouseWheel;
            // 
            // branchWidthTrackbar
            // 
            branchWidthTrackbar.Location = new Point(1002, 656);
            branchWidthTrackbar.Margin = new Padding(3, 4, 3, 4);
            branchWidthTrackbar.Name = "branchWidthTrackbar";
            branchWidthTrackbar.Size = new Size(119, 56);
            branchWidthTrackbar.TabIndex = 16;
            branchWidthTrackbar.Scroll += branchWidthTrackbar_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1002, 619);
            label7.Name = "label7";
            label7.Size = new Size(158, 32);
            label7.TabIndex = 15;
            label7.Text = "Branch Width";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 897);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "MainForm";
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
    }
}