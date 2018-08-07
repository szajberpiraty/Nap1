using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Delegate
{
    class Program
    {
        /// <summary>
        /// Út a Delegate-ekhez (használatának lépései)
        /// 1. Készítünk egy típust, ez maga a delegate
        /// 2. Készítünk egy híváslistát
        /// 3. Meghívjuk a híváslistán szereplő függvényeket
        /// </summary>
        /// <param name="args"></param>
        /// 
        delegate void PeldaDelegate(string Uzenet); //A deklaráció a függvény visszatérési értékére ill. paraméterlistájára vonatkozik

        static void EgyikFuggveny(string Szov)
        {
            Console.WriteLine("Egyik függvény:{0}",Szov);
        }
        static void MasikFuggveny(string Par)
        {
            Console.WriteLine("Másik függvény:{0}", Par);
        }

        static void Main(string[] args)
        {
            //ElsoDelegateMinta(); //Kitettem füvvénybe



            Console.ReadLine();
        }

        private static void ElsoDelegateMinta()
        {
            PeldaDelegate hivasLista; //Híváslista a delegate alapján
            hivasLista = EgyikFuggveny; //felvesszük a függvényt a híváslistára
            hivasLista("első üzenet");  //híváslista meghívása
            hivasLista += MasikFuggveny; //Hozzáadunk egy másik függvényt

            hivasLista("mizu?");
        }
    }
}
