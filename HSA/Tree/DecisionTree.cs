using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Tree
{
    public class DecisionTree
    {
        public double OverallGiniIndex { get; set; }
        public DataTable Data { get; set; }
        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data)
        {
            Data = data;
            calculateOverallGiniIndex();

        }    

        // ----------------------------------------------------------------------------------------------------

        // Information of the root

        private Node root;

        public Node Root
        {
            get { return root; }
            set { root = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        //Overall entropy calculation

        public void calculateOverallGiniIndex() 
        {
            Hashtable priceRanges = new Hashtable();
            
            foreach (DataRow item in Data.Rows)
            {
               string range =  item["price_range"].ToString();
               AddPriceRangeRecordToHashTable(priceRanges,range);
            }

            int totalRows = Data.Rows.Count;

            double sumGiniIndex = 0;

            foreach (DictionaryEntry item in priceRanges)
            {
                int count = (int)priceRanges[item.Key];
                sumGiniIndex += calculateSingleGiniIndex(count, totalRows);
            }

            OverallGiniIndex = 1 - sumGiniIndex;


        }

        private double calculateSingleGiniIndex(int count, int totalRows)
        {
            double result = 0;

            double castCount = (double)count;
            double castTotalRows = (double)totalRows;

            double proportion = castCount / castTotalRows;
            result = proportion * proportion;

            return result;
        }

        private void AddPriceRangeRecordToHashTable(Hashtable priceRanges, string range)
        {
            if (priceRanges.ContainsKey(range))
            {


                object objArray = priceRanges[range];

                if (objArray != null)
                {
                    int count = (int)objArray;

                    count = count + 1;

                    priceRanges[range] = count;
                }


            }
            else
            {
                priceRanges.Add(range, 1);
            }
        }
    }
}
