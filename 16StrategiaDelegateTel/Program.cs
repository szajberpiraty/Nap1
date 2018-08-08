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
            var eredmeny = adatOsztaly.Muvelet(ListaOsszegzes); //Itt már három lépésből meg lehet adni a műveletet az osztálynak

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
    }
}
