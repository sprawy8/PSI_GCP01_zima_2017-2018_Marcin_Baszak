using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Tester
    {
       

       public List<Letter> input_vector = new List<Letter>();
        
        public
         Tester()
        {
            
            Letter l = new Letter();

            for (int i = 0; i < 5; i++)
            {
              //  input_vector[i] = l;
            }

        }
        public void addInput(Letter a)
        {
            input_vector.Add(a);
        }
    }
}
