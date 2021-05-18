using HSA.Tree;
using System;
using System.Windows.Forms;

namespace HSA.UserInterface
{
    public partial class DecisionTreeControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public DecisionTreeControl()
        {
            InitializeComponent();           
        }

        public void initializa(Node root)
        {
            LoadTree(root);
        }


        // ----------------------------------------------------------------------------------------------------

        // Adds the root node to the tree

        private void LoadTree(Node root)
        {
            TreeNode dad = new TreeNode(root.ConditionAttributeName);
            decisionTreeView.Nodes.Add(root.ConditionAttributeName.ToString());
            AddChildrenToTree(root, dad);
        }


        // ----------------------------------------------------------------------------------------------------

        // Adds the children of a given node in recursive way
        private void AddChildrenToTree(Node root, TreeNode dad)
        {
           
            if (root.FalseNode != null && root.TrueNode != null)
            {
                TreeNode left = new TreeNode(root.FalseNode.ConditionAttributeName);
                TreeNode right = new TreeNode(root.TrueNode.ConditionAttributeName);
                dad.Nodes.Add(root.FalseNode.ConditionAttributeName);
                dad.Nodes.Add((root.TrueNode.ConditionAttributeName));

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
                // The user select the own implementation

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

      



        // ----------------------------------------------------------------------------------------------------

    }
}
