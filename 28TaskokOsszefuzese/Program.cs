using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _28TaskokOsszefuzese
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string,int,int> Szamolas = (nev,param) =>
            {
                Console.WriteLine("ID{0},Param:{1},Név{2}",Thread.CurrentThread.ManagedThreadId,param,nev);
                int sum = 0;
                for (int i = 0; i < param; i++)
                {
                    if (i%2==0)//ha páros, számolok
                    {
                        sum += i;
                    }
                    else
                    {
                        Thread.Sleep(20);
                    }
                }
                return sum;
            };
            //Hogyan kell visszaadni eredményt taskból
            //A megoldás a generikus taszk osztály
            //Hogyan adok paramétert a task által végrehajtott feladatnak
            //A megoldás a Func<T> lambda, amin belül már tetszőlegesen lehet paraméterezni

            var tindulo = new Task<int>(() => {return Szamolas("tindulo",15); } );
            //Folytatás 21.43-tól
            //Olyan taszkot csatolunk a tindulo-hoz, ami képes értéket visszaadni
            var tkovetkezo1 = tindulo.ContinueWith<int>(ti=> { return Szamolas("tkovetkezo1", ti.Result); });
            var tkovetkezo2 = tindulo.ContinueWith<int>(ti => { return Szamolas("tkovetkezo2", ti.Result/2); });
            var tkovetkezo3 = tindulo.ContinueWith<int>(ti => { return Szamolas("tkovetkezo3", ti.Result *2 ); });

            var tlezaro = Task<int>.Factory.ContinueWhenAll(new Task<int>[] {tkovetkezo1,tkovetkezo2,tkovetkezo3 },tasks=> 
            {
                int sum = 0;
                foreach (var task in tasks)
                {
                    sum += task.Result;
                }
                return Szamolas("tlezaro",sum/10);
            });

            tindulo.Start();
            Console.WriteLine("Eredmény {0}",tlezaro.Result);

            //nem kell tlezaro.Wait()
            Console.ReadLine();
        }
    }
}
