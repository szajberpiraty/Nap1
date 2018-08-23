using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31CodeFirst.Data.models
{
    public class Teacher
    {
        public Teacher()
        {//Null object
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassCode { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
