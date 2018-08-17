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

            teszt2();


            Console.ReadLine();
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
