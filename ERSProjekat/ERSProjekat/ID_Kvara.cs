using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ID_Kvara
    {
        private static Dictionary<DateTime, int> brojaci = new Dictionary<DateTime, int>();
        private static readonly string brojacKvaraFilePath = "brojacKvara.txt"; // Cuvamo podatak o brojacu u fajlu

        public static string GetIDKvara()
        {
            DateTime trenutniDatum = DateTime.Now; // Trenutni datum
            string formattedDate = trenutniDatum.ToString("yyyyMMddhhmmss"); // Formatiraj kao "yyyyMMddhhmmss"

            //Brojac kvara
            int counter = GetBrojacDana(trenutniDatum);
            formattedDate += "_" + counter.ToString("D2");
            UpdateBrojacKvara(trenutniDatum, counter + 1);

            return formattedDate;
        }

        static int GetBrojacDana(DateTime datum)
        {
            if (brojaci.TryGetValue(datum.Date, out int brojac))
            {
                return brojac;
            }
            else
            {
                brojaci[datum.Date] = BrojacIzFajla() ?? 1; 
                return brojaci[datum.Date];
            }
        }

        static void UpdateBrojacKvara(DateTime date, int noviBrojac)
        {
            // Da li je novi dan?
            if (brojaci.ContainsKey(date.Date))
            {
                brojaci[date.Date] = noviBrojac;
            }
            else
            {
                // Resetuj brojac za novi dan
                brojaci.Clear();
                brojaci[date.Date] = noviBrojac;
            }

            ZapamtiBrojac(noviBrojac);
        }

        static int? BrojacIzFajla()
        {
            try
            {
                if (File.Exists(brojacKvaraFilePath))
                {
                    string counterString = File.ReadAllText(brojacKvaraFilePath);
                    if (int.TryParse(counterString, out int counter))
                    {
                        return counter;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        static void ZapamtiBrojac(int brojac)
        {
            try
            {
                File.WriteAllText(brojacKvaraFilePath, brojac.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
