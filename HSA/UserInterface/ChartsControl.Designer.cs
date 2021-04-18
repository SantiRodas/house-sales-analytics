
namespace HSA.UserInterface
{
    partial class ChartsControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartZipcodeXAverage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartZipcodeXPercentage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartYearXQuantity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartZipcodeXAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartZipcodeXPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearXQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // chartZipcodeXAverage
            // 
            chartArea1.AxisX.Title = "Zipcode";
            chartArea1.AxisY.Title = "Average Price";
            chartArea1.Name = "ChartArea1";
            this.chartZipcodeXAverage.ChartAreas.Add(chartArea1);
            this.chartZipcodeXAverage.Location = new System.Drawing.Point(0, 93);
            this.chartZipcodeXAverage.Name = "chartZipcodeXAverage";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Average Sale Price";
            this.chartZipcodeXAverage.Series.Add(series1);
            this.chartZipcodeXAverage.Size = new System.Drawing.Size(883, 467);
            this.chartZipcodeXAverage.TabIndex = 0;
            this.chartZipcodeXAverage.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Average Sale Price per Zipcode";
            this.chartZipcodeXAverage.Titles.Add(title1);
            // 
            // chartZipcodeXPercentage
            // 
            chartArea2.AxisX.Title = "Zipcode";
            chartArea2.AxisY.Title = "Average Price";
            chartArea2.Name = "ChartArea1";
            this.chartZipcodeXPercentage.ChartAreas.Add(chartArea2);
            this.chartZipcodeXPercentage.Location = new System.Drawing.Point(-3, 621);
            this.chartZipcodeXPercentage.Name = "chartZipcodeXPercentage";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Percentage per Zipcode";
            this.chartZipcodeXPercentage.Series.Add(series2);
            this.chartZipcodeXPercentage.Size = new System.Drawing.Size(883, 467);
            this.chartZipcodeXPercentage.TabIndex = 1;
            this.chartZipcodeXPercentage.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Sales Participation per Zipcode";
            this.chartZipcodeXPercentage.Titles.Add(title2);
            // 
            // chartYearXQuantity
            // 
            chartArea3.AxisX.Title = "Year Built";
            chartArea3.AxisY.Title = "Houses sold";
            chartArea3.Name = "ChartArea1";
            this.chartYearXQuantity.ChartAreas.Add(chartArea3);
            legend1.Name = "Years";
            this.chartYearXQuantity.Legends.Add(legend1);
            this.chartYearXQuantity.Location = new System.Drawing.Point(-3, 1169);
            this.chartYearXQuantity.Name = "chartYearXQuantity";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Years";
            series3.Name = "Years";
            this.chartYearXQuantity.Series.Add(series3);
            this.chartYearXQuantity.Size = new System.Drawing.Size(880, 467);
            this.chartYearXQuantity.TabIndex = 2;
            this.chartYearXQuantity.Text = "chartYearXQuantity";
            title3.Name = "Title1";
            title3.Text = "Number of houses sold according of its building year";
            this.chartYearXQuantity.Titles.Add(title3);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Charts ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChartsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartYearXQuantity);
            this.Controls.Add(this.chartZipcodeXPercentage);
            this.Controls.Add(this.chartZipcodeXAverage);
            this.Name = "ChartsControl";
            this.Size = new System.Drawing.Size(883, 1709);
            ((System.ComponentModel.ISupportInitialize)(this.chartZipcodeXAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartZipcodeXPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearXQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartZipcodeXAverage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartZipcodeXPercentage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYearXQuantity;
        private System.Windows.Forms.Label label1;
    }
}
