using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24AsyncFileUsingNelkul
{
    class Program
    {
        static void Main(string[] args)
        {
            string filenev = "teszt.txt";
            using (var fscreate = new FileStream(filenev, FileMode.Create))
            {
                fscreate.SetLength(1000000);
            }



            //Rossz megoldás lambdával
            var fs = new FileStream(filenev, FileMode.Open);
            
                int pufferMeret = 90000;
                byte[] puffer = new byte[pufferMeret];
                AsyncCallback rekurzivCallback = null;
                AsyncCallback callback = ar =>
                {
                    var olvasottByteok = fs.EndRead(ar);
                    if (olvasottByteok > 0)
                    {//még nem végeztünk
                        Console.WriteLine("Beolvasva {0},pozício {1}", olvasottByteok, fs.Position);
                        fs.BeginRead(puffer, 0, pufferMeret, rekurzivCallback, null);
                    }
                    else
                    {//végeztünk
                        //beállítom a szemafort
                      
                        Console.WriteLine("Végeztünk");
                        fs.Dispose();
                    }

                };
                rekurzivCallback = callback;
                fs.BeginRead(puffer, 0, pufferMeret, callback, null);
             
            

            //Ez a megoldás elszáll, megy az aszinkron hívás, közben a főszál véget ér, így aztán kezeletlen dispose-al meghal a program
            Console.ReadLine();
            //Folytatás 28:50-től az async hagyományossal
        }
    }
}
