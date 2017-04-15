using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science___Forecasting
{
    class ForecastDES
    {
        public static float alpha = 0.1f;
        public static float beta = 0.1f;
        static float precisionStep = 0.01f;

        static float optimalBeta = 1f;
        static float optimalAlpha = 1f;
        public static double optimalError = double.PositiveInfinity;

        public static List<DemandPoint> calcDES(List<DemandPoint> demandList)
        {
            List<DemandPoint> smoothedList = initalization(demandList);

            while (alpha < 1)
            {
                beta = 0.1f;
                while (beta < 1)
                {
                    smoothedList = smoothList(smoothedList);
                    double error = calculateError(smoothedList);
                    if (error < optimalError)
                    {
                        optimalAlpha = alpha;
                        optimalBeta = beta;
                        optimalError = error;
                    }
                    beta += precisionStep;
                }
              
                alpha += precisionStep;
                Console.WriteLine(alpha);
            }

            alpha = optimalAlpha;
            beta = optimalBeta;

            smoothedList = smoothList(smoothedList);

            Console.WriteLine("OPTIMAL ERROR: " + optimalError);
            Console.WriteLine("OPTIMAL ALPHA: " + optimalAlpha);
            Console.WriteLine("OPTIMAL BETA: " + optimalBeta);

            return smoothedList;


        }

        private static List<DemandPoint> initalization(List<DemandPoint> values)
        {
            values[1].smoothend = values[1].demand;
            values[1].trendSmoothend = values[1].demand - values[0].demand;

            return values;
        }

        public static List<DemandPoint> smoothList(List<DemandPoint> values)
        {
            List<DemandPoint> smoothedList = values;
            for (int i = 1; i < smoothedList.Count; i++)
            {
                smoothedList[i].smoothend = smoothPoint(smoothedList[i - 1], smoothedList[i]);
                smoothedList[i].trendSmoothend = smoothTrendPoint(smoothedList[i - 1], smoothedList[i]);
                smoothedList[i].trendDemand = smoothedList[i - 1].smoothend + smoothedList[i - 1].trendSmoothend;
            }
            
            return smoothedList;
        }

        private static float smoothPoint(DemandPoint prevPoint, DemandPoint currentPoint)
        {
            return alpha * currentPoint.demand + (1 - alpha) * (prevPoint.smoothend + prevPoint.trendSmoothend);
        }

        private static float smoothTrendPoint(DemandPoint prevPoint, DemandPoint currentPoint)
        {
            return beta * (currentPoint.smoothend - prevPoint.smoothend) + (1 - beta) * prevPoint.trendSmoothend;
        }

        public static List<DemandPoint> forecast(List<DemandPoint> data) {
            List<DemandPoint> forecastList = new List<DemandPoint>(data);

            for (int i = 1; i < 13; i++) {
                DemandPoint lastPoint = forecastList[forecastList.Count - 1];
                DemandPoint newPoint = new DemandPoint();

                newPoint.time = 36 + i;
                newPoint.trendDemand = forecastList[data.Count - 1].smoothend + ((36 + i) - data.Count) * forecastList[data.Count - 1].trendSmoothend;
                forecastList.Add(newPoint);
            }
            return forecastList; 
        }

        private static double calculateError(List<DemandPoint> values)
        {
            double distance = 0;
            for (int i = 0; i < values.Count; i++)
            {
                distance += Math.Pow(values[i].trendDemand - values[i].demand, 2);
            }
            return Math.Sqrt(distance / (values.Count - 2));

        }
    }
}
