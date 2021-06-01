using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HSA.Model;

namespace HSA.UserInterface
{

    public partial class ChartsControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Relation with the graphics processos class

        private GraphicsProcessor graphicsManager;

        // ----------------------------------------------------------------------------------------------------

        // Constructor method of the charts control

        public ChartsControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        // ----------------------------------------------------------------------------------------------------

        // Initialize method

        public void Initialize(GraphicsProcessor manager)
        {
            this.graphicsManager = manager;

            UpdateCharts();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update charts

        public void UpdateCharts() 
        {
            graphicsManager.UpdateFilteredData();

            UpdateChartZipcodeXAverage();

            UpdateChartZipcodeXPercentage();

            UpdateChartYearXQuantity();

            UpdateChartPriceRangeXHousesSelled();

            UpdateChartYearBuiltXAveragePrice();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update chart zip code X average

        private void UpdateChartZipcodeXAverage() 
        {
            chartZipcodeXAverage.Series["Average Sale Price"].Points.Clear();

            List<double[]> chartData = graphicsManager.ZipcodeXAveragePrice();

            foreach (double[] i in chartData)
            {
                chartZipcodeXAverage.Series["Average Sale Price"].Points.AddXY(i[0], i[1]);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update chart zio code X peercentage

        private void UpdateChartZipcodeXPercentage()
        {
            chartZipcodeXPercentage.Series["Percentage per Zipcode"].Points.Clear();

            List<double[]> chartData = graphicsManager.ZipcodeXPercentage();

            chartZipcodeXPercentage.Series["Percentage per Zipcode"].IsValueShownAsLabel = true;

            chartZipcodeXPercentage.Series["Percentage per Zipcode"].BorderColor = Color.Black;

            chartZipcodeXPercentage.Series["Percentage per Zipcode"]["PieLabelStyle"] = "Outside";

            chartZipcodeXPercentage.Series["Percentage per Zipcode"]["PieLabelStyle"] = "";

            foreach (double[] i in chartData)
            {
                chartZipcodeXPercentage.Series["Percentage per Zipcode"].Points.AddXY(i[0], i[1]);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update chart year X quantity

        private void UpdateChartYearXQuantity()
        {
            chartYearXQuantity.Series["Years"].Points.Clear();

            List<int[]> chartData = graphicsManager.YearXQuantity();

            chartData.Sort((x,y) => x[0].CompareTo(y[0]));

            for (int i = 0; i < chartData.Count; i++)
            {
                chartYearXQuantity.Series["Years"].Points.AddXY(chartData[i][0], chartData[i][1]);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update chart zip code X average Sqrft

        private void UpdateChartPriceRangeXHousesSelled()
        {
            chartHousesSoldPerPriceRange.Series["House Count"].Points.Clear();

            SortedDictionary<int, KeyValuePair<string, int>> chartData = graphicsManager.PriceRangeXHousesSold();
            
            foreach(KeyValuePair<int,KeyValuePair<string,int>> rangeMarkAndCount in chartData)
            {
                KeyValuePair<string, int> rangeAndCount = rangeMarkAndCount.Value;

                chartHousesSoldPerPriceRange.Series["House Count"].Points.AddXY((string)rangeAndCount.Key, (int)rangeAndCount.Value);                
            }

        }

        // ----------------------------------------------------------------------------------------------------

        // Method update chart zip code X average Sqrft price

        private void UpdateChartYearBuiltXAveragePrice()
        {
            chartAveragePriceVsYearBuilt.Series["Average Price"].Points.Clear();

            SortedDictionary<int, double> chartData = graphicsManager.YearBuiltXAveragePrice();

            foreach (KeyValuePair<int, double> yearAndAvgPrice in chartData)
            {
                chartAveragePriceVsYearBuilt.Series["Average Price"].Points.AddXY(yearAndAvgPrice.Key,yearAndAvgPrice.Value);
            }
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
