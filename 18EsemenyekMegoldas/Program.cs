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
            bankszamla.MinuszbaMenne += EsemenyKezelo;
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
            Console.WriteLine("Minuszba menté'!! Egyenleg előtte {0},Összeg{1},Egyenleg utána{2}",e.EgyenlegElotte,e.JovairOsszeg,e.EgyenlegUtana);
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

        public event EventHandler<EsemenyDTO> MinuszbaMenne = null;

        private bool OnMinuszbaMenne(int osszeg,int egyenlegElotte, int egyenlegUtana)
        {
            var hivaslista = MinuszbaMenne;
            var dto = new EsemenyDTO(osszeg, egyenlegElotte, Egyenleg);

            if (hivaslista != null)
            {
                //paraméterezni kell, az eventargs.empty jelenti, ha semmit nem akarunk az e paraméterben küldeni
               
                hivaslista(this, dto);
                
            }
            return dto.MehetAJovairas;
        }

        public int Egyenleg { get; private set; }

        public void Jovairas(int osszeg)
        {
            var egyenlegElotte = Egyenleg;
           
            if (Egyenleg+osszeg < 0)
            {
                //Értesíteni kell a tulajdonost
               
                    //paraméterezni kell, az eventargs.empty jelenti, ha semmit nem akarunk az e paraméterben küldeni
                   
                    if (OnMinuszbaMenne(osszeg,egyenlegElotte,Egyenleg+osszeg))
                    {
                        Egyenleg += osszeg;
                        Console.WriteLine("Összeg:{0},új egyenleg{1}", osszeg, Egyenleg);
                    }
                
            }
            else
            {

            }
        }
    }

    //Data Transfer Object
    //public class EsemenyDTO:EventArgs -nem kötelező, de C# konvenció, hogy az EsemenyDTO osztály leszármaztatjuk  az EventArgs-ból

    public class EsemenyDTO
    {
        

        public EsemenyDTO(int osszeg,int elotte,int egyenleg)
        {
            this.JovairOsszeg = osszeg;
            this.EgyenlegElotte = elotte;
            this.EgyenlegUtana = egyenleg;
            this.MehetAJovairas = true;
        }

        public int JovairOsszeg { get; set; }
        public int EgyenlegElotte { get; set; }
        public int EgyenlegUtana { get; set; }
        public bool MehetAJovairas { get; set; }
    }
}
