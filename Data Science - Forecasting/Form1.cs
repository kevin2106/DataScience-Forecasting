using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Data_Science___Forecasting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<DemandPoint> data = CSVReader.getDemandPoints();
            Series demandSeries = new Series("Demand");
            demandSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            demandChart.ChartAreas[0].AxisX.Title = "Time";
            demandChart.ChartAreas[0].AxisY.Title = "Demand";

            for (int x = 0; x < data.Count; x++) {
                demandSeries.Points.AddXY(data[x].time, data[x].demand);
            }

            demandSeries.BorderWidth = 5;
            demandChart.Series.Add(demandSeries);

            
        }

    }
}
