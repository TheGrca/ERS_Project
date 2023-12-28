using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ERSProjekat
{
    public class Database 
    {
        public static void SacuvajKvarUFajl(Kvar kvar,string putanja)
        {
            try
            {
                List<Kvar> ListaKvarova;
                if (File.Exists(putanja))
                {
                    XmlSerializer Serializer = new XmlSerializer(typeof(List<Kvar>));
                    using (TextReader reader = new StreamReader(putanja))
                    {
                        ListaKvarova = (List<Kvar>)Serializer.Deserialize(reader);
                    }
                }
                else
                {
                    ListaKvarova = new List<Kvar>();
                }
                ListaKvarova.Add(kvar);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Kvar>));
                using (StreamWriter writer = new StreamWriter(putanja))
                {
                    serializer.Serialize(writer, ListaKvarova);
                }
                Console.WriteLine("Kvar je registrovan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greska prilikom registrovanja kvara: {ex.Message}");
            }
        }
    }
}
