using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _27TaskokBevezetes
{
    class Program
    {
        static void Main(string[] args)
        {
            //task státuszok
            //teszt1();

            //teszt2();

            //Taszkok leállítása
            teszt3();


            Console.ReadLine();
        }

        private static void teszt3()
        {
            //1.lépés, token létrehozása
            var cts = new CancellationTokenSource();
            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //3.lépés, erőforrás takarítás ha kell
                    if (cts.IsCancellationRequested)
                    {//Ha érkezett leállítási kérés, akkor itt el lehet végezni az erőforrások felszabadítását
                        Console.WriteLine("Cancel érkezett, takarítunk");
                    }
                    //4.Exception dobása
                    cts.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("i:{0}", i);
                    Thread.Sleep(100);

                }

              

            };
            var task = new Task(todo,cts.Token);//2.lépés, token átadása
            task.Start();
          
            try
            {
                Thread.Sleep(200);
                //5.lépés, cancel kiadása
                cts.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {//6. cancel kezelése

                foreach (var e in ex.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Cancel érkezett");
                    }
                }
                
            }
            Console.WriteLine(task.Status);

        }

        private static void teszt2()
        {
            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("i:{0}", i);
                    Thread.Sleep(100);
                 
                }
                
                throw new StackOverflowException();
               
            };
           
            var task = new Task(todo);
            task.Start();
            try
            {
                task.Wait();
            }
            //catch (Exception ex)
            catch (AggregateException ex) //Ha innerexceptions-t akarunk használni a foreach-ben, akkor AggregateException kell
            {

                //Console.WriteLine("Mess:{0}",ex.Message);
                //Egyik lehetőség a hiba megállapítására
                //Console.WriteLine(((AggregateException)ex).Flatten());
                //((AggregateException)ex).Flatten(); //A fa struktúrájú exception láncot kiteríthetjük
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        private static void teszt1()
        {
            Action todo = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("i:{0}", i);
                    Thread.Sleep(500);
                }
            };
            var task = new Task(todo);

            Console.WriteLine("Státusz:{0}", task.Status);
            task.Start();
            Console.WriteLine("Státusz:{0}", task.Status);
            Thread.Sleep(100);
            Console.WriteLine("Státusz:{0}", task.Status);
            task.Wait();
            Console.WriteLine("Státusz:{0}", task.Status);
        }
    }
}
