using System;
using System.Data;
using System.Windows.Forms;
using HSA.Model;

namespace HSA.UserInterface
{
    public partial class DataViewerControl : UserControl
    {

        // ----------------------------------------------------------------------------------------------------

        // Relations with another classes of the system

        private DataSetManager manager;

        private ChartsControl graphicsManager;

        // ----------------------------------------------------------------------------------------------------

        // Constructor method of the data viewer control

        public DataViewerControl()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------------------------------------

        // Initialize method of the class

        public void Initialize(DataSetManager manager, ChartsControl graphicsManager)
        {
            this.manager = manager;

            this.graphicsManager = graphicsManager;

            int page = this.manager.CurrentPage;

            UpdatePageInfoLabelsAndButtons(page);

            dataSetDataGridView.DataSource = this.manager.CurrentPageData;

            //Adds columns to filter columns selector

            DataColumnCollection columns = manager.Data.Columns;

            for (int i = 0; i < columns.Count; i++)
            {
                string columnName = columns[i].ToString();

                filterColumnSelector.Items.Add(columnName);

                sortCriteriaSelector.Items.Add(columnName);
            }

            //Initialize sort order combo box to be - to +

            sortOrderSelector.SelectedIndex = 0;

            //Sets properties to allow a nice resize

            dataViewerSplitContainer.FixedPanel = FixedPanel.Panel2;

            dataViewAndFilterSplitContainer.FixedPanel = FixedPanel.Panel1;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method next page button click

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            int page = manager.NextPage();

            UpdatePageInfoLabelsAndButtons(page);
        }

        // ----------------------------------------------------------------------------------------------------

        // Method prevous page button click

        private void prevousPageButton_Click(object sender, EventArgs e)
        {
            int page = manager.PreviousPage();

            UpdatePageInfoLabelsAndButtons(page);
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update page info labels and buttons

        private void UpdatePageInfoLabelsAndButtons(int page)
        {
            int maxPage = manager.MaxPage;

            if (page > 0)
            {
                int lowerLimit = manager.LowerLimit;

                int upperLimit = manager.UpperLimit;

                int dataCount = manager.DataCount;

                pageNumberLabel.Text = "Page " + page + "/" + maxPage;

                dataShowingLabel.Text = "Showing " + (lowerLimit + 1) + " to " + (upperLimit) + " of " + dataCount;
            }

            if (page == maxPage)
            {
                nextPageButton.Enabled = false;
            }

            if (page <= 1 || (page <= 1 && page == maxPage))
            {
                prevousPageButton.Enabled = false;
            }

            if(page > 1 && page < maxPage)
            {
                prevousPageButton.Enabled = true;

                nextPageButton.Enabled = true;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter button click

        private void filterButton_Click(object sender, EventArgs e)
        {
            try
            {
                Type columnType = manager.Data.Columns[filterColumnSelector.SelectedIndex].DataType;

                string columnName = (string)filterColumnSelector.SelectedItem;

                if (columnType.Equals(typeof(Int32)))
                {
                    int from = Int32.Parse(fromTextBox.Text);

                    int to = Int32.Parse(toTextBox.Text);

                    if (to < from) { throw new FormatException("Upper limit is smaller than lower limit."); }                    

                    manager.FilterIntegerData(columnName,from,to);
                }
                else if (columnType.Equals(typeof(Double)))
                {
                    double from = Double.Parse(fromTextBox.Text);

                    double to = Double.Parse(toTextBox.Text);

                    if (to < from) { throw new FormatException("Upper limit is smaller than lower limit."); }

                    manager.FilterDoubleData(columnName, from, to);
                }
                else if (columnType.Equals(typeof(DateTime)))
                {
                    DateTime startDate = startDatePicker.Value;

                    DateTime endDate = endDatePicker.Value;

                    if(startDate == null || endDate == null) { throw new NullReferenceException("A date is null"); }

                    if (startDate.CompareTo(endDate) > 0) { throw new FormatException("End date is after start date"); }

                    manager.FilterDateData(columnName, startDate, endDate);
                }
                else if (columnType.Equals(typeof(String)))
                {
                    manager.FilterStringData(columnName, stringFilterTextBox.Text);
                }
                else//boolean
                {
                    manager.FilterBooleanData(columnName, Boolean.Parse((string)booleanComboBox.SelectedItem));
                }

                UpdatePageInfoLabelsAndButtons(1);

                graphicsManager.UpdateCharts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("There was an error filtering the data, please check the following: \n 1. A filter criteria is selected\n 2. Numbers are written and written correctly.\n 3. If in range be sure the upper limit is larger than the lower limit\n 4. If criteria has a drop down list be sure at least a option is selected", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method reset table button click

        private void resetTableButton_Click(object sender, EventArgs e)
        {
            manager.ClearSortFiters();

            UpdatePageInfoLabelsAndButtons(1);

            graphicsManager.UpdateCharts();

            ResetFilteringFields();

            UpdateEnable(false, false, false, false);

            filterColumnSelector.SelectedIndex = -1;

            sortCriteriaSelector.SelectedIndex = -1;

            sortOrderSelector.SelectedIndex = 0;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter column selector - selected value changed

        private void filterColumnSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if(filterColumnSelector.SelectedIndex >= 0) 
            { 
                Type columnType = manager.Data.Columns[filterColumnSelector.SelectedIndex].DataType;

                if (columnType.Equals(typeof(Int32))|| columnType.Equals(typeof(Double)))
                {
                    UpdateEnable(true, false, false, false);
                }
                else if (columnType.Equals(typeof(DateTime)))
                {
                    UpdateEnable(false, false, true, false);
                }
                else if (columnType.Equals(typeof(String)))
                {
                    UpdateEnable(false, true, false, false);
                }
                else//boolean
                {
                    UpdateEnable(false, false, false, true);
                }

                ResetFilteringFields();
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method reset filtering fields

        private void ResetFilteringFields()
        {
            fromTextBox.Text = "";

            toTextBox.Text = "";

            stringFilterTextBox.Text = "";

            booleanComboBox.SelectedIndex = -1;

            startDatePicker.Value = DateTime.Now;

            endDatePicker.Value = DateTime.Now;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update enable

        private void UpdateEnable(bool isNumber, bool isString, bool isDate, bool isBool)
        {
            fromTextBox.Enabled = isNumber;

            toTextBox.Enabled = isNumber;

            startDatePicker.Enabled = isDate;

            endDatePicker.Enabled = isDate;

            stringFilterTextBox.Enabled = isString;

            booleanComboBox.Enabled = isBool;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method sort button click

        private void sortButton_Click(object sender, EventArgs e)
        {
            try 
            {
                bool ascendantOrder = sortOrderSelector.SelectedIndex == 0 ? true : false;

                manager.SortData((string)sortCriteriaSelector.SelectedItem,ascendantOrder);

                UpdatePageInfoLabelsAndButtons(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("There was an error sorting the data please check the following: \n 1. A sorting criteria is selected", "Something went wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------------------------------------

    }
}
