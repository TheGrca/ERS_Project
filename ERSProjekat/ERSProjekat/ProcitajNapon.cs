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
        private string putanjaDoFajla;
        
        public ProcitajNapon(string putanja)
        {
            putanjaDoFajla = putanja;
            }
        public void ProcitajNaponElementa()
        {
            try
            {
                string[] linije = File.ReadAllLines(putanjaDoFajla);

                foreach(string linija in linije)
                {
                    string[] podaci = linija.Split(',');
                    if(decimal.TryParse(podaci[4],out decimal napon))
                    {
                        Console.WriteLine("Izvuceni napon" + napon);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}