using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        //Védeni kell a függvényeket és a property-ket is
        public void Tennivalo()
        {
            //todo:tennivaló végiggondolni, hogy a megoldás teljes-e
            if (isDisposed==1)
            {
                throw new ObjectDisposedException(nameof(TisztaLevego));
            }
            //Tennivaló elintézése

        }

        //property védelme
        private int myProperty;
        public int MyProperty
        {
            get
            {
                if (isDisposed == 1)
                {
                    throw new ObjectDisposedException(nameof(TisztaLevego));
                }
                //Tennivaló elintézés
                return myProperty;
            }


            set
            {
                if (isDisposed == 1)
                {
                    throw new ObjectDisposedException(nameof(TisztaLevego));
                }
                //Tennivaló elintézés
            }



        }
        

              



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

        private int isDisposed=0;
      

        private void Dispose(bool dispose)
        {
            //Ez így nem szálbiztos!
            //if (isDisposed)
            //{
            //    throw new ObjectDisposedException(nameof(TisztaLevego));
            //}
            //isDisposed = true;

            //Szálbiztos verzió: itt az isDispose típusát meg kell változtatni, mert bool-al nem megy
            //Három dolgot csinál
            //1. var old=isDisposed  elmenti a változót
            //2. isDisposed=1
            //3. return old /visszatér az old-al

            if (Interlocked.Exchange(ref isDisposed, 1)==1)
            {//ha ez van akkor a dispose már lefutott
                throw new ObjectDisposedException(nameof(TisztaLevego));
            }
            


            if (dispose)
            {
                //if (menedzseltLista!=null) nem tökéletes megoldás
                //{
                    //még nem futott le a szemétgyűjtés, a menedzselt objektumokat takarítani kell
                    menedzseltLista.Clear();
                    //menedzseltLista=null;
                //}
                menedzseltStream.Dispose();
                //menedzseltStream = null;
                                

            }
            //nem menedzselt memória takarítása
            Marshal.FreeHGlobal(NemMenedzseltMemoria);
            GC.RemoveMemoryPressure(1000000);

        }
    }

}
