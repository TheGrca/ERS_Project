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
        public  void SacuvajKvarUFajl(Kvar kvar,string putanja)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Kvar));
                using(TextWriter writer=new StreamWriter(putanja))
                {
                    serializer.Serialize(writer, kvar);
                }
                Console.WriteLine("Kvar je uspesno sacuvan");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Greska prilikom cuvanja",ex.Message);
            }
        }

        

    }
}
