using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Delegate
{
    class Program
    {
        /// <summary>
        /// Út a Delegate-ekhez (használatának lépései)
        /// 1. Készítünk egy típust, ez maga a delegate
        /// 2. Készítünk egy híváslistát
        /// 3. Meghívjuk a híváslistán szereplő függvényeket
        /// </summary>
        /// <param name="args"></param>
        /// 
        //Ha senki sincs a hívási listára feliratkozva, akkor a program hibára fut
        delegate void PeldaDelegate(string Uzenet); //A deklaráció a függvény visszatérési értékére ill. paraméterlistájára vonatkozik

        delegate int FvDelegatePelda();

        //Olyan delegate, ami képes módosítani az adatokon

        static void EgyikFuggveny(string Szov)
        {
            Console.WriteLine("Egyik függvény:{0}",Szov);
        }
        static void MasikFuggveny(string Par)
        {
            Console.WriteLine("Másik függvény:{0}", Par);
        }

        static void Main(string[] args)
        {
            //ElsoDelegateMinta(); //Kitettem füvvénybe
            MasodikDelegatePelda();



            //Ha visszatérési értékkel rendelkező függvényeket teszünk a híváslistára,
            //akkor abból egyet kapunk vissza, és nem fogjuk tudni, hogy melyiket,
            //tehát ilyet ne csináljunk

            HarmadikDelegatePelda();

            NegyedikDelegatePelda();

            Console.ReadLine();
        }


        /// <summary>
        /// Biztosítani kell, hogy  híváslistát csak akkor hívjuk meg, ha van rá feliratkozva metódus
        /// egyébként null reference errorral elszáll .
        /// </summary>
        private static void NegyedikDelegatePelda()
        {
            PeldaDelegate hivaslista=null;


            
            //if (hivaslista != null) helyett
            

            //lemásoljuk a híváslistát
            var lista = hivaslista;
            //majd itt ellenőrzünk
            if (lista!=null)
            {
                lista("paraméter");
            }
            //Vs2015, vagy az utáni környezetben
            //lista?.Invoke("paraméter");
           
            hivaslista("ez egy példa");
        }

        private static void HarmadikDelegatePelda()
        {
            FvDelegatePelda fuggvenyek = delegate { return 0; };


            fuggvenyek += ElsoFuggveny;
            fuggvenyek += MasodikFuggveny;
            
            //Leiratkozás a híváslistáról
            //fuggvenyek-=MasodikFuggveny;  


            var fv = fuggvenyek;
            //Biztosítjuk, hogy valaki legyen a híváslistán

            if (fv!=null)
            {
                var eredmeny = fuggvenyek();

                Console.WriteLine(eredmeny);  //Nem tudni, melyiket kapjuk vissza
            }

           
        }

        private static int MasodikFuggveny()
        {
            return 2;
        }

        private static int ElsoFuggveny()
        {
            return 1;
        }

        private static void MasodikDelegatePelda()
        {
            var modositoOsztaly = new ModositoOsztaly();
            modositoOsztaly.Add("Első");
            modositoOsztaly.Add("Második");
            modositoOsztaly.Add("Harmadik");
            modositoOsztaly.Add("Negyedik");
            modositoOsztaly.Add("Ötödik");

            modositoOsztaly.ModositasElvegzes(veddKiGt);
            modositoOsztaly.Tartalom();

            ModositoOsztaly.fvDefinicio modositasok;
            modositasok = veddKiM;

            //anonymous delegált
            modositasok += delegate (ref string szoveg)
            {
                szoveg = szoveg.Replace("a", "");
            };
            modositoOsztaly.ModositasElvegzes(modositasok);
            modositoOsztaly.Tartalom();
        }

        private static void veddKiM(ref string modositando)
        {
            modositando = modositando.Replace("m", "");
        }

        private static void veddKiGt(ref string modositando)
        {
            modositando = modositando.Replace("g", "");
           
        }

        private static void ElsoDelegateMinta()
        {
            PeldaDelegate hivasLista; //Híváslista a delegate alapján
            hivasLista = EgyikFuggveny; //felvesszük a függvényt a híváslistára
            hivasLista("első üzenet");  //híváslista meghívása
            hivasLista += MasikFuggveny; //Hozzáadunk egy másik függvényt


            //Biztosítjuk, hogy legyen valaki a híváslistán
            var hl = hivasLista;
            if (hl!=null)
            {
                hivasLista("mizu?");
            }

            
        }
    }

    internal class ModositoOsztaly
    {
        List<string> lista = new List<string>();
        public delegate void fvDefinicio(ref string modositando);

        public void ModositasElvegzes(fvDefinicio fvHivaslista)
        {

            for (int i = 0; i < lista.Count; i++)
            {
                var x = lista[i];

                //Biztosítjuk, hogy ne lehessen üres híváslistát meghívni
                var fvl = fvHivaslista;
                if (fvl!=null)
                {
                    fvHivaslista(ref x);
                    
                }
                lista[i] = x;
            }

        }
       
        public void Add(string elem)
        {
            lista.Add(elem);
        }
        public void Tartalom()
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
