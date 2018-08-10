using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17Esemenyek
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankszamla = new Bankszamla();
            bankszamla.ErtesitesiHivasLista += delegate { Console.WriteLine("Minuszba menté'!!"); };
            bankszamla.Jovairas(osszeg:500);

            //Probléma, hogy ezt meg lehet csinálni, így elvesztem az egységbezárást, ez ezt teszi
            bankszamla.ErtesitesiHivasLista = null;

            //Probléma, hogy kívülről meg lehet hívni a híváslistát
            //bankszamla.ErtesitesiHivasLista();
            bankszamla.Jovairas(osszeg: -5500);

          

            Console.ReadLine();
            //Nem engedhetem, hogy az egyenleget kívülről lehessen írni, ezért a property setterét private-ra kell állítani
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
        public Action ErtesitesiHivasLista = null;

        public int Egyenleg { get; private set; }

        public void Jovairas(int osszeg)
        {
            Egyenleg += osszeg;
            Console.WriteLine("Összeg:{0},új egyenleg{1}",osszeg,Egyenleg);
            if (Egyenleg<0)
            {
                //Értesíteni kell a tulajdonost
                var hivaslista = ErtesitesiHivasLista;
                if (hivaslista!=null)
                {
                    hivaslista();
                }
            }
        }
    }
}
