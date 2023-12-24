using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{

    public enum Status
    {
        Nepotvrdjen,
        U_popravci,
        Testiranje,
        Zatvoreno
    }

    internal class Kvar : ID_Kvara
    {
        private string IDKvara;
        private string vremeKvara;
        private Status Status;
        private string Kratki_opis;
        private string Elektricni_element;
        private string Opis;
        public List<Akcija> Akcije = new List<Akcija>();

        
        public Kvar(string kratkiOpis, string e_Element, string opis)
        {
            Kratki_opis = kratkiOpis;
            Elektricni_element = e_Element;
            Opis = opis;
            IDKvara = ID();
            vremeKvara = GetTrenutnoVreme();
            Status = Status.Nepotvrdjen;
            SacuvajInformacijeUFajl("informacije.txt");
        }



        public void SacuvajInformacijeUFajl(string putanja)
        {
            string[] linije = {
            $"Kratki opis: {Kratki_opis}",
            $"Električni element: {Elektricni_element}",
            $"Opis: {Opis}",
            $"ID kvara: {IDKvara}",
            $"Vreme kvara: {vremeKvara}",
            $"Status: {Status}",
            $"Akcije: {Akcije}"
        };
            File.WriteAllLines(putanja, linije);
        } //TEST FUNKCIJA, POSLE NAPRAVITI BAZU


        public static string GetTrenutnoVreme() //Funkcija koja dobavlja trenutno vreme
        {
            DateTime trenutnoVreme = DateTime.Now;

            string dateString = trenutnoVreme.ToString("yyyy-MM-dd HH:mm:ss");

            return dateString;
        }

    }
}

