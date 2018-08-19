using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30CodeFirstData.models
{
    //A SchoolContext-et le kell származtatni a DbContext-ből, ehhez be kell tölteni a System.Data.Entity-t, amit az EntityFramework szállít
    class SchoolContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
    }
}
