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

            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException; //Feliratkozás kivételekre, minden kivételnél kiváltódik, loggolható


            try
            {//Itt hajtjuk végre a kódot
                Console.WriteLine("Try ág kezdete");
                //throw new ArgumentOutOfRangeException();
                Foprogram();
            }
            catch (Exception ex) //Ha az exception van itt, akkor minden kivételt elkap a catch ág, több catch ág lehet, egyre szélesebb eredményt kell adnia
                                 //tehát az Exception szűrőfeltételnek kell legalul lennie
            {
                //Ha viszont pl ArgumentOutOfRangeException, akkor csak akkor hajtódik végre a catch ág, ha ilyen kivétel váltódik ki
                //Ez végrehajtódik kivétel esetén
                //vagy továbbmegyünk
                //vagy dobunk egy új kivételt
                //Ha dobunk kivételt, akkor is végrahajtódik a finally, utána jön a további kivételkezelés
                //Mit lehet tenni, ha egy korábbi exceptiont kapunk el?
                //vagy dobunk egy kivételt
                //újraszámozza a stack vermet, mintha innen jönne a kivétel
                //throw ex; nem túl jó
                //throw -ez sem olyan jó megoldás
                throw new Exception("Saját kivétel", ex);// Jó megoldás, innerexceptionbe csomagoljuk az infót, nem veszik el a stack infó


                //vagy továbbmegyünk

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
            Console.WriteLine("Finally után");//Ide csak akkor jut a végrehajtás, ha kezeltük a kivételt
            Console.ReadLine();

        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine("Log:{0}", e.ToString());
        }

        private static void Foprogram()
        {
            try
            {
                Console.WriteLine("Fő Try ág kezdete");
                Alprogram();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fő Catch eleje");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Fő Catch vége");
            }
            finally
            {
                Console.WriteLine("Fő Finally eleje");
                //mindig végrehajtódik ami itt van

                Console.WriteLine("Fő Finally vége");

            }
            Console.WriteLine("Fő Finally után");

        }

        private static void Alprogram()
        {
            try
            {
                Console.WriteLine("Al Try ág kezdete");
                throw new ArgumentOutOfRangeException();
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine("Al Catch eleje");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Al Catch vége");
            }
            finally
            {
                Console.WriteLine("Al Finally eleje");
                //mindig végrehajtódik ami itt van

                Console.WriteLine("Al Finally vége");

            }
            Console.WriteLine("Al Finally után");
        }
    }
    public class SajatException:Exception //saját többszintű kivétel struktúrát hozhatunk létre, rétegezhetjük a dolgot
        {
            
        }
    public class MasikException:SajatException 
    {

    }
}
