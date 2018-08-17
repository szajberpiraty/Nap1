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
            //teszt3();
            //több taszk párhuzamos leállítása
            //teszt4();

            //Taszkok közötti függőségek kezelése
            teszt5();


            Console.ReadLine();
        }

        private static void teszt5()
        {
            var cts = new CancellationTokenSource();

            Task task = null;// így meg lehet oldani, hogy az Action-on belülről is ki lehessen iratni a taszk állapotát

            Action subtodo = () =>
            {
                Thread.Sleep(500);
                Console.WriteLine("+-Alfeladat futik{0},{1}",Thread.CurrentThread.ManagedThreadId,task.Status);

            };

            Action todo = () =>
            {
                Console.WriteLine("+Feladat futik {0},{1}",Thread.CurrentThread.ManagedThreadId,task.Status);
                Task.Factory.StartNew(subtodo,TaskCreationOptions.AttachedToParent); //Hozzákötjük a létrehozóhoz
            };
            //A fő feladatból hívjuk

            task = new Task(todo); //itt viszont akkor nem kell var, hiszen korábban már létrejött a task változó!!!!
            Console.WriteLine("Státusz:{0}", task.Status);
            task.Start();
            Console.WriteLine("Státusz:{0}", task.Status);
            Thread.Sleep(100);
            Console.WriteLine("Státusz:{0}", task.Status);
            Thread.Sleep(800);
            task.Wait();
            Console.WriteLine("Státusz:{0}", task.Status);

        }

        private static void teszt4()
        {
            //itt mindent úgy csinálunk, ahogy kell
            var cts = new CancellationTokenSource();
            Action todo1 = () =>
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
            Action todo2 = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //3.lépés, erőforrás takarítás ha kell
                    if (cts.IsCancellationRequested)
                    {//Ha érkezett leállítási kérés, akkor itt el lehet végezni az erőforrások felszabadítását
                        Console.WriteLine("Cancel érkezett, takarítunk");
                    }
                    //4.Exception dobása
                    //itt nem dobunk kivételt
                    //cts.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("i:{0}", i);
                    Thread.Sleep(100);

                }

                
            };
            Action todo3 = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("i:{0}", i);
                    Thread.Sleep(100);

                }

                throw new StackOverflowException();

            };

            //Csak akkor fog rendesen működni, ha mind a 6 lépést betartjuk, egyébként hibás lesz a működés
            var task1 = new Task(todo1,cts.Token);
            var task2 = new Task(todo2, cts.Token);
            var task3 = new Task(todo1);
            var task4 = new Task(todo2);
            var task5 = new Task(todo3,cts.Token);
            var task6 = new Task(todo3);
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            task5.Start();
            task6.Start();


            try
            {
                Thread.Sleep(200);
                //5.lépés, cancel kiadása
                cts.Cancel();
                Task.WaitAll(new Task[] {task1,task2,task3,task4,task5,task6 });
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
            Console.WriteLine("T1 státusz:{0}", task1.Status);
            Console.WriteLine("T2 státusz:{0}", task2.Status);
            Console.WriteLine("T3 státusz:{0}", task3.Status);
            Console.WriteLine("T4 státusz:{0}", task4.Status);
            Console.WriteLine("T5 státusz:{0}", task5.Status);
            Console.WriteLine("T6 státusz:{0}", task6.Status);
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
