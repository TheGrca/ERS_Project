using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    class ProveraID
    {
        public static bool ProveriIDuTXT(int id_elementa, string putanja)
        {
            try
            {
                foreach (string red in File.ReadLines(putanja))
                {
                    if (red.Contains(id_elementa.ToString()))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greska: { ex.Message}");
                return false;
            }
        }
    }
}
