using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18EsemenyekMegoldas
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankszamla = new Bankszamla();
            bankszamla.ErtesitesiHivasLista += EsemenyKezelo;
            bankszamla.Jovairas(osszeg: 500);

            //Probléma, hogy ezt meg lehet csinálni, így elvesztem az egységbezárást, ez ezt teszi
            //bankszamla.ErtesitesiHivasLista = null;

            //Probléma, hogy kívülről meg lehet hívni a híváslistát
            //bankszamla.ErtesitesiHivasLista();

            bankszamla.Jovairas(osszeg: -5500);



            Console.ReadLine();
            //Nem engedhetem, hogy az egyenleget kívülről lehessen írni, ezért a property setterét private-ra kell állítani
        }

        private static void EsemenyKezelo(object sender, EsemenyDTO e)
        {
            Console.WriteLine("Minuszba menté'!! Egyenleg {0},Összeg{1}",((Bankszamla)sender).Egyenleg,e.JovairOsszeg);
        }
    }
    class Bankszamla
    {
        //Ezt lehet, de nem feltétlenül szükséges
        //public Bankszamla()
        //{
        //    Egyenleg = 0;
        //}
        //delegate-el próbáljuk megoldani, hogy a számla értesítsen minket
        //public delegate void MinuszEgyenlegErtesitesiFvDef();

        //public MinuszEgyenlegErtesitesiFvDef ErtesitesiHivasLista=null;

        //Az action egyszerűbb megoldás
        //public Action ErtesitesiHivasLista = null;

        //Ezek helyett Event-et használunk
        //Event az  egy speciális delegate
        //Csak void metódust használhatunk, nincs visszatérési érték
        //Nem lehet az osztályon kívül hívni
        //Nem lehet az osztályon kyvül (=-vel) értéket adni,így felülírni a híváslistát
        // A delegate funkció kiváltására az EventHandler szolgál

        public event EventHandler<EsemenyDTO> ErtesitesiHivasLista = null;

        public int Egyenleg { get; private set; }

        public void Jovairas(int osszeg)
        {
            Egyenleg += osszeg;
            Console.WriteLine("Összeg:{0},új egyenleg{1}", osszeg, Egyenleg);
            if (Egyenleg < 0)
            {
                //Értesíteni kell a tulajdonost
                var hivaslista = ErtesitesiHivasLista;
                if (hivaslista != null)
                {
                    //paraméterezni kell, az eventargs.empty jelenti, ha semmit nem akarunk az e paraméterben küldeni
                    hivaslista(this, new EsemenyDTO(osszeg));
                }
            }
        }
    }

    public class EsemenyDTO
    {
        

        public EsemenyDTO(int osszeg)
        {
            this.JovairOsszeg = osszeg;
        }

        public int JovairOsszeg { get; set; }
    }
}
