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
            data = ForecastSES.calcSES(data);

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

            List<DemandPoint> forecastDataSES = ForecastSES.forecast(data);

            Series forecastSES = new Series("SES Forecast");
            forecastSES.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            forecastSES.BorderWidth = 5;
            for (int x = 0; x < forecastDataSES.Count; x++)
            {
                forecastSES.Points.AddXY(forecastDataSES[x].time, forecastDataSES[x].smoothend);
            }

            data = ForecastDES.calcDES(data);

            Series trendSeries = new Series("Trend Series");
            trendSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            trendSeries.BorderWidth = 5;
            for (int x = 1; x < data.Count; x++)
            {
                trendSeries.Points.AddXY(data[x].time, data[x].trendDemand);
            }

            List<DemandPoint> forecastDataDES = ForecastDES.forecast(data);

            Series forecastDES = new Series("DES Forecast");
            forecastDES.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            forecastDES.BorderWidth = 5;
            for (int x = 1; x < forecastDataDES.Count; x++)
            {
                forecastDES.Points.AddXY(forecastDataDES[x].time, forecastDataDES[x].trendDemand);
            }


            demandChart.Series.Add(demandSeries);
            //demandChart.Series.Add(SmoothedSeries);
            demandChart.Series.Add(forecastSES);
            //demandChart.Series.Add(trendSeries);
            demandChart.Series.Add(forecastDES);

            sesError.Text = "Error: " + ForecastSES.optimalError;
            sesAlpha.Text = "Alpha: " + ForecastSES.alpha;

            desError.Text = "Error: " + ForecastDES.optimalError;
            desAlpha.Text = "Alpha: " + ForecastDES.alpha;
            desBeta.Text = "Beta: " + ForecastDES.beta;
        }
    }
}
