using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ElektricniElementi
    {
        List<EvidencijaElemenata> elementi;
        private int id_elementa;
        private string naziv_elementa;
        private string tip_elementa;
        private int geografska_lokacija;
        private Napon naponski_nivo;

        public ElektricniElementi()
        {
            elementi = new List<EvidencijaElemenata>();
        }

        public void upisiElement(String txt)
        {
            
           // ElektricniElementi el = new ElektricniElementi(id_elementa,naziv_elementa,tip_elementa,geografska_lokacija,naponski_nivo);
            //elementi.Add(el);
        }

        

        
            
    
    }
}
