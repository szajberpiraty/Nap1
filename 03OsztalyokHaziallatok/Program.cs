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

            //egységbe tudom zárni az információt
            haziallat2.mennyiLab();
            haziallat2.HanySzeme = 12;
            haziallat2.HanyFogaVan = 34;
            var szemek = haziallat2.HanySzeme;

            Console.ReadKey();
        }
        class Haziallat
        {
            //ha nem adunk meg láthatóságot, akkor private lesz, kívülről nem látszik majd
            String AllatFaj;
            public String AllatNev;
            public int LabSzam;
            //A C# megkülönbözteti a kis és nagybetűket
            int labSzam;
            public int mennyiLab()
            {
                return labSzam;
            }
            public void setLabSzam(int labak)
            {
                labSzam = labak;
            }
            //property készítés
            public int HanySzeme { get; set; }
            private int hanyFogaVan;
            //csak settert automatikusan nem lehet beállítani
            public int HanyFogaVan {  set { hanyFogaVan = value; } }

        }
    }

}
