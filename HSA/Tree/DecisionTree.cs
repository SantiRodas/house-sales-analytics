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

        public Hashtable GiniIndexes { get; set; }


        public DataTable Data { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data)
        {
            Data = data;
            GiniIndexes = new Hashtable();
            calculateOverallGiniIndex();

            calculateGiniIndexForAllColumns();

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

        //Overall gini index calculation

        public void calculateOverallGiniIndex()
        {
            Hashtable priceRanges = new Hashtable();

            foreach (DataRow item in Data.Rows)
            {
                string range = item["price_range"].ToString();

                AddRecordToHashTable(priceRanges, range);

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

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes


        private void calculateGiniIndexForAllColumns()
        { 
        }

        // ----------------------------------------------------------------------------------------------------

        //  Calculate single gini index

        private double calculateSingleGiniIndex(int count, int totalRows)
        {
            double result = 0;

            double castCount = (double)count;

            double castTotalRows = (double)totalRows;

            double proportion = castCount / castTotalRows;

            result = proportion * proportion;

            return result;
        }


        // ----------------------------------------------------------------------------------------------------

        // Method add price range record to hash table

        private void AddRecordToHashTable<T>(Hashtable priceRanges, T range) where T : IComparable<T>
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

        // ----------------------------------------------------------------------------------------------------


        //Every column gini index calculation

        public double calculateGiniIndex(string column)
        {
            Hashtable hashtable = new Hashtable();
            
            foreach (DataRow item in Data.Rows)
            {
                string columnValue = item[column].ToString();
                string range = item["price_range"].ToString();
                AddRecordToOutterHashTable(hashtable, columnValue, range);
            }

            int totalRows = Data.Rows.Count;

            double sumGiniIndex = 0;

            List<double[]> giniIndexAndCountPerValueOfColumn = new List<double[]>();

            foreach (DictionaryEntry item in hashtable)
            {
                Hashtable innerHashtable = (Hashtable)hashtable[item.Key];
                sumGiniIndex = 0;

                foreach (DictionaryEntry innerHashtableKey in innerHashtable)
                {

                    int count = (int)innerHashtable[innerHashtableKey.Key];
                    sumGiniIndex += calculateSingleGiniIndex(count, totalRows);
                    double authenticGiniIndex =  1 - sumGiniIndex;
                    giniIndexAndCountPerValueOfColumn.Add(new double[3]{ (double)innerHashtableKey.Key, authenticGiniIndex, count});
                    // check count argument on the prior statement to this comment
                }
                
            }

            return 1 - sumGiniIndex;


        }

        private void AddRecordToOutterHashTable<T>(Hashtable hashtable, T columnValue, string range) where T : IComparable<T>
        {
            if (hashtable.ContainsKey(columnValue))
            {
                object objArray = hashtable[columnValue];

                if (objArray != null)
                {
                    Hashtable innerHashtable = (Hashtable)objArray;
                    AddRecordToHashTable(innerHashtable, range);
                }
            }
            else
            {
                Hashtable newInnerHashtable = new Hashtable();
                hashtable.Add(columnValue, newInnerHashtable);
            }
        }
    }
}

