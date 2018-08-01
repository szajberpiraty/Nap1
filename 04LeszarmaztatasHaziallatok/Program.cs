using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04LeszarmaztatasHaziallatok
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutya kutya = new Kutya(); //A függvényeket a kutya "felől" hívom
            
            
            kutya.Koszon();
            kutya.Enekel();
            kutya.Beszel();


            //Ebben az esetben a háziállat felől hívom a függvényeket. Lehet a Haziallat típusba new Kutya-t tenni hiszen abból származik
            Haziallat kutya2 = new Kutya(); 


            kutya2.Koszon();
            kutya2.Enekel();
            kutya2.Beszel();


            //direktben ki tudok jelölni egy felületet, most a Haziallat tipusu változónak a Kutya felületét használom
            ((Kutya)kutya2).Koszon();
            ((Kutya)kutya2).Enekel();
            ((Kutya)kutya2).Beszel();

            var haziallat2 = new Haziallat();
           // ((Kutya)haziallat2).Beszel(); invalid cast kivétel


            Console.ReadLine();
        }
        class Haziallat
        {
            public void Koszon()
            {
                Console.WriteLine("A háziállat köszön");
            }
            public void Enekel()
            {
                Console.WriteLine("A háziállat énekel");
            }
            //A leszármazottban felülírható
            public virtual void Beszel()
            {
                Console.WriteLine("A háziállat beszél");
            }

        }
        class Kutya : Haziallat
        {
            //Olyan, mintha a new kulcsszóval hoztuk volna létre
            public void Enekel()
            {
                Console.WriteLine("A kutya énekel"); 
            }
            public override void Beszel()
            {
                Console.WriteLine("A kutya beszél");
                //Az ősosztály függvényét a base-el tudom hívni.
                base.Beszel();
            }
        }
        class Macska:Haziallat
        {

        }
    }
}
