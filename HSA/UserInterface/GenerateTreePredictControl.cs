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
    public partial class GenerateTreePredictControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public GenerateTreePredictControl()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method to generate new tree (Button)

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

                int numberBedrooms = Int32.Parse(bedroomsText.Text);

                double numberBathrooms = double.Parse(bathroomsText.Text);

                double numberSqftLiving = double.Parse(sqftLivingText.Text);

                double numberSqftLot = double.Parse(sqftLotText.Text);

                double numberFloor = double.Parse(floorText.Text);

                // The decision bool take the information of the waterfront

                bool validationWaterfront = false;

                if (waterfrontOption1.Checked)
                {
                    validationWaterfront = true;

                } else if (waterfrontOption1.Checked == false && waterfrontOption2.Checked == false)
                {
                    MessageBox.Show("Please select a option");
                }
               

                // The system take the information of the house

                int numberView = Int32.Parse(viewText.Text);

                int numberCondition = Int32.Parse(conditionText.Text);

                int numberGrade = Int32.Parse(gradeText.Text);

                double numberSqftAbove = double.Parse(sqftAboveText.Text);

                // The right part of the window

                double numberSqftBasement = double.Parse(sqftBasementText.Text);

                int numberYearRenovated = Int32.Parse(yearRenovatedText.Text);

                int numberZipCode = Int32.Parse(zipCodeText.Text);

                double numberSqftLiving15 = double.Parse(sqftLiving15Text.Text);

                double numberSqftLot15 = double.Parse(sqftLot15Text.Text);

                Record newDataPoint = new Record(numberBedrooms, numberBathrooms, numberSqftLiving, numberSqftLot, numberFloor , validationWaterfront, numberView, numberCondition, numberGrade, numberSqftAbove, numberSqftBasement, numberYearRenovated, numberZipCode , numberSqftLiving15 ,  numberSqftLot15);

                // With this information the system can work

                

                ClearTextBoxes();

            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format, please try again with another one");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Null information, please try to write something in all the components");
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



        // ----------------------------------------------------------------------------------------------------

    }
}
