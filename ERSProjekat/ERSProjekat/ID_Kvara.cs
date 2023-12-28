using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSProjekat
{
    public class ID_Kvara
    {
        private static Dictionary<DateTime, int> counters = new Dictionary<DateTime, int>();
        public static string GetIDKvara()
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
            // Check if it's a new day
            if (counters.ContainsKey(date.Date))
            {
                counters[date.Date] = newCounter;
            }
            else
            {
                // Reset counter for a new day
                counters.Clear();
                counters[date.Date] = 1;
            }
        }
    }
}
