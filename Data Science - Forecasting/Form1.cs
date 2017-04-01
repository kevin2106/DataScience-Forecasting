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
            demandChart.ChartAreas[0].AxisX.Title = "Time";
            demandChart.ChartAreas[0].AxisY.Title = "Demand";

            List<DemandPoint> data = CSVReader.getDemandPoints();
            data = Forecast.calcSES(data);

            Series demandSeries = new Series("Demand");
            demandSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            demandSeries.BorderWidth = 5;
            for (int x = 0; x < data.Count; x++) {
                demandSeries.Points.AddXY(data[x].time, data[x].demand);
            }

            Series SmoothedSeries = new Series("Smoothed");
            SmoothedSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SmoothedSeries.BorderWidth = 5;
            for (int x = 0; x < data.Count; x++)
            {
                SmoothedSeries.Points.AddXY(data[x].time, data[x].smoothend);
            }

            for (int i = 1; i < 13; i++)
            {
                DemandPoint lastPoint = data[data.Count - 1];
                lastPoint.time = 36 + i;
                data.Add(lastPoint);
            }
            data = Forecast.smoothList(data);

            Series forecastSES = new Series("SES Forecast");
            forecastSES.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            forecastSES.BorderWidth = 5;
            for (int x = 0; x < data.Count; x++)
            {
                forecastSES.Points.AddXY(data[x].time, data[x].smoothend);
            }

            demandChart.Series.Add(demandSeries);
            demandChart.Series.Add(SmoothedSeries);
            demandChart.Series.Add(forecastSES);


        }

    }
}
