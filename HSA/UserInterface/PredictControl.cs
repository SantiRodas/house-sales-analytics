using HSA.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSA.UserInterface
{
    public partial class PredictControl : UserControl
    {

        private DecisionTree dsTree;

        private bool ownImplementation;

        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public PredictControl()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to generate new tree (Button)

        public void Initialize(DecisionTree dsTree)
        {
            viewComboBox.SelectedIndex = 0;
            conditionComboBox.SelectedIndex = 0;
            gradeComboBox.SelectedIndex = 0;
            this.dsTree = dsTree;
        }


        // ----------------------------------------------------------------------------------------------------

        private void generateNewTreeButton_Click(object sender, EventArgs e)
        {
            // The system have to update the tree decision
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to predict the information (Button)

        private void predictButton_Click(object sender, EventArgs e)
        {
            try
            {
                // The system take the information of the house

                int bedrooms = int.Parse(bedroomsText.Text);
                if (bedrooms < 0) throw new FormatException("Bedrooms is less than 0");

                double bathrooms = double.Parse(bathroomsText.Text);
                if (bathrooms < 0) throw new FormatException("Bathrooms is less than 0");

                double sqftLiving = double.Parse(sqftLivingText.Text);
                if (sqftLiving <= 0) throw new FormatException("sqftLiving  is less or equal than 0");

                double sqftLot = double.Parse(sqftLotText.Text);
                if (sqftLot <= 0) throw new FormatException("sqftLot is less or equal than 0");

                double floors = double.Parse(floorText.Text);
                if (floors <= 0) throw new FormatException("floors is less or equal than 0");

                // The decision bool take the information of the waterfront

                bool waterfront = false;

                if (waterfrontTrue.Checked)
                {
                    waterfront = true;

                } else if (waterfrontTrue.Checked == false && waterfrontFalse.Checked == false)
                {
                    throw new Exception("No waterfront option was seleceted");
                }
               
                
                // The system take the information of the house

                int view = int.Parse((string)viewComboBox.SelectedItem);

                int condition = int.Parse((string)conditionComboBox.SelectedItem);

                int grade = int.Parse((string)gradeComboBox.SelectedItem);

                double sqftAbove = double.Parse(sqftAboveText.Text);
                if (sqftAbove <= 0) throw new FormatException("sqftAbove is less than 0");

                // The right part of the window

                double sqftBasement = double.Parse(sqftBasementText.Text);
                if (sqftBasement < 0) throw new FormatException("sqftBasement is less than 0");

                int yearBuilt = int.Parse(yearBuiltText.Text);

                int yearRenovated = int.Parse(yearRenovatedText.Text);

                int zipCode = int.Parse(zipCodeText.Text);
                if (zipCode <= 0) throw new FormatException("Zipcode is less or equal than 0");

                double sqftLiving15 = double.Parse(sqftLiving15Text.Text);
                if (sqftLiving15 <= 0) throw new FormatException("sqftLiving15 is less or equal than 0");

                double sqftLot15 = double.Parse(sqftLot15Text.Text);
                if (sqftLot15 <= 0) throw new FormatException("sqftLot15 is less or equal than 0");

                DataRow newDataPoint = dsTree.Data.NewRow();

                newDataPoint["bedrooms"] = bedrooms;
                newDataPoint["bathrooms"] = bathrooms;
                newDataPoint["sqft_living"] = sqftLiving;
                newDataPoint["sqft_lot"] = sqftLot;
                newDataPoint["floors"] = floors;
                newDataPoint["waterfront"] = waterfront;
                newDataPoint["view"] = view;
                newDataPoint["condition"] = condition;
                newDataPoint["grade"] = grade;
                newDataPoint["sqft_above"] = sqftAbove;
                newDataPoint["sqft_basement"] = sqftBasement;
                newDataPoint["yr_built"] = yearBuilt;
                newDataPoint["yr_renovated"] = yearRenovated;
                newDataPoint["zipcode"] = zipCode;
                newDataPoint["sqft_living15"] = sqftLiving15;
                newDataPoint["sqft_lot15"] = sqftLot15;

                // With this information the system can work

                String priceRange = predictOwnImplementation(newDataPoint);

                priceRangeLabel.Text = "Price Range: " + priceRange;

                ClearTextBoxes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error ocurred, please check that every fill is filled:\n" + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private string predictOwnImplementation(DataRow newDataPoint)
        {
            Node root = dsTree.Root;

            if(!root.IsLeaf && root.TrueNode == null)
            {
                throw new Exception("No tree has been generated");
            }

            Node currentNode = root;
                        
            while (!currentNode.IsLeaf)
            {

                string attributeName = currentNode.ConditionAttributeName;

                object dataPointAttributeValue = newDataPoint[attributeName];

                if (dataPointAttributeValue.GetType().Equals(typeof(int))){
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

            }

            return currentNode.Answer;
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }



        // ----------------------------------------------------------------------------------------------------

    }
}
