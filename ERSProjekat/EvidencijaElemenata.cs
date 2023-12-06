using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public enum Napon { srednji_napon,visoki_napon,nizak_napon}
     public class EvidencijaElemenata
    {
        private int id_elementa;
        private string naziv_elementa;
        private string tip_elementa;
        private int geografska_lokacija;
        private Napon naponski_nivo;


        public EvidencijaElemenata()
        {
            naponski_nivo = Napon.srednji_napon;
        }

        public EvidencijaElemenata(int id,string naziv,string tip,int geografska,Napon napon)
        {
            id_elementa = id;
            naziv_elementa = naziv;
            tip_elementa = tip;
            geografska_lokacija = geografska;
            naponski_nivo = napon;
        }
    }
}
