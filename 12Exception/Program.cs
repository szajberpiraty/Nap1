using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            //kivétel kiváltása
            //throw new Exception();

            try
            {//Itt hajtjuk végre a kódot
                Console.WriteLine("Try ág kezdete");
                //throw new ArgumentOutOfRangeException();
                Foprogram();
            }
            catch (ArgumentOutOfRangeException ex) //Ha az exception van itt, akkor minden kivételt elkap a catch ág
            {   
                //Ha viszont pl ArgumentOutOfRangeException, akkor csak akkor hajtódik végre a catch ág, ha ilyen kivétel váltódik ki
                //Ez végrehajtódik kivétel esetén
                //vagy továbbmegyünk
                //vagy dobunk egy új kivételt
                //Ha dobunk kivételt, akkor is végrahajtódik a finally, utána jön a további kivételkezelés
                Console.WriteLine("Catch eleje");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Catch vége");
                //throw;
            }
            finally
            {
                Console.WriteLine("Finally eleje");
                //mindig végrehajtódik ami itt van

                Console.WriteLine("Finally vége");

            }
            Console.WriteLine("Finally után");
            Console.ReadLine();

        }

        private static void Foprogram()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("Finally eleje");
                //mindig végrehajtódik ami itt van

                Console.WriteLine("Finally vége");

            }

        }
    }
}
