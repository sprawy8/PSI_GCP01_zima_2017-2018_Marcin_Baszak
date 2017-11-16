using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Letter
    {
        char letter;                    // char przechowywujacy dana litere w postaci ASCII
        public int[] byte_series;           // seria znakow w postaci 1 i 0 przedstawiajacych dana litere w formacie graficznym 5x7
        int y;                      // y=1 jezeli litera jest duza, y=0 jezeli litera jest mala


        public
        Letter()
        {
            letter = 'a';
            byte_series = new int[35];
            for (int i = 0; i < 35; i++)
            {
                byte_series[i] = 0;
            }

        }
        public int getSize()
        {
            return y;
        }

        public
          void writeLetter()
        {
            Console.Write(letter);
            for (int i = 0; i < 35; i++)
            {
                Console.Write(byte_series[i]);
            }
            Console.Write("  -> Wielkosc litery: "); Console.WriteLine(y);

        }
        public
          void  loadLetter(char Letter, int[] byte_Series, int z)
        {
            letter = Letter;
            byte_series = byte_Series;
            y = z;
        }
        public int[] getByte()
        {
            return this.byte_series;
        }
    }
}
