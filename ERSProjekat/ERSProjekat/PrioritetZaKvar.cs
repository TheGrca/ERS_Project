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
            int brojDana = (DateTime.Now - kvar.DatumRegistrovanja).Days;
            double prioritet = brojDana;
            if (kvar.Akcije != null)
            {
                foreach (var akcija in kvar.Akcije)
                {
                    prioritet = prioritet + 0.5;
                }
            }
            return prioritet;
        }
    }
}
