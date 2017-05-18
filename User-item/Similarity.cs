using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_item
{
    class Similarity
    {

        public static double comparePearson(Dictionary<int, float> one, Dictionary<int, float> two) {
            Dictionary<int, float> intersectionX = one.Keys.Intersect(two.Keys).ToDictionary(a => a, a => one[a]);
            Dictionary<int, float> intersectionY = one.Keys.Intersect(two.Keys).ToDictionary(a => a, a => two[a]);

            float averageX = intersectionX.Values.Average();
            float averageY = intersectionY.Values.Average();

            float totalXY = 0;
            double squareX = 0;
            double squareY = 0;

            foreach (KeyValuePair<int, float> article in intersectionX)
            {
                int key = article.Key;
 
                float X = (one[key] - averageX);
                float Y = (two[key] - averageY);
                totalXY += X * Y;
                squareX += Math.Pow(X, 2);
                squareY += Math.Pow(Y, 2);

            }

            double pearson = totalXY / Math.Sqrt(squareX) * Math.Sqrt(squareY);
            return 1 / (1 + pearson);
        }

        public static double compareEuclidian(Dictionary<int, float> one, Dictionary<int, float> two) {
            Dictionary<int, float> intersection = one.Keys.Intersect(two.Keys).ToDictionary(a => a, a => one[a]);

            double sum = 0;
            foreach (KeyValuePair<int, float> article in intersection)
            {
                int key = article.Key;
                sum += Math.Pow((one[key] - two[key]), 2);
            }

            double euclidian =  Math.Sqrt(sum);
            return 1 / (1 + euclidian);
        }

        public static double compareCosine(Dictionary<int, float> one, Dictionary<int, float> two) {
            Dictionary<int, float> merged = one.Concat(two).GroupBy(d => d.Key).OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);

            double dot = 1;
            double normX = 0;
            double normY = 0;
            foreach (KeyValuePair<int, float> article in merged)
            {
                int key = article.Key;
                float x = one.ContainsKey(key) ? one[key] : 0;
                float y = two.ContainsKey(key) ? two[key] : 0;

                dot += x * y;
                normX += x * x;
                normY += y * y;
            }

            normX = Math.Sqrt(normX);
            normY = Math.Sqrt(normY);


            return dot / (normX * normY);
        }
    }
}
