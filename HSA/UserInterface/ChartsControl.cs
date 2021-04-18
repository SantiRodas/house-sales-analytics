using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSA.Model;

namespace HSA.UserInterface
{
    public partial class ChartsControl : UserControl
    {
        private GraphicsProcessor manager;
       
        public ChartsControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
                    }

        public void Initialize(GraphicsProcessor manager)
        {
            this.manager = manager;
            UpdateCharts();
            



        }

        public void UpdateCharts() 
        {
            manager.UpdateFilteredData();

            UpdateChartZipcodeXAverage();
            UpdateChartZipcodeXPercentage();
            UpdateChartYearXQuantity();
            UpdateChartZipcodeXAverageSqrFt();
            UpdateChartZipcodeXAverageSqrFtPrice();
        }

        private void UpdateChartZipcodeXAverage() 
        {
            chartZipcodeXAverage.Series["Average Sale Price"].Points.Clear();
            List<double[]> chartData = manager.ZipcodeXAveragePrice();
            foreach (double[] i in chartData)
            {
                chartZipcodeXAverage.Series["Average Sale Price"].Points.AddXY(i[0], i[1]);
            }
        }
       

        private void UpdateChartZipcodeXPercentage()
        {
            chartZipcodeXPercentage.Series["Percentage per Zipcode"].Points.Clear();
            List<double[]> chartData = manager.ZipcodeXPercentage();
            chartZipcodeXPercentage.Series["Percentage per Zipcode"].IsValueShownAsLabel = true;
            chartZipcodeXPercentage.Series["Percentage per Zipcode"].BorderColor = Color.Black;
            chartZipcodeXPercentage.Series["Percentage per Zipcode"]["PieLabelStyle"] = "Outside";
            chartZipcodeXPercentage.Series["Percentage per Zipcode"]["PieLabelStyle"] = "";
            foreach (double[] i in chartData)
            {
                chartZipcodeXPercentage.Series["Percentage per Zipcode"].Points.AddXY(i[0], i[1]);
            }
        }

        private void UpdateChartYearXQuantity()
        {
            chartYearXQuantity.Series["Years"].Points.Clear();
            List<int[]> chartData = manager.YearXQuantity();
            foreach (int[] i in chartData)
            {
                chartYearXQuantity.Series["Years"].Points.AddXY(i[0], i[1]);
            }
        }

        private void UpdateChartZipcodeXAverageSqrFt()
        {
            chartZipcodeXAverageSqrFt.Series["Square Feet"].Points.Clear();
            List<double[]> chartData = manager.ZipcodeXAverageSqrFt();
            
            foreach (double[] i in chartData)
            {
                chartZipcodeXAverageSqrFt.Series["Square Feet"].Points.AddXY(i[0], i[1]);
            }
        }


        private void UpdateChartZipcodeXAverageSqrFtPrice()
        {
            chartZipcodeXAverageSqrFtPrice.Series["Square Feet Price"].Points.Clear();
            List<double[]> chartData = manager.ZipcodeXAverageOneSqrFt();

            foreach (double[] i in chartData)
            {
                chartZipcodeXAverageSqrFtPrice.Series["Square Feet Price"].Points.AddXY(i[0], i[1]);
            }
        }

        


    }
}
