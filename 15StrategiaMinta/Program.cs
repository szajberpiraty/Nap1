using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15StrategiaMinta
{
    //A lényeg, hogy nem kell műveleteket bedrótozni egy adott osztályba, hanem a műveletet ki tudjuk emelni, 
    //készítünk neki felületet, megvalósítjuk egy másik osztályban, majd a cél osztályban is.
    class Program
    {
        static void Main(string[] args)
        {
            var adatOsztaly = new AdatOsztaly(adatok: new List<int>(new int[] {1,2,3,4,5,6,11,22}));

            var osszeg = adatOsztaly.Osszeg();

            //stratégia mintával való megvalósítás
            adatOsztaly.MuveletMegadasa(new OsszegzoMuvelet1());

            var osszeg2 = adatOsztaly.MuveletElvegzese();

        }
    }


    //Ez az interfész definiálja, hogy milyen műveletet tud fogadni egy osztály
    public interface IosszegzoMuvelet
    {
        int Osszegzes(List<int>adatok);
    }
    public class OsszegzoMuvelet1 : IosszegzoMuvelet
    {
        public int Osszegzes(List<int> adatok)
        {
            return adatok.Sum();
        }
    }

    public class Osszegzomuvelet2 : IosszegzoMuvelet
    {
        public int Osszegzes(List<int> adatok)
        {
            var osszeg = 0;
            foreach (var item in adatok)
            {
                osszeg = osszeg + item;
            }
            return osszeg;
        }

    }

    public class AdatOsztaly
    {
        List<int> adatok;
        private IosszegzoMuvelet muvelet;

        public void MuveletMegadasa(IosszegzoMuvelet muvelet)
        {
            this.muvelet = muvelet;
        }

        public AdatOsztaly(List<int> adatok)
        {
            this.adatok = adatok;
        }

        public int MuveletElvegzese()
        {
            if (this.muvelet==null)
            {
                throw new ArgumentNullException("muvelet");
            }
            return this.muvelet.Osszegzes(adatok);
        }

        internal int Osszeg()
        {
            return adatok.Sum();
        }
    }
}
