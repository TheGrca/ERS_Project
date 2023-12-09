using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ID_Kvara
    {

        public static string ID()
        {
            DateTime currentDate = DateTime.Now; // Trenutni datum
            string formattedDate = currentDate.ToString("yyyyMMddhhmmss"); // Formatiraj kao "yyyyMMddhhmmss"

            //Brojac kvara
            int counter = GetCounterForDate(currentDate);
            formattedDate += "_" + counter.ToString("D2"); 
            UpdateCounterForDate(currentDate, counter + 1);

            return formattedDate;
        }

        static int GetCounterForDate(DateTime date)
        {
            Dictionary<DateTime, int> counters = new Dictionary<DateTime, int>();

            if (counters.TryGetValue(date.Date, out int counter))
            {
                return counter;
            }
            else
            {
                counters[date.Date] = 1; 
                return 1;
            }
        }

        static void UpdateCounterForDate(DateTime date, int newCounter)
        {
            Dictionary<DateTime, int> counters = new Dictionary<DateTime, int>();
            counters[date.Date] = newCounter;
        }
    }
}
