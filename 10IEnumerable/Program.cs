using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var listaElem in BevasarloLista())
            //{
            //    Console.WriteLine(listaElem);
            //}

            //Console.WriteLine("1 kg kenyér");
            //Console.WriteLine("10 dkg szalámi");
            //Console.WriteLine("1l tej");
            //Console.WriteLine("1 kg liszt");
            //Console.WriteLine("édesség");
            //Console.WriteLine("lakat");
            //Console.WriteLine("póni");
            Console.ReadKey();


        }

        private static IEnumerable<string> BevasarloLista()
        {
            yield return "1 kg kenyér";
            yield return "10 dkg szalámi";
            yield return "1l tej";
            yield return "1 kg liszt";
            yield return "édesség";
            yield return "lakat";
            yield return "póni";
            
        }
        class BejarhatoOsztaly : IEnumerable
        {
            List<string> lista = new List<string>();
            public void Add(string s)
            {
                lista.Add(s);
            }

            public IEnumerator GetEnumerator()
            {
                return new Bejaro(lista);
            }
        }
        class Bejaro : IEnumerator
        {
            private List<string> lista;
            int pozicio = -1;


            public Bejaro(List<string> lista)
            {
                this.lista = lista;
            }

            public object Current
            {
                get
                {
                    var current = lista[pozicio];
                    Console.WriteLine("Aktuális pozíció:{0}",current);
                    return current;
                }
            }

            public bool MoveNext()
            {
                pozicio++;
                var vanMegElem = pozicio < lista.Count();
                Console.WriteLine("Pozicio:{0},Van még:{1}",pozicio,vanMegElem);
                return vanMegElem;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
