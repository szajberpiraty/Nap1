using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var tisztalevego = new TisztaLevego())
            { }

            //Ez kódblokk a try ágban megpróbálja végrahajtani a parancsokat(vagy sikerül, vagy nem), utána a finally ágban lévő kódot mindenképp végrehajtja

            var tisztalev2 = new TisztaLevego();
            //A using-ot a fordító egy ilyen kódblokká alakítja
            try
            {
                
            }
            finally//akármi van, lefut
            {
                if (tisztalev2!=null)
                {
                    tisztalev2.Dispose();
                }
            }

        }

    }
    class TisztaLevego : IDisposable
    {
        //File stream esetében "kötelesek" (gentleman agreement) vagyunk megvalósítani az IDisposable-t.
        //Ha nem menedzselt memóriát használunk
        IntPtr nemmenedzseltmem = IntPtr.Zero; //Itt kikerül a szemétgyűjtő fennhatósága alól a memória terület, a megfelelő felszabadításról nekünk kell gondoskodni


        Stream ms = new FileStream("testfile.txt",FileMode.Create);

        ~TisztaLevego()
        {
            Dispose(false);
        }

       
        public void Dispose()
        {
            Dispose(true);
            //Mivel már normálban takarítunk, ezért megadjuk a GC-nek, hogy a véglegesítőt nem kell később meghívni.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            throw new NotImplementedException();
        }
    }

}
