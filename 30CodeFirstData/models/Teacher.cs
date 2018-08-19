using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30CodeFirstData.models
{
    class Teacher
    {

        /// <summary>
        /// Minden tanár egy adott osztályban egy adott tantárgyat tanít
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassCode { get; set; }
        


    }
}
