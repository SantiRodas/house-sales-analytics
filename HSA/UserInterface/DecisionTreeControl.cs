using HSA.Tree;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace HSA.UserInterface
{
    public partial class DecisionTreeControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Relation with the class decision tree

        public DecisionTree DecisionTree {get; set;}

        // ----------------------------------------------------------------------------------------------------

        // 
        public LibraryDecisionTree LibraryDecisionTree { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // 
        public PredictControl PredictControl { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method

        public DecisionTreeControl()
        {
            InitializeComponent();           
        }

        // ----------------------------------------------------------------------------------------------------

        // Initialize method

        public void Initialize(DecisionTree dsTree, LibraryDecisionTree libDsTree, PredictControl pControl)
        {
            DecisionTree = dsTree;

            LibraryDecisionTree = libDsTree;

            PredictControl = pControl;

            trainingSizeSelector.SelectedIndex = 8;

            implementationOption1.Select();
        }


        // ----------------------------------------------------------------------------------------------------

        // Method to load the tree

        private void LoadTree(Node root)
        {
            if (root != null)
            {
                TreeNode dad = new TreeNode(root.ConditionAttributeName.ToString() + " " + root.ConditionOperator.ToString() + " " + root.ConditionValue.ToString());
                
                decisionTreeView.Nodes.Add(dad);

                AddChildrenToTree(root, dad);
            }
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

                    Stopwatch sw = new Stopwatch();

                    sw.Start();                    

                    DecisionTree.GenerateTree(heightLimit, trainingP, testP);

                    sw.Stop();

                    Console.WriteLine("Training time(own): " + sw.ElapsedMilliseconds + " ms");

                    accuracyLabelTraining.Text = "Accuracy: " + Math.Round(DecisionTree.AccuracyTraining*100, 2) + "%";

                    resetTreeButton.Enabled = true;

                    trainButton.Enabled = false;

                    LoadTree(DecisionTree.Root);

                    testingButton.Enabled = true;

                    PredictControl.OwnImplementation = true;

                }
                catch(FormatException)
                {
                    MessageBox.Show("Be sure the number input is correct!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else if (implementationOption2.Checked)
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();
                LibraryDecisionTree.BuildMultiClassificationTree();

                sw.Stop();

                Console.WriteLine("Training time(library): " + sw.ElapsedMilliseconds + " ms");

                double accuracyTraining = LibraryDecisionTree.ClassificationTrainingMetrics.MicroAccuracy;

                double accuracyTesting = LibraryDecisionTree.ClassificationTestMetrics.MicroAccuracy;
                
                accuracyLabelTraining.Text = $"Accuracy: {Math.Round(accuracyTraining*100,2)}%";
                accuracyLabelTest.Text = $"Accuracy: {Math.Round(accuracyTesting * 100, 2)}%";

                PredictControl.OwnImplementation = false;
            }
            else
            {
                MessageBox.Show("Please select one option");
            }

        }

        // ----------------------------------------------------------------------------------------------------

        // Method to do the click in the label 2

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // ----------------------------------------------------------------------------------------------------

        // Method to testing the decision tree

        private void testingButton_Click(object sender, EventArgs e)
        {
            double accuracyTest = DecisionTree.Test();

            accuracyLabelTest.Text = "Accuracy: " + Math.Round(accuracyTest*100,2) + "%";
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to training se size selector

        private void trainingSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            testSizeSelector.SelectedIndex = 9 - trainingSizeSelector.SelectedIndex;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to select the test size

        private void testSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            trainingSizeSelector.SelectedIndex = 9 - testSizeSelector.SelectedIndex;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to reset the tree

        private void resetTreeButton_Click(object sender, EventArgs e)
        {
            DecisionTree.Reset();

            resetTreeButton.Enabled = false;

            trainButton.Enabled = true;

            testingButton.Enabled = false;

            Clear();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to clear the information

        private void Clear()
        {
            implementationOption1.Select();

            heigthLimitTxtBox.Text = "";

            accuracyLabelTraining.Text = "Accuracy: -%";

            accuracyLabelTest.Text = "Accuracy: -%";

            decisionTreeView.Nodes.Clear();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to take the option 1

        private void implementationOption1_CheckedChanged(object sender, EventArgs e)
        {
            heigthLimitTxtBox.Enabled = true;

            trainingSizeSelector.Enabled = true;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to take the option 2

        private void implementationOption2_CheckedChanged(object sender, EventArgs e)
        {
            heigthLimitTxtBox.Enabled = false;

            trainingSizeSelector.Enabled = false;
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
