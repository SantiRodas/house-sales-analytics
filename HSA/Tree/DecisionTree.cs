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
        //Hallar el gini impurty de todo el dataset (con base en los rangos de precio)

        //Hasta que????

        //Recorrer todas las columnas
            //Para cada columna determinar la pregunta que mejor particiona los datos, es decir la que tenga mayor info gain




        //Hallar el information gain de todas las columnas y particionar los datos con la columna y pregunta que mas informacion de




        public double OverallGiniIndex { get; set; }

        public Hashtable GiniIndexes { get; set; }


        public DataTable Data { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data)
        {
            Data = data;
            GiniIndexes = new Hashtable();
            CalculateOverallGiniIndex();

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
        //Calculate the gini index/impurity of the whole dataset (in price  ranges)

        public void CalculateOverallGiniIndex()
        {
            Hashtable priceRangesCount = new Hashtable();

            foreach (DataRow register in Data.Rows)
            {
                string range = register["price_range"].ToString();

                AddRecordToHashTable(priceRangesCount, range); //Adds not repeating price ranges to the hashtable

            }

            int totalRows = Data.Rows.Count; //Total number of rows in the data set

            double sumProportionSquared = 0;

            foreach (DictionaryEntry item in priceRangesCount)
            {
                int count = (int)priceRangesCount[item.Key];

                sumProportionSquared += CalculateProportionSquared(count, totalRows);
            }

            OverallGiniIndex = 1 - sumProportionSquared;
        }

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes


        private void calculateGiniIndexForAllColumns()
        { 
        }

        // ----------------------------------------------------------------------------------------------------

        //Calculate single gini index
        //Calculates proportion squared
        private double CalculateProportionSquared(int count, int totalRows)
        {
            double proportion = (double)count / (double)totalRows;

            double proportionSquared = proportion * proportion;

            return proportionSquared;
        }


        // ----------------------------------------------------------------------------------------------------

        // Method add price range record to hash table

        private void AddRecordToHashTable<T>(Hashtable priceRangesCount, T range) where T : IComparable<T>
        {
            if (priceRangesCount.ContainsKey(range))
            {
                object countObj = priceRangesCount[range];

                if (countObj != null)
                {
                    int count = (int)countObj;

                    count++;

                    priceRangesCount[range] = count;
                }
            }
            else
            {
                priceRangesCount.Add(range, 1);
            }
        }

        // ----------------------------------------------------------------------------------------------------


        //Every column gini index calculation
        //Return a pair with the categorical value that best separates the data and its gini index

        public KeyValuePair<string,double> calculateGiniIndex(string column, DataTable partition)
        {
            Hashtable outerHashtable = new Hashtable(); //Stores each possible category value

            SortedDictionary<string, double> columnValuesGiniIndex = new SortedDictionary<string, double>();

            foreach (DataRow item in partition.Rows)
            {
                string columnValue = item[column].ToString();

                //Adds column value to column values gini index sorted dictionary (works like a heap)
                if (!columnValuesGiniIndex.ContainsKey(columnValue))
                {
                    columnValuesGiniIndex[columnValue] = -1; //-1 works like a flag for telling that is not yet calculated a gini index
                }

                string itemPriceRange = item["price_range"].ToString();

                AddRecordToOutterHashTable(outerHashtable, columnValue, itemPriceRange);//Adds column value if not present and counts the times a price range appears in each columna value
            }

            int totalRows = partition.Rows.Count; //Change to take into acount data separation

            foreach (DictionaryEntry item in outerHashtable)
            {
                Hashtable innerHashtable = (Hashtable)outerHashtable[item.Key];
                double sumProportionSquared = 0;
                double authenticGiniIndex = -1;

                foreach (DictionaryEntry priceRange in innerHashtable)
                {
                    int count = (int)priceRange.Value;

                    sumProportionSquared += CalculateProportionSquared(count, totalRows);

                    authenticGiniIndex =  1 - sumProportionSquared;
                    //giniIndexAndCountPerValueOfColumn.Add(new double[3]{ (double)priceRange.Key, authenticGiniIndex, count});
                    // check count argument on the prior statement to this comment
                }

                columnValuesGiniIndex[(string)item.Key] = authenticGiniIndex; //Sets columnValue gini index to the calculated gini index

            }

            return columnValuesGiniIndex.Min();

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

