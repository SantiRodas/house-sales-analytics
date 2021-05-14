using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSA.Tree
{
    class Node
    {

        // ----------------------------------------------------------------------------------------------------

        // Information of the name

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the edge

        private String edge;

        public String Edge
        {
            get { return edge; }
            set { edge = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the attribute

        private Attribute nodeAttribute;

        public Attribute Attribute
        {
            get { return nodeAttribute; }
            set { nodeAttribute = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the child nodes

        private List<Node> childNodes;

        public List<Node> ChildNodes
        {
            get { return childNodes; }
            set { childNodes = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the table index

        private int tableIndex;

        public int TableIndex
        {
            get { return tableIndex; }
            set { tableIndex = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the leaf

        private bool isLeaf;

        public bool IsLeaf
        {
            get { return isLeaf; }
            set { isLeaf = value; }
        }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method

        public Node(string name, string edge, Attribute nodeAttribute, int tableIndex, bool isLeaf)
        {
            Name = name;
            Edge = edge;
            Attribute = nodeAttribute;
            ChildNodes = new List<Node>();
            TableIndex = tableIndex;
            IsLeaf = isLeaf;
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
