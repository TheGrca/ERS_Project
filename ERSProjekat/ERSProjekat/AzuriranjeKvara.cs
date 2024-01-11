using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ERSProjekat
{
    public class AzuriranjeKvara
    {
        public static void Azuriraj(Kvar kvar)
        {
            string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kvar_DATABASE.xml");

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(putanja);

                string trazeniKvar = $"/ArrayOfKvar/Kvar[ID_Kvara='{kvar.IDKvara}']";
                XmlNode kvarNode = xmlDoc.SelectSingleNode(trazeniKvar);

                if (kvarNode != null)
                {
                    kvarNode.SelectSingleNode("Vreme_Kvara").InnerText = kvar.vremeKvara;
                    kvarNode.SelectSingleNode("Kratki_Opis_Kvara").InnerText = kvar.Kratki_opis;
                    kvarNode.SelectSingleNode("Status_Kvara").InnerText = kvar.Status.ToString();
                    kvarNode.SelectSingleNode("EL_Element_Kvara").InnerText = kvar.Elektricni_element;
                    kvarNode.SelectSingleNode("Opis_Kvara").InnerText = kvar.Opis;
                    foreach (Akcija akcija in kvar.Akcije)
                    {
                        XmlNode akcijaNode = xmlDoc.CreateElement("Akcija_Kvara");
                        XmlNode opisNode = xmlDoc.CreateElement("Opis");
                        opisNode.InnerText = akcija.Opis;
                        akcijaNode.AppendChild(opisNode);
                        XmlNode dateNode = xmlDoc.CreateElement("VremeAkcije");
                        dateNode.InnerText = akcija.VremeAkcije;
                        akcijaNode.AppendChild(dateNode);
                        kvarNode.AppendChild(akcijaNode);
                    }
                    xmlDoc.Save(putanja);

                    Console.WriteLine("Kvar uspesno azuriran!");
                }
                else
                {
                    Console.WriteLine("Greska! Kvar nije azuriran!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
