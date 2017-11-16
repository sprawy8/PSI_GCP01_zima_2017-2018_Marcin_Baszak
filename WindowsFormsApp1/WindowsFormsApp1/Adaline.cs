using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsFormsApp1
{
    class Adaline
    {
        //  Letter[] input_vector;
        //  Double[] weight_vector;
       public List<Letter> input_vector = new List<Letter>();
       public List<Double> weight_vector = new List<double>();
        
        double learning_rate;
        int output;
       public  double[] sums;

        

        public
        Adaline()
        {
           // input_vector = new Letter[20];
           // weight_vector = new double[35];
            learning_rate = 0.01;
            Letter l;
            l = new Letter();

            sums = new double[35];
            for (int i = 0; i < 20; i++)
            {
               
            }
            for (int i = 0; i < 35; i++)
            {
                
            }
        }
       public
            void addInput(Letter a)
        {
            input_vector.Add(a);
        }
        public
            void writeLetters()
        {
            foreach(Letter letter in input_vector) { letter.writeLetter(); }
        }
        public
            void random_weights()
        {

            Random rnd = new Random();
            for (int i = 0; i < 35; i++)
            {
                weight_vector.Add(rnd.NextDouble());
               
            }
        }
        public
            void writeWeights()
        {
            foreach (Double weight in weight_vector) { Console.WriteLine(weight);  }
        }
        public double[] getSums()
        {
            return sums;
        }
        public void setSum(int counter, double value)
        {
            sums[counter] = value;
        }
        public void updateWeights(List<double> tmp)
        {
            this.weight_vector.Clear();
            for (int i = 0; i < 35; i++)
            {
                this.weight_vector.Add(tmp[i]);
            }
        }
        public double getLR()
        {
            return this.learning_rate;
        }
        public void setLR(double lr)
        {
            this.learning_rate = lr;
        }

       
    }
}
