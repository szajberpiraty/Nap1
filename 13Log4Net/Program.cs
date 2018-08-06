using _13Log4Net.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13Log4Net
{
    class Program
    {
        private static readonly log4net.ILog log= log4net.LogManager.GetLogger("_13Log4Net program");
        static void Main(string[] args)
        {
            //Nagyon egyszerű nyomkövetés
            //PeldaNaplo();
            log4net.Config.XmlConfigurator.Configure();//appconfig konfigot betölti, létrehozza a környezetet
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            //Peldanaplo2();

            Peldanaplo3();

            //Így lehet elérni a Codefirts adatbázist

            //using (var db = new Log4netContext())
            //{
            //    Console.WriteLine("Bejegyzések:{0}",db.Logs.Count());
            //}

                Console.ReadLine();
            



        }

        private static void Peldanaplo3()
        {
            var r = new Random();



            while (!Console.KeyAvailable)
            {
                var level = r.Next(95);
                if (level < 50)
                {
                    log.DebugFormat("Debug üzenet {0}", level);

                }

                if (level >= 50 && level <= 70)
                {
                    log.InfoFormat("Info üzenet {0}", level);
                }
                if (level > 70 && level <= 85)
                {
                    try
                    {
                        throw new ArgumentNullException();
                    }
                    catch (Exception ex)
                    {

                        log.Error("Hiba!",ex);
                    }
                    log.WarnFormat("Warning üzenet {0}", level);
                }
                if (level > 85 && level <= 95)
                {
                    log.ErrorFormat("Warning üzenet {0}", level);
                }
                Thread.Sleep(200);
            }
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            log.Error("Hiba történet",e.Exception);
        }

        private static void Peldanaplo2()
        {
            for (int i = 0; i < 10; i++)
            {
                log.Debug("Naplóüzenet a log4net-ből");
            }
        }

        private static void PeldaNaplo()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("Hibakeresés:{0}", i);
            }
        }
    }
}
