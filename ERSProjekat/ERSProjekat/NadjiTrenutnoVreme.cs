using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class NadjiTrenutnoVreme
    {
        public static string GetTrenutnoVreme()
        {
            DateTime trenutnoVreme = DateTime.Now;

            string dateString = trenutnoVreme.ToString("yyyy-MM-dd HH:mm:ss");

            return dateString;
        }
    }
}
