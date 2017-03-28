using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Data_Science___Forecasting
{
    class CSVReader
    {
        public static List<DemandPoint> getDemandPoints()
        {
            List<DemandPoint> demandPointsList = new List<DemandPoint>();
            using (var fs = File.OpenRead(@"../data.csv"))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    DemandPoint demandPoint = new DemandPoint();
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    demandPoint.time = Convert.ToInt32(values[0]);
                    demandPoint.demand = Convert.ToInt32(values[1]);

                    demandPointsList.Add(demandPoint);
                }
            }
            return demandPointsList;
        }
    }
}
