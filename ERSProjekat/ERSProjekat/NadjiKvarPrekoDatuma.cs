using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ERSProjekat
{
    class NadjiKvarPrekoDatuma
    {
        public static void IspisiKvarPrekoDatuma(string pocetak, string kraj)
        {
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kvar_DATABASE.xml");
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(putanja);

                XmlNodeList kvarLista = xmlDoc.SelectNodes($"/Root/ArrayOfKvar/Kvar[starts-with(Vreme_Kvara, '{pocetak}') and starts-with(Vreme_Kvara, '{kraj}')]");
                if (kvarLista.Count > 0)
                {
                    Console.WriteLine("Kvarovi izmedju {0} i {1}:", pocetak, kraj);

                    foreach (XmlNode kvarNode in kvarLista)
                    {
                        string vremeKvara = kvarNode.SelectSingleNode("Vreme_Kvara").InnerText;
                        string kratkiOpisKvara = kvarNode.SelectSingleNode("Kratki_Opis_Kvara").InnerText;
                        string statusKvara = kvarNode.SelectSingleNode("Status_Kvara").InnerText;

                        Console.WriteLine("Datum: {0}, Kratki Opis: {1}, Status: {2}", vremeKvara, kratkiOpisKvara, statusKvara);
                    }
                }
                else
                {
                    Console.WriteLine("Nema kvarova izmedju {0} i {1}.", pocetak, kraj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
