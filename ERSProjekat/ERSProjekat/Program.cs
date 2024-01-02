using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ERSProjekat
{
    internal class Program : UIClass
    {
        static void Main(string[] args)
        {

            UIClass ui = new UIClass();

            Console.WriteLine("----- OMS - Evidencija kvarova u elektricnoj mrezi -----\n\n\n");
            string opcija;
            do
            {
            Console.WriteLine("Izaberite opciju:\n");
            Console.WriteLine("1 - Unos podataka o kvaru\n");
            Console.WriteLine("2 - Evidencija elektricnih elemenata\n");
            Console.WriteLine("3 - Lista kvarova\n");
            Console.WriteLine("x - Izlazak iz aplikacije");
            opcija = Console.ReadLine();
                if (opcija == "1")
                {
                    ui.UnesiKvar();
                }
                else if (opcija == "2")
                {
                    ui.UnesiElElement();
                }
                else if (opcija == "3")
                {
                    ui.ListaKvarova();
                }
                else
                {
                    Console.WriteLine("Greska prilikom unosa! Ponovite Unos.");
                }
            } while (opcija != "x");
            
        }
    }
}
