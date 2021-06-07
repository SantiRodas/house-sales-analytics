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
using System.Diagnostics;

namespace HSA.UserInterface
{
    public partial class PredictControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Relation with the class decision tree, and attribute bool

        private DecisionTree dsTree;

        private LibraryDecisionTree libDsTree;

        public bool OwnImplementation { get; set; }

        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public PredictControl()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to initialize

        public void Initialize(DecisionTree dsTree, LibraryDecisionTree libDsTree)
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

            OwnImplementation = true;

            this.dsTree = dsTree;
            this.libDsTree = libDsTree;
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

                string priceRange = "";

                if (OwnImplementation)
                {
                    if (dsTree.Root == null) throw new Exception("No own implementation decision tree has been generated");

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

                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    string[] prediction = dsTree.Predict(newDataPoint).Split(';');

                    sw.Stop();

                    Console.WriteLine("Prediction time(own): " + sw.ElapsedMilliseconds + " ms");

                    priceRange = prediction[0];

                    string treeTraversal = prediction[1];

                    treeTraversalRichTxtBox.Text = treeTraversal;
                }
                else
                {
                    if (!libDsTree.ClassificationTreeGenerated) throw new Exception("No library implementation decision tree has been generated");

                    HouseSaleDataClassification houseSale = new HouseSaleDataClassification()
                    {
                        Bedrooms = bedrooms,
                        Bathrooms = (float)bathrooms,
                        SqftLiving = sqftLiving,
                        SqftLot = sqftLot,
                        Floors = (float)floors,
                        Waterfront = (float)(waterfront?1:0),
                        View = view,
                        Condition = condition,
                        Grade = grade,
                        SqftAbove = sqftAbove,
                        SqftBasement = sqftBasement,
                        YrBuilt = yearBuilt,
                        Zipcode = zipcode,
                        SqftLiving15 = sqftLiving15,
                        SqftLot15 = sqftLot15
                    };
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    priceRange = libDsTree.PredictClassification(houseSale);
                    sw.Stop();

                    Console.WriteLine("Prediction time (library): " + sw.ElapsedMilliseconds + " ms");
                }                    

                priceRangeLabel.Text = "Price Range: " + priceRange;

                ClearTextBoxes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error ocurred, please check that every fill is filled and the tree is generated:\n" + ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to clear the text boxes

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

        // Method to clear (button)

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();

            Initialize(dsTree,libDsTree);

            treeTraversalRichTxtBox.Text = "";
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
