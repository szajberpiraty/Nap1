using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11IEnumerableT
{
    class Program
    {
        static void Main(string[] args)
        {
            var adatok = new BejarhatoAdatok<Adatok>(
                new Adatok[] {
                
                new Adatok(szoveg:"ZU",szam:11),
                new Adatok(szoveg:"ZUU",szam:12),
                new Adatok(szoveg:"ZUUU",szam:13)


                }); 
            foreach (var adat in adatok) //Foreach-ban sosem módosítunk listát!!! Exceptiont vált ki!
            {
                Console.WriteLine("Név:{0},Szám{1}",adat.szoveg,adat.Szam);
            }
        }
    }

    internal class BejarhatoAdatok<T>:IEnumerable<T>,IEnumerator<T>
    {
        List<T> lista = new List<T>();
        int pozicio=-1;
        private Adatok[] adatok;

        public BejarhatoAdatok(T[] adatok) //Így más működik, de nagyon zavaros, Plesz is belezavarodott :) A végső értelme a saját implementációnak, hogy többféle szempont szerint is be lehet járni a gyűjteményt
        {
            lista = new List<T>(adatok);
        }

        public T Current
        {
            get
            {
               return lista[pozicio];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            //Ebben az esetben nem kell implementálni, mert ciklusból kilépéskor meghívódik
            //throw new NotImplementedException();
        }

      

        public bool MoveNext()
        {
            pozicio++;
            return pozicio < lista.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

  public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }

    //Ezt használjuk a gyűjteményben
    class Adatok
    {
        public Adatok(string szoveg, int szam)
        {
            this.szoveg = szoveg;
            Szam = szam;
        }

        public int Szam { get; set; }
        public string szoveg { get; set; }
    }
}
