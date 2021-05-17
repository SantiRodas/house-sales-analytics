using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HSA.Utilities;

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
        //The partition received as a parameter is the current node partition that is going to be split into two
        //ONLY FOR CATEGORICAL OR true/false DATA

        public KeyValuePair<double, string> CategoricalColumnOverallGiniImpurity(string columnName, DataView partition)
        {
            Hashtable outerHashtable = new Hashtable(); //Stores each possible category value

            int totalRows = partition.Count;

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = partition[i].Row;

                string columnValue = item[columnName].ToString();

                if (!outerHashtable.ContainsKey(columnValue))
                {

                    Hashtable partitionTrueInnerHashtable= new Hashtable();
                    Hashtable partitionFalseInnerHashtable = new Hashtable();

                    Pair partitionsInnerHashtables = new Pair(partitionTrueInnerHashtable, partitionFalseInnerHashtable);

                    outerHashtable[columnValue] = partitionsInnerHashtables;
                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = partition[i].Row;

                string columnValue = item[columnName].ToString();

                string itemPriceRange = item["price_range"].ToString();

                foreach (DictionaryEntry possibleCondition in outerHashtable)
                {
                    Pair partitionsInnerHashtables = (Pair)possibleCondition.Value;

                    Hashtable partitionInnerHashtable;

                    if (columnValue.Equals(possibleCondition.Key))
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element1;
                    }
                    else
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element2;
                    }

                    AddRecordToHashTable(partitionInnerHashtable, itemPriceRange);

                }

            }

            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, string> columnValuesGiniIndex = new SortedDictionary<double, string>();

            foreach (DictionaryEntry item in outerHashtable)
            {
                Pair partitionsInnerHashtables = (Pair)item.Value;

                Hashtable innerHashtableTrue = (Hashtable)partitionsInnerHashtables.Element1;

                Hashtable innerHashtableFalse = (Hashtable)partitionsInnerHashtables.Element1;

                double sumProportionSquaredTrue = 0;
                double sumProportionSquaredFalse = 0;

                int trueCount = 0;

                foreach (DictionaryEntry priceRange in innerHashtableTrue)
                {
                    int count = (int)priceRange.Value;

                    trueCount += count;

                    sumProportionSquaredTrue += CalculateProportionSquared(count, totalRows);
                }

                foreach (DictionaryEntry priceRange in innerHashtableFalse)
                {
                    int count = (int)priceRange.Value;

                    sumProportionSquaredFalse += CalculateProportionSquared(count, totalRows);
                }

                double giniImpurityTrue = 1 - sumProportionSquaredTrue;
                double giniImpurityFalse = 1 - sumProportionSquaredFalse;

                double overallTrueProportion = trueCount / totalRows;

                double giniImpurityOverall = giniImpurityTrue*(overallTrueProportion) + giniImpurityFalse*(1- overallTrueProportion);

                //Item.key is the condition, the column value (assume equals)
                columnValuesGiniIndex[giniImpurityOverall] = (string)item.Key;
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

        //Retornar esto al contrario
        //Asumes condition is expressed as <=
        public KeyValuePair<double, double> NumericalOverallGiniIndex(string columnName, DataView partition)
        {
            Hashtable outerHashtable = new Hashtable(); //Stores each possible category value
            
            int totalRows = partition.Count;
            partition.Sort = $"{columnName} ASC";

            if (totalRows == 1)
            {
                DataRow item = partition[0].Row;

                Hashtable partitionTrueInnerHashtable = new Hashtable();
                Hashtable partitionFalseInnerHashtable = new Hashtable();

                Pair partitionsInnerHashtables = new Pair(partitionTrueInnerHashtable, partitionFalseInnerHashtable);

                outerHashtable[(double)item[columnName]] = partitionsInnerHashtables;
            }
            
            double pastAverage = Double.MinValue;          

            for (int i = 0; i < totalRows - 1; i++)
            {
                DataRow item = partition[i].Row;
                DataRow nextItem = partition[i].Row;

                double average = ((double)item[columnName] + (double)nextItem[columnName]) / 2;

                if (average > pastAverage)
                {
                    Hashtable partitionTrueInnerHashtable = new Hashtable();
                    Hashtable partitionFalseInnerHashtable = new Hashtable();

                    Pair partitionsInnerHashtables = new Pair(partitionTrueInnerHashtable, partitionFalseInnerHashtable);

                    outerHashtable[average] = partitionsInnerHashtables;

                    pastAverage = average;
                }               
            }

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = partition[i].Row;

                double columnValue = (double)item[columnName];

                string itemPriceRange = item["price_range"].ToString();

                foreach (DictionaryEntry possibleCondition in outerHashtable)
                {
                    Pair partitionsInnerHashtables = (Pair)possibleCondition.Value;

                    Hashtable partitionInnerHashtable;

                    if (columnValue >= (double)possibleCondition.Key)
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element1;
                    }
                    else
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element2;
                    }

                    AddRecordToHashTable(partitionInnerHashtable, itemPriceRange);
                }

            }

            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, double> columnValuesGiniIndex = new SortedDictionary<double, double>();

            foreach (DictionaryEntry item in outerHashtable)
            {
                Pair partitionsInnerHashtables = (Pair)item.Value;

                Hashtable innerHashtableTrue = (Hashtable)partitionsInnerHashtables.Element1;

                Hashtable innerHashtableFalse = (Hashtable)partitionsInnerHashtables.Element1;

                double sumProportionSquaredTrue = 0;
                double sumProportionSquaredFalse = 0;

                int trueCount = 0;

                foreach (DictionaryEntry priceRange in innerHashtableTrue)
                {
                    int count = (int)priceRange.Value;

                    trueCount += count;

                    sumProportionSquaredTrue += CalculateProportionSquared(count, totalRows);
                }

                foreach (DictionaryEntry priceRange in innerHashtableFalse)
                {
                    int count = (int)priceRange.Value;

                    sumProportionSquaredFalse += CalculateProportionSquared(count, totalRows);
                }

                double giniImpurityTrue = 1 - sumProportionSquaredTrue;
                double giniImpurityFalse = 1 - sumProportionSquaredFalse;

                double overallTrueProportion = trueCount / totalRows;

                double giniImpurityOverall = giniImpurityTrue * (overallTrueProportion) + giniImpurityFalse * (1 - overallTrueProportion);

                //Item.key is the condition, the column value (assume equals)
                columnValuesGiniIndex[giniImpurityOverall] = (double)item.Key;
            }

            return columnValuesGiniIndex.Min();
        }

        
    }
}

