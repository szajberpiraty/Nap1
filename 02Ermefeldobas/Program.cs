using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Ermefeldobas
{
    //OOP alapelvek
    //Elvonatkoztatás (absztrakció)-> a számunkra fontos dolgok kiemelése
    //Egységbe zárás (encapsulation)-> csak azokat mutatja az objektum, ami a külvilágra tartozik. Példa: távirányító
    //Modularitás (a problémát kisebb problémákra osztjuk, azokat oldjuk meg)
    //Hierarchia a modulokat egymás alá-fölé lehet rendelni

    //OOP programozás
    //Objektum 
    //  1. azonosíthatóság (identity)
    //  2. van állapota (state)
    //  3. van viselkedése (behaviour)
    //
    //Osztály
    // Absztrakció, az objektum terve, ezt példányosítjuk

    //Amikor leszármaztatunk  egy osztályt, akkor létrejön a leszármazott és az ős példánya is, az ős szolgáltatja az ős viselkedését és 
    //tulajdonságait.


    class Program
    {
        static void Main(string[] args)
        {
            ErmeFeldobo ermeFeldobo = new ErmeFeldobo();
           int eredmeny=ermeFeldobo.FeldobasEredmeny();
            Console.WriteLine("A feldobás eredménye:{0}", eredmeny);
            Console.ReadLine();

            ErmeFeldobo ermeFeldobo2 = new HamisErmeFeldobo();
            int eredmeny2 = ermeFeldobo2.FeldobasEredmeny();
            Console.WriteLine("A feldobás eredménye:{0}", eredmeny2);
            Console.ReadLine();

            //cast-olás, azaz elérjük hogy a HamisErmeFeldobo függvénye legyen meghívva
            int eredmeny3 = ((HamisErmeFeldobo)ermeFeldobo2).FeldobasEredmeny();

            Console.WriteLine("A hamis feldobás eredménye:{0}", eredmeny3);
            Console.ReadLine();

            //36-perctől folytatni
        }
    }
    class ErmeFeldobo
    {
        public ErmeFeldobo()
        {
            Console.WriteLine("Ermefeldobo konstruktor");
        }

        Random generator = new Random();
        /// <summary>
        /// Érmefeldobó osztály
        /// </summary>
        /// <returns>0=fej,1=írás</returns>
        internal int FeldobasEredmeny()
        {
            //throw new NotImplementedException(); Figyelmeztet, hogy nem implementáltuk még a függvényt
            Console.WriteLine("Eredeti generátor");
            var szam=generator.Next(0,2);
            return szam;
        }
    }
    //származtatás az ErmeFeldobo osztályból
    /// <summary>
    /// A new kulcsszóval az eredetihez hasonló nevű, de ahhoz nem kapcsolódó függvényt csinálok
    /// </summary>
    class HamisErmeFeldobo:ErmeFeldobo
    {
        public HamisErmeFeldobo()
        {
            Console.WriteLine("Hamis feldobo konstr");
        }

        internal new int FeldobasEredmeny()
        {
            Console.WriteLine("Hamisított generátor");
            return 1;
        }
    }
}
