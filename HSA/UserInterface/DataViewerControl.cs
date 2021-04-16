﻿using System;
using System.Data;
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

            //Adds columns to filter columns selector

            DataColumnCollection columns = manager.Data.Columns;

            for(int i = 0; i < columns.Count; i++)
            {
                filterColumnSelector.Items.Add(columns[i].ToString());
            }

            


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

     
    }
}
