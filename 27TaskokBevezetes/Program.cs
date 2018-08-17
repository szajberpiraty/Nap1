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
            Action todo = () =>
              {
                  for (int i = 0; i < 10; i++)
                  {
                      Console.WriteLine("i:{0}",i);
                      Thread.Sleep(500);
                  }
              };
            var task = new Task(todo);

            Console.WriteLine("Státusz:{0}",task.Status);
            task.Start();
            Console.WriteLine("Státusz:{0}", task.Status);
            Thread.Sleep(100);
            Console.WriteLine("Státusz:{0}", task.Status);
            task.Wait();
            Console.WriteLine("Státusz:{0}", task.Status);
            Console.ReadLine();
        }
    }
}
