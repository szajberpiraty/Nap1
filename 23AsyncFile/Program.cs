using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _23AsyncFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filenev = "teszt.txt";
            using (var fs = new FileStream(filenev, FileMode.Create))
            {
                fs.SetLength(1000000);
            }

            //A várakozáshoz létrehozunk egy kétállapotú nem beállított szemafort
            var mre = new ManualResetEvent(false);
            //Rossz megoldás lambdával
            using (var fs = new FileStream(filenev, FileMode.Open))
            {
                int pufferMeret = 90000;
                byte[] puffer = new byte[pufferMeret];
                AsyncCallback rekurzivCallback = null;
                AsyncCallback callback = ar=> 
                {
                    var olvasottByteok = fs.EndRead(ar);
                    if (olvasottByteok>0)
                    {//még nem végeztünk
                        Console.WriteLine("Beolvasva {0},pozício {1}",olvasottByteok,fs.Position);
                        fs.BeginRead(puffer, 0, pufferMeret, rekurzivCallback, null);
                    }
                    else
                    {//végeztünk
                        //beállítom a szemafort
                        mre.Set();
                        Console.WriteLine("Végeztünk");
                    }
                   
                };
                rekurzivCallback = callback;
                fs.BeginRead(puffer,0,pufferMeret,callback,null);
                Console.WriteLine("Szemaforra várunk");
                mre.WaitOne();
                Console.WriteLine("Szemafor zöld");
            }

            //Ez a megoldás elszáll, megy az aszinkron hívás, közben a főszál véget ér, így aztán kezeletlen dispose-al meghal a program
            Console.ReadLine();
        }
    }
}
