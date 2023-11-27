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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Bracket Depths:";
            // 
            // lblBracketDepths
            // 
            lblBracketDepths.AutoSize = true;
            lblBracketDepths.Location = new Point(12, 24);
            lblBracketDepths.Name = "lblBracketDepths";
            lblBracketDepths.Size = new Size(0, 15);
            lblBracketDepths.TabIndex = 1;
            // 
            // lblTrueBracketDepth
            // 
            lblTrueBracketDepth.AutoSize = true;
            lblTrueBracketDepth.Location = new Point(202, 24);
            lblTrueBracketDepth.Name = "lblTrueBracketDepth";
            lblTrueBracketDepth.Size = new Size(0, 15);
            lblTrueBracketDepth.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(202, 9);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 2;
            label3.Text = "True Depths:";
            // 
            // lblTransformationCount
            // 
            lblTransformationCount.AutoSize = true;
            lblTransformationCount.Location = new Point(403, 24);
            lblTransformationCount.Name = "lblTransformationCount";
            lblTransformationCount.Size = new Size(0, 15);
            lblTransformationCount.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(403, 9);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 4;
            label4.Text = "Transformation Count:";
            // 
            // DebugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 334);
            Controls.Add(lblTransformationCount);
            Controls.Add(label4);
            Controls.Add(lblTrueBracketDepth);
            Controls.Add(label3);
            Controls.Add(lblBracketDepths);
            Controls.Add(label1);
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
    }
}