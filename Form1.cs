using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Bach.Model;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using LSystemsDemo;


namespace LSystemsDemo
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private PointF currentGraphicalPosition;
        private Stack<(PointF, float)> stack = new Stack<(PointF, float)>(); // Stack to save state
        private float timeTracker = 0;
        private float[] durations = [0.25f, 0.25f, 0.25f, 0.25f, 0.5f, 0.5f, 1];
        private int bracketDepth = 0;
        private int previousBracketDepth = 0;
        private List<int> bracketDepths = new List<int>();
        private int trueDepth = 0;
        private List<int> trueDepths = new List<int>();
        private List<MusicalEvent> musicalEvents = new List<MusicalEvent>();
        private int transformationCount = 0;
        private PitchClass rootNote = PitchClass.C;
        DebugForm debugForm;

        private StringBuilder sbDebug;
        private StreamWriter debugWriter;

        //motifs dictionary
        private List<MusicalEvent>[] motifs = new List<MusicalEvent>[100];


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


        public Form1()
        {
            InitializeComponent();

            //Initialize the graphics object
            graphics = pictureBox.CreateGraphics();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void initializeSystem()
        {
            //clear the musical events list
            musicalEvents.Clear();

            //clear both depths lists
            bracketDepths.Clear();
            trueDepths.Clear();
            bracketDepth = 0;
            trueDepth = 0;

            timeTracker = 0;

            //clear the motifs list
            motifs = new List<MusicalEvent>[100];
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            sbDebug = new StringBuilder("../../../Output/DebugOutput - " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");
            debugWriter = new StreamWriter(sbDebug.ToString());
            debugForm = new DebugForm(bracketDepths, trueDepths, transformationCount);

            //Get the value of the numeric up down for the amount of iterations
            int iterations = (int)IterationsNumericUpDown.Value;
            int preset = presetSelect;

            initializeSystem();

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

            var firstForwardMoveCompleted = false;

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

                        //Draw the letter F between the two points, accounting for offsets
                        //graphics.DrawString("F", new Font("Arial", 8), Brushes.Black, (currentPosition.X + newPosition.X) / 2, (currentPosition.Y + newPosition.Y) / 2);

                        currentPosition = newPosition;

                        //adjust the depth 
                        if (bracketDepth == 0)
                        {
                            if (firstForwardMoveCompleted == false)
                            {
                                firstForwardMoveCompleted = true;
                            }
                            else
                            {
                                trueDepth++;
                            }
                        }

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
                        bracketDepth++;
                        trueDepth++;
                        break;
                    case ']': // Pop state from the stack
                        (currentPosition, angle) = stack.Pop();
                        bracketDepth--;
                        trueDepth--;
                        break;
                }
            }

        }

        private void GenerateMotif()
        {
            //if this motif is at the same bracket depth as the previous motif, then we need to play the same motif again, but transformed in some way
            //if this motif is at a different bracket depth than the previous motif, then we need to generate a new motif

            //if bracket depth is negative, throw an error
            if (bracketDepth < 0)
            {
                MessageBox.Show("Bracket depth is negative");
                return;
            }
            else
            {
                bracketDepths.Add(bracketDepth);
                trueDepths.Add(trueDepth);
            }


            //generate a motif
            //generate a random number of notes between 3 and 7
            Random rnd = new Random(DateTime.Now.Millisecond);

            int numberOfNotes = rnd.Next(4, 7);

            //generate a random number of rests between 1 and 5
            int numberOfRests = rnd.Next(1, 3);

            //Get our pitch set
            ScaleFormula scaleFormula = Registry.ScaleFormulas["Major"];
            Scale scale = new Scale(rootNote, scaleFormula);

            List<PitchClass> pc = new List<PitchClass>();

            //initialize tempMusicalEvents list
            List<MusicalEvent> tempMusicalEvents = new List<MusicalEvent>();

            //notes list
            List<Pitch> notes = new List<Pitch>();

            //rests list
            List<float> rests = new List<float>();


            //generate our notes
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

                //add the note to the notes list
                notes.Add(note);
            }
            //generate our rests
            for (int i = 0; i < numberOfRests; i++)
            {
                //generate a random rest
                float rest = durations[rnd.Next(0, durations.Length - 1)];

                //add the rest to the rests list
                rests.Add(rest);
            }


            //check if we already have a motif at this depth. If we do, then we need to transform it, otherwise we need to add this motif to the array, at the index of the true depth
            if (motifs[trueDepth] != null)
            {
                debugWriter.WriteLine("Transforming an existing motif\n");

                //create a deep copy of the motif
                List<MusicalEvent> tempMotif = motifs[trueDepth].ConvertAll(ev => new MusicalEvent(ev.startTime, ev.duration, ev.pitch, ev.pan));

                //transform the motif using a temp variable
                tempMotif = transformMotif(tempMotif);
                tempMusicalEvents = tempMotif;

                //add our notes and rests to the musical events list from the tempMusicalEvents list, in normal order
                foreach (MusicalEvent musicalEvent1 in tempMusicalEvents)
                {
                    musicalEvents.Add(musicalEvent1);
                }
            }
            else
            {
                debugWriter.WriteLine("Generating a new motif\n");

                //combine the notes and rests lists into a single list in random order
                List<float> tempRests = new List<float>(rests);
                List<Pitch> tempNotes = new List<Pitch>(notes);

                while (tempRests.Count > 0 || tempNotes.Count > 0)
                {
                    //generate a random number between 0 and 1
                    float random = (float)rnd.NextDouble();

                    //generate a random duration
                    float duration = durations[rnd.Next(0, durations.Length)];

                    //if random is less than 0.5, then we need to add a note, or add a note if its the first event
                    if ((random < 0.5 && tempNotes.Count > 0) || tempNotes.Count == notes.Count)
                    {
                        debugWriter.WriteLine("Adding a note\n");

                        //generate a random index between 0 and the number of notes in the tempNotes list
                        int index = rnd.Next(0, tempNotes.Count);

                        //add the note to the tempMusicalEvents list
                        tempMusicalEvents.Add(new MusicalEvent(timeTracker, duration, (float)tempNotes[index].Frequency, 0.5f));

                        //remove the note from the tempNotes list
                        tempNotes.RemoveAt(index);

                        //increment the time tracker by the duration of the last event
                        timeTracker += tempMusicalEvents[tempMusicalEvents.Count - 1].duration;

                        debugWriter.WriteLine("Added Note of duration " + tempMusicalEvents[tempMusicalEvents.Count - 1].duration + "! Time tracker at: " + timeTracker + "\n");
                    }
                    else if (random >= 0.5 && tempRests.Count > 0) //if random is greater than or equal to 0.5, then we need to add a rest
                    {
                        debugWriter.WriteLine("Adding a rest\n");

                        //generate a random index between 0 and the number of rests in the tempRests list
                        int index = rnd.Next(0, tempRests.Count);

                        //add the rest to the tempMusicalEvents list
                        tempMusicalEvents.Add(new MusicalEvent(timeTracker, tempRests[index], 0, 0.5f));

                        //remove the rest from the tempRests list
                        tempRests.RemoveAt(index);

                        //increment the time tracker by the duration of the last event
                        timeTracker += tempMusicalEvents[tempMusicalEvents.Count - 1].duration;

                        debugWriter.WriteLine("Added Rest of duration " + tempMusicalEvents[tempMusicalEvents.Count - 1].duration + "! Time tracker at: " + timeTracker + "\n");
                    }
                    else
                    {
                        debugWriter.WriteLine("Doing Nothing. Time tracker at: " + timeTracker + "\n");
                        //do nothing
                    }


                }

                //after generating the motif, make sure the same note isn't played twice in a row to keep it from sounding too repetitive. 
                for (int i = 0; i < tempMusicalEvents.Count - 1; i++)
                {
                    if (tempMusicalEvents[i].pitch == tempMusicalEvents[i + 1].pitch)
                    {
                        //generate a random note
                        PitchClassCollection pitchClasses = scale.PitchClasses;

                        PitchClass notePC;
                        Pitch note;


                        notePC = pitchClasses[rnd.Next(0, pitchClasses.Count)];

                        note = Pitch.Create(notePC, 4);

                        //change the pitch of the note
                        tempMusicalEvents[i + 1].pitch = (float)note.Frequency;

                        debugWriter.WriteLine("Changed Note! Duration: " + tempMusicalEvents[i + 1].duration + " Time tracker at: " + timeTracker + "\n");
                    }
                }

                //add the motif to the arrayf
                motifs[trueDepth] = tempMusicalEvents;

                List<MusicalEvent> parseTempEvents = new List<MusicalEvent>(tempMusicalEvents);

                //add our notes and rests in random order to the musical events list from the tempMusicalEvents list
                while (parseTempEvents.Count > 0)
                {
                    int index = rnd.Next(0, parseTempEvents.Count);
                    musicalEvents.Add(parseTempEvents[index]);
                    parseTempEvents.RemoveAt(index);
                }
            }
        }

        private List<MusicalEvent> transformMotif(List<MusicalEvent> motif)
        {
            debugWriter.WriteLine("Starting of Transforming of Motif\n");

            List<MusicalEvent> tempMotif = new List<MusicalEvent>(motif);

            //generate a random number between 0 and 2
            Random rnd = new Random();
            int transform = rnd.Next(0, 12);

            //if transform is 0 - 3, then we need to transpose the motif
            if (transform == 0 || transform == 1 || transform == 2 || transform == 3)
            {
                debugWriter.WriteLine("Transposing Motif\n");

                //generate a random number between -7 and 7
                int transpose = rnd.Next(-7, 8);

                //transpose the motif
                for (int i = 0; i < tempMotif.Count; i++)
                {
                    // create deep copy of the event
                    MusicalEvent tempEvent = tempMotif[i];

                    //transpose the pitch
                    tempEvent.pitch = tempMotif[i].pitch * (float)Math.Pow(2, transpose / 12);

                    //adjust the start time of the event
                    tempEvent.startTime = timeTracker;

                    //adjust the time tracker
                    timeTracker += tempEvent.duration;

                    debugWriter.WriteLine("Transposed Note by " + transpose + " semitones! Duration: " + tempEvent.duration + " Time tracker at: " + timeTracker + "\n");

                    //replace the event in the motif
                    tempMotif[i] = tempEvent;

                }
            }
            else if (transform == 4 || transform == 5) //if transform is 4 or 5, we will add a note to the motif
            {
                debugWriter.WriteLine("Adding a note to the motif\n");

                //generate a random note
                ScaleFormula scaleFormula = Registry.ScaleFormulas["Major"];
                Scale scale = new Scale(rootNote, scaleFormula);
                PitchClassCollection pitchClasses = scale.PitchClasses;

                PitchClass notePC;
                Pitch note;

                if (tempMotif.Count == 0)
                {
                    notePC = pitchClasses[0];
                }
                else if (tempMotif.Count == 1)
                {
                    notePC = pitchClasses[0];
                }
                else
                {
                    notePC = pitchClasses[rnd.Next(0, pitchClasses.Count)];
                }

                note = Pitch.Create(notePC, 4);

                //add the note to the motif
                tempMotif.Add(new MusicalEvent(timeTracker, durations[rnd.Next(0, durations.Length - 1)], (float)note.Frequency, 0.5f));

                //adjust the start time of all the motif events
                for (int i = 0; i < tempMotif.Count; i++)
                {
                    //create deep copy of the event
                    MusicalEvent tempEvent = tempMotif[i];

                    //adjust the start time of the event
                    tempEvent.startTime = timeTracker;

                    //adjust the time tracker
                    timeTracker += tempEvent.duration;

                    debugWriter.WriteLine("Added Note! Duration: " + tempEvent.duration + " Time tracker at: " + timeTracker + "\n");

                    tempMotif[i] = tempEvent;
                }
            }
            else if (transform == 6) //if transform is 6, then we need to retrograde the motif
            {
                debugWriter.WriteLine("Retrograding Motif\n");

                //retrograde the motif, by reversing the order of the events and making sure that the durations are correct
                tempMotif.Reverse();

                //adjust the start times of the events
                for (int i = 0; i < tempMotif.Count; i++)
                {
                    //create deep copy of the event
                    MusicalEvent tempEvent = tempMotif[i];

                    //adjust the start time of the event
                    tempEvent.startTime = timeTracker;

                    //adjust the time tracker
                    timeTracker += tempEvent.duration;

                    debugWriter.WriteLine("Retrograded Note! Duration: " + tempEvent.duration + " Time tracker at: " + timeTracker + "\n");

                    //replace the event in the motif
                    tempMotif[i] = tempEvent;
                }

            }
            else if (transform == 7 || transform == 8) //if transform is 7 or 8, we will simply change one of the notes in the motif
            {
                debugWriter.WriteLine("Changing a note in the motif\n");

                //generate a random index between 0 and the number of notes in the motif
                int index = rnd.Next(0, tempMotif.Count);

                //change the note at the index
                MusicalEvent tempEvent = tempMotif[index];

                //generate a random note
                ScaleFormula scaleFormula = Registry.ScaleFormulas["Major"];
                Scale scale = new Scale(rootNote, scaleFormula);
                PitchClassCollection pitchClasses = scale.PitchClasses;

                PitchClass notePC;
                Pitch note;

                do
                {
                    if (index == 0)
                    {
                        notePC = pitchClasses[0];
                    }
                    else if (index == tempMotif.Count - 1)
                    {
                        notePC = pitchClasses[0];
                    }
                    else
                    {
                        notePC = pitchClasses[rnd.Next(0, pitchClasses.Count)];
                    }

                    note = Pitch.Create(notePC, 4);

                } while (tempEvent.pitch == note.Frequency); //making sure that the new note is different from the original note

                //change the pitch of the note
                tempEvent.pitch = (float)note.Frequency;

                debugWriter.WriteLine(
                    "Changed Note! Duration: " + tempEvent.duration + " Time tracker at: " + timeTracker + "\n");

                tempMotif[index] = tempEvent;

                //adjust the start time of all the motif events
                for (int i = 0; i < tempMotif.Count; i++)
                {
                    //create deep copy of the event
                    MusicalEvent tempEvent2 = tempMotif[i];

                    //adjust the start time of the event
                    tempEvent2.startTime = timeTracker;

                    //adjust the time tracker
                    timeTracker += tempEvent2.duration;

                    debugWriter.WriteLine("Changed Note! Duration: " + tempEvent2.duration + " Time tracker at: " + timeTracker + "\n");

                    tempMotif[i] = tempEvent2;
                }
            }
            else if (transform == 9) //if transform is 9, we will remove a note from the transformed motif
            {
                debugWriter.WriteLine("Removing a note from the motif\n");

                //generate a random index between 0 and the number of notes in the motif
                int index = rnd.Next(0, tempMotif.Count);

                //remove the note at the index
                MusicalEvent tempEvent = tempMotif[index];

                //remove the note from the motif
                tempMotif.RemoveAt(index);

                //adjust the start time of all the motif events
                for (int i = 0; i < tempMotif.Count; i++)
                {
                    //create deep copy of the event
                    MusicalEvent tempEvent2 = tempMotif[i];

                    //adjust the start time of the event
                    tempEvent2.startTime = timeTracker;

                    //adjust the time tracker
                    timeTracker += tempEvent2.duration;

                    debugWriter.WriteLine("Removed Note! Duration: " + tempEvent2.duration + " Time tracker at: " + timeTracker + "\n");

                    tempMotif[i] = tempEvent2;
                }
            }
            else if (transform == 10 || transform == 11) //if the transform is 10 or 11, change 2 notes in the motif
            {
                debugWriter.WriteLine("Changing 2 notes in the motif\n");

                //generate a random index between 0 and the number of notes in the motif
                int index1 = rnd.Next(0, tempMotif.Count);
                int index2 = rnd.Next(0, tempMotif.Count);

                //change the note at the index
                MusicalEvent tempEvent1 = tempMotif[index1];
                MusicalEvent tempEvent2 = tempMotif[index2];

                //generate a random note
                ScaleFormula scaleFormula = Registry.ScaleFormulas["Major"];
                Scale scale = new Scale(rootNote, scaleFormula);
                PitchClassCollection pitchClasses = scale.PitchClasses;

                PitchClass notePC;
                Pitch note;

                do
                {
                    if (index1 == 0)
                    {
                        notePC = pitchClasses[0];
                    }
                    else if (index1 == tempMotif.Count - 1)
                    {
                        notePC = pitchClasses[0];
                    }
                    else
                    {
                        notePC = pitchClasses[rnd.Next(0, pitchClasses.Count)];
                    }

                    note = Pitch.Create(notePC, 4);

                } while (tempEvent1.pitch == note.Frequency); //making sure that the new note is different from the original note

                //change the pitch of the note
                tempEvent1.pitch = (float)note.Frequency;

                debugWriter.WriteLine(
                                       "Changed Note! Duration: " + tempEvent1.duration + " Time tracker at: " + timeTracker + "\n");

                tempMotif[index1] = tempEvent1;


                PitchClass notePC2;
                Pitch note2;

                do
                {
                    if (index2 == 0)
                    {
                        notePC2 = pitchClasses[0];
                    }
                    else if (index2 == tempMotif.Count - 1)
                    {
                        notePC2 = pitchClasses[0];
                    }
                    else
                    {
                        notePC2 = pitchClasses[rnd.Next(0, pitchClasses.Count)];
                    }

                    note2 = Pitch.Create(notePC2, 4);

                } while (tempEvent2.pitch == note2.Frequency); //making sure that the new note is different from the original note

                //change the pitch of the note
                tempEvent2.pitch = (float)note2.Frequency;

                debugWriter.WriteLine(
                                                          "Changed Note! Duration: " + tempEvent2.duration + " Time tracker at: " + timeTracker + "\n");

                tempMotif[index2] = tempEvent2;

            }


            transformationCount++;
            return tempMotif;
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

            //label the leaf with its order in the tree
            if (debugForm.getDebugMode())
            {
                g.DrawString(trueDepth.ToString(), new Font("Arial", 8), Brushes.Black, position.X - 5, position.Y - 5);
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
                initializeSystem();
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
            initializeSystem();
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
            initializeSystem();
            RenderLSystem(lastGeneratedLSystem);
        }

        private void branchAngleTrackbar_Scroll(object sender, EventArgs e)
        {
            branchAngle = branchAngleTrackbar.Value;
            graphics.Clear(Color.White);
            initializeSystem();
            RenderLSystem(lastGeneratedLSystem);
        }

        private void generateRTCMix()
        {
            //first, sort the musical events list by start time, so that the events are in the correct order
            musicalEvents.Sort((x, y) => x.startTime.CompareTo(y.startTime));

            //generate the rtcmix code for each musical event into a new list of strings that we can write to a file
            List<string> outputEvents = new List<string>();

            float droneLength = musicalEvents[musicalEvents.Count - 1].startTime + musicalEvents[musicalEvents.Count - 1].duration;

            //get the pitch and pitch class of the root note 2 octaves below middle C
            Pitch rootPitch = Pitch.Create(rootNote, 2);
            float rootFrequency = (float)rootPitch.Frequency;

            //force the pitch of the last note to be the root pitch, in the middle octave
            Pitch finalPitch = Pitch.Create(rootNote, 4);
            float finalFrequency = (float)finalPitch.Frequency;
            musicalEvents[musicalEvents.Count - 1].pitch = finalFrequency;

            foreach (MusicalEvent musicalEvent in musicalEvents)
            {
                outputEvents.Add(musicalEvent.outputRTCMix());
            }

            //generate the RTcmix file
            StringBuilder sb = new StringBuilder("../../../Output/RTCMixOutput - " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");
            StreamWriter writer = new StreamWriter(sb.ToString());
            writer.WriteLine("rtsetparams(44100,2)");
            writer.WriteLine("load(\"WAVETABLE\")");
            writer.WriteLine("ampenv = maketable(\"wave\", 1000, \"saw20\")");
            writer.WriteLine("droneenv = maketable(\"wave\", 1000, \"square10\")");
            writer.WriteLine("WAVETABLE(0, " + droneLength.ToString() + ", 1700, " + rootFrequency + ", 0.5, droneenv)");
            foreach (string s in outputEvents)
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
            initializeSystem();
            RenderLSystem(lastGeneratedLSystem);
        }

        private void presetsTrackbar_Scroll(object sender, EventArgs e)
        {
            presetSelect = presetsTrackbar.Value;
            string lSystem = GenerateLSystem(selectedPreset.axiom, (int)IterationsNumericUpDown.Value);
            lastGeneratedLSystem = lSystem;
            graphics.Clear(Color.White);
            initializeSystem();
            RenderLSystem(lastGeneratedLSystem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //opens a new form to view debug info
            debugForm = new DebugForm(bracketDepths, trueDepths, transformationCount);
            debugForm.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            debugWriter.Close();
        }
    }
}

/*
// Unused inversion code
debugWriter.WriteLine("Inverting Motif\n");

//invert the motif
for (int i = 0; i < tempMotif.Count; i++)
{

    //create deep copy of the event
    MusicalEvent tempEvent = tempMotif[i];

    //invert the frequency around the root and prevent rests from being inverted
    if (tempEvent.pitch == 0 || tempEvent.amplitude == 0)
    {

    }
    else
    {
        //invert the interval around the root
        float rootFrequency = (float)Pitch.Create(rootNote, 4).Frequency;
        //tempEvent.pitch = freq * 2 - tempMotif[i].pitch;

        // Calculate the ratio of the note's frequency to the root's frequency
        float ratio = tempEvent.pitch / rootFrequency;

        // Invert the ratio to find the interval below the root
        float invertedRatio = 1 / ratio;

        // Multiply the root's frequency by the inverted ratio to get the frequency of the inverted note
        float invertedNoteFrequency = rootFrequency * invertedRatio;

        tempEvent.pitch = invertedNoteFrequency;

        float midiNoteNumber = (float)(69 + 12 * (Math.Log(tempEvent.pitch / 440, 2)));
        Pitch rootPitch = Pitch.Create(rootNote, 4);
        float rootMidiNoteNumber = (float)(69 + 12 * (Math.Log((float)rootPitch.Frequency / 440, 2)));
        float interval = Math.Abs(midiNoteNumber - rootMidiNoteNumber);

        float newMidiNoteNumber = 0;


        if (midiNoteNumber > rootMidiNoteNumber) //if the note is above the root
        {
            newMidiNoteNumber = rootMidiNoteNumber - (interval * 2);

        }
        else if (midiNoteNumber < rootMidiNoteNumber) //if the note is below the root
        {
            newMidiNoteNumber = rootMidiNoteNumber + (interval * 2);
        }else 
        {
            //do nothing
        }



    }

    //adjust the start time of the event
    tempEvent.startTime = timeTracker;

    //adjust the time tracker
    timeTracker += tempEvent.duration;

    debugWriter.WriteLine("Inverted Note! Duration: " + tempEvent.duration + " Time tracker at: " + timeTracker + "\n");

    //replace the event in the motif
    tempMotif[i] = tempEvent;

} */