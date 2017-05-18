using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_item
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<int, float>> preferenceList = CSVReader.read();

            double pearson = Similarity.comparePearson(preferenceList[1], preferenceList[2]);
            double euclidian = Similarity.compareEuclidian(preferenceList[1], preferenceList[2]);
            double cosine = Similarity.compareCosine(preferenceList[1], preferenceList[2]);

            Console.WriteLine("Pearson: " + pearson);
            Console.WriteLine("Euclidian: " + euclidian);
            Console.WriteLine("Cosine: " + cosine);

            Console.ReadLine();
        }
    }
}
