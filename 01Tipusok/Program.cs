﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Tipusok
{
    //A fordítás célja egy MSIL (köztes nyelv) nyelvű állomány létrehozása. A köztes nyelvet a Dotnet keretrendszer futtatja (Linuxon Mono)
    //Igény arra, hogy a program több eszközön is fusson.
    //Programkönyvtárak : egységesebb felület a programozók felé
    //C++ oop lehetőségek, de számos dolog a programozó kezében marad, memóriakezelés, stb.
    //Megjelent a JAVA - köztes kód
    //.NET ->futtató keretrendszer. C# ->.NET hez való C gyakorlatilag, kényelmesen használható futtatási és programozási környezet
    //MSIL - intermediate language
    //


    class Program
    {

        static void Main(string[] args)
        {
            var valtozo = 11; // a fordító meg tudja állapítani a típust, nem szükséges deklarálni
            valtozo = 21;

            //Ez is jó
            int valtozo2 = 0;
            int valtozo3;
            valtozo3 = 0;

            //Érték típusnál az érték másolódik

            var valtozo4 = valtozo3;
            valtozo4 = 12;

            //A C# változók is objektumok, akár így is deklarálhatunk
            Int32 valt_obj = new Int32();

            //Ezek primitív típusok: számok, logikai érték, enum (a stack-en vannak), de mögötte OOP mechanizmus van.

            Console.WriteLine("3:{0},4:{1}",valtozo3,valtozo4);
            Console.ReadKey();

            //referencia típus, érték helyett a változóra mutató hivatkozás tárolódik

            var tomb1 = new int[] { 0 }; //egy elemű tömb
            var tomb2 = tomb1;
            tomb1[0] = 112;

            Console.WriteLine("t1:{0},t2:{1}", tomb1[0], tomb2[0]); //a két érték együtt mozog, egy helyre mutat a referencia
            Console.ReadKey();

            //

            var sajatertek1 = new SajatErtekTipus();
            sajatertek1.Ertek = 10;
            sajatertek1.Hivatkozas = new SajatHivatkozasTipus();
            sajatertek1.Hivatkozas.Ertek = 33;

            var sajatertek2 = sajatertek1;

            sajatertek2.Ertek = 20;

            Console.WriteLine("s1:{0},s2:{1},sh1{2},sh2{3}", sajatertek1.Ertek,sajatertek2.Ertek,sajatertek1.Hivatkozas.Ertek,sajatertek2.Hivatkozas.Ertek); 
            //érték típus, saját, a hivatkozás típusok együtt változnak. A hivatkozás típus jellege nem változik akkor sem, ha érték típusba van csomagolva

            
            Console.ReadKey();


            var sajathivatkozas1 = new SajatHivatkozasTipus();
            sajathivatkozas1.Ertek = 11;

            var sajathivatkozas2 = sajathivatkozas1;
            sajathivatkozas2.Ertek = 22;

            Console.WriteLine("s1:{0},s2:{1}", sajathivatkozas1.Ertek, sajathivatkozas2.Ertek); //ref típus, saját, együtt mozognak
            Console.ReadKey();
            //Stringek a heap-re kerülnek, de értékként viselkednek
            var szoveg1 = "Valami";
            var szoveg2 = szoveg1;
            szoveg1 = "Bármi";

            Console.WriteLine("szöveg1:{0},szöveg2:{1}", szoveg1, szoveg2); //a szöveg értéktípusként viselkedik, mindig másolódik a heap-en
            Console.ReadKey();

            //teljesen rossz megoldás tehát:
            var szoveg = "";
            for (int i = 0; i < 10000; i++)
            {
                szoveg = szoveg + "valami";
            }

            //Sokkal jobb a beépített stringbuilder, csak egy példányt hoz létre
            var sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("Lóface");
            }
            sb.ToString(); //Itt adódik az eredmény

        }
    }
    //Mi is tudunk osztályt (típust) csinálni
    class SajatHivatkozasTipus
    {
        public int Ertek;
    }
    struct SajatErtekTipus
    {
        public int Ertek;
        public SajatHivatkozasTipus Hivatkozas;
    }


}
