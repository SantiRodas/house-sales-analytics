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
    public partial class DecisionTreeControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Constructor method with initialize component

        public DecisionTreeControl()
        {
            InitializeComponent();
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
                // Th user select the library implementation

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
