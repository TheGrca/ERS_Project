using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ERSProjekat
{
    public class ID_Kvara
    {
        private static int brojac = 0;
        private static DateTime poslednjiDatum;

        private static readonly string brojacKvaraFilePath = "brojacKvara.xml";

        public static string GetIDKvara()
        {
            DateTime trenutniDatum = DateTime.Now;

            if (poslednjiDatum.Date < trenutniDatum.Date)
            {
                // Ako je danas novi dan, resetuj brojač
                brojac = 1;
                poslednjiDatum = trenutniDatum.Date;

                // Sačuvaj brojač u XML fajl
                SacuvajBrojacUFajl();
            }
            else
            {
                brojac++;
            }

            string formattedDate = trenutniDatum.ToString("yyyyMMddhhmmss");
            string idKvara = $"{formattedDate}_{brojac:D2}";

            return idKvara;
        }

        static void SacuvajBrojacUFajl()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("BrojacKvara");
                xmlDoc.AppendChild(root);

                XmlElement brojacElement = xmlDoc.CreateElement("Brojac");
                brojacElement.SetAttribute("Vrednost", brojac.ToString());
                root.AppendChild(brojacElement);

                XmlElement datumElement = xmlDoc.CreateElement("PoslednjiDatum");
                datumElement.SetAttribute("Vrednost", poslednjiDatum.ToString("yyyy-MM-dd"));
                root.AppendChild(datumElement);

                xmlDoc.Save(brojacKvaraFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void InicijalizujBrojacIzFajla()
        {
            try
            {
                if (File.Exists(brojacKvaraFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(brojacKvaraFilePath);

                    XmlNode brojacNode = xmlDoc.SelectSingleNode("/BrojacKvara/Brojac");
                    if (brojacNode != null && int.TryParse(brojacNode.Attributes["Vrednost"].Value, out int ucitaniBrojac))
                    {
                        brojac = ucitaniBrojac;
                    }

                    XmlNode datumNode = xmlDoc.SelectSingleNode("/BrojacKvara/PoslednjiDatum");
                    if (datumNode != null && DateTime.TryParse(datumNode.Attributes["Vrednost"].Value, out DateTime ucitaniDatum))
                    {
                        poslednjiDatum = ucitaniDatum;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static ID_Kvara() //Statički konstruktor se automatski poziva pre bilo kakvog pristupa 
        {
            InicijalizujBrojacIzFajla();
        }
    }
}
