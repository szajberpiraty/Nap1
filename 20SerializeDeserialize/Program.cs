using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _20SerializeDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            var adat = new Adatosztaly() {
                Egesz = 10,
                TizedesTort=12.67m,
                Datum=DateTime.MaxValue,
                DatumMin=DateTime.MinValue,
                Szoveg="ÁrvíztűrőTükörfúrógép"
            
            };
            var filename = "teszt.txt";
            using (var fs = new FileStream(filename, FileMode.Create))
            {

                var serializer = new XmlSerializer(typeof(Adatosztaly));
                serializer.Serialize(fs,adat);

            }


        }
    }
    public class Adatosztaly
    {
        public int Egesz { get; set; }
        public decimal TizedesTort { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumMin { get; set; }
        public string Szoveg { get; set; }
    }
}
