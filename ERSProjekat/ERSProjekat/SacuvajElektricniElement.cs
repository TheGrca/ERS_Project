using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ERSProjekat
{
    public class SacuvajElektricniElement
    {
        public void SacuvajUTxt(string putanja, int id_elementa, string naziv_elementa, string tip_elementa, Point geografska_lokacija, Napon naponski_nivo)
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
    }
}

