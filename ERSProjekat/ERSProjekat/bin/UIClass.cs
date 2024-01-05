using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;


namespace ERSProjekat
{
    class UIClass
    {
        public void UnesiKvar()
        {
            string kratakOpis;
            string e_Element;
            string Opis;
            bool kvarovi = true;
            List<Kvar> Kvarovi = new List<Kvar>();
            Console.WriteLine("----- Unesite kvar -----\n");
            do
            {
              Console.WriteLine("Kratak opis kvara (max. 30 karaktera): ");
              kratakOpis = Console.ReadLine();
              if (kratakOpis.Length > 30)
                    Console.WriteLine("Nepravilno unesen kratki opis");
            } while (kratakOpis.Length > 30);
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
                Akcija akcija = new Akcija(NadjiTrenutnoVreme.GetTrenutnoVreme(), izvrsene_Akcije);
                kvar.Akcije.Add(akcija);
                Console.WriteLine("Da li zelite da upisete jos jednu akciju?: \n");
                Console.WriteLine("1 - Da\n");
                Console.WriteLine("2 - Ne\n");
                if (Console.ReadLine() == "2")
                    kvarovi = false;
            }
            kvarovi = true;
            Kvarovi.Add(kvar);
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kvar_DATABASE.xml");
            Database.SacuvajKvarUFajl(kvar, putanja);

            Console.WriteLine("Da li zelite da za kvar koji ste trenutno uneli kreirate poseban Excel fajl?");
            Console.WriteLine("1 - Da");
            Console.WriteLine("Bilo koji drugi taster - Ne");
            if (Console.ReadLine() == "1")
            {
                PodaciZaKvar pk = new PodaciZaKvar(kvar.IDKvara, kvar.Elektricni_element, "Srednji Napon", kvar.Akcije);
                pk.sacuvajUExcelKvar(pk);
            }
        }

        public void UnesiElElement()
        {
            int id_elementa;
            string naziv_elementa;
            string tip_elementa;
            Console.WriteLine("----- Unesite Elektricni Element -----\n");
            Console.WriteLine("ID Elektricnog Elementa: "); // Proveriti da li element sa id-jem postoji vec
            id_elementa = int.Parse(Console.ReadLine()); //Proveriti da je broj
            Console.WriteLine("Naziv Elektricnog Elementa: ");
            naziv_elementa = Console.ReadLine();
            Console.WriteLine("Tip elementa: ");
            tip_elementa = Console.ReadLine();
            Console.WriteLine("Geografska lokacija: ");
            Console.WriteLine("Unesite geografsku sirinu: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Unesite geografsku duzinu: ");
            int y = Int32.Parse(Console.ReadLine());
            Point geografska_lokacija = new Point(x, y);
            Napon n;
            Console.WriteLine("Da li znate napon elektricnog elementa? ");
            Console.WriteLine("1 - Da");
            Console.WriteLine("Bilo koji taster - Ne");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Napon elektricnog elementa(Srednji, Visok, Nizak): ");
                string unos = Console.ReadLine();
                switch (unos.ToLower())
                {
                    case "srednji":
                        n = Napon.srednji_napon;
                        break;
                    case "visok":
                        n = Napon.visoki_napon;
                        break;
                    case "nizak":
                        n = Napon.nizak_napon;
                        break;
                }

            }
            n = Napon.srednji_napon;
            ElektricniElement el = new ElektricniElement(id_elementa, naziv_elementa, tip_elementa, geografska_lokacija, n);
            Console.WriteLine("Uspesno ste uneli elektricni element");
        }

        public void ListaKvarova()
        {
            string pocetak, kraj;
            Console.WriteLine("Unesite vremenski opseg u formatu 'yyyy-MM-dd'");
            Console.WriteLine("Pocetni opseg: ");
            pocetak = Console.ReadLine();
            Console.WriteLine("Krajnji opseg: ");
            kraj = Console.ReadLine();
            NadjiKvarPrekoDatuma.IspisiKvarPrekoDatuma(pocetak, kraj); // nije dobar ispis
            //Implementirati dalje
        }
    }
}
