using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rastrigin3D
{
    public partial class Form1 : Form
    {
        float srednia;
        float odchylenie;
        float suma_rastrigin=0;
        float roznice=0;
        int iterations;
        NeuralNetwork net = new NeuralNetwork(new int[] {3, 5, 2, 3, 1 });         // # of inputs , # of layers and neurons, na koncu output = 1
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iterations = int.Parse(textBox1.Text);
            
            Random rand = new Random();
            float[] x1 = new float[20];
            float[] x2 = new float[20];
            float[] x3 = new float[20];
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("wartosci x1:");
                x1[i] = (float)rand.NextDouble() * 4 - 2;
                Console.WriteLine(x1[i]);

                Console.WriteLine("wartosci x2:");
                x2[i] = (float)rand.NextDouble() * 4 - 2;
                Console.WriteLine(x2[i]);

                Console.WriteLine("wartosci x3:");
                x3[i] = (float)rand.NextDouble() * 4 - 2;
                Console.WriteLine(x3[i]);

                Console.WriteLine("Wartosc Rastrigin: " + Rastrigin(x1[i], x2[i], x3[i]));
                Console.WriteLine("------------------");
                suma_rastrigin += Rastrigin(x1[i], x2[i], x3[i]);
            }
            srednia = suma_rastrigin / 20;
            float temp;
            for (int i = 0; i < 20; i++)
            {
                temp = (Rastrigin(x1[i], x2[i], x3[i]) - srednia) * (Rastrigin(x1[i], x2[i], x3[i]) - srednia);
                roznice += temp;
            }
            odchylenie = (float)Math.Sqrt(roznice);

            Console.WriteLine("Srednia Rastrigin = " + srednia);
            Console.WriteLine("Odchylenie = " + odchylenie);
            for (int i = 0; i < 20; i++)
            {
                float tmp = normalizeRastrigin(Rastrigin(x1[i], x2[i], x3[i]), srednia, odchylenie);
                Console.WriteLine("Normalized rast = " + tmp);
            }
            for (int i = 0; i < iterations; i++)
            {
               //Console.WriteLine("Iteracja numer " + (i+1));
               for (int j = 0; j < 20; j++)
                {
                    net.FeedForward(new float[] { normalize(x1[j]), normalize(x2[j]), normalize(x3[j]) });
                    net.BackProp(new float[] { normalizeRastrigin(Rastrigin(x1[j], x2[j], x3[j]), srednia, odchylenie) });
                }       
                
            }
            float error;

            float error_sum = 0;

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Zestaw numer " + (i + 1));
                float tmp = normalizeRastrigin(Rastrigin(x1[i], x2[i], x3[i]), srednia, odchylenie);
                error = tmp - net.FeedForward(new float[] { x1[i], x2[i], x3[i] })[0];
                if (error < 0)
                    error = Math.Abs(error);
                Console.WriteLine("Rastrigin: " + Rastrigin(x1[i], x2[i], x3[i]) + " Normalized Rast = " + tmp + " Obliczony = " + net.FeedForward(new float[] { x1[i], x2[i], x3[i] })[0]);
                Console.WriteLine("Error = " + error);
                error_sum += error;
            }

            Console.WriteLine("Sredni error: " + error_sum / 20);
            

        }
        public float Rastrigin(float x1, float x2, float x3)
        {
            double temp;
            double A = 10;
            temp = 3 * A + (Math.Pow(x1, 2) - A * Math.Cos(2 * Math.PI * x1)) + (Math.Pow(x2, 2) - A * Math.Cos(2 * Math.PI * x2)) + (Math.Pow(x3, 2) - A * Math.Cos(2 * Math.PI * x3));

            return (float)temp;
        }
        public float normalize(float x)
        {
            int min = -2;
            int max = 2;
            float temp;

            temp = ((x - min) / (max - min)) * (0 - 1) + 1;

            return temp;
        }
        public float normalizeRastrigin(float rast, float srednia, float odchylenie)
        {
            float temp = (rast - srednia) / odchylenie;
            return temp;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Learning Rate: " + (double)trackBar1.Value / 1000;
        }
    }
}

/* net.FeedForward(new float[] { 0, 0, 0 });
                 net.BackProp(new float[] { 0 });
                 
                 net.FeedForward(new float[] { 0, 0, 1 });
                 net.BackProp(new float[] { 1 });

                 net.FeedForward(new float[] { 0, 1, 0 });
                 net.BackProp(new float[] { 1 });

                 net.FeedForward(new float[] { 0, 1, 1 });
                 net.BackProp(new float[] { 0 });

                 net.FeedForward(new float[] { 1, 0, 0 });
                 net.BackProp(new float[] { 1 });

                 net.FeedForward(new float[] { 1, 0, 1 });
                 net.BackProp(new float[] { 0 });

                 net.FeedForward(new float[] { 1, 1, 0 });
                 net.BackProp(new float[] { 0 });

                 net.FeedForward(new float[] { 1, 1, 1 });
                 net.BackProp(new float[] { 1 });
                net.FeedForward(new float[] { 0, 0, 0 });
                net.BackProp(new float[] { Rastrigin(0, 0, 0) });

                net.FeedForward(new float[] { 0, 0, 1 });
                net.BackProp(new float[] { Rastrigin(0, 0, 1) });

                net.FeedForward(new float[] { 0, 1, 0 });
                net.BackProp(new float[] { Rastrigin(0, 1, 0) });

                net.FeedForward(new float[] { 0, 1, 1 });
                net.BackProp(new float[] { Rastrigin(0, 1, 1) });

                net.FeedForward(new float[] { 1, 0, 0 });
                net.BackProp(new float[] { Rastrigin(1, 0, 0) });

                net.FeedForward(new float[] { 1, 0, 1 });
                net.BackProp(new float[] { Rastrigin(1, 0, 1) });

                net.FeedForward(new float[] { 1, 1, 0 });
                net.BackProp(new float[] { Rastrigin(1, 1, 0) });

                net.FeedForward(new float[] { 1, 1, 1 });
                net.BackProp(new float[] { Rastrigin(1, 1, 1) });
                */
/* Console.WriteLine(Rastrigin(0, 0, 0));
Console.WriteLine(net.FeedForward(new float[] { 0, 0, 0 })[0]);
Console.WriteLine(Rastrigin(0, 0, 1));
Console.WriteLine(net.FeedForward(new float[] { 0, 0, 1 })[0]);
Console.WriteLine(Rastrigin(0, 1, 0));
Console.WriteLine(net.FeedForward(new float[] { 0, 1, 0 })[0]);
Console.WriteLine(Rastrigin(0, 1, 1));
Console.WriteLine(net.FeedForward(new float[] { 0, 1, 1 })[0]);
Console.WriteLine(Rastrigin(1, 0, 0));
Console.WriteLine(net.FeedForward(new float[] { 1, 0, 0 })[0]);
Console.WriteLine(Rastrigin(1, 0, 1));
Console.WriteLine(net.FeedForward(new float[] { 1, 0, 1 })[0]);
Console.WriteLine(Rastrigin(1, 1, 0));
Console.WriteLine(net.FeedForward(new float[] { 1, 1, 0 })[0]);
Console.WriteLine(Rastrigin(1, 1, 1));
Console.WriteLine(net.FeedForward(new float[] { 1, 1, 1 })[0]);
*/
