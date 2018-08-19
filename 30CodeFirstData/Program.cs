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

            //Rekordok felvitele
            var teacher1 = new Teacher() { FirstName = "Zubornyák", LastName = "Zénó", ClassCode = "1/9/1" };
            var teacher2 = new Teacher() { FirstName = "Vargánya", LastName = "Ubul", ClassCode = "1/9/2" };
            var teacher3 = new Teacher() { FirstName = "Vargassz", LastName = "Laller", ClassCode = "1/9/3" };

            db.Teachers.Add(teacher1);
            db.Teachers.Add(teacher2);
            db.Teachers.Add(teacher3);


           db.SaveChanges(); //változások mentése


            Console.WriteLine("A tanárok száma {0}", db.Teachers.Count());

            db.Teachers.Remove(teacher1); //Egy tanár törlése

            db.SaveChanges(); //változások mentése
            Console.WriteLine("A tanárok száma {0}", db.Teachers.Count());

            db.Teachers.RemoveRange(new Teacher[] { teacher2, teacher3 });  //Több tanár törlése

            db.SaveChanges(); //változások mentése
            Console.WriteLine("A tanárok száma {0}", db.Teachers.Count());

            

            Console.ReadLine();
        }
    }
}
