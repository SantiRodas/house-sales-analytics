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
            sqftLiving15ComboBox.SelectedIndex = 0;
            sqftLivingComboBox.SelectedIndex = 0;
            sqftAboveComboBox.SelectedIndex = 0;
            sqftBsmteComboBox.SelectedIndex = 0;
            sqftLiving15ComboBox.SelectedIndex = 0;
            sqftLot15ComboBox.SelectedIndex = 0;
            sqftLotComboBox.SelectedIndex = 0;

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

                string sqftLiving = (string)sqftLivingComboBox.SelectedItem;

                string sqftLot = (string) sqftLotComboBox.SelectedItem;

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

                string view = (string)viewComboBox.SelectedItem;

                string condition = (string)conditionComboBox.SelectedItem;

                string grade = (string)gradeComboBox.SelectedItem;

                string sqftAbove = (string)sqftAboveComboBox.SelectedItem;

                // The right part of the window

                string sqftBasement = (string)sqftBsmteComboBox.SelectedItem;

                int yearBuilt = int.Parse(yearBuiltText.Text);

                int zipcodeInt = int.Parse(zipCodeText.Text);

                if (zipcodeInt <= 0) throw new FormatException("Zipcode is less or equal than 0");
                string zipcode = zipcodeInt.ToString();

                string sqftLiving15 = (string)sqftLiving15ComboBox.SelectedItem;

                string sqftLot15 = (string)sqftLot15ComboBox.SelectedItem;

                DataRow newDataPoint = dsTree.DataTraining.NewRow();

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
                newDataPoint["zipcode"] = zipcode;
                newDataPoint["sqft_living15"] = sqftLiving15;
                newDataPoint["sqft_lot15"] = sqftLot15;

                // With this information the system can work

                string[] prediction = dsTree.Predict(newDataPoint).Split(';');

                string priceRange = prediction[0];
                string treeTraversal = prediction[2];

                treeTraversalRichTxtBox.Text = treeTraversal;
                priceRangeLabel.Text = "Price Range: " + priceRange;

                ClearTextBoxes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error ocurred, please check that every fill is filled:\n" + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            Initialize(dsTree);
            treeTraversalRichTxtBox.Text = "";
        }



        // ----------------------------------------------------------------------------------------------------

    }
}
