using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeluletSikidomok
{
    //Névterek
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Zu");
            sw.Stop();
            Console.WriteLine("Eltelt:{0}",sw.ElapsedTicks);
            var alap = new Alap();
            var leszarmazott = new Leszarmaztatott();





            Console.ReadKey();
        }

        class Alap
        {
            //ha nincs konstruktor, akkor a fordító csinál alapértelmezett paraméter nélküli konstruktort
            public Alap()
            {

            }
        }

        class Leszarmaztatott : Alap
        {

        }
    }
}
