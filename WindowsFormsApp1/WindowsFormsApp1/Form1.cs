using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    

    public partial class Form1 : Form
    {
        int N_BYTES = 10;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int  epoka = 0, iterations= int.Parse(textBox3.Text);
            double MSE, MAPE;

            Adaline adaline = new Adaline();
            Tester tester = new Tester();
            // INPUT WEKTOR --> LITERY ZALADOWAC
            // PO KOLEI ZALADOWAC LITERY DO LISTY LETTER -> TEXTBOXY OBOK SIEBIE -> W LEWYM WPISUJEMY A, B itd.. W PRAWYM NA TEJ PODSTAWIE SIE UZUPELNIA ( Z GOTOWEJ LISTY BYTOW ), A JESLI ZLA LITERKA TO BLAD
            loadLetters(adaline);
            adaline.random_weights();
            adaline.writeWeights();
            double[] tmpSums = new double[35];


            adaline.setLR((double)trackBar1.Value / 1000);
            do
            {
                Console.WriteLine("Epoka: " + epoka);
                for (int i = 0; i < 35; i++)
                {
                    //adaline.setSum(i, countSum(adaline, i));
                    adaline.sums[i] = countSum(adaline, i);
                }

                MSE = countMSE(adaline);
                MAPE = countMAPE(adaline);

                Console.WriteLine("Wartosc MSE: " + MSE);
                Console.WriteLine("Wartosc MAPE: " + MAPE);

                
                adaline.weight_vector = updateWeights(adaline.weight_vector, adaline);
               // adaline.updateWeights(updateWeights(adaline.weight_vector, adaline));
                epoka++;
            } while (epoka < iterations);

            loadTester(tester);
            tester.input_vector[0].writeLetter();
            testuj(adaline, tester);
           // Console.Write(adaline.weight_vector[0]);
 
            //Console.WriteLine(iterations);
        }


        void loadLetters(Adaline ada)
        {
            Letter tmp_A = new Letter();
            Letter tmp_B = new Letter();
            Letter tmp_C = new Letter();
            Letter tmp_D = new Letter();
            Letter tmp_E = new Letter();
            Letter tmp_F = new Letter();
            Letter tmp_G = new Letter();
            Letter tmp_H = new Letter();
            Letter tmp_I = new Letter();
            Letter tmp_J = new Letter();

            Letter tmp_a = new Letter();
            Letter tmp_b = new Letter();
            Letter tmp_c = new Letter();
            Letter tmp_d = new Letter();
            Letter tmp_e = new Letter();
            Letter tmp_f = new Letter();
            Letter tmp_g = new Letter();
            Letter tmp_h = new Letter();
            Letter tmp_i = new Letter();
            Letter tmp_j = new Letter();


            int[] tmpA = { 0,1,1,1,0,1,0,0,0,1,1,0,0,0,1,1,1,1,1,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1 };        

            tmp_A.loadLetter('A',tmpA, 1);
            ada.addInput(tmp_A);
            tmp_A.writeLetter();
            

            int[] tmpB = { 1,1,1,1,0,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0};
            tmp_B.loadLetter('B', tmpB, 1);
            ada.addInput(tmp_B);
            tmp_B.writeLetter();

            int[] tmpC = { 0,1,1,1,0,1,0,0,0,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,1,1,1,0 };
            tmp_C.loadLetter('C', tmpC, 1);
            ada.addInput(tmp_C);
            tmp_C.writeLetter();

            int[] tmpD = { 1,1,1,1,0,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0 };
            tmp_D.loadLetter('D', tmpD, 1);
            ada.addInput(tmp_D);

            int[] tmpE = { 1,1,1,1,1,1,0,0,0,0,1,0,0,0,0,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,1,1,1,1,1 };
            tmp_E.loadLetter('E', tmpE, 1);
            ada.addInput(tmp_E);

            int[] tmpF = { 1,1,1,1,1,1,0,0,0,0,1,0,0,0,0,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0 };
            tmp_F.loadLetter('F', tmpE, 1);
            ada.addInput(tmp_F);

            int[] tmpG = { 1,1,1,1,1,1,0,0,0,1,1,0,0,0,0,1,0,1,1,1,1,0,0,0,1,1,0,0,0,1,0,1,1,1,0 };
            tmp_G.loadLetter('G', tmpG, 1);
            ada.addInput(tmp_G);

            int[] tmpH = { 1,0,0,0,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,1 };
            tmp_H.loadLetter('H', tmpH, 1);
            ada.addInput(tmp_H);

            int[] tmpI = { 0,1,1,1,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,1,1,0 };
            tmp_I.loadLetter('I', tmpI, 1);
            ada.addInput(tmp_I);

            int[] tmpJ = { 1,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,0,0,0,1,0,1,1,1,0 };
            tmp_J.loadLetter('J', tmpJ, 1);
            ada.addInput(tmp_J);

            int[] tmpa = { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,0,0,1,0,1,1,1,1 };
            tmp_a.loadLetter('a', tmpa, 0);
            ada.addInput(tmp_a);

            int[] tmpb = { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,1,0,0,1,0,0,1,0,1,1,1,0,0 };
            tmp_b.loadLetter('b', tmpb, 0);
            ada.addInput(tmp_b);

            int[] tmpc = { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,0,1,1,0,0,0,0,1,0,0,0,1,0,1,1,1,0 };
            tmp_c.loadLetter('c', tmpc, 0);
            ada.addInput(tmp_c);

            int[] tmpd = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,0,1,1,1 };
            tmp_d.loadLetter('d', tmpa, 0);
            ada.addInput(tmp_d);

            int[] tmpe = { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,0,1,1,1,1,1,0,1,0,0,0,0,0,1,1,1,0 };
            tmp_e.loadLetter('e', tmpe, 0);
            ada.addInput(tmp_e);

            int[] tmpf = { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,1,0,0,0,1,1,1,0,0,0,1,0,0,0,0,1,0,0,0 };
            tmp_f.loadLetter('f', tmpf, 0);
            ada.addInput(tmp_f);

            int[] tmpg = { 0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,1,0,1,1,1,1,0,0,0,0,1,1,1,1,1,0 };
            tmp_g.loadLetter('g', tmpg, 0);
            ada.addInput(tmp_g);

            int[] tmph = { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,1,1,0,1,0,0,0,1,1,0,0,0,1 };
            tmp_h.loadLetter('h', tmph, 0);
            ada.addInput(tmp_h);

            int[] tmpi = { 0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,0 };
            tmp_i.loadLetter('i', tmpi, 0);
            ada.addInput(tmp_i);

            int[] tmpj = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,1,0,0,1,0,0,1,1,0 };
            tmp_j.loadLetter('j', tmpj, 0);
            ada.addInput(tmp_j);


            ada.writeLetters();
        }

        void loadTester(Tester test)
        {
            Letter tmp_E = new Letter();
            Letter tmp_B = new Letter();
            Letter tmp_C = new Letter();

            Letter tmp_h = new Letter();
            Letter tmp_i = new Letter();
            Letter tmp_j = new Letter();

            int[] tmpE = { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
            tmp_E.loadLetter('E', tmpE, 1);
            test.addInput(tmp_E);


            int[] tmpB = { 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0 };
            tmp_B.loadLetter('B', tmpB, 1);
            test.addInput(tmp_B);
            tmp_B.writeLetter();

            int[] tmpC = { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };
            tmp_C.loadLetter('C', tmpC, 1);
            test.addInput(tmp_C);
            tmp_C.writeLetter();

            int[] tmph = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };
            tmp_h.loadLetter('h', tmph, 0);
            test.addInput(tmp_h);

            int[] tmpi = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0 };
            tmp_i.loadLetter('i', tmpi, 0);
            test.addInput(tmp_i);

            int[] tmpj = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0 };
            tmp_j.loadLetter('j', tmpj, 0);
            test.addInput(tmp_j);

        }

        double countSum(Adaline ada, int letter)
        {
            double sum = 0;
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 35; i++)
                {
                    sum += ada.input_vector[j].byte_series[i] * ada.weight_vector[i];
                }

            }

            return sum;
        }
      
        double countMSE(Adaline ada)
        {
            double tmp = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    tmp += Math.Pow(function(ada.sums[j] - ada.input_vector[i].getSize()), 2);
                }
                tmp /= 35;
            }

            return tmp;
        }

        double countMAPE(Adaline ada)
        {
            double tmp = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    //tmp += (Math.Abs((function(ada.sums[j]) - ada.input_vector[i].getSize())) / function(ada.sums[j]));
                    tmp +=  (Math.Abs((function(ada.sums[j]) - ada.input_vector[i].getSize())) / function(ada.sums[j]));
                }
            }
            tmp /= 35;
            return tmp;
        }

          List<double> updateWeights(List<double> wv, Adaline ada)
        {
            List<double> tmp = wv;
            double iterator;
            List<double> tmp2 = new List<double>();
            double temp;

            for (int i = 0; i < 20; i++)
            {
                double delta = 0;
                for (int j = 0; j < 35; j++)
                {
                   // Console.WriteLine("Przed update: " + iterator);
                    delta += ada.getLR() * (ada.input_vector[i].getSize() - function(ada.sums[j])) * ada.input_vector[i].byte_series[j];
                }
                //temp = ada.weight_vector[i] + delta;
                tmp[i] += delta;
               // tmp1.Add(temp);
                Console.WriteLine("Updated Weight: " + tmp[i]);
            }


                return tmp;
            
        }

        double function(double sum)
        {
            return 1 / (1 + Math.Exp(-0.5 * sum));
        }

        void testuj(Adaline ada, Tester t)
        {
            Console.WriteLine("-----TESTOWANIE-----");
            double tmp = 0;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 35; i++)
                {
                    tmp += t.input_vector[j].byte_series[i] * ada.weight_vector[i];
                }
                 t.input_vector[j].writeLetter();
                if (tmp >= 1)
                {
                    Console.WriteLine("Wielkosc po testowaniu: 1");
                    textBox4.Text += "1, ";
                }
                else 
                {
                    Console.WriteLine("Wielkosc po testowaniu: 0");
                    textBox4.Text += "0, ";
                }
                tmp = 0;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Learning Rate: " + (double)trackBar1.Value / 1000;
        }

        // tmp += t.input_vector[0].byte_series[j]

    }
}
