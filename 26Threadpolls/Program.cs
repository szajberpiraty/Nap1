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
        /// 
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            //Teszt1();
           // Teszt2();

            Teszt3();
            Console.ReadLine();
        }

        private static void Teszt3()
        {
            int gyujto = 0;
            var mre = new ManualResetEvent(false);

            WaitCallback callback = o =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
               
                Console.WriteLine("+->{0} Elindult, id {1}", o, id);

                for (int i = 0; i < 20000; i++)
                {
                    lock (_lock) { 
                    gyujto += i;
                    }
                }
                //mre.Set();    
                Console.WriteLine("+->{0}, eredmény {1} Végzett, id {2}", o, gyujto,id);
            };
          
            ThreadPool.QueueUserWorkItem(callback, "Egy");
            ThreadPool.QueueUserWorkItem(callback, "Kettő");
            ThreadPool.QueueUserWorkItem(callback, "Három");
            ThreadPool.QueueUserWorkItem(callback, "Négy");
            //Káosz az eredmény, nem lehet, hogy ugyanazon változót több szálból olvassuk, írjuk
            //mre.WaitOne();
            Console.ReadLine();
            Console.WriteLine("Eredmeny: {0}",gyujto);
        }

        private static void Teszt2()
        {
            var mre = new ManualResetEvent(false);
            WaitCallback callback = o =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("+->{0} Elindult, id {1}", o, id);
                //Ha ez rövidebb idő, akkor a thread időben felszabadul,és a következő megkapja
                //Ha több idő, pl 10.sec, akkor egy idő után a scheduler új szálat hoz létre, de ez időbe telik
                //Thread.Sleep(10000);
                mre.WaitOne();
                Console.WriteLine("+->{0} Végzett, id {1}", o, id);
            };

           

            ThreadPool.QueueUserWorkItem(callback, "Egy");
            ThreadPool.QueueUserWorkItem(callback, "Kettő");
            ThreadPool.QueueUserWorkItem(callback, "Három");
            ThreadPool.QueueUserWorkItem(callback, "Négy");
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("Öt vár");Thread.Sleep(2000); Console.WriteLine("Öt beállít"); mre.Set(); });

            //Console.WriteLine("+Main A jelző piros");
            //Console.ReadLine();
            //mre.Set();
            //Console.WriteLine("+Main A jelző zöld");


        }

        private static void Teszt1()
        {
            WaitCallback callback = o =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("+->{0} Elindult, id {1}", o, id);
                //Ha ez rövidebb idő, akkor a thread időben felszabadul,és a következő megkapja
                //Ha több idő, pl 10.sec, akkor egy idő után a scheduler új szálat hoz létre, de ez időbe telik
                Thread.Sleep(10000);
                Console.WriteLine("+->{0} Végzett, id {1}", o, id);
            };

            //Processzoronként 1 thread a minimum, ez alá nem tudunk menni
            ThreadPool.SetMaxThreads(6, 300);

            //Szálak minimális száma
            ThreadPool.SetMinThreads(6, 300);

            ThreadPool.QueueUserWorkItem(callback, "Egy");
            ThreadPool.QueueUserWorkItem(callback, "Kettő");
            ThreadPool.QueueUserWorkItem(callback, "Három");
            ThreadPool.QueueUserWorkItem(callback, "Négy");
            ThreadPool.QueueUserWorkItem(callback, "Öt");
            ThreadPool.QueueUserWorkItem(callback, "Hat");
            ThreadPool.QueueUserWorkItem(callback, "Hét");
            ThreadPool.QueueUserWorkItem(callback, "Nyolc");
           
        }
    }
}
