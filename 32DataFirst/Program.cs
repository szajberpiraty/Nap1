using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32DataFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SchoolContext0Entities();

            foreach (var t in db.Teachers.ToList())
            {
                Console.WriteLine("{0},{1}", t.FirstName, t.LastName);
                Console.WriteLine("-->Subject:{0}", t.Subject);
                foreach (var student in t.Students.ToList())
                {
                    Console.WriteLine("---->Student{0}", student.Name);
                }
            }
            Console.ReadLine();
        }
    }
}
