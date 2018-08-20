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
        static void Main(string[] args)
        {
            var db = new SchoolContext();
            Console.WriteLine("Tanárok:{0}",db.Teachers.Count());
            Console.ReadLine();
        }
    }
}
