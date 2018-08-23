using _31CodeFirst.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31CodeFirst.Data
{
    class Program
    {
        //CRUD:Create,Read,Update,Delete
        //Kapcsolódáshoz connectionstrings.com!!!

        static void Main(string[] args)
        {
            var db = new SchoolContext();

            foreach (var t in db.Teachers.ToList())
            {
                Console.WriteLine("{0},{1}",t.FirstName,t.LastName);
                Console.WriteLine("-->Subject:{0}",t.Subject);
                foreach (var student  in t.Students.ToList())
                {
                    Console.WriteLine("---->Student{0}",student.Name);
                }
            }
            Console.WriteLine("Tanárok:{0}",db.Teachers.Count());
            Console.ReadLine();

            //Folytatás 44.06-től
            //Működik, további információk: Anders Abel, Julie Abel, Arthur Vickers (Entity Framework csapat tagja)
        }
    }
}
