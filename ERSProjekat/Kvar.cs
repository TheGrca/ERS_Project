using System;
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
        private DateTime vremeKvara;
        private Status Status;
        private string Kratki_opis;
        private string Elektricni_element; // Treba ubaciti klasu
        private string Opis;
        //private List<Akcija> Akcije { get; set; }

        //Konstruktor
        public Kvar(string kratkiOpis, string e_Element, string opis)
        {
            Kratki_opis = kratkiOpis;
            Elektricni_element = e_Element;
            Opis = opis;
            IDKvara = ID();
            //VREME
            Status = Status.Nepotvrdjen;
        }

    }

}

