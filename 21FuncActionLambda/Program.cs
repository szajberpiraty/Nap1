using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21FuncActionLambda
{
    class Program
    {
        public delegate int NegyztreEmelesDef(int x);

        static void Main(string[] args)
        {
            //Ha delegate-et használok akkor a megoldás
            //delegate definíció
            //függvény definíció
            //változó létrehozás és értékadás=híváslista feltöltése
            //híváslista meghívása

            NegyztreEmelesDef hivaslista = NegyzetreEmeles;
            Console.WriteLine(NegyzetreEmeles(2));
            Console.ReadLine();
        }
        static int NegyzetreEmeles(int x)
        {
            return x * x;
        }
    }
}
