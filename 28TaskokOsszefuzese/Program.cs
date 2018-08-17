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
                return 10;
            };
            //Hogyan kell visszaadni eredményt taskból
            //A megoldás a generikus taszk osztály
            //Hogyan adok paramétert a task által végrehajtott feladatnak
            //A megoldás a Func<T> lambda, amin belül már tetszőlegesen lehet paraméterezni

            var tindulo = new Task<int>(() => {return Szamolas("tindulo",15); } );
            //Folytatás 21.43-tól
        }
    }
}
