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
            var listaadat = new ListaAdat();
            

            var adat = new Adatosztaly() {
                Egesz = 10,
                TizedesTort=12.67m,
                Datum=DateTime.MaxValue,
                DatumMin=DateTime.MinValue,
                Szoveg="ÁrvíztűrőTükörfúrógép",
                Jelszo="Titok",
                Aladatosztaly=new AlAdatosztaly()
                {
                    Egesz = 112,
                    TizedesTort = decimal.MinValue,
                    Datum = DateTime.MaxValue,
                    DatumMin = DateTime.MinValue,
                    Szoveg = "ÁrvíztűrőTükörfúrógép"
                }
            
            };

            listaadat.ListaAdatok.Add(adat);
            listaadat.ListaAdatok.Add(adat);
            listaadat.ListaAdatok.Add(adat);
            listaadat.ListaAdatok.Add(adat);

            var filename = "teszt.txt";
            //var serializer = new XmlSerializer(typeof(Adatosztaly));
            var serializer = new XmlSerializer(typeof(ListaAdat));
            using (var fs = new FileStream(filename, FileMode.Create))
            {

               
                //serializer.Serialize(fs,adat);
                //A property-jét kell kiírni, különben kivételt dob
                serializer.Serialize(fs, listaadat);

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
        [XmlElement("MasValami")] //Az XML állományban így szerepel
        public DateTime Datum { get; set; }
        public DateTime DatumMin { get; set; }
        public string Szoveg { get; set; }
        //Meg lehet akadályozni a property fájlba írását
        [XmlIgnore]
        public string Jelszo { get; set; }
        public AlAdatosztaly Aladatosztaly { get; set; }
    }
    public class AlAdatosztaly
    {
        public int Egesz { get; set; }
        public decimal TizedesTort { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumMin { get; set; }
        public string Szoveg { get; set; }
    }
    public class ListaAdat
    {
        public ListaAdat()
        {
            //Kell a konstruktor, különben mindig ellenőrizni kell, hogy létezik-e (minden hozzáadás előtt)
            ListaAdatok = new List<Adatosztaly>(); 
        }
        public List<Adatosztaly> ListaAdatok { get; set; }
    }
}
