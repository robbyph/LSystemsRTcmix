using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSystemsDemo
{
    public partial class DebugForm : Form
    {
        private List<int> myBracketDepths;
        private bool isDebugMode;

        public DebugForm(List<int> bracketDepths, List<int> trueBracketDepths, int transformationCount)
        {
            InitializeComponent();
            myBracketDepths = bracketDepths;
            for (int i = 0; i < myBracketDepths.Count; i++)
            {
                lblBracketDepths.Text += ("Node " + i + ": " + myBracketDepths[i] + '\n');
            }
            for (int i = 0; i < trueBracketDepths.Count; i++)
            {
                lblTrueBracketDepth.Text += ("Node " + i + ": " + trueBracketDepths[i] + '\n');
            }
            lblTransformationCount.Text = "Transformation Count: " + transformationCount;
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }

        public bool getDebugMode()
        {
            return isDebugMode;
        }

        public void updateForm(List<int> bracketDepths, List<int> trueBracketDepths, int transformationCount)
        {
            myBracketDepths = bracketDepths;
            lblBracketDepths.Text = "";
            for (int i = 0; i < myBracketDepths.Count; i++)
            {
                lblBracketDepths.Text += ("Node " + i + ": " + myBracketDepths[i] + '\n');
            }
            lblTrueBracketDepth.Text = "";
            for (int i = 0; i < trueBracketDepths.Count; i++)
            {
                lblTrueBracketDepth.Text += ("Node " + i + ": " + trueBracketDepths[i] + '\n');
            }
            lblTransformationCount.Text = "Transformation Count: " + transformationCount;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isDebugMode = true;
            }
            else
            {
                isDebugMode = false;
            }
        }
    }
}
