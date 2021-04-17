using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Model
{
    class GraphicsProcessor
    {
        public DataSetManager Data { get; set; }

        private DataTable FilteredData { get; set; }
        private Hashtable PricesByZip { get; set; }

        public GraphicsProcessor(DataSetManager data) {
            Data = data;
            UpdateFilteredData();
            PricesByZip = new Hashtable();
        }

        public void UpdateFilteredData()
        {
            FilteredData = Data.DataFiltered.ToTable();
        }

        public void UpdatePricesByZip()
        {
            for (int i =0; i< FilteredData.Rows.Count;i++) 
            {
                string zipcode = (string)FilteredData.Rows[i]["zipcode"];
                int price = (int)FilteredData.Rows[i]["price"];
                AddPriceToHashtable(zipcode, price);
            }
        }

        private void AddPriceToHashtable(string zipcode, int price) {
            int[] arrayForAverage = { 0, 0 };

            if (PricesByZip.ContainsKey(zipcode))
            {


                object objArray = PricesByZip[zipcode];

                if (objArray != null)
                {
                    arrayForAverage = (int[])objArray;

                    arrayForAverage[0] = arrayForAverage[0] + price;
                    arrayForAverage[1] = arrayForAverage[1] + 1;

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

        public List<int[]> ZipcodeXAveragePrice()
        {

            List<int[]> displayData = new List<int[]>();
            foreach (DictionaryEntry i in PricesByZip)
            {
                int[] dataPoint = new int[2];
                int[] values = (int[])i.Value;
                int a = values[0];
                int b = values[1];
                int c = a / b;
                dataPoint[0] = Int32.Parse(i.Key.ToString());
                dataPoint[1] = c;
                
                displayData.Add(dataPoint);
            }

            return displayData;
        }










    }
}
