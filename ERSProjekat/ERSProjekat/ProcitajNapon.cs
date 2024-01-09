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
        public string ProcitajNaponElementa(string putanjaDoFajla,string e_Element) //On procita prvi naponski nivo, neka nadje taj elektricni element pa procita njegov naponski nivo
        {
            try
            {
                string[] linije = File.ReadAllLines(putanjaDoFajla);
                
                       
                foreach (string linija in linije)
                {
                    
                    string[] podaci = linija.Split('\n');
                    if (podaci.Length == 4)
                    {
                        string element = podaci[1].Trim();
                        string napon = podaci[4].Trim();
                        if(element==e_Element && e_Element.StartsWith("Naponski nivo"))
                        {
                            return napon;
                        }
                    }
                    //foreach (string podatak in podaci)
                   // {
                    //    if (podatak.Trim().StartsWith("Naponski nivo:"))
                    //    {
                      //      return  podatak.Split(':')[1].Trim();
                        //}
                    //}
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           return "Srednji napon";
        }
    }
}