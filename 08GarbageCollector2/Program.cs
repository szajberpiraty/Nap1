using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08GarbageCollector2
{
    class Program
    {
        static void Main(string[] args)
        {

            while (!Console.KeyAvailable)
            {
                //var stream = new MemoryStream(100000); //Folyamatosan megy a szemétgyűjtő
                var bitmap = new Bitmap(1280,1024);//Van véglegesítője, ezért nagyon könnyen elfogy a memória
                //using( var bitmap = new Bitmap(1280,1024)) {} -Így nem lesz memória probléma
            }
        }
    }
}
