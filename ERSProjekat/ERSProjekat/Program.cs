using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kvar
            string kratakOpis;
            string e_Element;
            string Opis;
            string izvrsene_Akcije;
            //El. Element
            

            Console.WriteLine("----- OMS - Evidencija kvarova u elektricnoj mrezi -----\n\n\n");
            Console.WriteLine("Izaberite opciju:\n");
            Console.WriteLine("1 - Unos podataka o kvaru\n");
            Console.WriteLine("2 - Evidencija elektricnih elemenata\n");
            Console.WriteLine("3 - Lista kvarova\n");
            string opcija = Console.ReadLine();

            if (opcija == "1")
            {
                 Console.WriteLine("----- Unesite kvar -----\n");
                 Console.WriteLine("Kratak opis kvara: ");
                 kratakOpis = Console.ReadLine();
                 Console.WriteLine("Na kojem elektricnom elementu se desio kvar: ");
                 e_Element = Console.ReadLine();
                 Console.WriteLine("Opis kvara: ");
                 Opis = Console.ReadLine();
                 Console.WriteLine("Izvrsene akcije: ");
                 izvrsene_Akcije = Console.ReadLine();
                 Kvar k = new Kvar(kratakOpis, e_Element, Opis);
            }
            else if(opcija == "2")
            {

            }
            else if(opcija == "3")
            {

            }
            else
            {

            }
            
        }
    }
}
