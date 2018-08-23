using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31CodeFirst.Data.models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher teacher { get; set; }
    }
}
