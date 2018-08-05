using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nagyon egyszerű nyomkövetés
            //PeldaNaplo();



        }

        private static void PeldaNaplo()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("Hibakeresés:{0}", i);
            }
        }
    }
}
