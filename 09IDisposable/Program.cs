using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

            //var tisztalev2 = new TisztaLevego();
            ////A using-ot a fordító egy ilyen kódblokká alakítja
            //try
            //{
                
            //}
            //finally//akármi van, lefut
            //{
            //    if (tisztalev2!=null)
            //    {
            //        tisztalev2.Dispose();
            //    }
            //}

        }

    }
    class TisztaLevego : IDisposable
    {
        //File stream esetében "kötelesek" (gentleman agreement) vagyunk megvalósítani az IDisposable-t.
        Stream menedzseltStream = new FileStream("testfile.txt", FileMode.Create);

        //Ha nem menedzselt memóriát használunk
        IntPtr NemMenedzseltMemoria = IntPtr.Zero; //Itt kikerül a szemétgyűjtő fennhatósága alól a memória terület, a megfelelő felszabadításról nekünk kell gondoskodni

        //HA nagy méretű menedzselt memóriát használunk
        List<string> menedzseltLista= new List<string>();
        public TisztaLevego()
        {
            NemMenedzseltMemoria = Marshal.AllocHGlobal(1000000);//Lefoglalok 1000000 byte-ot
            GC.AddMemoryPressure(1000000);//A szemétgyűjtő nem kezeli azt amit én lefoglaltam, közölni kell vele, hogy mennyit foglaltam le
            for (int i = 0; i < 1000000; i++)
            {
                menedzseltLista.Add(new string('A',1));
            }
        }

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
            if (dispose)
            {
                //még nem futott le a szemétgyűjtés
            }
        }
    }

}
