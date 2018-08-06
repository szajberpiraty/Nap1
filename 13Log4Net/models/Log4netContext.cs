using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13Log4Net.models
{
    public class Log4netContext:DbContext
    {
        public DbSet<Log> dbSet { get; set; }
    }
}
