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
            e_Element = Console.ReadLine(); 
            string putanjaTxt = "EvidencijaElektricnihElemenata.txt";
            bool pronadjenElement = false;
            do
            {
                if (ProveriElement.ProverElementUTxt(e_Element, putanjaTxt))   
                {
                    Console.WriteLine($"Elektricni element {e_Element} se nalazi u fajlu");
                    pronadjenElement = true;
                }
                else
                {
                    Console.WriteLine($"Elektricni element {e_Element} se ne nalazi u fajlu");
                    Console.WriteLine("Unesite ponovo elektricni element:");
                    Console.ReadLine();
                }
            } while (!pronadjenElement);
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
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kvar_DATABASE.xlsx");
            Database.SacuvajKvarUFajl(kvar, putanja);

            Console.WriteLine("Da li zelite da za kvar koji ste trenutno uneli kreirate poseban Excel fajl?");
            Console.WriteLine("1 - Da");
            Console.WriteLine("Bilo koji drugi taster - Ne");
            
            if (Console.ReadLine() == "1")
            {
                //Ovdje pozovi funkciju koja ce ti vratiti naponski nivo
                ProcitajNapon procitajNapon = new ProcitajNapon();
                string putanjaDoFajla = "EvidencijaElektricnihElemenata.txt";
                string naponskiNivo = procitajNapon.ProcitajNaponElementa(putanjaDoFajla, e_Element);
  
                PodaciZaKvar pk = new PodaciZaKvar(kvar.IDKvara, kvar.Elektricni_element,naponskiNivo, kvar.Akcije); //Umjesto srednji napon neka nadje napon od elektricnog elementa preko txt fajla
                pk.sacuvajUExcelKvar(pk);
            }
        }

        public void UnesiElElement()
        {
            int id_elementa;
            string naziv_elementa;
            string tip_elementa;
            Console.WriteLine("----- Unesite Elektricni Element -----\n");
            Console.WriteLine("ID Elektricnog Elementa: ");
            string putanjatxt = "EvidencijaElektricnihElemenata.txt";
            bool pronadjenID = false;
            // id_elementa = int.Parse(Console.ReadLine()); //Proveriti da je broj
            do
            {
                if (int.TryParse(Console.ReadLine(), out id_elementa))
                {
                    Console.WriteLine($"Uneli ste broj: {id_elementa}");
                    break;

                }
                else
                {
                    Console.WriteLine("Greska: Niste uneli broj");
                }
            } while (true);
           
            do
            {
                if (ProveraID.ProveriIDuTXT(id_elementa, putanjatxt))
                {
                    Console.WriteLine($"ID elementa {id_elementa} se nalazi u fajlu");
                    pronadjenID = true;
                }
                else
                {

                    Console.WriteLine($"ID elementa {id_elementa} se ne nalazi u fajlu");
                    Console.WriteLine("Unesite ponovo ID elementa:");

                    id_elementa = int.Parse(Console.ReadLine());
                }
            } while (!pronadjenID);


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
            Napon n = Napon.srednji_napon;
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
            List<Kvar> kvaroviZaDatum = new List<Kvar>();
            kvaroviZaDatum = NadjiKvarPrekoDatuma.IspisiKvarPrekoDatuma(pocetak, kraj); // Nije dobar ispis kvarova, ovo cu ja srediti
            if (kvaroviZaDatum == null)
            {
                
                Console.WriteLine("Nema kvarova između {0} i {1}.", pocetak, kraj);
            }
            else
            {
                int brojac = 1;
                foreach (Kvar k in kvaroviZaDatum)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}", brojac, k.DatumRegistrovanja, k.Kratki_opis, k.Status);
                    brojac++;
                }
                    Console.WriteLine("Da li zelite izabrati neki kvar?: ");
                    Console.WriteLine("Da - Unesite broj kvara"); 
                    Console.WriteLine("Ne - 0");
                    int izabraniKvar = int.Parse(Console.ReadLine());
                if (izabraniKvar != 0)
                {
                    if (izabraniKvar < brojac && izabraniKvar > 0)
                    {
                        if (kvaroviZaDatum[izabraniKvar - 1].Status == Status.U_popravci)
                            Console.WriteLine("Izabrali ste kvar: {0}, a njegov prioritet je: {1}", kvaroviZaDatum[izabraniKvar - 1].ToString(), PrioritetZaKvar.IzracunajPrioritet(kvaroviZaDatum[izabraniKvar - 1]));
                        else
                            Console.WriteLine("Izabrali ste kvar: {0}", kvaroviZaDatum[izabraniKvar - 1].ToString());

                        Console.WriteLine("Da li zelite azurirati izabrani kvar?");
                        Console.WriteLine("Da - 1");
                        Console.WriteLine("Ne - Bilo koji drugi taster");
                        if (Console.ReadLine() == "1")
                        {
                            if (kvaroviZaDatum[izabraniKvar - 1].Status == Status.Zatvoreno)
                            {
                                Console.WriteLine("Izabrani kvar nije moguce azurirati zbog statusa!");
                            }
                            else
                            {
                                AzuriranjeKvara.Azuriraj(kvaroviZaDatum[izabraniKvar - 1]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Niste uneli dobar broj kvara");
                    }
                }   
            }
        }

        public void AzuriranjeKvaraUI()
        {
            string kratakOpis;
            string e_Element;
            string Opis;
            Status st;
            bool kvarovi = true;
            do
            {
              Console.WriteLine("Kratak opis kvara (max. 30 karaktera): ");
              kratakOpis = Console.ReadLine();
              if (kratakOpis.Length > 30)
                Console.WriteLine("Nepravilno unesen kratki opis");
            } while (kratakOpis.Length > 30);
            Console.WriteLine("Na kojem elektricnom elementu se desio kvar: ");
            e_Element = Console.ReadLine(); 
            string putanjaTxt = "EvidencijaElektricnihElemenata.txt";
            bool pronadjenElement = false;
            do
            {
                if (ProveriElement.ProverElementUTxt(e_Element, putanjaTxt))
                {
                    Console.WriteLine($"Elektricni element {e_Element} se nalazi u fajlu");
                    pronadjenElement = true;
                }
                else
                {
                    Console.WriteLine($"Elektricni element {e_Element} se ne nalazi u fajlu");
                    Console.WriteLine("Unesite ponovo elektricni element:");
                    Console.ReadLine();
                }
            } while (!pronadjenElement);
            Console.WriteLine("Opis kvara: ");
            Opis = Console.ReadLine();
            Console.WriteLine("Unesite status(Nepotvrdjen, U_popravci, Testiranje, Zatvoreno): ");
            st = (Status)Enum.Parse(typeof(Status),Console.ReadLine());
            Console.WriteLine("Izvrsene akcije: ");
            Kvar kvar = new Kvar(kratakOpis, e_Element, Opis, st);
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
            AzuriranjeKvara.Azuriraj(kvar);
        }
    }
}
