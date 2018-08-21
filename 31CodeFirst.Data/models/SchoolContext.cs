using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31CodeFirst.Data.models
{
    public class SchoolContext:DbContext
    {
        //Induláskor keres egy schoolcontext nevű connection string-et, ha van használja, ha nincs, akkor a SchoolContext az adatbázisnév
        //public SchoolContext():base("SchoolContext") //Adunk neki rendes nevet a konstruktorban
        //{

        //}
        //Ha így írjuk, name=.... akkor ez a connectionstringet jelöli
        public SchoolContext() : base("name=SchoolContext") //Adunk neki rendes nevet a konstruktorban
        {

        }

        //A SchoolContext-et le kell származtatni a DbContext-ből, ehhez be kell tölteni a System.Data.Entity-t, amit az EntityFramework szállít
        public DbSet<Teacher> Teachers { get; set; }


        //Akár ez is következhetne, de akkor mindig újra kellene építgetni az adatbázist, ezért nem lesz jó.
        //A migráció bekapcsolása után már jó a dolog
        public DbSet<Subject> Subjects { get; set; }

        //A package management console-ban engedélyezni kell a migrációt (enable-migration)
    }
}
