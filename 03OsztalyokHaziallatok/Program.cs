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
    //-viselkedése van
    //Folytatás 29.17-től
    //függvény szignatúra: a függvény neve és paramétereinek listája
    //overload: ugyanazzal a névvel több függvényt is lehet csinálni, ha különbözik a szignatúrájuk
    
    
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

            //érték szerinti átadás
            var lepes = 5;
            haziallat.LepjenEnnyit(lepes);

            //referencia átadása
            haziallat.LepjenEnnyitR(ref lepes);
            Console.WriteLine(lepes);

            haziallat.AllatNeve();


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
            //a get és a set lehet private is
            public int HanyFogaVan {  set { hanyFogaVan = value; } }

            //ha mi akarjuk implementálni a gettert
            private int hanyFarkaVan;
            public int HanyFarkaVan
            {

                get
                {
                    return hanyFarkaVan;
                }

                set
                {
                    hanyFarkaVan = value;
                }


                
            }

            //Viselkedés definíció
            public void LepjenEnnyit(int lepes)
            {
                Console.WriteLine("Ennyit lépek:{0}",lepes);
            }

            public void LepjenEnnyitR(ref int lepes)
            {
                Console.WriteLine("Ennyit lépek:{0}", lepes);
                lepes = 4;
            }
            //Kimenő paraméter megadása, bejövő adatot ez nem fogad
            public void LepjenEnnyitOut(ref int lepes,out int Kimeno)
            {
                Console.WriteLine("Ennyit lépek:{0}", lepes);
                lepes = 4;
                Kimeno = 1;
            }

            //Beállító metódus alapértelmezett értékkel
            String allatNev;
            public void AllatNeve(String nev="Bubu")
            {
                allatNev = nev;
            }

        }
    }

}
