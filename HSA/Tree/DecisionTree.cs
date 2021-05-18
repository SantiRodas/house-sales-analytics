using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HSA.Model;
using HSA.Utilities;

namespace HSA.Tree
{
    public class DecisionTree
    {
        public double OverallGiniIndex { get; set; }

        public Hashtable PriceRangesCountGlobal { get; private set; }     
        
        public DataTable Data { get; set; }

        public DataView DataFiltered { get; set; }

        private double giniImpurityTrue;

        private double giniImpurityFalse;

        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataSetManager dataSetManager)
        {
            Data = dataSetManager.Data;
            DataFiltered = new DataView(Data);

            CalculateOverallGiniIndex();

            root = new Node
            {
                GiniIndex = OverallGiniIndex,
                ObservationClassCount = PriceRangesCountGlobal,
                Partition = DataFiltered
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
            Console.WriteLine(currentNode.Partition.Count);
            //<giniIndex, [columnName, condition]>
            KeyValuePair<double, Tuple<string, object, Hashtable, Hashtable>> bestColumnGiniAndCondition = SelectBestColumn(currentNode.Partition);

            double infoGain = currentNode.GiniIndex - bestColumnGiniAndCondition.Key;

            string columnName = bestColumnGiniAndCondition.Value.Item1;
            object conditionObj = bestColumnGiniAndCondition.Value.Item2;
            Hashtable trueHashtable = bestColumnGiniAndCondition.Value.Item3;
            Hashtable falseHashtable = bestColumnGiniAndCondition.Value.Item4;

            if (infoGain > 0.05)//Nodo de decision
            {
                Type columnDataType = conditionObj.GetType();

                DataView partitionTrue = new DataView(Data);
                DataView partitionFalse = new DataView(Data);

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

                    partitionTrue.RowFilter = $"{columnName} = {condition}";
                    partitionFalse.RowFilter = $"{columnName} != {condition}";

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

                nodeTrue.Partition = partitionTrue;
                nodeTrue.GiniIndex = giniImpurityTrue;
                nodeTrue.ObservationClassCount = trueHashtable;
                nodeFalse.Partition = partitionFalse;
                nodeFalse.GiniIndex = giniImpurityFalse;
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

        public KeyValuePair<double, Tuple<string, object, Hashtable, Hashtable>> SelectBestColumn(DataView nodePartition)
        {

            SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable>> columnsGiniImpurity = CalculateGiniIndexForAllColumns(nodePartition);

            return columnsGiniImpurity.First();
        }

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes


        private SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable>> CalculateGiniIndexForAllColumns(DataView nodePartition)
        {

            SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable>> columnsGiniImpurity = new SortedDictionary<double, Tuple<string, object, Hashtable, Hashtable>>();

            for (int i = 0; i < nodePartition.Table.Columns.Count; i++)
            {
                Console.WriteLine("Column processed = " + i);
                DataColumn column = nodePartition.Table.Columns[i];
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

                    if (columnDataType.Equals(typeof(double)))
                    {
                        Console.WriteLine("Double column");

                        KeyValuePair<double, Tuple<double, Hashtable, Hashtable>> giniIndexAndCondition = ColumnOverallGiniImpurity<Double>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;

                    }
                    else if (columnDataType.Equals(typeof(int)))
                    {
                        KeyValuePair<double, Tuple<int, Hashtable, Hashtable>> giniIndexAndCondition = ColumnOverallGiniImpurity<Int32>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;

                    }
                    else if (columnDataType.Equals(typeof(bool)))
                    {
                        KeyValuePair<double, Tuple<bool, Hashtable, Hashtable>> giniIndexAndCondition = ColumnOverallGiniImpurity<Boolean>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                    }
                    else if (columnDataType.Equals(typeof(string)))
                    {
                        KeyValuePair<double, Tuple<string, Hashtable, Hashtable>> giniIndexAndCondition = ColumnOverallGiniImpurity<String>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        condition = giniIndexAndCondition.Value.Item1;
                        truePartition = giniIndexAndCondition.Value.Item2;
                        falsePartition = giniIndexAndCondition.Value.Item3;
                    }
                    else
                    {
                        throw new Exception("Unsupported data type");
                    }

                    columnsGiniImpurity[giniIndexValue] = new Tuple<string, object, Hashtable, Hashtable>(columnName, condition, truePartition, falsePartition);

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
        public KeyValuePair<double, Tuple<T, Hashtable, Hashtable>> ColumnOverallGiniImpurity<T>(string columnName, DataView nodePartition) where T : IComparable<T>
        {
            int totalRows = nodePartition.Count;

            //Stores each possible category or numeric value with inner hash table for price range counting of comlying and not complying data
            Hashtable outerHashtable = ObtainPossibleConditions<T>(nodePartition, totalRows, columnName);
            Console.WriteLine("Pass obtain possible conditions");

            //Counting
            outerHashtable = CountPriceRangesForPossibleCondition<T>(outerHashtable, nodePartition, columnName, totalRows);
            Console.WriteLine("Pass count price ranges for possible condition");

            //Possible gini ipurities calculation
            //<gini impurity, columnValue (condition)>
            SortedDictionary<double, T> columnValuesGiniImpurities = CalculatePossibleOverallGiniImpurities<T>(outerHashtable, totalRows);
            Console.WriteLine("Pass claculate overall gini impurity");

            KeyValuePair<double, T> minGiniImpurityAndCondition = columnValuesGiniImpurities.First();

            Pair innerHashTables = (Pair)outerHashtable[minGiniImpurityAndCondition.Value];

            Hashtable trueInnerHashtable = (Hashtable)innerHashTables.Element1;
            Hashtable falseInnerHashtable = (Hashtable)innerHashTables.Element2;
            T condition = minGiniImpurityAndCondition.Value;
            double overallGiniIMpurity = minGiniImpurityAndCondition.Key;

            //Return the gini impurity with a pair that contains the condition and the count of each price range in the partitions
            return new KeyValuePair<double, Tuple<T, Hashtable, Hashtable>>(overallGiniIMpurity, new Tuple<T, Hashtable, Hashtable>(condition, trueInnerHashtable, falseInnerHashtable));
        }

        public Hashtable ObtainPossibleConditions<T>(DataView nodePartition, int totalRows, string columnName) where T : IComparable<T>
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

        public Hashtable CountPriceRangesForPossibleCondition<T>(Hashtable outerHashtable, DataView nodePartition, String columnName, int totalRows) where T : IComparable<T>
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
        public SortedDictionary<double, T> CalculatePossibleOverallGiniImpurities<T>(Hashtable outerHashtable, int totalRows) where T : IComparable<T>
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

                sumProportionSquaredTrue = trueCount > 0 ?(sumProportionSquaredTrue)*(totalRows/trueCount)* (totalRows / trueCount) : 0;

                foreach (DictionaryEntry priceRange in innerHashtableFalse)
                {
                    int count = (int)priceRange.Value;

                    sumProportionSquaredFalse += CalculateProportionSquared(count, totalRows);
                }

                sumProportionSquaredFalse = totalRows - trueCount > 0? (sumProportionSquaredFalse) * (totalRows / (totalRows - trueCount))* (totalRows / (totalRows - trueCount)) : 0;

                giniImpurityTrue = 1 - sumProportionSquaredTrue;
                giniImpurityFalse = 1 - sumProportionSquaredFalse;

                double overallTrueProportion = (double)trueCount / (double)totalRows;

                double giniImpurityOverall = giniImpurityTrue * (overallTrueProportion) + giniImpurityFalse * (1 - overallTrueProportion);

                //Item.key is the condition, the column value (assume equals in categorical and <= in numerical)
                columnValuesGiniImpurities[giniImpurityOverall] = (T)item.Key;
            }
            return columnValuesGiniImpurities;
        }

    }
}

