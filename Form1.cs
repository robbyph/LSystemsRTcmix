using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace LSystemsDemo
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private PointF currentGraphicalPosition;
        private Stack<(PointF, float)> stack = new Stack<(PointF, float)>(); // Stack to save state

        private string axiom = "F";  // Hardcoded axioms
        Dictionary<char, string>[] rulePresets = [
                new Dictionary<char, string>{
                    { 'F', "FF+[+F-F-F]-[-F+F+F]" }
                },
                new Dictionary<char, string>{
                        {'F', "F[+F]F[-F]F" }
                    },
                new Dictionary<char, string>{
                        {'F', "F[+F][-F][F]" }
                    },
                new Dictionary<char, string>{
                        {'F', "F[+F-F][-F+F][F]" }
                    },
            ];

        Dictionary<char, string> selectedPreset;
        private float branchLength = 20;
        private float branchAngle = 45;
        private float branchWidth = 1;
        private int presetSelect = 0; 
        private Pen myPen = new Pen(Color.Black, 1);

        string lastGeneratedLSystem = "";

        public Form1()
        {
            InitializeComponent();

            //Initialize the graphics object
            graphics = pictureBox.CreateGraphics();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //Get the value of the numeric up down for the amount of iterations
            int iterations = (int)IterationsNumericUpDown.Value;
            int preset = presetSelect;
      
            try
            {
                selectedPreset = rulePresets[preset];
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a Valid Preset");
                return;
            }

            //Generate the L-System
            string lSystem = GenerateLSystem(axiom, iterations);
            lastGeneratedLSystem = lSystem;

            graphics.Clear(Color.White);

            //Render the L-System to the picture box
            RenderLSystem(lSystem);

            generateRTCMix();
        }

        private string GenerateLSystem(string axiom, int iterations)
        {
            string result = axiom;

            for (int i = 0; i < iterations; i++)
            {
                StringBuilder nextResult = new StringBuilder();
                foreach (char c in result)
                {
                    if (selectedPreset.ContainsKey(c))
                    {
                        nextResult.Append(selectedPreset[c]);
                    }
                    else
                    {
                        nextResult.Append(c);
                    }
                }
                result = nextResult.ToString();
            }

            return result;
        }


        private void RenderLSystem(string lSystem)
        {
            float stepLength = branchLength; // Adjust as needed
            float angleIncrement = branchAngle; // Adjust as needed

            var currentPosition = new PointF(pictureBox.Width / 2, 0);

            float initialAngle = 90; // Adjust as needed
            float angle = initialAngle * (float)Math.PI / 180; // Convert to radians

            foreach (char c in lSystem)
            {
                switch (c)
                {
                    case 'F': // Move forward
                        PointF newPosition = new PointF(currentPosition.X + stepLength * (float)Math.Cos(angle), currentPosition.Y + stepLength * (float)Math.Sin(angle));
                        graphics.DrawLine(myPen, currentPosition, newPosition);
                        currentPosition = newPosition;
                        break;
                    case '+': // branch right
                        angle += angleIncrement * (float)Math.PI / 180; // Convert to radians
                        break;
                    case '-': // branch left
                        angle -= angleIncrement * (float)Math.PI / 180;
                        break;
                    case '[': // Push current state to the stack
                        stack.Push((currentPosition, angle));
                        break;
                    case ']': // Pop state from the stack
                        (currentPosition, angle) = stack.Pop();
                        break;
                }
            }

        }

        private bool isDragging = false;
        private Point lastPosition;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastPosition = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.Location.X - lastPosition.X;
                int deltaY = e.Location.Y - lastPosition.Y;

                graphics.TranslateTransform(deltaX, deltaY);
                graphics.Clear(Color.White);
                RenderLSystem(lastGeneratedLSystem);
                lastPosition = e.Location; // Added to update lastPosition
            }
        }


        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            int pointerOffsetX = e.X - pictureBox.Location.X;
            int pointerOffsetY = e.Y - pictureBox.Location.Y;

            float zoomFactor;

            if (e.Delta > 0)
            {
                zoomFactor = 1.1f;

            }
            else if (e.Delta < 0)
            {
                zoomFactor = 0.9f;
            }
            else
            {
                return;
            }


            //translate the graphics object to the pointer position, scale, and translate back
            graphics.TranslateTransform(pointerOffsetX, pointerOffsetY);
            graphics.ScaleTransform(zoomFactor, zoomFactor);
            graphics.TranslateTransform(-pointerOffsetX, -pointerOffsetY);

            //pictureBox.Invalidate();
            //clear the graphics object
            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }



        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            lastPosition = new Point();
        }

        private void branchLengthTrackbar_Scroll(object sender, EventArgs e)
        {
            branchLength = branchLengthTrackbar.Value;
            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }

        private void branchAngleTrackbar_Scroll(object sender, EventArgs e)
        {
            branchAngle = branchAngleTrackbar.Value;
            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }

        private void generateRTCMix()
        {
            StringBuilder sb = new StringBuilder("../../../Output/RTCMixOutput - " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");
            StreamWriter writer = new StreamWriter(sb.ToString());
            writer.WriteLine("rtsetparams(44100,2)");
            writer.WriteLine("load(\"WAVETABLE\")");
            writer.WriteLine("ampenv = maketable(\"wave\", 1000, \"saw\")");
            writer.Close();

        }

        private void branchWidthTrackbar_Scroll(object sender, EventArgs e)
        {
            branchWidth = branchWidthTrackbar.Value;
            myPen = new Pen(Color.Black, branchWidth);

            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }

        private void presetsTrackbar_Scroll(object sender, EventArgs e)
        {
            presetSelect = presetsTrackbar.Value;
            string lSystem = GenerateLSystem(axiom, (int)IterationsNumericUpDown.Value);
            lastGeneratedLSystem = lSystem;
            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }
    }
}