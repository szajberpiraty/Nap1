using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25AsyncFileHagyomanyos
{
    class Program
    {

        static int pufferMeret = 90000;
        static byte[] puffer = new byte[pufferMeret];

        static void Main(string[] args)
        {
            string filenev = "teszt.txt";
            using (var fscreate = new FileStream(filenev, FileMode.Create))
            {
                fscreate.SetLength(1000000);
            }
                       
            var fs = new FileStream(filenev, FileMode.Open);
                  
            fs.BeginRead(puffer, 0, pufferMeret, CallbackFv, fs);

            //innentől kezdve a beolvasás megy egy másik szálon, nem kell vele foglalkozni
           
            Console.ReadLine();
        }

        private static void CallbackFv(IAsyncResult ar)
        {

            var fs = (FileStream)ar.AsyncState;

            var olvasottByteok = fs.EndRead(ar);
            if (olvasottByteok > 0)
            {//még nem végeztünk
                Console.WriteLine("Beolvasva {0},pozício {1}", olvasottByteok, fs.Position);
                fs.BeginRead(puffer, 0, pufferMeret, CallbackFv, fs);
            }
            else
            {//végeztünk
             //beállítom a szemafort

                Console.WriteLine("Végeztünk");
                fs.Dispose();
            }

        }
            
        }
    }


