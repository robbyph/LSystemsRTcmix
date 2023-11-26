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

        public DebugForm(List<int> bracketDepths, List<int> trueBracketDepths)
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
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }
    }
}
