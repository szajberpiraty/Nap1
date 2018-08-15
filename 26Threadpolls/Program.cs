using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _26ThreadPools
{
    class Program
    {
        /// <summary>
        /// Az operációs rendszer által elindított alkalmazás: folyamat (process)
        /// Az alkalmazáson belüli végrehajtási egység a szál (thread)
        /// A thread létrehozása erőforrásigényes, ennek kezelésére ThreadPool-t használ a dotnet
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WaitCallback callback = o=>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("+->{0} Elindult, id {1}", o,id);
                //Ha ez rövidebb idő, akkor a thread időben felszabadul,és a következő megkapja
                //Ha több idő, pl 10.sec, akkor egy idő után a scheduler új szálat hoz létre, de ez időbe telik
                Thread.Sleep(10000);
                Console.WriteLine("+->{0} Végzett, id {1}", o,id);
            };

            //Processzoronként 1 thread a minimum, ez alá nem tudunk menni
            ThreadPool.SetMaxThreads(4,300);

            ThreadPool.QueueUserWorkItem(callback,"Egy");
            ThreadPool.QueueUserWorkItem(callback,"Kettő");
            ThreadPool.QueueUserWorkItem(callback, "Három");
            ThreadPool.QueueUserWorkItem(callback, "Négy");
            ThreadPool.QueueUserWorkItem(callback, "Öt");
            ThreadPool.QueueUserWorkItem(callback, "Hat");
            ThreadPool.QueueUserWorkItem(callback, "Hét");
            ThreadPool.QueueUserWorkItem(callback, "Nyolc");
            Console.ReadLine();
        }
    }
}
