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
            Console.WriteLine("A tanárok száma {0}", db.Teachers.Count());

            //Rekordok felvitele
            var teacher1 = new Teacher() { FirstName = "Zubornyák", LastName = "Zénó", ClassCode = "1/9/1" };
            var teacher2 = new Teacher() { FirstName = "Vargánya", LastName = "Ubul", ClassCode = "1/9/2" };
            var teacher3 = new Teacher() { FirstName = "Vargassz", LastName = "Laller", ClassCode = "1/9/3" };
            var teacher4 = new Teacher() { FirstName = "Zubornyák", LastName = "Zénó", ClassCode = "1/9/1" };
            var teacher5 = new Teacher() { FirstName = "Vargánya", LastName = "Ubul", ClassCode = "1/9/2" };
            var teacher6 = new Teacher() { FirstName = "Vargassz", LastName = "Laller", ClassCode = "1/9/3" };

            db.Teachers.Add(teacher1);
            db.Teachers.Add(teacher2);
            db.Teachers.Add(teacher3);
            db.Teachers.Add(teacher4);
            db.Teachers.Add(teacher5);
            db.Teachers.Add(teacher6);

            MentesEsDarabszam(db);

            //db.Teachers.Remove(teacher1); //Egy tanár törlése

            //MentesEsDarabszam(db);

            //db.Teachers.RemoveRange(new Teacher[] { teacher2, teacher3 });  //Több tanár törlése

            //MentesEsDarabszam(db);

            //Bármi csinálásához listává kell alakítani, majd utána lehet rajta végigmenni, tehát ne a dbset-et kapja meg az enumerátor
            //hanem az adatbázis lekérdezést egy lépésben végrehajtva a memóriában lévő adatokon iteráljunk
            //foreach (var teacher in db.Teachers.ToList())
            //{
            //    db.Teachers.Remove(teacher);
            //}

            //MentesEsDarabszam(db);

            //Az EntityFramework sql lekérdezésre fordítja ezt a kifejezést
            var teachers191 = db.Teachers.Where(x=>x.ClassCode=="1/9/1");

            //Itt is érvényes a listává alakítás!!!
            foreach (var t191 in teachers191.ToList())
            {
                Console.WriteLine("Név {0},{1}",t191.FirstName,t191.LastName);
            }


            Console.ReadLine();
        }

        private static void MentesEsDarabszam(SchoolContext db)
        {
            db.SaveChanges(); //változások mentése
            Console.WriteLine("A tanárok száma {0}", db.Teachers.Count());
        }
    }
}
