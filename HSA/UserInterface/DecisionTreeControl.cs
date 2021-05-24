using HSA.Tree;
using System;
using System.Windows.Forms;

namespace HSA.UserInterface
{
    public partial class DecisionTreeControl : UserControl
    {
        public DecisionTree DecisionTree {get; set;}
        
        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public DecisionTreeControl()
        {
            InitializeComponent();           
        }

        public void Initialize(DecisionTree dsTree)
        {
            DecisionTree = dsTree;
        }


        // ----------------------------------------------------------------------------------------------------

        // Adds the root node to the tree

        private void LoadTree(Node root)
        {
            TreeNode dad = new TreeNode(root.ConditionAttributeName.ToString() + " " + root.ConditionOperator.ToString() + " " + root.ConditionValue.ToString());
            decisionTreeView.Nodes.Add(dad);            
            AddChildrenToTree(root, dad);
            
        }


        // ----------------------------------------------------------------------------------------------------

        // Adds the children of a given node in recursive way
        private void AddChildrenToTree(Node root, TreeNode dad)
        {
           
            if (root.FalseNode != null && root.TrueNode != null)
            {
                decisionTreeView.SelectedNode = dad;

                string printValueFalse = "";
                string printValueTrue = "";

                if (root.FalseNode.ConditionAttributeName != null)
                {
                    printValueFalse = root.FalseNode.ConditionAttributeName + " " + root.FalseNode.ConditionOperator.ToString() + " " + root.FalseNode.ConditionValue.ToString();
                }
                else
                {
                    printValueFalse = root.FalseNode.Answer;
                }

                if (root.TrueNode.ConditionAttributeName != null)
                {
                    printValueTrue = root.TrueNode.ConditionAttributeName + " " + root.TrueNode.ConditionOperator.ToString() + " " + root.TrueNode.ConditionValue.ToString();
                }
                else
                {
                    printValueTrue = root.TrueNode.Answer;
                }

                
                
                
                TreeNode left = new TreeNode("False: " + printValueFalse);
                TreeNode right = new TreeNode("True: " + printValueTrue);

                Node trueNode = root.TrueNode;
                Node falseNode = root.FalseNode;

                if (root.IsLeaf || root.TrueNode.IsLeaf || root.FalseNode.IsLeaf)
                {
                    int i = 0;
                }

                dad.Nodes.Add(left);
                dad.Nodes.Add(right);

                AddChildrenToTree(root.FalseNode, left);
                AddChildrenToTree(root.TrueNode, right);
            }

            return;
           
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to implementate the tree (Button)

        private void selectImplementationButton_Click(object sender, EventArgs e)
        {
            if (implementationOption1.Checked)
            {
                DecisionTree.generateTree();
                Console.WriteLine("Finish generating");
                LoadTree(DecisionTree.Root);

            } else if (implementationOption2.Checked)
            {
                // The user select the library implementation

                MessageBox.Show("This option is not yet implemented, please wait for future versions");
            }
            else
            {
                MessageBox.Show("Please select one option");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void testingButton_Click(object sender, EventArgs e)
        {

        }





        // ----------------------------------------------------------------------------------------------------

    }
}
