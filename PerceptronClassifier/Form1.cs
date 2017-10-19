using Perceptron;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerceptronClassifier
{
    public partial class Form1 : Form
    {

        List<Perceptron.Sample> samples = new List<Sample>();
        Graphics objGraphics;
        Graphics graph;

        double w1, w2, w0 = 0;
        double alpha = 0.5;
        double x0 = -1;

        int maxIterations;

        public Graphics ObjGraphics { get => objGraphics; set => objGraphics = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblLearningRate.Text = "Learning Rate: " + (double)trackLearningRate.Value / 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, iterations = 0;
            bool error = true;
            double GlobalError = 0;

            maxIterations = int.Parse(textBox1.Text);

            Random rnd = new Random();
            w0 = rnd.NextDouble();
            w1 = rnd.NextDouble();
            w2 = rnd.NextDouble();

           
                alpha = (double)trackLearningRate.Value / 1000;
                
            while(error && iterations < maxIterations)
            {
                error = false;
                for (i = 0; i < samples.Count -1; i++)
                {

                    double x1 = samples[i].X1;
                    double x2 = samples[i].X2;
                    double y;

                    if(calculateOutput(x1, x2, w0, w1, w2) < 0)
                    {
                        y = -1;
                    }
                    else
                    {
                        y = 1;
                    }
                    

                    if (y != samples[i].Class)
                    {
                        error = true;

                        w0 += alpha * (samples[i].Class - y) * x0 /2;         // local error? 
                        w1 += alpha * (samples[i].Class - y) * x1 /2;
                        w2 += alpha * (samples[i].Class - y) * x2 /2;
                    }

                    Console.WriteLine(samples[i].Class - y);

                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                textBox2.Text += w0;
                textBox3.Text += w1;
                textBox4.Text += w2;
                textBox5.Text += iterations;
                objGraphics.Clear(Color.White);
                DrawSeparationLine();
                iterations++;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Sample sample;
            Pen pen;

            double posX = (double)(e.X - panel1.Width / 2) / 10;
            double posY = (double)(panel1.Height / 2 - e.Y) / 10;

            if (e.Button == MouseButtons.Left)
            {
                pen = new Pen(Color.Blue);
                sample = new Sample(posX, posY, 1);
            }
            else
            {
                pen = new Pen(Color.Red);
                sample = new Sample(posX, posY, -1);
            }
            samples.Add(sample);

            ObjGraphics.DrawLine(pen, new Point(e.X - 3, e.Y), new Point(e.X + 3, e.Y));
            ObjGraphics.DrawLine(pen, new Point(e.X, e.Y - 3), new Point(e.X, e.Y + 3));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objGraphics = panel1.CreateGraphics();
            graph = panel1.CreateGraphics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            samples.Clear();
            objGraphics.Clear(Color.White);

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private double calculateOutput(double x1, double x2, double w0, double w1, double w2) // przewidywany output
        {
            double output;
            output = (w1 * x1) + (w2 * x2) - w0;

            return output;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DrawSeparationLine()
        {
            objGraphics.DrawLine(new Pen(Color.Gainsboro), new Point(0, panel1.Height / 2), new Point(panel1.Width, panel1.Height / 2));
            objGraphics.DrawLine(new Pen(Color.Gainsboro), new Point(panel1.Width / 2, 0), new Point(panel1.Width / 2, panel1.Height));

            Pen pen = new Pen(Color.DarkGreen);
            double x1;

            x1 = -10;
            double y = -(x1 * w1 / w2) - ((x0 * w0) / w2);

            double shift = panel1.Height / 2;


            Point p1 = new Point(0, (int)(shift - y * 10));

            x1 = 10;
            double y2 = -(x1 * w1 / w2) + ((w0) / w2);

            Point p2 = new Point(panel1.Width, (int)(shift - y2 * 10));
            if (w2 != 0)
            {
                objGraphics.DrawLine(pen, p1, p2);
                DrawSamples();
            }
        }

        private void DrawSamples()
        {
            foreach (Sample sample in samples)
            {

                double posX = (panel1.Width / 2) + sample.X1 * 10;
                double posY = (panel1.Height / 2) - sample.X2 * 10;

                Pen pen;
                if (sample.Class == 1)
                {
                    pen = new Pen(Color.Blue);
                }
                else
                {
                    pen = new Pen(Color.Red);
                }

                objGraphics.DrawLine(pen, new Point((int)posX - 3, (int)posY), new Point((int)posX + 3, (int)posY));
                objGraphics.DrawLine(pen, new Point((int)posX, (int)posY - 3), new Point((int)posX, (int)posY + 3));
            }
        }

    }
}
