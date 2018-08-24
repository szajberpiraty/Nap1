using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32DataFirst
{
    public partial class Teacher
    {
        public string FullName
        {
            get
            {
                return string.Format("{0},{1}",FirstName,LastName);
            }

        }
    }
}
