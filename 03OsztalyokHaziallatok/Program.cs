using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OsztalyokHaziallatok
{
    //Objektum: 
    //-egyértelmű határok
    //-állapota van
    //-működése van
    class Program
    {
        static void Main(string[] args)
        {
            var haziallat = new Haziallat();
            var haziallat2 = new Haziallat();
            if (haziallat==haziallat2)
            {
                Console.WriteLine("Egyezőek");
            }
            else
            {
                Console.WriteLine("Nem azonosak");
            }

            //Megtöri az egységbezárást
            haziallat2.LabSzam = 3;
            
            Console.ReadKey();
        }
        class Haziallat
        {
            //ha nem adunk meg láthatóságot, akkor private lesz, kívülről nem látszik majd
            String AllatFaj;
            public String AllatNev;
            public int LabSzam;

        }
    }

}
