using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19StreamekStreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "teszt.txt";
            File.WriteAllText(filename,
                string.Format("Ez a kiírandó tartalom{0},{1},{2},{3}"
                , Environment.NewLine
                , (char)113
                , Convert.ToChar(119)
                , '\u0027')
                , Encoding.UTF8);
        }
    }
}
