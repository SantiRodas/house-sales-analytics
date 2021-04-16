using System;
using System.Windows.Forms;
using HSA.Model;

namespace HSA.UserInterface
{
    public partial class DataViewerControl : UserControl
    {
        private DataSetManager manager;

        public DataViewerControl()
        {
            InitializeComponent();            
        }

        public void Initialize(DataSetManager manager)
        {
            this.manager = manager;

            int page = this.manager.CurrentPage;

            UpdatePageInfoLabelsAndButtons(page);

            dataSetDataGridView.DataSource = this.manager.CurrentPageData;
        }
        
        private void nextPageButton_Click(object sender, EventArgs e)
        {
            int page = manager.NextPage();
            UpdatePageInfoLabelsAndButtons(page);
        }

        private void prevousPageButton_Click(object sender, EventArgs e)
        {
            int page = manager.PreviousPage();
            UpdatePageInfoLabelsAndButtons(page);
        }

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

            if (page <= 1)
            {
                prevousPageButton.Enabled = false;
            }
            else if (page == maxPage)
            {
                nextPageButton.Enabled = false;
            }
            else
            {
                prevousPageButton.Enabled = true;
                nextPageButton.Enabled = true;
            }
        }

        private void dataViewAndFilterSplitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataSetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
