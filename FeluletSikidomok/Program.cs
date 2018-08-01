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

            Letrehozas();

          




            Console.ReadKey();
        }

        private static void Letrehozas()
        {
            var alap = new Alap("Faka", "Faka cím");
            Console.WriteLine();
            var leszarmazott = new Leszarmaztatott();
            Console.WriteLine();
            var tovabb = new TovabbSzarmaztatott();
            Console.ReadKey();
        }

        class Alap
        {
            //ha nincs konstruktor, akkor a fordító csinál alapértelmezett paraméter nélküli konstruktort
            string Nev;
            string Cim;

            public Alap(String nev,String cim):this(nev) //meghívja az előző paraméterrel az előző konstruktort
            {
                this.Nev = nev;
                //this.Cim = cim;
                Console.WriteLine("Alap konstruktor 3:{0},{1}", Nev,Cim);
            }

            public Alap(String nev):this() //overload, meghívja az alap konstruktort
            {
                this.Nev = nev;
                Console.WriteLine("Alap konstruktor 2:{0}",Nev);
            }

            public Alap() //publikus, nincs visszatérési értéke
            {
                Console.WriteLine("Alap konstruktor");
            }
            //Finalizer, akkor fut amikor az osztálypéldány befejezi az életét
            ~Alap() //ő a véglegesítő aka destruktor, meg sem lehet hívni, a futtató környezet hívja meg
            {
                Console.WriteLine("Alap destruktor");
            }
        }

        class Leszarmaztatott : Alap
        {
            public Leszarmaztatott()
            {
                Console.WriteLine("Leszármaztatott konstr");
            }
            ~Leszarmaztatott()
            {
                Console.WriteLine("Leszarmazott destr");
            }
        }
        class TovabbSzarmaztatott:Leszarmaztatott
        {
            public TovabbSzarmaztatott()
            {
                Console.WriteLine("Tovább származtatott konstr");
            }
            ~TovabbSzarmaztatott()
            {
                Console.WriteLine("Tovább származtatott destr");
            }
        }
    }
}
