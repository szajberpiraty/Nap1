using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22AsyncMukodes
{
    class Program
    {
        static void Main(string[] args)
        {
            //függvény létrehozás, int és string paramétert vár, DateTime-ot ad vissza
            Func<int, string, DateTime> am = (ciklusok, nev) => 
            {
                Console.WriteLine("+-{0} elindult ciklusok {1}",nev,ciklusok);
                for (int i = 0; i < ciklusok; i++)
                {
                    Console.WriteLine("+-{0} ciklus {1}",nev,i);
                    Thread.Sleep(400);
                }
                Console.WriteLine("+-{0} végzett", nev);
                return DateTime.Now;
            };
            var eredmeny0=am(3, "szinkron hívás");
            Console.WriteLine("+Fő szál szinkron hívás elindult");
            Console.WriteLine("+Fő szál végzett eredmény {0}",eredmeny0);

            //Szinkron módon így is meg lehetett volna hívni
            //var eredmeny0=am.Invoke(3,"Szinkron hívás");

            am.BeginInvoke(5, "Aszinkron példa 1", null, null);

            Console.ReadLine();
        }
    }
}
