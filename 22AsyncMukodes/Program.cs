using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22AsyncMukodes
{
    class Program
    {
        static void Main(string[] args)
        {
            //függvény létrehozás, int és string paramétert vár, DateTime-ot ad vissza
            Func<int, string, DateTime> am = (ciklusok, nev) => 
            {
                Console.WriteLine("+-{0} elindult ciklusok {1}",nev,ciklusok);
                for (int i = 0; i < ciklusok; i++)
                {
                    Console.WriteLine("+-{0} ciklus {1}",nev,i);
                    Thread.Sleep(400);
                }
                Console.WriteLine("+-{0} végzett", nev);
                return DateTime.Now;
            };
            var eredmeny0=am(3, "szinkron hívás");
            Console.WriteLine("+Fő szál szinkron hívás elindult");
            Console.WriteLine("+Fő szál végzett eredmény {0}",eredmeny0);

            //Szinkron módon így is meg lehetett volna hívni
            //var eredmeny0=am.Invoke(3,"Szinkron hívás");

            //Aszinkron indítás
            var ar01=am.BeginInvoke(5, "Aszinkron példa 1", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult");

            //Hogyan lehet egy aszinkron hívás eredményéhez hozzáférni?

            //1.lehetőség: blokkolás
            var eredmeny01 = am.EndInvoke(ar01);
            Console.WriteLine("+Fő szál aszinkron 1 végzett eredmény {0}", eredmeny01);

            //Folytatás 20:54-től
            //2. lehetőség: pollozás, pollozhatjuk a hívás végét jelző flag-et

            var ar02 = am.BeginInvoke(5, "Aszinkron példa 2", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult");

            var wait = 0;
            while (!ar02.IsCompleted)
            {
                //Itt lehet egyéb munkát elvégezni
                Thread.Sleep(300);
                wait += 300;
                Console.WriteLine("+Fő szál: várakozunk a második példára {0}",wait);
            }

            var eredmeny02 = am.EndInvoke(ar02);
            Console.WriteLine("+Fő szál aszinkron 2 végzett eredmény {0}", eredmeny02);

            //3.Várunk egy ideig az aszinkron végrehajtásra
            

            var ar03 = am.BeginInvoke(5, "Aszinkron példa 3", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult");

            wait = 0;
            //Minden ciklusban várunk, amíg véget ér a feladat, de legfeljebb 300ms-ot
            while (!ar03.AsyncWaitHandle.WaitOne(300))
            {
                //Itt lehet egyéb munkát elvégezni
                //Thread.Sleep(300);
                wait += 300;
                Console.WriteLine("+Fő szál: várakozunk a harmadik példára {0}", wait);
            }

            var eredmeny03 = am.EndInvoke(ar03);
            Console.WriteLine("+Fő szál aszinkron 3 végzett eredmény {0}", eredmeny03);

            //4.Több függvényt indítunk párhuzamosan


            var ar041 = am.BeginInvoke(6, "Aszinkron példa 401", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult 401");

            var ar042 = am.BeginInvoke(4, "Aszinkron példa 402", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult 402");

            var ar043 = am.BeginInvoke(5, "Aszinkron példa 403", null, null);
            Console.WriteLine("+Fő szál aszinkron hívás elindult 403");

            //Így egyszerre tetszőleges számú aszinkron végrehajtást be tudunk várni
            WaitHandle.WaitAll(new WaitHandle[]
            {
                ar041.AsyncWaitHandle,
                ar042.AsyncWaitHandle,
                ar043.AsyncWaitHandle
            }
                
                );

            var eredmeny041 = am.EndInvoke(ar041);
            Console.WriteLine("+Fő szál aszinkron 401 végzett eredmény {0}", eredmeny041);
            var eredmeny042 = am.EndInvoke(ar042);
            Console.WriteLine("+Fő szál aszinkron 402 végzett eredmény {0}", eredmeny042);
            var eredmeny043 = am.EndInvoke(ar043);
            Console.WriteLine("+Fő szál aszinkron 403 végzett eredmény {0}", eredmeny043);


            //5.Callback használata
            var ar051 = am.BeginInvoke(5, "Aszinkron példa 51", MunkaVege, null);
            Console.WriteLine("+Fő szál aszinkron 5 hívás elindult");

            //ugyanez lambdával
            var ar052 = am.BeginInvoke(5, "Aszinkron példa 52"
                ,x=> Console.WriteLine("Callback szál ötödik példa végzett")
                , null);
            Console.WriteLine("+Fő szál aszinkron 5 hívás elindult");

            //6.callback visszatérési értékkel
            //Visszatérési értékhez EndInvoke-ot kell hívni, ahhoz pedig kell a híváslista am változója,
            //ezért ezt átadjuk
            var ar061 = am.BeginInvoke(5, "Aszinkron példa 61", MunkaVegeEredmennyel, am);
            Console.WriteLine("+Fő szál aszinkron 61 hívás elindult");


            Console.ReadLine();
        }

        private static void MunkaVegeEredmennyel(IAsyncResult ar)
        {
            //A híváskor átadott 4. paraméterhez így lehet hozzáférni
            var hivaslista = ar.AsyncState;
            //Ahhoz, hogy a típus felületéhez hozzáférjünk, konvertálni (castolni) kell
            var am = (Func<int, string, DateTime>)hivaslista;

            //Így már elérhető az eredmény
            var eredmeny = am.EndInvoke(ar);
            Console.WriteLine("Callback szál ötödik példa végzett, eredmény {0}",eredmeny);
        }

        private static void MunkaVege(IAsyncResult ar)
        {
            Console.WriteLine("Callback szál ötödik példa végzett");
        }
    }
}
