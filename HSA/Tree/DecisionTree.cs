﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HSA.Model;
using HSA.Utilities;
using static System.Collections.Generic.Dictionary<string, int>;

namespace HSA.Tree
{
    public class DecisionTree
    {
        public double OverallGiniIndex { get; set; }

        public Hashtable PriceRangesCountGlobal { get; private set; }     
        
        public DataTable Data { get; set; }

        public DataView DataFiltered { get; set; }


        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataSetManager dataSetManager)
        {
            Data = dataSetManager.Data;

            CalculateOverallGiniIndex();

            root = new Node
            {
                GiniIndex = OverallGiniIndex,
                ObservationClassCount = PriceRangesCountGlobal,
                Partition = Data
            };

            Console.WriteLine(OverallGiniIndex);
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

            PriceRangesCountGlobal = priceRangesCount;
        }      

        public Node generateTree()
        {
            generateTreeRecursive(root);

            return root;
        }

        private void generateTreeRecursive(Node currentNode)
        {
            if(currentNode.Partition.Rows.Count <= 1)
            {
                currentNode.IsLeaf = true;

                Hashtable currentNodePriceRangeCount = currentNode.ObservationClassCount;

                int maxCount = -1;

                String maxPriceRange = "";

                foreach (DictionaryEntry priceRangeCount in currentNodePriceRangeCount)
                {

                    if ((int)priceRangeCount.Value > maxCount)
                    {
                        maxCount = (int)priceRangeCount.Value;
                        maxPriceRange = (string)priceRangeCount.Key;
                    }

                }

                currentNode.Answer = maxPriceRange;

                return;
            }

            Console.WriteLine(currentNode.Partition.Rows.Count);
            //<giniIndex, [columnName, condition]>
            KeyValuePair<double, Tuple<string, object, Hashtable, Hashtable,double,double>> bestColumnGiniAndCondition = SelectBestColumn(currentNode.Partition);

            double infoGain = currentNode.GiniIndex - bestColumnGiniAndCondition.Key;

            Console.WriteLine("curent node gini index = " + currentNode.GiniIndex);
            Console.WriteLine("best column gini and condition" + bestColumnGiniAndCondition.Key);
            Console.WriteLine("Info gain = " + infoGain);

            string columnName = bestColumnGiniAndCondition.Value.Item1;
            object conditionObj = bestColumnGiniAndCondition.Value.Item2;
            Hashtable trueHashtable = bestColumnGiniAndCondition.Value.Item3;
            Hashtable falseHashtable = bestColumnGiniAndCondition.Value.Item4;

            if (infoGain > 0 && trueHashtable.Count > 0 && falseHashtable.Count > 0)//Nodo de decision
            {
                Type columnDataType = conditionObj.GetType();

                DataView partitionTrue = new DataView(currentNode.Partition);
                DataView partitionFalse = new DataView(currentNode.Partition);

                Node nodeTrue = new Node();
                Node nodeFalse = new Node();

                if (columnDataType.Equals(typeof(double)))
                {
                    double condition = (double)conditionObj;

                    partitionTrue.RowFilter = $"{columnName} <= {condition}";
                    partitionFalse.RowFilter = $"{columnName} > {condition}";

                    currentNode.ConditionOperator = LogicalOperator.SMALLER_EQUALS_THAN;

                }
                else if (columnDataType.Equals(typeof(int)))
                {
                    int condition = (int)conditionObj;

                    partitionTrue.RowFilter = $"{columnName} <= {condition}";
                    partitionFalse.RowFilter = $"{columnName} > {condition}";

                    currentNode.ConditionOperator = LogicalOperator.SMALLER_EQUALS_THAN;
                }
                else if (columnDataType.Equals(typeof(bool)))
                {
                    bool condition = (bool)conditionObj;

                    if (condition)
                    {
                        partitionTrue.RowFilter = $"{columnName} = 1";
                        partitionFalse.RowFilter = $"{columnName} = 0";
                    }
                    else
                    {
                        partitionTrue.RowFilter = $"{columnName} = 0";
                        partitionFalse.RowFilter = $"{columnName} = 1";
                    }

                    

                    currentNode.ConditionOperator = LogicalOperator.EQUALS;
                }
                else if (columnDataType.Equals(typeof(string)))
                {
                    string condition = (string)conditionObj;

                    partitionTrue.RowFilter = $"{columnName} = '{condition}'";
                    partitionFalse.RowFilter = $"{columnName} != '{condition}'";

                    currentNode.ConditionOperator = LogicalOperator.EQUALS;
                }
                else
                {
                    throw new Exception("Unsupported data type");
                }

                nodeTrue.Partition = partitionTrue.ToTable();
                nodeTrue.GiniIndex = bestColumnGiniAndCondition.Value.Item5;
                nodeTrue.ObservationClassCount = trueHashtable;
                nodeFalse.Partition = partitionFalse.ToTable();
                nodeFalse.GiniIndex = bestColumnGiniAndCondition.Value.Item6;
                nodeFalse.ObservationClassCount = falseHashtable;

                currentNode.ConditionAttributeName = columnName;
                currentNode.IsLeaf = false;
                currentNode.ConditionValue = conditionObj;
                currentNode.AttributeType = columnDataType;

                currentNode.TrueNode = nodeTrue;
                currentNode.FalseNode = nodeFalse;

                generateTreeRecursive(nodeTrue);
                generateTreeRecursive(nodeFalse);

            }
            else//Es una hoja
            {
                currentNode.IsLeaf = true;

                Hashtable currentNodePriceRangeCount = currentNode.ObservationClassCount;

                int maxCount = -1;

                String maxPriceRange = "";

                foreach (DictionaryEntry priceRangeCount in currentNodePriceRangeCount)
                {

                    if ((int)priceRangeCount.Value > maxCount)
                    {
                        maxCount = (int)priceRangeCount.Value;
                        maxPriceRange = (string)priceRangeCount.Key;
                    }

                }

                currentNode.Answer = maxPriceRange;
            }

        }

        public KeyValuePair<double, Tuple<string, object, Hashtable, Hashtable,double,double>> SelectBestColumn(DataTable nodePartition)
        {

            SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable, double, double>> columnsGiniImpurity  = CalculateGiniIndexForAllColumns(nodePartition);

            return columnsGiniImpurity.First();
        }

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes


        private SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable, double, double>> CalculateGiniIndexForAllColumns(DataTable nodePartition)
        {

            SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable,double,double>> columnsGiniImpurity = new SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable,double,double>>();

            for (int i = 0; i < nodePartition.Columns.Count; i++)
            {
                Console.WriteLine("Column processed = " + i);
                DataColumn column = nodePartition.Columns[i];
                String columnName = column.ColumnName;
                Type columnDataType = column.DataType;

                if (!columnName.Equals("id") && !columnName.Equals("date")
                    && !columnName.Equals("lat") && !columnName.Equals("long")
                    && !columnName.Equals("price") && !columnName.Equals("price_range"))
                {

                    double giniIndexValue;
                    object condition;
                    Hashtable truePartition;
                    Hashtable falsePartition;
                    double giniImpurityTrue;
                    double giniImpurityFalse;

                    if (columnDataType.Equals(typeof(double)))
                    {
                        Console.WriteLine("Double column");

                        KeyValuePair<double, Tuple<double, Hashtable, Hashtable,double,double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Double>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;

                    }
                    else if (columnDataType.Equals(typeof(int)))
                    {
                        KeyValuePair<double, Tuple<int, Hashtable, Hashtable, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Int32>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;

                    }
                    else if (columnDataType.Equals(typeof(bool)))
                    {
                        KeyValuePair<double, Tuple<bool, Hashtable, Hashtable, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Boolean>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;
                    }
                    else if (columnDataType.Equals(typeof(string)))
                    {
                        KeyValuePair<double, Tuple<string, Hashtable, Hashtable, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<String>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;
                    }
                    else
                    {
                        throw new Exception("Unsupported data type");
                    }

                    columnsGiniImpurity[giniIndexValue] = new Tuple<string, object, Hashtable, Hashtable,double,double>(columnName, condition, truePartition, falsePartition,giniImpurityTrue,giniImpurityFalse);

                    Console.WriteLine(giniIndexValue);

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
        public KeyValuePair<double, Tuple<T, Hashtable, Hashtable, double, double>> ColumnOverallGiniImpurity<T>(string columnName, DataTable nodePartition) where T : IComparable<T>
        {
            int totalRows = nodePartition.Rows.Count;

            //Stores each possible category or numeric value with inner hash table for price range counting of comlying and not complying data
            Hashtable outerHashtable = ObtainPossibleConditions<T>(nodePartition, totalRows, columnName);
            Console.WriteLine("Pass obtain possible conditions");

            //Counting
            outerHashtable = CountPriceRangesForPossibleCondition<T>(outerHashtable, nodePartition, columnName, totalRows);
            Console.WriteLine("Pass count price ranges for possible condition");

            //Possible gini ipurities calculation
            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, Tuple<T,double,double>> columnValuesGiniImpurities = CalculatePossibleOverallGiniImpurities<T>(outerHashtable, totalRows);
            Console.WriteLine("Pass claculate overall gini impurity");

            KeyValuePair<double, Tuple<T,double,double>> minGiniImpurityAndCondition = columnValuesGiniImpurities.First();

            Pair innerHashTables = (Pair)outerHashtable[minGiniImpurityAndCondition.Value.Item1];

            Hashtable trueInnerHashtable = (Hashtable)innerHashTables.Element1;
            Hashtable falseInnerHashtable = (Hashtable)innerHashTables.Element2;
            T condition = minGiniImpurityAndCondition.Value.Item1;
            double giniImpurityTrue = minGiniImpurityAndCondition.Value.Item2;
            double giniImpurityFalse = minGiniImpurityAndCondition.Value.Item3;
            double overallGiniIMpurity = minGiniImpurityAndCondition.Key;

            //Return the gini impurity with a pair that contains the condition and the count of each price range in the partitions
            return new KeyValuePair<double, Tuple<T, Hashtable, Hashtable, double, double>>(overallGiniIMpurity, new Tuple<T, Hashtable, Hashtable,double,double>(condition, trueInnerHashtable, falseInnerHashtable,giniImpurityTrue,giniImpurityFalse));
        }

        public Hashtable ObtainPossibleConditions<T>(DataTable nodePartition, int totalRows, string columnName) where T : IComparable<T>
        {
            Hashtable outerHashtable = new Hashtable();

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = nodePartition.Rows[i];

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

        public Hashtable CountPriceRangesForPossibleCondition<T>(Hashtable outerHashtable, DataTable nodePartition, String columnName, int totalRows) where T : IComparable<T>
        {
            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = nodePartition.Rows[i];

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
        public SortedDictionary<double, Tuple<T, double, double>> CalculatePossibleOverallGiniImpurities<T>(Hashtable outerHashtable, int totalRows) where T : IComparable<T>
        {

            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, Tuple<T,double,double>> columnValuesGiniImpurities = new SortedDictionary<double, Tuple<T,double,double>>();
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

                sumProportionSquaredTrue = trueCount > 0 ?(sumProportionSquaredTrue)*(totalRows/trueCount)* (totalRows / trueCount) : 0;

                foreach (DictionaryEntry priceRange in innerHashtableFalse)
                {
                    int count = (int)priceRange.Value;

                    sumProportionSquaredFalse += CalculateProportionSquared(count, totalRows);
                }

                sumProportionSquaredFalse = totalRows - trueCount > 0? (sumProportionSquaredFalse) * (totalRows / (totalRows - trueCount))* (totalRows / (totalRows - trueCount)) : 0;

                double giniImpurityTrue = 1 - sumProportionSquaredTrue;
                double giniImpurityFalse = 1 - sumProportionSquaredFalse;

                double overallTrueProportion = (double)trueCount / (double)totalRows;

                double giniImpurityOverall = giniImpurityTrue * (overallTrueProportion) + giniImpurityFalse * (1 - overallTrueProportion);

                //Item.key is the condition, the column value (assume equals in categorical and <= in numerical)
                columnValuesGiniImpurities[giniImpurityOverall] = new Tuple<T, double, double>((T)item.Key,giniImpurityTrue,giniImpurityFalse);
            }
            return columnValuesGiniImpurities;
        }

    }
}

