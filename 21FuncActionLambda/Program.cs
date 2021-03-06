﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21FuncActionLambda
{
    class Program
    {
        public delegate int NegyztreEmelesDef(int x);

        static void Main(string[] args)
        {
            //Ha delegate-et használok akkor a megoldás
            //delegate definíció
            //függvény definíció
            //változó létrehozás és értékadás=híváslista feltöltése
            //híváslista meghívása

            NegyztreEmelesDef hivaslista = NegyzetreEmeles;
            Console.WriteLine(NegyzetreEmeles(2));
            

            //Ezek helyett kell egy egyszerűbb megoldás
            //A függvény definíciók kiváltására szolgálnak a lambda kifejezések

            //Első verzió
            //Bal oldalt a paraméterlista
            //jobb oldalt a kódblokk

            hivaslista = (x) => { return x * x; };

            //Ha egy kifejezéssel kell visszatérni, akkor nem kell a kódblokk, csak a kifejezés
            //ha egy paraméter van, nem kell zárójel

            hivaslista += z => z * z;
            Console.WriteLine(hivaslista(2));
            //Console.ReadLine();
            //Az Action<> és a Func<> előre legyártott, a keretrendszer részét képező delegate definíciók
            //A kacsacsőrök között egy generikus paramétert tudok átadni, ami egy típus
            //Action<> visszatérési érték nélküli delegate definíció
            //Func<> visszatérési értékkel rendelkező delegate def

            //megadjuk a paraméterlistát, és megadjuk a visszatérési érték típusát
            Func<int, int> negyzet2 = z => z * z;

            //Ha egynél több paraméter van
            Func<int, int, string> szorzas = (a,b) => (a*b).ToString();

            //Négyzetre emelés az Action-al
            Action<int> ujnegyzet = x => Console.WriteLine(x * x);
            ujnegyzet(9);

            //Actionnál kell kiírás, mert egyébként nem működik
            Action<int,int,int> ujszorzas = (a,b,c) => Console.WriteLine("Új szorzás:{0}",a*b*c);
            ujszorzas(3, 4, 5);



            Console.WriteLine(negyzet2(4));
            Console.WriteLine(szorzas(2,3));

            Console.ReadLine();

        }
        static int NegyzetreEmeles(int x)
        {
            return x * x;
        }
    }
}
