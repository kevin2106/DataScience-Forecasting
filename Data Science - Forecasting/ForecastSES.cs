using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science___Forecasting
{
    class ForecastSES
    {
        public static float alpha = 0.1f;
        static float precisionStep = 0.01f;

        static float optimalAlpha = 1f;
        public static double optimalError = double.PositiveInfinity;

        public static List<DemandPoint> calcSES(List<DemandPoint> demandList)
        {
            List<DemandPoint> smoothedList = demandList;
            smoothedList[0] = initialization(demandList);

            while (alpha < 1) {
                smoothedList = smoothList(smoothedList);
                double error = calculateError(smoothedList);
                if (error < optimalError) {
                    optimalAlpha = alpha;
                    optimalError = error;
                }
                alpha += precisionStep;
                Console.WriteLine(alpha);
            }
            alpha = optimalAlpha;

            smoothedList = smoothList(smoothedList);

            Console.WriteLine("OPTIMAL ERROR: " + optimalError);
           Console.WriteLine("OPTIMAL ALPHA: " + optimalAlpha);

            return smoothedList;
        }

        public static List<DemandPoint> smoothList(List<DemandPoint> values) {
            List<DemandPoint> smoothedList = values;
            for (int i = 1; i < 36; i++)
            {
                smoothedList[i].smoothend = smoothPoint(smoothedList[i - 1]);
            }
            return smoothedList;
        }

        private static DemandPoint initialization(List<DemandPoint> values)
        {
            float average = 0;
            for (int i = 0; i < 12; i++)
            {
                average += values[i].demand;
            }
            average = average / 12;
            values[0].smoothend = average;
            return values[0];
        }

        public static List<DemandPoint> forecast(List<DemandPoint> data)
        {
            List<DemandPoint> forecastList = new List<DemandPoint>(data);
            for (int i = 1; i < 13; i++)
            {
                DemandPoint lastpoint = forecastList[forecastList.Count - 1];
                DemandPoint newPoint = new DemandPoint();
                newPoint.time = 36 + i;
                newPoint.smoothend = lastpoint.smoothend;
                Console.WriteLine("SMOOTEHND: " + lastpoint.time + " : " + lastpoint.smoothend);
                forecastList.Add(newPoint);
            }
            return forecastList;
        }
        private static float smoothPoint(DemandPoint prevPoint)
        {
            return alpha * prevPoint.demand + (1 - alpha) * prevPoint.smoothend;
        }

        private static double calculateError(List<DemandPoint> values) {
            double distance = 0;
            for (int i = 0; i < values.Count; i++)
            {
                distance += Math.Pow(values[i].smoothend - values[i].demand, 2);
            }
            return Math.Sqrt(distance / (values.Count - 1));

        }
    }
}

        
