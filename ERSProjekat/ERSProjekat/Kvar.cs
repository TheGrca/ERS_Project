using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ERSProjekat
{
    [Serializable]
    public enum Status
    {
        Nepotvrdjen,
        U_popravci,
        Testiranje,
        Zatvoreno
    }

    public class Kvar
    {
        [XmlElement("ID_Kvara")]
        public string IDKvara { get; set; }
        [XmlElement("Vreme_Kvara")]
        public string vremeKvara { get; set; }
        [XmlElement("Status_Kvara")]
        public Status Status { get; set; }
        [XmlElement("Kratki_Opis_Kvara")]
        public string Kratki_opis { get; set; }
        [XmlElement("EL_Element_Kvara")]
        public string Elektricni_element { get; set; }
        [XmlElement("Opis_Kvara")]
        public string Opis { get; set; }
        [XmlElement("Akcija_Kvara")]
        public List<Akcija> Akcije { get; set; } = new List<Akcija>();
        [XmlElement("Datum_Kvara")]
        public DateTime DatumRegistrovanja { get; set; }

        
        public Kvar(string kratkiOpis, string e_Element, string opis)
        {
            Kratki_opis = kratkiOpis;
            Elektricni_element = e_Element;
            Opis = opis;
            IDKvara = ID_Kvara.GetIDKvara();
            vremeKvara = NadjiTrenutnoVreme.GetTrenutnoVreme();
            Status = Status.Nepotvrdjen;
            List<Akcija> akcije = new List<Akcija>();
        }

        public Kvar()
        {

        }

        public Kvar(string kratkiOpis, string e_Element, string opis, Status s) //Konstruktor za azuriranje kvara
        {
            Kratki_opis = kratkiOpis;
            Elektricni_element = e_Element;
            Opis = opis;
            Status = s;
        }


        public override string ToString()
        {
            return $"IDKvara: {IDKvara}, " +
                   $"VremeKvara: {vremeKvara}, " +
                   $"Status: {Status}, " +
                   $"Kratki_opis: {Kratki_opis}, " +
                   $"Elektricni_element: {Elektricni_element}, " +
                   $"Opis: {Opis}, ";
        }

    }
}

