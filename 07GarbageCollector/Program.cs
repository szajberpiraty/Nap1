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
            var lesz = new Leszarmaztatott();

            Console.WriteLine(GC.GetGeneration(alap));
            //Console.ReadKey();

            GC.Collect(); //minden generációra fut
            Console.WriteLine(GC.GetGeneration(alap));
            alap = null;
            lesz = null;
            GC.Collect();

            Console.ReadKey();
        }

    }
    class Alap
    {
        ~Alap()
        {
            Console.WriteLine("Alap véglegesítő");
        }
    }
    class Leszarmaztatott:Alap
    {
        ~Leszarmaztatott()
        {
            Console.WriteLine("Leszárm véglegesítő");
        }
    }
}
