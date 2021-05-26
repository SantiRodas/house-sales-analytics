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
            trainingSizeSelector.SelectedIndex = 8;
            implementationOption1.Select();
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
                    printValueFalse = root.FalseNode.ConditionAttributeName + " " + root.FalseNode.ConditionOperator.ToString() + " " + root.FalseNode.ConditionValue.ToString() + " " + root.FalseNode.Partition.Rows.Count;
                }
                else
                {
                    printValueFalse = root.FalseNode.Answer;
                }

                if (root.TrueNode.ConditionAttributeName != null)
                {
                    printValueTrue = root.TrueNode.ConditionAttributeName + " " + root.TrueNode.ConditionOperator.ToString() + " " + root.TrueNode.ConditionValue.ToString() +  " " + root.TrueNode.Partition.Rows.Count;
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
                try
                {
                   

                    int heightLimit = int.Parse(heigthLimitTxtBox.Text);

                    if (heightLimit <= 1) { throw new FormatException("Invalid height"); }

                    double trainingP = double.Parse((string)trainingSizeSelector.SelectedItem);

                    double testP = double.Parse((string)testSizeSelector.SelectedItem);

                    DecisionTree.generateTree(heightLimit, trainingP, testP);

                    Console.WriteLine("Finish generating");

                    accuracyLabelTraining.Text = "Accuracy: " + Math.Round(DecisionTree.Accuracy*100, 2) + "%";

                    resetTreeButton.Enabled = true;

                    trainButton.Enabled = false;

                    LoadTree(DecisionTree.Root);

                    testingButton.Enabled = true;
                }
                catch(FormatException)
                {
                    MessageBox.Show("Be sure the number input is correct!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                

            } else if (implementationOption2.Checked)
            {
             

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
            double accuracyTest = DecisionTree.Test();

            accuracyLabelTest.Text = "Accuracy: " + Math.Round(accuracyTest*100,2) + "%";
        }

        private void trainingSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {



            testSizeSelector.SelectedIndex = 9 - trainingSizeSelector.SelectedIndex;



        }

        private void testSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            trainingSizeSelector.SelectedIndex = 9 - testSizeSelector.SelectedIndex;
        }

        private void resetTreeButton_Click(object sender, EventArgs e)
        {
            DecisionTree.Reset();
            resetTreeButton.Enabled = false;
            trainButton.Enabled = true;
            testingButton.Enabled = false;
            Clear();
        }


        private void Clear()
        {
            implementationOption1.Select();

            heigthLimitTxtBox.Text = "";

            accuracyLabelTraining.Text = "Accuracy: -%";

            accuracyLabelTest.Text = "Accuracy: -%";

            decisionTreeView.Nodes.Clear();
        }

        private void implementationOption1_CheckedChanged(object sender, EventArgs e)
        {
            heigthLimitTxtBox.Enabled = true;
        }

        private void implementationOption2_CheckedChanged(object sender, EventArgs e)
        {
            heigthLimitTxtBox.Enabled = false;
        }


        // ----------------------------------------------------------------------------------------------------

    }
}
