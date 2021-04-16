
namespace HSA.UserInterface
{
    partial class DataViewerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataViewerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.dataViewAndFilterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.filteringCriteriaLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.stringFilterLabel = new System.Windows.Forms.Label();
            this.stringFilterTextBox = new System.Windows.Forms.TextBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.filterColumnSelector = new System.Windows.Forms.ComboBox();
            this.dataSetDataGridView = new System.Windows.Forms.DataGridView();
            this.dataShowingLabel = new System.Windows.Forms.Label();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.prevousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerSplitContainer)).BeginInit();
            this.dataViewerSplitContainer.Panel1.SuspendLayout();
            this.dataViewerSplitContainer.Panel2.SuspendLayout();
            this.dataViewerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAndFilterSplitContainer)).BeginInit();
            this.dataViewAndFilterSplitContainer.Panel1.SuspendLayout();
            this.dataViewAndFilterSplitContainer.Panel2.SuspendLayout();
            this.dataViewAndFilterSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewerSplitContainer
            // 
            this.dataViewerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewerSplitContainer.IsSplitterFixed = true;
            this.dataViewerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.dataViewerSplitContainer.Name = "dataViewerSplitContainer";
            this.dataViewerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // dataViewerSplitContainer.Panel1
            // 
            this.dataViewerSplitContainer.Panel1.Controls.Add(this.dataViewAndFilterSplitContainer);
            // 
            // dataViewerSplitContainer.Panel2
            // 
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.dataShowingLabel);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.pageNumberLabel);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.prevousPageButton);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.nextPageButton);
            this.dataViewerSplitContainer.Size = new System.Drawing.Size(894, 547);
            this.dataViewerSplitContainer.SplitterDistance = 503;
            this.dataViewerSplitContainer.TabIndex = 1;
            // 
            // dataViewAndFilterSplitContainer
            // 
            this.dataViewAndFilterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewAndFilterSplitContainer.IsSplitterFixed = true;
            this.dataViewAndFilterSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.dataViewAndFilterSplitContainer.Name = "dataViewAndFilterSplitContainer";
            this.dataViewAndFilterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // dataViewAndFilterSplitContainer.Panel1
            // 
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.endDateLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.startDateLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.startDatePicker);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.filteringCriteriaLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.searchButton);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.stringFilterLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.stringFilterTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.endDatePicker);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.toTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.fromTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.toLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.fromLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.filterColumnSelector);
            // 
            // dataViewAndFilterSplitContainer.Panel2
            // 
            this.dataViewAndFilterSplitContainer.Panel2.Controls.Add(this.dataSetDataGridView);
            this.dataViewAndFilterSplitContainer.Size = new System.Drawing.Size(894, 503);
            this.dataViewAndFilterSplitContainer.SplitterDistance = 85;
            this.dataViewAndFilterSplitContainer.TabIndex = 0;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(300, 58);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(66, 13);
            this.endDateLabel.TabIndex = 12;
            this.endDateLabel.Text = "Ending Date";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(4, 58);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(69, 13);
            this.startDateLabel.TabIndex = 11;
            this.startDateLabel.Text = "Starting Date";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(79, 52);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 10;
            // 
            // filteringCriteriaLabel
            // 
            this.filteringCriteriaLabel.AutoSize = true;
            this.filteringCriteriaLabel.Location = new System.Drawing.Point(767, 17);
            this.filteringCriteriaLabel.Name = "filteringCriteriaLabel";
            this.filteringCriteriaLabel.Size = new System.Drawing.Size(78, 13);
            this.filteringCriteriaLabel.TabIndex = 9;
            this.filteringCriteriaLabel.Text = "Filtering Criteria";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(644, 33);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
      
            // 
            // stringFilterLabel
            // 
            this.stringFilterLabel.AutoSize = true;
            this.stringFilterLabel.Location = new System.Drawing.Point(446, 20);
            this.stringFilterLabel.Name = "stringFilterLabel";
            this.stringFilterLabel.Size = new System.Drawing.Size(56, 13);
            this.stringFilterLabel.TabIndex = 7;
            this.stringFilterLabel.Text = "String filter";
            // 
            // stringFilterTextBox
            // 
            this.stringFilterTextBox.Location = new System.Drawing.Point(517, 17);
            this.stringFilterTextBox.Name = "stringFilterTextBox";
            this.stringFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.stringFilterTextBox.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(372, 52);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 5;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(303, 17);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(100, 20);
            this.toTextBox.TabIndex = 4;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(79, 17);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(100, 20);
            this.fromTextBox.TabIndex = 3;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(277, 20);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(20, 13);
            this.toLabel.TabIndex = 2;
            this.toLabel.Text = "To";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(40, 20);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(33, 13);
            this.fromLabel.TabIndex = 1;
            this.fromLabel.Text = "From:";
            // 
            // filterColumnSelector
            // 
            this.filterColumnSelector.FormattingEnabled = true;
            this.filterColumnSelector.Location = new System.Drawing.Point(745, 33);
            this.filterColumnSelector.Name = "filterColumnSelector";
            this.filterColumnSelector.Size = new System.Drawing.Size(121, 21);
            this.filterColumnSelector.TabIndex = 0;
            // 
            // dataSetDataGridView
            // 
            this.dataSetDataGridView.AllowUserToAddRows = false;
            this.dataSetDataGridView.AllowUserToDeleteRows = false;
            this.dataSetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetDataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataSetDataGridView.Name = "dataSetDataGridView";
            this.dataSetDataGridView.ReadOnly = true;
            this.dataSetDataGridView.RowHeadersVisible = false;
            this.dataSetDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataSetDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataSetDataGridView.Size = new System.Drawing.Size(894, 414);
            this.dataSetDataGridView.TabIndex = 0;
            // 
            // dataShowingLabel
            // 
            this.dataShowingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataShowingLabel.AutoSize = true;
            this.dataShowingLabel.Location = new System.Drawing.Point(717, 15);
            this.dataShowingLabel.Name = "dataShowingLabel";
            this.dataShowingLabel.Size = new System.Drawing.Size(109, 13);
            this.dataShowingLabel.TabIndex = 3;
            this.dataShowingLabel.Text = "showing xx to yy of zz";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(446, 15);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(56, 13);
            this.pageNumberLabel.TabIndex = 2;
            this.pageNumberLabel.Text = "Page 1/xx";
            // 
            // prevousPageButton
            // 
            this.prevousPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.prevousPageButton.Location = new System.Drawing.Point(355, 10);
            this.prevousPageButton.Name = "prevousPageButton";
            this.prevousPageButton.Size = new System.Drawing.Size(75, 25);
            this.prevousPageButton.TabIndex = 1;
            this.prevousPageButton.Text = "Previous";
            this.prevousPageButton.UseVisualStyleBackColor = true;
            this.prevousPageButton.Click += new System.EventHandler(this.prevousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nextPageButton.Location = new System.Drawing.Point(517, 11);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(75, 24);
            this.nextPageButton.TabIndex = 0;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // dataViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataViewerSplitContainer);
            this.Name = "dataViewerControl";
            this.Size = new System.Drawing.Size(894, 547);
            this.dataViewerSplitContainer.Panel1.ResumeLayout(false);
            this.dataViewerSplitContainer.Panel2.ResumeLayout(false);
            this.dataViewerSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerSplitContainer)).EndInit();
            this.dataViewerSplitContainer.ResumeLayout(false);
            this.dataViewAndFilterSplitContainer.Panel1.ResumeLayout(false);
            this.dataViewAndFilterSplitContainer.Panel1.PerformLayout();
            this.dataViewAndFilterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAndFilterSplitContainer)).EndInit();
            this.dataViewAndFilterSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer dataViewerSplitContainer;
        private System.Windows.Forms.SplitContainer dataViewAndFilterSplitContainer;
        private System.Windows.Forms.DataGridView dataSetDataGridView;
        private System.Windows.Forms.Label dataShowingLabel;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button prevousPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.TextBox stringFilterTextBox;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.ComboBox filterColumnSelector;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label filteringCriteriaLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label stringFilterLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
    }
}
