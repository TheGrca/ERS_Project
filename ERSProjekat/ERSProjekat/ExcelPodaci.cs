using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ExcelPodaci
    {
        public string idKvara;
        public string nazivElementa;
        public string naponskiNivo;
        public List<string> spisakAkcija;

        public ExcelPodaci(string id,string naziv,string napon,List<string> spisak)
        {
            idKvara = id;
            nazivElementa = naziv;
            naponskiNivo = napon;
            spisakAkcija = spisak;
        }
    }
}
