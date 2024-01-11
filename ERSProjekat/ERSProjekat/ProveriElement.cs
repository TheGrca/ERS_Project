using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ProveriElement
    {
        public static bool ProverElementUTxt(string e_Element,string putanja)
        {
            
            try
            {
                foreach(string red in File.ReadLines(putanja))
                {
                    if (red.Contains(e_Element))
                    {
                       
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Greska: { ex.Message}");
                return false;
            }
        }
    }
}
