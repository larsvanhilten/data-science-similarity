using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_item
{
    class CSVReader
    {
        public static Dictionary<int, Dictionary<int, float>> read() {
            using(var fs = File.OpenRead(@"userItem.data"))
            using(var reader = new StreamReader(fs)) {
                Dictionary<int, Dictionary<int, float>> preferenceList = new Dictionary<int, Dictionary<int, float>>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    int userId = Int32.Parse(values[0]);
                    int article = Int32.Parse(values[1]);
                    float rating = float.Parse(values[2], CultureInfo.InvariantCulture);

                    if (preferenceList.TryGetValue(userId, out Dictionary<int, float> ratings))
                    {
                        ratings.Add(article, rating);
                    }
                    else {
                        preferenceList.Add(userId, new Dictionary<int, float>() { { article, rating } });
                    }

      
                }
                return preferenceList;
            }
        }
    }
}
