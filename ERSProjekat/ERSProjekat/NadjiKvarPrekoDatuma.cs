using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ERSProjekat
{
    class NadjiKvarPrekoDatuma
    {
        public static List<Kvar> IspisiKvarPrekoDatuma(string pocetak, string kraj)
        {
            List<Kvar> listaKvarova = new List<Kvar>();
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kvar_DATABASE.xml");
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(putanja);
                XmlNodeList kvarLista = xmlDoc.SelectNodes($"/Root/ArrayOfKvar/Kvar");
                
                if (kvarLista != null)
                {
                    foreach (XmlNode kvarNode in kvarLista)
                    {
                        DateTime vremeKvara = DateTime.ParseExact(kvarNode.SelectSingleNode("Vreme_Kvara").InnerText, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime pocetniDatum = DateTime.ParseExact(pocetak, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        DateTime krajnjiDatum = DateTime.ParseExact(kraj, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        Kvar kvar = new Kvar();
                        if (vremeKvara >= pocetniDatum && vremeKvara <= krajnjiDatum)
                        {
                            kvar.IDKvara = kvarNode.SelectSingleNode("ID_Kvara").InnerText;
                            kvar.vremeKvara = vremeKvara.ToString("yyyy-MM-dd HH:mm:ss");
                            kvar.Kratki_opis = kvarNode.SelectSingleNode("Kratki_Opis_Kvara").InnerText;
                            kvar.Status = (Status)Enum.Parse(typeof(Status), kvarNode.SelectSingleNode("Status_Kvara").InnerText);
                            kvar.Elektricni_element = kvarNode.SelectSingleNode("EL_Element_Kvara").InnerText;
                            kvar.Opis = kvarNode.SelectSingleNode("Opis_Kvara").InnerText;
                            kvar.DatumRegistrovanja = DateTime.Parse(kvarNode.SelectSingleNode("Datum_Kvara").InnerText);

                            listaKvarova.Add(kvar);
                        }
                    }
                    return listaKvarova;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
