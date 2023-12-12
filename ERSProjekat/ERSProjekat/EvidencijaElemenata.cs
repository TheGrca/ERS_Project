using System;
using System.IO; // Funkcija za upis u txt fajl
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public enum Napon { 
        srednji_napon,
        visoki_napon, 
        nizak_napon 
    }
    public class EvidencijaElemenata
    {
        private int id_elementa;
        private string naziv_elementa;
        private string tip_elementa;
        private int geografska_lokacija;
        private Napon naponski_nivo;


        public EvidencijaElemenata()
        {
            id_elementa = 0;
            naziv_elementa = "";
            tip_elementa = "";
            geografska_lokacija = 0;
            naponski_nivo = Napon.srednji_napon;
        }

        public EvidencijaElemenata(int id, string naziv, string tip, int geografska)
        {
            id_elementa = id;
            naziv_elementa = naziv;
            tip_elementa = tip;
            geografska_lokacija = geografska;
            naponski_nivo = Napon.srednji_napon;
            SacuvajElektricniElement("EvidencijaElektricnihElemenata.txt");
        }

        private void SacuvajElektricniElement(string putanja)
        {
            // Formatiranje informacija kao niz stringova
            string[] linije = {
            $"ID elementa: {id_elementa}",
            $"Naziv elementa: {naziv_elementa}",
            $"Tip elementa: {tip_elementa}",
            $"Geografska lokacija: {geografska_lokacija}",
            $"Naponski nivo: {naponski_nivo}",
            ""
        };
            File.AppendAllLines(putanja, linije);
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

        public int GeografskaLokacija
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