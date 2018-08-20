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
        //A SchoolContext-et le kell származtatni a DbContext-ből, ehhez be kell tölteni a System.Data.Entity-t, amit az EntityFramework szállít
        public DbSet<Teacher> Teachers { get; set; }
    }
}
