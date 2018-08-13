using Newtonsoft.Json;
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
            var serializer = new XmlSerializer(typeof(Adatosztaly));
            using (var fs = new FileStream(filename, FileMode.Create))
            {

               
                serializer.Serialize(fs,adat);

            }
            using (var fs = new FileStream(filename, FileMode.Open))
            {
               
                var beolvasott = serializer.Deserialize(fs);

                //Remek json konverter, naplózáskor is jól jöhet, egyszerűbb az adatok kiírása
                Console.WriteLine(JsonConvert.SerializeObject(beolvasott,Formatting.Indented));
            }
            Console.ReadLine();
            //Folytatás 28 perctől
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
