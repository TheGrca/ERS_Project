using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    class PrioritetZaKvar
    {
        public static double IzracunajPrioritet(Kvar kvar)
        {
            int brojDana = (DateTime.Now - DateTime.Parse(kvar.vremeKvara)).Days;
            double prioritet = brojDana;
            if (kvar.Akcije != null)
            {
                foreach (Akcija akcija in kvar.Akcije)
                {
                    prioritet = prioritet + 0.5;
                }
            }
            return prioritet;
        }
    }
}
