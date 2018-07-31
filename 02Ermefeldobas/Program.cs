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


            //A virtual/override működése, nem kell castolni a hamisításhoz
            ErmeFeldobo ermeFeldobo4 = new HamisErmeFeldobo();
            int eredmeny4 = ermeFeldobo4.HamisithatoFeldobasEredmeny();

            ErmeFeldobo ermeFeldobo5 = new MegMegEgyFeldobo();
            

            Console.WriteLine("A hamis feldobás eredménye:{0}v4{0}", eredmeny3,eredmeny4);
            Console.ReadLine();

            //36-perctől folytatni
            //1.09-től folytatás
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
        /// Érmefeldobó osztály, nem hamisítható
        /// </summary>
        /// <returns>0=fej,1=írás</returns>
        internal int FeldobasEredmeny()
        {
            //throw new NotImplementedException(); Figyelmeztet, hogy nem implementáltuk még a függvényt
            Console.WriteLine("Eredeti generátor");
            var szam=generator.Next(0,2);
            return szam;
        }
        /// <summary>
        /// Direkt hamisíthatóra hozom létre a virtual kulcsszóvalí így a leszármazott osztályban módosítható a függvény
        /// </summary>
        /// <returns></returns>
        internal virtual int HamisithatoFeldobasEredmeny()
        {
            //throw new NotImplementedException(); Figyelmeztet, hogy nem implementáltuk még a függvényt
            Console.WriteLine("Eredeti generátor");
            var szam = generator.Next(0, 2);
            return szam;
        }
    }
    //származtatás az ErmeFeldobo osztályból
    /// <summary>
    /// A new kulcsszóval az eredetihez hasonló nevű, de ahhoz nem kapcsolódó függvényt csinálok. Ha a függvénynév megegyezik, akkor a 
    /// fordító automatikusan kiteszi a new kulcsszót
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

        /// <summary>
        /// Ha az ősosztályban virtual függvény van, akkor a leszármazottban az override kulcsszóval felül lehet írni
        /// </summary>
        /// <returns></returns>
        internal override int HamisithatoFeldobasEredmeny()
                
        {
           // Console.WriteLine("Hamisított generátor");
            return 1;
        }

        
        
    }
    class MegEgyFeldobo : ErmeFeldobo
    {

    }

    //Többszörös öröklés
    //Castolással bármelyik felület elérhető az öröklési láncban
    class MegMegEgyFeldobo : HamisErmeFeldobo
    {

    }

}
