using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Tree
{

    //T represents the type of the attribute stored in this node

    public class Node
    {
        // ----------------------------------------------------------------------------------------------------

        // Attributes

        private string conditionAttributeName; //Column name from the dataset

        private LogicalOperator conditionOperator; //Operator that represent how to evaluate the condition

        private object conditionValue; // Value to be compared to a new value

        private Type attributeType; //Type of the attribute represented as a Type object

        private bool isLeaf;

        private Node trueNode; //Connected node for a true conditon evaluation result //Right

        private Node falseNode; //Connected node for a true conditon evaluation result //Left

        private string answer; // If node is leaf the answer or classifier predicted

        private double giniIndex; //Gini index of this node, is stored but not updated in node

        private DataTable partition;

        private Dictionary<object,int> observationClassCount;

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute name condition

        public string ConditionAttributeName
        {
            get { return conditionAttributeName; }

            set { conditionAttributeName = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute condition operator

        public LogicalOperator ConditionOperator
        {
            get { return conditionOperator; }

            set { conditionOperator = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute condition value

        public object ConditionValue
        {
            get { return conditionValue; }

            set { conditionValue = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute type

        public Type AttributeType
        {
            get { return attributeType; }

            set { attributeType = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute true node

        public Node TrueNode
        {
            get { return trueNode; }

            set { trueNode = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute false node

        public Node FalseNode
        {
            get { return falseNode; }

            set { falseNode = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute answer

        public string Answer
        {
            get { return answer; }

            set { answer = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute is leaf

        public bool IsLeaf
        {
            get { return isLeaf; }

            set { isLeaf = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute gini index

        public double GiniIndex
        {
            get { return giniIndex; }

            set { giniIndex = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute partition

        public DataTable Partition
        {
            get { return partition; }

            set { partition = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Get and set of the attribute observation class count

        public Dictionary<object,int> ObservationClassCount
        {
            get { return observationClassCount; }

            set { observationClassCount = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method 1

        public Node(string conditionAttributeName, LogicalOperator conditionOperator, object conditionValue, Type attributeType, bool isLeaf)
        {
            this.conditionAttributeName = conditionAttributeName;

            this.conditionOperator = conditionOperator;

            this.conditionValue = conditionValue;

            this.attributeType = attributeType;

            this.isLeaf = isLeaf;
        }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method 2

        public Node()
        {

        }

        // ----------------------------------------------------------------------------------------------------
        
        // Evaluate Condition method

        // Evaluates the condition stored in this node with a value of type T such as T is the type of the stored attribute
        
        public Node EvaluateCondition<T>(T value) where T : IComparable<T>
        {
            if (isLeaf)
            {
                throw new Exception("Node is leaf");
            }

            if (!typeof(T).Equals(attributeType))
            {
                throw new Exception("T type is not the same of the stored attribute");
            }

            switch (ConditionOperator)
            {
                case LogicalOperator.EQUALS:
                    return value.Equals(conditionValue) ? trueNode : falseNode;

                case LogicalOperator.LARGER_THAN:
                    return value.CompareTo((T)conditionValue) > 0 ? trueNode : falseNode;

                case LogicalOperator.LARGER_EQUALS_THAN:
                    return value.CompareTo((T)conditionValue) >= 0 ? trueNode : falseNode;

                case LogicalOperator.SMALLER_THAN:
                    return value.CompareTo((T)conditionValue) < 0 ? trueNode : falseNode;

                case LogicalOperator.SMALLER_EQUALS_THAN:
                    return value.CompareTo((T)conditionValue) <= 0 ? trueNode : falseNode;

                default:
                    return null;
            }
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
