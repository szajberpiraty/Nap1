using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Sikidomok
{
    class Program
    {
        static void Main(string[] args)
        {
            var teglalap = new Teglalap(szelesseg:3,magassag:3);  //ki lehet így generáltatni a konstruktort
            var haromszog = new Haromszog(alap: 3, magassag: 3);
            var kor = new Kor(sugar: 5);
            var lista = new List<ISikidom>();// Bármit elfogad, ami megvalósítja az ISikidom felületet
            lista.Add(teglalap);
            lista.Add(haromszog);
            lista.Add(kor);

        }

        
        
        //Megadja, hogy mi látszik kívülről, I-vel kezdődik a neve (névadási konvenció)
        interface ISikidom
        {
            int Terulet();
        }
        class Teglalap : ISikidom
        {
            public int Magassag { get; private set; }
            public int Szelesseg { get; private set; }

            public Teglalap()
            {
                this.Szelesseg = 1;
                this.Magassag = 1;
            }

            public Teglalap(int szelesseg, int magassag)
            {
                Szelesseg = szelesseg;
                Magassag = magassag;
            }

            public int Terulet()
            {
                return Magassag * Szelesseg;
            }
        }
        class Haromszog : ISikidom
        {
            public Haromszog(int alap, int magassag)
            {
                Alap = alap;
                Magassag = magassag;
            }

            public int Alap { get; private set; }
            public int Magassag { get; private set; }



            public int Terulet()
            {
                return (Alap * Magassag) / 2;
            }
        }
        class Kor : ISikidom
        {
            public Kor(int sugar)
            {
                Sugar = sugar;
            }

            public int Sugar { get; private set; }

            public int Terulet()
            {
                return (int)(Sugar * Sugar * Math.PI); //Eredetileg a végeredmény double, de castolom integer-re és minden rendben
            }
        }
    }
}
