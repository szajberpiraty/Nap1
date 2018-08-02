using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07GarbageCollector
{
    //A heap alján kezdődik az objektum példányok tárolása, minden tárolással egyre feljebb kerül az a mutató, ami a verem legelső szabad pozícióját mutatja.
    //Mindig itt jön létre a következő objektum példány,mindig a verem tetején vannak a legfiatalabb objektumok
    //Generációkat kezel
    //0:(gyerek):a heap tetején vannak, rájuk még nem futott le
    //1:(szülő):rájuk már lefutott, de nem takarította őket
    //2:rájuk már kétszer lefutott, de még mindig állnak

    class Program
    {
        static void Main(string[] args)
        {
            var alap = new Alap();
            //var lesz = new Leszarmaztatott();

            Console.WriteLine(GC.GetGeneration(alap));
            //Console.ReadKey();

            GC.Collect(); //minden generációra fut
            Console.WriteLine(GC.GetGeneration(alap));
           // alap = null;
           // lesz = null;
            GC.Collect();

            //objektumok helyfoglalása
            
            Console.WriteLine(GC.GetTotalMemory(false));

            //méretes listát készítünk

            var lista = new List<String>();

            for (int i = 0; i < 1000; i++)
            {
                lista.Add(new String('X',7000));
            }

            for (int i = 0; i < 2; i++)
            {
                var leszarmaztatott = new Leszarmaztatott(i);
                leszarmaztatott = null; //ha ezt kiadom, akkor lefut az utolsóra is
            }
            GC.Collect();
            //Kollektálás után az utolsó példány beragad! Debug és release mód között különbség van
            //Jitter-optimalizálja a kódot. A jitter és a debug össze van kötve

            Console.WriteLine(GC.GetTotalMemory(false));
            Console.ReadKey();
        }

    }
    class Alap
    {
        protected int i;
        public Alap()
        {

        }

        public Alap(int i)
        {
            this.i = i;
        }

        ~Alap()
        {
            Console.WriteLine("Alap véglegesítő {0}",i);
        }
    }
    class Leszarmaztatott:Alap
    {
        

        public Leszarmaztatott(int i):base(i)

        {
            
        }

        ~Leszarmaztatott()
        {
            Console.WriteLine("Leszárm véglegesítő {0}",i);
        }
    }
}
