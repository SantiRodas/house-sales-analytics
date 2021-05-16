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

                int numberBathrooms = Int32.Parse(bathroomsText.Text);

                int numberSqftLiving = Int32.Parse(sqftLivingText.Text);

                int numberSqftLot = Int32.Parse(sqftLotText.Text);

                double numberFlorr = double.Parse(floorText.Text);

                // The decision bool take the information of the waterfront

                bool validationWaterfront = false;

                if (waterfrontOption1.Checked)
                {
                    validationWaterfront = true;

                } else if (waterfrontOption2.Checked)
                {
                    validationWaterfront = false;
                }
                else
                {
                    MessageBox.Show("Please select a option");
                }

                // The system take the information of the house

                int numberView = Int32.Parse(viewText.Text);

                int numberCondition = Int32.Parse(conditionText.Text);

                int numberGrade = Int32.Parse(gradeText.Text);

                int numberSqftAbove = Int32.Parse(sqftAboveText.Text);

                // The right part of the window

                int numberSqftBasement = Int32.Parse(sqftBasementText.Text);

                int numberYearRenovated = Int32.Parse(yearRenovatedText.Text);

                int numberZipCode = Int32.Parse(zipCodeText.Text);

                int numberSqftLiving15 = Int32.Parse(sqftLiving15Text.Text);

                int numberSqftLot15 = Int32.Parse(sqftLot15Text.Text);

                // With this information the system can work

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

        // ----------------------------------------------------------------------------------------------------

    }
}
