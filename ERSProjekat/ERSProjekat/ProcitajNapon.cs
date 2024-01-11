using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ERSProjekat
{
    class ProcitajNapon
    {
        public string ProcitajNaponElementa(string putanjaDoFajla,string e_Element) 
        {
            try
            {
                string[] linije = File.ReadAllLines(putanjaDoFajla);

                string trenutniElement = null;

                foreach (string linija in linije)
                {
                    string[] podaci = linija.Split(':');
                    if (podaci.Length == 2)
                    {
                        string kljuc = podaci[0].Trim();
                        string vrednost = podaci[1].Trim();

                        if (kljuc == "Naziv elementa")
                            trenutniElement = vrednost;

                        else if (kljuc == "Naponski nivo" && trenutniElement == e_Element)
                        {
                            return vrednost;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Srednji napon";
        }
    }
}