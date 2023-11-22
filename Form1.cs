using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Bach.Model;


namespace LSystemsDemo
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private PointF currentGraphicalPosition;
        private Stack<(PointF, float)> stack = new Stack<(PointF, float)>(); // Stack to save state
        private float timeTracker = 0;
        private float[] durations = [0.25f, 0.5f, 1];


        //create a class called preset, which contains a string called axiom and a Dictionary<char, string> called rules
        class Preset
        {
            public string axiom;
            public Dictionary<char, string> rules;

            //constructor
            public Preset(string axiom, Dictionary<char, string> rules)
            {
                this.axiom = axiom;
                this.rules = rules;
            }
        }

        //create an array of preset objects, populated with the hardcoded presets
        readonly Preset[] presets = new Preset[]
        {
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F]F" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "FF-[-F+F+F]+[+F-F-F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "FF+[+F-F-F]-[-F+F+F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+FF][-FF]F[-F][+F]F" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F][-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F-F][-F+F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F][+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } }),
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } })
        };

        Preset selectedPreset =
            new Preset("F", new Dictionary<char, string> { { 'F', "F[+F]F[-F][F]" } });

        private float branchLength = 20;
        private float branchAngle = 30;
        private float branchWidth = 1;
        private int presetSelect = 0;
        private Pen myPen = new Pen(Color.Black, 1);

        string lastGeneratedLSystem = "";

        List<string> musicalEvents = new List<string>();

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

            //clear the musical events list
            musicalEvents.Clear();

            timeTracker = 0;

            try
            {
                selectedPreset = presets[preset];
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter a Valid Preset");
                return;
            }

            //Generate the L-System
            string lSystem = GenerateLSystem(selectedPreset.axiom, iterations);
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
                    if (selectedPreset.rules.ContainsKey(c))
                    {
                        nextResult.Append(selectedPreset.rules[c]);
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

            for (int i = 0; i < lSystem.Length; i++)
            {
                char c = lSystem[i];
                switch (c)
                {
                    case 'F': // Move forward
                        PointF newPosition = new PointF(
                            currentPosition.X + stepLength * (float)Math.Cos(angle),
                            currentPosition.Y + stepLength * (float)Math.Sin(angle)
                        );
                        graphics.DrawLine(myPen, currentPosition, newPosition);
                        currentPosition = newPosition;

                        // Check if this is a terminal segment
                        if (IsTerminalSegment(lSystem, i))
                        {
                            //Draw leaves
                            DrawLeaf(graphics, currentPosition);

                            //add a musical event to the musical events list
                            GenerateMotif();
                        }
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

        private void GenerateMotif()
        {
            //generate a motif
            //generate a random number of notes between 1 and 10
            Random rnd = new Random();
            int numberOfNotes = rnd.Next(4, 10);

            //generate a random number of rests between 0 and 5
            int numberOfRests = rnd.Next(1, 5);

            //Get our pitch set
            ScaleFormula scaleFormula = Registry.ScaleFormulas["Major"];
            Scale scale = new Scale(PitchClass.C, scaleFormula);

            List<PitchClass> pc = new List<PitchClass>();

            for (int i = 0; i < numberOfNotes; i++)
            {
                //generate a random note
                PitchClassCollection pitchClasses = scale.PitchClasses;

                PitchClass notePC;
                Pitch note;

                if (i == 0)
                {
                    notePC = pitchClasses[0];
                }
                else if (i == numberOfNotes - 1)
                {
                    notePC = pitchClasses[0];
                }
                else
                {
                    notePC = pitchClasses[rnd.Next(0, pitchClasses.Count)];
                }

                note = Pitch.Create(notePC, 4);

                //generate a random duration
                float duration = durations[rnd.Next(0, durations.Length)];

                //add a musical event to the musical events list
                musicalEvents.Add("WAVETABLE(" + timeTracker + "," + duration + ", 2500," + note.Frequency + ", .5, ampenv)");
                timeTracker += duration;
            }

        }

        private bool IsTerminalSegment(string lSystem, int index)
        {
            // Check if the next significant character after 'F' at the same level is ']'
            int depth = 0;
            for (int i = index + 1; i < lSystem.Length; i++)
            {
                switch (lSystem[i])
                {
                    case 'F':
                        if (depth == 0)
                        {
                            // If we encounter another 'F' at the same level, this is not terminal.
                            return false;
                        }
                        break;
                    case '[':
                        depth++;
                        if (depth > 0)
                        {
                            // If we find an opening bracket before another 'F' at the same level, this is not terminal.
                            return false;
                        }
                        break;
                    case ']':
                        depth--;
                        if (depth < 0)
                        {
                            // If we find a closing bracket before another 'F' at the same level, this is terminal.
                            return true;
                        }
                        break;
                }
            }
            // If we reach the end of the string without finding another 'F' at the same level, it's terminal.
            return depth == 0;
        }



        private void DrawLeaf(Graphics g, PointF position)
        {
            // Draw a leaf using an ellipse or a custom shape
            g.FillEllipse(Brushes.Green, position.X - 5, position.Y - 5, 10, 10);
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
            /*writer.WriteLine("freqenv = maketable(\"wave\", 1000, \"saw\")");
            writer.WriteLine("amp = 0.5");
            writer.WriteLine("freq = 440");*/
            foreach (string s in musicalEvents)
            {
                writer.WriteLine(s);
            }
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
            string lSystem = GenerateLSystem(selectedPreset.axiom, (int)IterationsNumericUpDown.Value);
            lastGeneratedLSystem = lSystem;
            graphics.Clear(Color.White);
            RenderLSystem(lastGeneratedLSystem);
        }
    }
}