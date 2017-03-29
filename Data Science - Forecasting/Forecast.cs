using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science___Forecasting
{
    class Forecast
    {
        public void calcSES(List<DemandPoint> demandList)
        {
            List<DemandPoint> optimalValue = new List<DemandPoint>();

            float minError = float.PositiveInfinity;
            float optimalA = 1;

            float alpha = 0.01f;
            while (alpha < 1)
            {
                List<DemandPoint> demandPoints = new List<DemandPoint>();
                demandPoints.Add(demandList[0]);
            }
        }
    }
}

        
