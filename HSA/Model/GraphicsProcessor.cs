using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Model
{
    public class GraphicsProcessor
    {

        // ----------------------------------------------------------------------------------------------------

        // Information of the graphics processor

        public DataSetManager Data { get; set; }

        private DataTable FilteredData { get; set; }

        private Hashtable PricesByZip { get; set; }

        private Hashtable QuantityPerYear { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Method constructor of the graphics processor

        public GraphicsProcessor(DataSetManager data) {
            Data = data;
            PricesByZip = new Hashtable();
            QuantityPerYear = new Hashtable();
            UpdateFilteredData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update filtered data

        public void UpdateFilteredData()
        {
            FilteredData = Data.DataFiltered.ToTable();

            QuantityPerYear.Clear();

            PricesByZip.Clear();

            UpdateQuantityPerYear();

            UpdatePricesByZip();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update quantity per year

        public void UpdateQuantityPerYear()
        {
            for (int i = 0; i < FilteredData.Rows.Count; i++)
            {
                int yr_built = (int)FilteredData.Rows[i]["yr_built"];

                AddYearToHashtable(yr_built);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method add year to hash table

        private void AddYearToHashtable(int yr_built)
        {
            if (QuantityPerYear.ContainsKey(yr_built))
            {
                object objArray = QuantityPerYear[yr_built];

                if (objArray != null)
                {
                    int valueYear = (int)objArray;
                    
                    QuantityPerYear[yr_built] = valueYear + 1;
                }
            }
            else
            {
                QuantityPerYear.Add(yr_built, 1);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update prices by zip

        public void UpdatePricesByZip()
        {
            for (int i =0; i< FilteredData.Rows.Count;i++) 
            {
                string zipcode = (string)FilteredData.Rows[i]["zipcode"];

                double price = (double)FilteredData.Rows[i]["price"];

                AddPriceToHashtable(zipcode, price);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method add price to hash table

        private void AddPriceToHashtable(string zipcode, double price) {

            double[] arrayForAverage = {0, 0};

            if (PricesByZip.ContainsKey(zipcode))
            {
                object objArray = PricesByZip[zipcode];

                if (objArray != null)
                {
                    arrayForAverage = (double[])objArray;

                    arrayForAverage[0] = arrayForAverage[0] + price; //keeps the sum of the prices per zipcode
                    arrayForAverage[1] = arrayForAverage[1] + 1; //keeps the sum of the number of sales per zipcode

                    PricesByZip[zipcode] = arrayForAverage;
                }
            }
            else
            {
                arrayForAverage[0] = price;
                arrayForAverage[1] = 1;

                PricesByZip.Add(zipcode, arrayForAverage);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method year X quantity

        public List<int[]> YearXQuantity()
        {
            List<int[]> displayData = new List<int[]>();

            foreach (DictionaryEntry i in QuantityPerYear)
            {
                int[] dataPoint = new int[2];

                int values = (int)i.Value;
                
                dataPoint[0] = Int32.Parse(i.Key.ToString());

                dataPoint[1] = (int)i.Value;

                displayData.Add(dataPoint);
            }

            return displayData;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method zip code X average price

        public List<double[]> ZipcodeXAveragePrice()
        {
            List<double[]> displayData = new List<double[]>();

            foreach (DictionaryEntry i in PricesByZip)
            {
                double[] dataPoint = new double[2];
                double[] values = (double[])i.Value;

                double a = values[0];
                double b = values[1];
                double c = a / b;

                dataPoint[0] = Int32.Parse(i.Key.ToString());
                dataPoint[1] = c;

                displayData.Add(dataPoint);
            }
            return displayData;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method zip code X percentage

        public List<double[]> ZipcodeXPercentage()
        {
            double sum = 0;

            foreach (DictionaryEntry j in PricesByZip)
            {
                double[] values = (double[])j.Value;

                sum += values[1];
            }

            List<double[]> displayData = new List<double[]>();

            foreach (DictionaryEntry i in PricesByZip)
            {
                double[] dataPoint = new double[2];
                double[] values = (double[])i.Value;

                double b = values[1];
                double percentage = b / sum;

                percentage = Math.Round(percentage*100, 2);
                
                dataPoint[0] = Int32.Parse(i.Key.ToString());
                dataPoint[1] = percentage;

                displayData.Add(dataPoint);
            }
            return displayData;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method zip code X average Sqrft

        public SortedDictionary<int, KeyValuePair<string, int>> PriceRangeXHousesSold()
        {
            SortedDictionary<int,KeyValuePair<string,int>> displayData = new SortedDictionary<int, KeyValuePair<string, int>>();

            foreach(DataRow dr in FilteredData.Rows)
            {
                string priceRange = (string)dr["price_range"];
                int priceRangeClassMark = int.Parse(priceRange.Split('-')[0].Replace("[", ""));

                if (displayData.ContainsKey(priceRangeClassMark))
                {
                    int currentCount = (int)displayData[priceRangeClassMark].Value;
                    currentCount++;
                    displayData[priceRangeClassMark] = new KeyValuePair<string, int>(priceRange,currentCount);
                }
                else
                {
                    displayData[priceRangeClassMark] = new KeyValuePair<string, int>(priceRange, 1);
                }
                
            }
            return displayData;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method zip code X average one Sqrft

        public SortedDictionary<int, double> YearBuiltXAveragePrice()
        {
            SortedDictionary<int, double> displayData = new SortedDictionary<int, double>();
            SortedDictionary<int, int> displayDataCount = new SortedDictionary<int, int>();

            foreach (DataRow dr in FilteredData.Rows)
            {
                int buildYear = (int)dr["yr_built"];
                double price = (double)dr["price"];

                if (displayData.ContainsKey(buildYear))
                {
                    int currentCount = displayDataCount[buildYear];
                    currentCount += 1;

                    displayDataCount[buildYear] =currentCount;

                    double currentSumPrice = displayData[buildYear];
                    currentSumPrice += price;

                    displayData[buildYear] = currentSumPrice;

                }
                else
                {
                    displayDataCount[buildYear] =  1;
                    displayData[buildYear] = price;
                }

            }


            foreach(KeyValuePair<int,int> displayDataEntryCount in displayDataCount)
            {
                displayData[displayDataEntryCount.Key] = Math.Round(displayData[displayDataEntryCount.Key] / (double)displayDataEntryCount.Value, 2);
            }

            return displayData;
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
