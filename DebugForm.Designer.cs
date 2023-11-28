namespace LSystemsDemo
{
    partial class DebugForm
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
            label1 = new Label();
            lblBracketDepths = new Label();
            lblTrueBracketDepth = new Label();
            label3 = new Label();
            lblTransformationCount = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 0;
            label1.Text = "Bracket Depths:";
            // 
            // lblBracketDepths
            // 
            lblBracketDepths.AutoSize = true;
            lblBracketDepths.Location = new Point(14, 32);
            lblBracketDepths.Name = "lblBracketDepths";
            lblBracketDepths.Size = new Size(0, 20);
            lblBracketDepths.TabIndex = 1;
            // 
            // lblTrueBracketDepth
            // 
            lblTrueBracketDepth.AutoSize = true;
            lblTrueBracketDepth.Location = new Point(231, 32);
            lblTrueBracketDepth.Name = "lblTrueBracketDepth";
            lblTrueBracketDepth.Size = new Size(0, 20);
            lblTrueBracketDepth.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(231, 12);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 2;
            label3.Text = "True Depths:";
            // 
            // lblTransformationCount
            // 
            lblTransformationCount.AutoSize = true;
            lblTransformationCount.Location = new Point(461, 32);
            lblTransformationCount.Name = "lblTransformationCount";
            lblTransformationCount.Size = new Size(0, 20);
            lblTransformationCount.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(461, 12);
            label4.Name = "label4";
            label4.Size = new Size(168, 20);
            label4.TabIndex = 4;
            label4.Text = "Transformation Count:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(697, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(123, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = " Debug Mode";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += checkBox1_Click;
            // 
            // DebugForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 445);
            Controls.Add(checkBox1);
            Controls.Add(lblTransformationCount);
            Controls.Add(label4);
            Controls.Add(lblTrueBracketDepth);
            Controls.Add(label3);
            Controls.Add(lblBracketDepths);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DebugForm";
            Text = "DebugForm";
            Load += DebugForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblBracketDepths;
        private Label lblTrueBracketDepth;
        private Label label3;
        private Label lblTransformationCount;
        private Label label4;
        private CheckBox checkBox1;
    }
}