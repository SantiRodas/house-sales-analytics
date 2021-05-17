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
        public double OverallGiniIndex { get; set; }

        public Hashtable GiniIndexes { get; set; }


        public DataTable Data { get; set; }

        public DataView DataFiltered { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data)
        {
            Data = data;
            GiniIndexes = new Hashtable();
            CalculateOverallGiniIndex();
            DataFiltered = new DataView(data);

            root = new Node();
            root.GiniIndex = OverallGiniIndex;

            //calculateGiniIndexForAllColumns();

            ColumnOverallGiniImpurity<int>("yr_built", new DataView(data));
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

                AddPriceRangeRecordToHashTable(priceRangesCount, range); //Adds not repeating price ranges to the hashtable

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

        public Node generateTree()
        {
            return generateTreeRecursive(root);
        }

        private Node generateTreeRecursive(Node currentNode)
        {
            if(currentNode == root)
            {
                KeyValuePair<double, Pair> bestColumnGiniAndCondition = SelectBestColumn(DataFiltered);
                //calcular el information gain
                //si el gain es mayor a 0 entonces particiona
                //crea dos nodos con dos data views con cada particion
                //agrega la condicion al nodo actual
                //y llama generat tree de manera recursiva

                //si no este nodo es hoja y se determina la respuesta
                //retorna el nodo actual
            }
            else
            {
                KeyValuePair<double, Pair> bestColumnGiniAndCondition = SelectBestColumn(currentNode.Partition);
                //calcular el information gain
                //si el gain es mayor a 0 entonces particiona
                //crea dos nodos con dos data views con cada particion
                //agrega la condicion al nodo actual
                //y llama generat tree de manera recursiva

                //si no este nodo es hoja y se determina la respuesta
                //retorna el nodo actual
            }

            return null;
        }

        public KeyValuePair<double,Pair> SelectBestColumn(DataView nodePartition)
        {

            SortedDictionary<double, Pair> columnsGiniImpurity = CalculateGiniIndexForAllColumns(nodePartition);

            return columnsGiniImpurity.First();
        }

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes


        private SortedDictionary<double, Pair> CalculateGiniIndexForAllColumns(DataView nodePartition)
        {

            SortedDictionary<double, Pair> columnsGiniImpurity = new SortedDictionary<double, Pair>();

            for(int i = 0; i < nodePartition.Table.Columns.Count; i++)
            {
                DataColumn column = nodePartition.Table.Columns[i];
                String columnName = column.ColumnName;
                Type columnDataType = column.DataType;

                if (!columnName.Equals("id") && !columnName.Equals("date") 
                    && !columnName.Equals("lat") && !columnName.Equals("long") 
                    && !columnName.Equals("price") && !columnName.Equals("price_range"))
                {

                    double giniIndexValue;
                    object condition;

                    if (columnDataType.Equals(typeof(double)))
                    {
                        KeyValuePair<double, double> giniIndexAndCondition = ColumnOverallGiniImpurity<Double>(columnName, nodePartition);
                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value;
                    }
                    else if (columnDataType.Equals(typeof(int)))
                    {
                        KeyValuePair<double, int> giniIndexAndCondition = ColumnOverallGiniImpurity<Int32>(columnName, nodePartition);
                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value;
                    }
                    else if (columnDataType.Equals(typeof(bool)))
                    {
                        KeyValuePair<double, bool> giniIndexAndCondition = ColumnOverallGiniImpurity<Boolean>(columnName, nodePartition);
                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value;
                    }
                    else if (columnDataType.Equals(typeof(string)))
                    {
                        KeyValuePair<double, string> giniIndexAndCondition = ColumnOverallGiniImpurity<String>(columnName, nodePartition);
                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value;
                    }
                    else
                    {
                        throw new Exception("Unsupported data type");
                    }

                    columnsGiniImpurity[giniIndexValue] = new Pair(columnName,condition);   

                }

            }

            return columnsGiniImpurity;
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

        private void AddPriceRangeRecordToHashTable<T>(Hashtable priceRangesCount, T range) where T : IComparable<T>
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
        //Overall column gini index 
        //Column overall gini impurity
        //Return a pair with the condition that best separates the data and its gini index
        //The partition received as a parameter is the current node partition that is going to be split into two
        public KeyValuePair<double, T> ColumnOverallGiniImpurity<T>(string columnName, DataView nodePartition) where T:IComparable<T>
        {
            int totalRows = nodePartition.Count;

            //Stores each possible category or numeric value with inner hash table for price range counting of comlying and not complying data
            Hashtable outerHashtable = ObtainPossibleConditions<T>(nodePartition, totalRows, columnName);

            //Counting
            outerHashtable = CountPriceRangesForPossibleCondition<T>(outerHashtable, nodePartition, columnName, totalRows);

            //Possible gini ipurities calculation
            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, T> columnValuesGiniImpurities = CalculatePossibleOverallGiniImpurities<T>(outerHashtable, totalRows);

            //Return the best condition with its gini impurity
            return columnValuesGiniImpurities.First();
        }

        public Hashtable ObtainPossibleConditions<T>(DataView nodePartition, int totalRows, string columnName) where T:IComparable<T>
        {
            Hashtable outerHashtable = new Hashtable();

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = nodePartition[i].Row;

                T columnValue = (T)item[columnName];

                if (!outerHashtable.ContainsKey(columnValue))
                {
                    Hashtable partitionTrueInnerHashtable = new Hashtable();
                    Hashtable partitionFalseInnerHashtable = new Hashtable();

                    Pair partitionsInnerHashtables = new Pair(partitionTrueInnerHashtable, partitionFalseInnerHashtable);

                    outerHashtable[columnValue] = partitionsInnerHashtables;
                }
            }
            return outerHashtable;
        }

        public Hashtable CountPriceRangesForPossibleCondition<T>(Hashtable outerHashtable, DataView nodePartition, String columnName, int totalRows) where T:IComparable<T>
        {
            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = nodePartition[i].Row;

                T columnValue = (T)item[columnName];

                string itemPriceRange = item["price_range"].ToString();

                foreach (DictionaryEntry possibleCondition in outerHashtable)
                {
                    Pair partitionsInnerHashtables = (Pair)possibleCondition.Value;

                    Hashtable partitionInnerHashtable;

                    if ((typeof(T).Equals(typeof(string)) && columnValue.Equals((T)possibleCondition.Key))
                    || (!typeof(T).Equals(typeof(string)) && columnValue.CompareTo((T)possibleCondition.Key) <= 0))//Conditions
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element1; //True inner hash table
                    }
                    else
                    {
                        partitionInnerHashtable = (Hashtable)partitionsInnerHashtables.Element2;//False inner hash table
                    }

                    AddPriceRangeRecordToHashTable(partitionInnerHashtable, itemPriceRange);

                }

            }
            return outerHashtable;
        }


        //Return a SortedDictionary with overall gini impurities for each possible column value or possible condition,
        //From a hashtable with the values as keys and to inner hash tables for priceRange counting in both true and false partitions
        public SortedDictionary<double, T> CalculatePossibleOverallGiniImpurities<T>(Hashtable outerHashtable, int totalRows) where T:IComparable<T>
        {
            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, T> columnValuesGiniImpurities = new SortedDictionary<double, T>();
            foreach (DictionaryEntry item in outerHashtable)
            {
                Pair partitionsInnerHashtables = (Pair)item.Value;

                Hashtable innerHashtableTrue = (Hashtable)partitionsInnerHashtables.Element1;

                Hashtable innerHashtableFalse = (Hashtable)partitionsInnerHashtables.Element2;

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

                //Item.key is the condition, the column value (assume equals in categorical and <= in numerical)
                columnValuesGiniImpurities[giniImpurityOverall]  = (T)item.Key;
            }
            return columnValuesGiniImpurities;
        }
        
    }
}

