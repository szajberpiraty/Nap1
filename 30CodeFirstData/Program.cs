using _30CodeFirstData.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30CodeFirstData
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SchoolContext();
            Console.WriteLine("A tanárok száma {0}",db.Teachers.Count());

            db.Teachers.Add(new Teacher() { FirstName = "Zubornyák", LastName = "Zénó", ClassCode = "1/9/1" });

            Console.ReadLine();
        }
    }
}
