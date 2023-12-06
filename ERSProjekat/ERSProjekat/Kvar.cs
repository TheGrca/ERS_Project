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

    internal class Kvar
    {
        private int IDKvara { get; set;  }
        private DateTime vremeKvara { get; set; }
        private Status Status { get; set; }
        private string Kratki_opis { get; set; }
        private string Elektricni_element { get; set; } // Treba ubaciti klasu
        private string Opis { get; set; }
        //private List<Akcija> Akcije { get; set; }

        public Kvar(int id, DateTime datum, Status status, string kratkiOpis, string e_Element, string opis)
        {
            IDKvara = id;
            vremeKvara = datum;
            Status = status;
            Kratki_opis = kratkiOpis;
            Elektricni_element = e_Element;
            Opis = opis;
            // = new List<Action>();
        }
    }

}

