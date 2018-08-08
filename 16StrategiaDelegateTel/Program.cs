using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16StrategiaDelegateTel
{
    class Program
    {
       

        static void Main(string[] args)
        {
            var adatOsztaly = new AdatOsztaly(adatok: new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 11, 22 }));

            //1.delegate definíció
            //2.függvény definíció
            //3.fogadni a delegate tipust
            //4.hívás


            var eredmeny = adatOsztaly.Muvelet(ListaOsszegzes); //Itt már három lépésből meg lehet adni a műveletet az osztálynak

            //Tömörebben
            //1.Kell egy függvény definíció
            //2.Fogadni a delegate típust
            //3.hívás func


            var eredmeny2 = adatOsztaly.Muvelet2(ListaOsszegzes);

            //Egy soros lambdás megoldás
            //1.Fogadni a delegate típust a Func segítségével
            //2. Lambda segítségével beküldjük a stratégiánkat
            var eredmeny3 = adatOsztaly.Muvelet3(x=>x.Sum());

        }
        static int ListaOsszegzes(List<int> adatok)
        {
            return adatok.Sum();
        }
    }
    public class AdatOsztaly
    {
        public delegate int ListaMuveletDef(List<int> adatok);
        List<int> adatok;

        public AdatOsztaly(List<int> adatok)
        {
            this.adatok = adatok;
        }
        public int Muvelet(ListaMuveletDef muvelet)
        {
            var muveletLista = muvelet;
            if (muveletLista==null)
            {
                return 0;
            }
            return muveletLista(adatok);

        }

        internal object Muvelet2(Func<List<int>, int> listaOsszegzes)
        {
            throw new NotImplementedException();
        }

        internal object Muvelet3(Func<List<int>, int> listaOsszegzes)
        {
            throw new NotImplementedException();
        }
    }
}
