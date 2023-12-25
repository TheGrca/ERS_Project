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
            //DODATI AKCIJE
            bool kvarovi = true;
            List<Kvar> Kvarovi = new List<Kvar>();

            //El. Element
            int id_elementa;
            string naziv_elementa;
            string tip_elementa;
            int geografska_lokacija;

           


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
                 e_Element = Console.ReadLine(); //Proveriti da li se element nalazi u listi elemenata
                 Console.WriteLine("Opis kvara: ");
                 Opis = Console.ReadLine();
                Console.WriteLine("Izvrsene akcije: ");
                Kvar kvar = new Kvar(kratakOpis, e_Element, Opis);
                while (kvarovi)
                {
                    Console.WriteLine("Unesite akciju: ");
                    string izvrsene_Akcije = Console.ReadLine();
                    Akcija akcija = new Akcija(Kvar.GetTrenutnoVreme(), izvrsene_Akcije);
                    kvar.Akcije.Add(akcija);
                    Console.WriteLine("Da li zelite da upisete jos jednu akciju?: \n");
                    Console.WriteLine("1 - Da\n");
                    Console.WriteLine("2 - Ne\n");
                    if (Console.ReadLine() == "2")
                        kvarovi = false;
                }
                kvarovi = true;
                Kvarovi.Add(kvar);

                string putanja=""; // ne znam sta da stavim za putanju
                Database db = new Database();
                db.SacuvajKvarUFajl(kvar, putanja);
            }
            else if(opcija == "2")
            {
                Console.WriteLine("----- Unesite Elektricni Element -----\n");
                Console.WriteLine("ID Elektricnog Elementa: "); // Proveriti da li element sa id-jem postoji vec
                id_elementa = int.Parse(Console.ReadLine()); //Proveriti da je broj
                Console.WriteLine("Naziv Elektricnog Elementa: ");
                naziv_elementa = Console.ReadLine();
                Console.WriteLine("Tip elementa: ");
                tip_elementa = Console.ReadLine();
                Console.WriteLine("Geografska lokacija: ");
                geografska_lokacija = int.Parse(Console.ReadLine());

                EvidencijaElemenata el = new EvidencijaElemenata(id_elementa,naziv_elementa,tip_elementa,geografska_lokacija);
               
                
            }
            else if(opcija == "3")
            {
                Console.WriteLine("Unesite vremenski opseg: ");
                //Implementirati ispis
            }
            else
            {

            }
            
        }
    }
}
