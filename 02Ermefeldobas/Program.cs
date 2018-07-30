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

            //36-perctől folytatni
        }
    }
    class ErmeFeldobo
    {
        Random generator = new Random();
        /// <summary>
        /// Érmefeldobó osztály
        /// </summary>
        /// <returns>0=fej,1=írás</returns>
        internal int FeldobasEredmeny()
        {
            //throw new NotImplementedException(); Figyelmeztet, hogy nem implementáltuk még a függvényt
            var szam=generator.Next(0,2);
            return szam;
        }
    }
    class HamisErmeFeldobo
    {
        internal int FeldobasEredmeny()
        {
            return 1;
        }
    }
}
