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
        public double OverallEntropy { get; set; }
        public DataTable Data { get; set; }
        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data)
        {
            Data = data;
            calculateOverallEntropy();

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

        public void calculateOverallEntropy() 
        {
            Hashtable priceRanges = new Hashtable();
            
            foreach (DataRow item in Data.Rows)
            {
               string range =  item["price_range"].ToString();
               AddPriceRangeRecordToHashTable(priceRanges,range);
            }

            int totalRows = Data.Rows.Count;

            double sumEntropies = 0;

            foreach (DictionaryEntry item in priceRanges)
            {
                int count = (int)priceRanges[item.Key];
                sumEntropies += calculateSingleEntropy(count, totalRows);
            }

            OverallEntropy = sumEntropies;


        }

        private double calculateSingleEntropy(int count, int totalRows)
        {
            double result = 0;

            double proportion = count / totalRows;
            result =  Math.Log(proportion, 2);
            result = (-proportion) * result;

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
