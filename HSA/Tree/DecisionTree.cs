using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using HSA.Utilities;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace HSA.Tree
{
    public class DecisionTree
    {       
        public double AccuracyTraining { get; set; }

        public double AccuracyTesting { get; set; }

        public int HeightLimit { get; set; }

        public double OverallGiniIndex { get; set; }

        public Dictionary<object,int> TargetVariableCountTraining { get; private set; }     
        
        public DataTable DataTraining { get; set; }

        public DataTable DataTest { get; set; }

        public DataTable DataOriginal { get; set; }

        public Node Root { get; set; }

        public string TargetVariableName { get; set; }

        private int trainingWrongClassifications = 0;

        // ----------------------------------------------------------------------------------------------------

        // Constructor

        public DecisionTree(DataTable data, string targetVariableName)
        {
            DataOriginal = data;

            TargetVariableName = targetVariableName;
        }
                
        // ----------------------------------------------------------------------------------------------------

        //Overall gini index calculation

        //Calculate the gini index/impurity of the whole dataset (in price  ranges)

        public void CalculateOverallGiniImpurity()
        {
            TargetVariableCountTraining = new Dictionary<object,int>();

            foreach (DataRow register in DataTraining.Rows)
            {
                string targetValue = register[TargetVariableName].ToString();

                if (TargetVariableCountTraining.ContainsKey(targetValue))
                {
                    int count = TargetVariableCountTraining[targetValue];

                    count++;

                    TargetVariableCountTraining[targetValue] = count;
                }
                else
                {
                    TargetVariableCountTraining.Add(targetValue, 1);
                }
            }

            int totalRows = DataTraining.Rows.Count; //Total number of rows in the data set

            double sumProportionSquared = 0;

            foreach (KeyValuePair<object,int> item in TargetVariableCountTraining)
            {
                int count = TargetVariableCountTraining[item.Key];

                sumProportionSquared += CalculateProportionSquared(count, totalRows);
            }

            OverallGiniIndex = 1 - sumProportionSquared;

        }

        // ----------------------------------------------------------------------------------------------------

        // Method test

        public double Test()
        {
            double hits = 0;

            double total = DataTest.Rows.Count;

            foreach (DataRow register in DataTest.Rows)
            {
                object predicted = Predict(register).Split(';')[0];

                object actual = register[TargetVariableName];

                if (predicted.Equals(actual))
                {
                    hits++;
                }
            }

            AccuracyTesting = hits / total;

            return AccuracyTesting;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method predict

        public string Predict(DataRow newDataPoint)
        {
            string treeTraversal = "";

            if (Root == null)
            {
                throw new Exception("No tree has been generated");
            }

            Node parent;

            Node currentNode = Root;

            while (!currentNode.IsLeaf)
            {
                string attributeName = currentNode.ConditionAttributeName;

                object dataPointAttributeValue = newDataPoint[attributeName];

                parent = currentNode;

                if (dataPointAttributeValue.GetType().Equals(typeof(int)))
                {                    
                    currentNode = currentNode.EvaluateCondition<int>((int)dataPointAttributeValue);
                }
                else if (dataPointAttributeValue.GetType().Equals(typeof(double)))
                {
                    currentNode = currentNode.EvaluateCondition<double>((double)dataPointAttributeValue);
                }
                else if (dataPointAttributeValue.GetType().Equals(typeof(bool)))
                {
                    currentNode = currentNode.EvaluateCondition<bool>((bool)dataPointAttributeValue);
                }
                else if (dataPointAttributeValue.GetType().Equals(typeof(string)))
                {
                    currentNode = currentNode.EvaluateCondition<string>((string)dataPointAttributeValue);
                }
                else
                {
                    throw new Exception("Unsupported data type");
                }

                if(currentNode == parent.TrueNode)
                {
                    treeTraversal += "True: " + parent.ConditionAttributeName + " " + parent.ConditionOperator + " " + parent.ConditionValue + "\n";
                }
                else
                {
                    treeTraversal += "False: " + parent.ConditionAttributeName + " " + parent.ConditionOperator + " " + parent.ConditionValue + "\n";
                }

            }

            treeTraversal += currentNode.Answer; 

            return currentNode.Answer + ";" + treeTraversal;
        }

        // ----------------------------------------------------------------------------------------------------

        // Mehot to do the split data set train and test

        private void SplitDataSetTrainAndTest(double trainingP, double testP)
        {
            int trainingIndex = (int)((double)trainingP * (double)DataOriginal.Rows.Count);

            int testIndex = DataOriginal.Rows.Count - (int)((double)testP * (double)DataOriginal.Rows.Count) - 1;

            DataView auxDataView = new DataView(DataOriginal);

            auxDataView.RowFilter = $"pos <= {trainingIndex}";

            DataTraining = auxDataView.ToTable();

            auxDataView.RowFilter = $"pos > {testIndex}";

            DataTest = auxDataView.ToTable();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to generate the tree

        public Node GenerateTree(int heightLimit, double trainingP, double testP)
        {
            trainingWrongClassifications = 0;

            HeightLimit = heightLimit;

            SplitDataSetTrainAndTest(trainingP, testP);

            CalculateOverallGiniImpurity();

            Root = new Node
            {
                GiniIndex = OverallGiniIndex,

                ObservationClassCount = TargetVariableCountTraining,

                Partition = DataTraining
            };
            
            GenerateTreeRecursive(Root, 1);

            AccuracyTraining = 1 - (double)trainingWrongClassifications / (double)DataTraining.Rows.Count;

            return Root;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to reset

        public void Reset()
        {
            DataTraining = null;

            DataTest = null;

            TargetVariableCountTraining = null;

            AccuracyTesting = 0;

            AccuracyTraining = 0;

            OverallGiniIndex = 0;

            Root = null;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to process leaf node

        private void ProcessLeafNode(Node currentNode)
        {
            currentNode.IsLeaf = true;

            Dictionary<object, int> currentNodeTargetVariableCount = currentNode.ObservationClassCount;

            int maxCount = -1;

            int count = 0;

            string maxTargetValue = "";

            foreach (KeyValuePair<object, int> priceRangeCount in currentNodeTargetVariableCount)
            {
                count += priceRangeCount.Value;

                if (priceRangeCount.Value > maxCount)
                {
                    maxCount = priceRangeCount.Value;

                    maxTargetValue = (string)priceRangeCount.Key;
                }

            }

            trainingWrongClassifications += count - maxCount;

            currentNode.Answer = maxTargetValue;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to generate tree recursive

        private void GenerateTreeRecursive(Node currentNode, int currentHeight)
        {
            if(currentNode.Partition.Rows.Count <= 1 || currentHeight >= HeightLimit)
            {
                ProcessLeafNode(currentNode);

                return;
            }

            //<giniIndex, [columnName, condition]>

            KeyValuePair<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double,double>> bestColumnGiniAndCondition = SelectBestColumn(currentNode.Partition);

            double infoGain = currentNode.GiniIndex - bestColumnGiniAndCondition.Key;         

            string columnName = bestColumnGiniAndCondition.Value.Item1;

            object conditionObj = bestColumnGiniAndCondition.Value.Item2;

            Dictionary<object, int> trueHashtable = bestColumnGiniAndCondition.Value.Item3;

            Dictionary<object, int> falseHashtable = bestColumnGiniAndCondition.Value.Item4;

            if (trueHashtable.Count > 0 && falseHashtable.Count > 0)//Nodo de decision
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

                    partitionFalse.RowFilter = $"{columnName} <> '{condition}'";

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

                GenerateTreeRecursive(nodeTrue, currentHeight+1);

                GenerateTreeRecursive(nodeFalse,currentHeight+1);

            }
            else//Es una hoja
            {
                ProcessLeafNode(currentNode);
            }

        }

        // ----------------------------------------------------------------------------------------------------

        // Method to select the best column

        public KeyValuePair<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double,double>> SelectBestColumn(DataTable nodePartition)
        {
            SortedDictionary<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double, double>> columnsGiniImpurity  = CalculateGiniIndexForAllColumns(nodePartition);

            return columnsGiniImpurity.First();
        }

        // ----------------------------------------------------------------------------------------------------

        // Calculate all gini indexes

        private SortedDictionary<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double, double>> CalculateGiniIndexForAllColumns(DataTable nodePartition)
        {
            SortedDictionary<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double,double>> columnsGiniImpurity = new SortedDictionary<double, Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double,double>>();

            for (int i = 0; i < nodePartition.Columns.Count; i++)
            {
                DataColumn column = nodePartition.Columns[i];

                String columnName = column.ColumnName;

                Type columnDataType = column.DataType;

                if (!columnName.Equals("id") && !columnName.Equals("pos") && !columnName.Equals("date")

                    && !columnName.Equals("lat") && !columnName.Equals("long")

                    && !columnName.Equals("price") && !columnName.Equals("price_range"))
                
                {
                    double giniIndexValue;

                    object condition;

                    Dictionary<object, int> truePartition;

                    Dictionary<object, int> falsePartition;

                    double giniImpurityTrue;

                    double giniImpurityFalse;

                    if (columnDataType.Equals(typeof(double)))
                    {
                        KeyValuePair<double, Tuple<double, Dictionary<object, int>, Dictionary<object, int>, double,double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Double>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        
                        condition = giniIndexAndCondition.Value.Item1;
                        
                        truePartition = giniIndexAndCondition.Value.Item2;
                        
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;

                    }
                    else if (columnDataType.Equals(typeof(int)))
                    {
                        KeyValuePair<double, Tuple<int, Dictionary<object, int>, Dictionary<object, int>, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Int32>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        
                        condition = giniIndexAndCondition.Value.Item1;
                        
                        truePartition = giniIndexAndCondition.Value.Item2;
                        
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;

                    }
                    else if (columnDataType.Equals(typeof(bool)))
                    {
                        KeyValuePair<double, Tuple<bool, Dictionary<object, int>, Dictionary<object, int>, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<Boolean>(columnName, nodePartition);

                        giniIndexValue = giniIndexAndCondition.Key;
                        
                        condition = giniIndexAndCondition.Value.Item1;
                        
                        truePartition = giniIndexAndCondition.Value.Item2;
                        
                        falsePartition = giniIndexAndCondition.Value.Item3;
                        
                        giniImpurityTrue = giniIndexAndCondition.Value.Item4;
                        
                        giniImpurityFalse = giniIndexAndCondition.Value.Item5;
                    }
                    else if (columnDataType.Equals(typeof(string)))
                    {
                        KeyValuePair<double, Tuple<string, Dictionary<object, int>, Dictionary<object, int>, double, double>> giniIndexAndCondition = ColumnOverallGiniImpurity<String>(columnName, nodePartition);

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

                    columnsGiniImpurity[giniIndexValue] = new Tuple<string, object, Dictionary<object, int>, Dictionary<object, int>, double,double>(columnName, condition, truePartition, falsePartition,giniImpurityTrue,giniImpurityFalse);

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

        public KeyValuePair<double, Tuple<T, Dictionary<object, int>, Dictionary<object, int>, double, double>> ColumnOverallGiniImpurity<T>(string columnName, DataTable nodePartition) where T : IComparable<T>
        {
            int totalRows = nodePartition.Rows.Count;

            //Stores each possible category or numeric value with inner hash table for price range counting of comlying and not complying data
            
            Hashtable outerHashtable = ObtainPossibleConditions<T>(nodePartition, totalRows, columnName);
            
            //Counting
            
            outerHashtable = CountPriceRangesForPossibleCondition<T>(outerHashtable, nodePartition, columnName, totalRows);
            
            //Possible gini ipurities calculation
            
            //<gini impurity, columnValue (condition)>
            
            SortedDictionary<double, Tuple<T,double,double>> columnValuesGiniImpurities = CalculatePossibleOverallGiniImpurities<T>(outerHashtable, totalRows);
            
            KeyValuePair<double, Tuple<T,double,double>> minGiniImpurityAndCondition = columnValuesGiniImpurities.First();

            Pair innerHashTables = (Pair)outerHashtable[minGiniImpurityAndCondition.Value.Item1];

            Dictionary<object, int> trueInnerHashtable = (Dictionary<object, int>)innerHashTables.Element1;
            
            Dictionary<object, int> falseInnerHashtable = (Dictionary<object, int>)innerHashTables.Element2;
            
            T condition = minGiniImpurityAndCondition.Value.Item1;
            
            double giniImpurityTrue = minGiniImpurityAndCondition.Value.Item2;
            
            double giniImpurityFalse = minGiniImpurityAndCondition.Value.Item3;
            
            double overallGiniIMpurity = minGiniImpurityAndCondition.Key;

            //Return the gini impurity with a pair that contains the condition and the count of each price range in the partitions
            
            return new KeyValuePair<double, Tuple<T, Dictionary<object, int>, Dictionary<object, int>, double, double>>(overallGiniIMpurity, new Tuple<T, Dictionary<object, int>, Dictionary<object, int>, double,double>(condition, trueInnerHashtable, falseInnerHashtable,giniImpurityTrue,giniImpurityFalse));
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to obtain possible conditions

        public Hashtable ObtainPossibleConditions<T>(DataTable nodePartition, int totalRows, string columnName) where T : IComparable<T>
        {
            Hashtable outerHashtable = new Hashtable();

            for (int i = 0; i < totalRows; i++)
            {
                DataRow item = nodePartition.Rows[i];

                T columnValue = (T)item[columnName];

                if (!outerHashtable.ContainsKey(columnValue))
                {
                    Dictionary<object, int> partitionTrueInnerHashtable = new Dictionary<object, int>();
                    
                    Dictionary<object, int> partitionFalseInnerHashtable = new Dictionary<object, int>();

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

                    Dictionary<object, int> partitionInnerHashtable;

                    if ((typeof(T).Equals(typeof(string)) && columnValue.Equals((T)possibleCondition.Key))
                    || (!typeof(T).Equals(typeof(string)) && columnValue.CompareTo((T)possibleCondition.Key) <= 0))//Conditions
                    {
                        partitionInnerHashtable = (Dictionary<object, int>)partitionsInnerHashtables.Element1; //True inner hash table
                    }
                    else
                    {
                        partitionInnerHashtable = (Dictionary<object, int>)partitionsInnerHashtables.Element2;//False inner hash table
                    }

                    if (partitionInnerHashtable.ContainsKey(itemPriceRange))
                    {
                        int count = partitionInnerHashtable[itemPriceRange];

                        count++;

                        partitionInnerHashtable[itemPriceRange] = count;
                    }
                    else
                    {
                        partitionInnerHashtable.Add(itemPriceRange, 1);
                    }

                }

            }

            return outerHashtable;
        }

        // ----------------------------------------------------------------------------------------------------

        //Return a SortedDictionary with overall gini impurities for each possible column value or possible condition,

        //From a hashtable with the values as keys and to inner hash tables for priceRange counting in both true and false partitions
        
        public SortedDictionary<double, Tuple<T, double, double>> CalculatePossibleOverallGiniImpurities<T>(Hashtable outerHashtable, int totalRows) where T : IComparable<T>
        {
            //<gini impurity, columnValue (condition)>

            SortedDictionary<double, Tuple<T,double,double>> columnValuesGiniImpurities = new SortedDictionary<double, Tuple<T,double,double>>();
            
            foreach (DictionaryEntry item in outerHashtable)
            {
                Pair partitionsInnerHashtables = (Pair)item.Value;

                Dictionary<object,int> innerHashtableTrue = (Dictionary<object, int>)partitionsInnerHashtables.Element1;

                Dictionary<object, int> innerHashtableFalse = (Dictionary<object, int>)partitionsInnerHashtables.Element2;

                double sumProportionSquaredTrue = 0;
                
                double sumProportionSquaredFalse = 0;

                int trueCount = 0;

                foreach (KeyValuePair<object,int> priceRange in innerHashtableTrue)
                {
                    int count = priceRange.Value;

                    trueCount += count;

                    sumProportionSquaredTrue += CalculateProportionSquared(count, totalRows);
                }

                sumProportionSquaredTrue = trueCount > 0 ?(sumProportionSquaredTrue)*(totalRows/trueCount)* (totalRows / trueCount) : 0;

                foreach (KeyValuePair<object, int> priceRange in innerHashtableFalse)
                {
                    int count = priceRange.Value;

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

        // ----------------------------------------------------------------------------------------------------

    }
}

