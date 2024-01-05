using System;
using System.IO; // Funkcija za upis u txt fajl
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ERSProjekat
{
    public enum Napon { 
        srednji_napon,
        visoki_napon, 
        nizak_napon 
    }
    public class ElektricniElement : SacuvajElektricniElement
    {
        private int id_elementa;
        private string naziv_elementa;
        private string tip_elementa;
        private Point geografska_lokacija;
        private Napon naponski_nivo;


        public ElektricniElement()
        {
            id_elementa = 0;
            naziv_elementa = "";
            tip_elementa = "";
            geografska_lokacija = new Point(0,0);
            naponski_nivo = Napon.srednji_napon;
        }

        public ElektricniElement(int id, string naziv, string tip, Point geografska, Napon napon)
        {
            id_elementa = id;
            naziv_elementa = naziv;
            tip_elementa = tip;
            geografska_lokacija = geografska;
            naponski_nivo = napon;
            SacuvajUTxt("EvidencijaElektricnihElemenata.txt",
                id,naziv,tip,geografska, naponski_nivo);
        }


        //Get-eri i Set-eri
        public int IdElementa
        {
            get { return id_elementa; }
            set { id_elementa = value; }
        }

        public string NazivElementa
        {
            get { return naziv_elementa; }
            set { naziv_elementa = value; }
        }

        public string TipElementa
        {
            get { return tip_elementa; }
            set { tip_elementa = value; }
        }

        public Point GeografskaLokacija
        {
            get { return geografska_lokacija; }
            set { geografska_lokacija = value; }
        }

        public Napon Napon
        {
            get { return naponski_nivo; }
            set { naponski_nivo = value; }
        }
    }
}