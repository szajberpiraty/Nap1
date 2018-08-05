using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            for (int i = 0; i < 10; i++)
            {
                log.Debug("Naplóüzenet a log4net-ből");
            }
            Console.ReadLine();
            //folytatás 0:47-től

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
