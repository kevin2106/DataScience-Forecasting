using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science___Forecasting
{
    class DemandPoint
    {
        public int time { get; set; }
        public float demand { get; set; }
        public float smoothend { get; set; }
        public float trendSmoothend { get; set; }
        public float trendDemand { get; set; }

    }
}
