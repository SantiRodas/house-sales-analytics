
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
            this.sortOrderSelector = new System.Windows.Forms.ComboBox();
            this.booleanComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortCriteriaLabel = new System.Windows.Forms.Label();
            this.sortCriteriaSelector = new System.Windows.Forms.ComboBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.separatorDateRangeLabel = new System.Windows.Forms.Label();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.filteringCriteriaLabel = new System.Windows.Forms.Label();
            this.filterButton = new System.Windows.Forms.Button();
            this.stringFilterLabel = new System.Windows.Forms.Label();
            this.stringFilterTextBox = new System.Windows.Forms.TextBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.rangeSeparatorLabel = new System.Windows.Forms.Label();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.filterColumnSelector = new System.Windows.Forms.ComboBox();
            this.dataSetDataGridView = new System.Windows.Forms.DataGridView();
            this.resetTableButton = new System.Windows.Forms.Button();
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
            this.dataViewerSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.resetTableButton);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.dataShowingLabel);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.pageNumberLabel);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.prevousPageButton);
            this.dataViewerSplitContainer.Panel2.Controls.Add(this.nextPageButton);
            this.dataViewerSplitContainer.Panel2MinSize = 42;
            this.dataViewerSplitContainer.Size = new System.Drawing.Size(894, 547);
            this.dataViewerSplitContainer.SplitterDistance = 501;
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
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.sortOrderSelector);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.booleanComboBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.label1);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.sortCriteriaLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.sortCriteriaSelector);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.sortButton);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.separatorDateRangeLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.dateRangeLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.startDatePicker);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.filteringCriteriaLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.filterButton);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.stringFilterLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.stringFilterTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.endDatePicker);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.toTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.fromTextBox);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.rangeSeparatorLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.rangeLabel);
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.filterColumnSelector);
            // 
            // dataViewAndFilterSplitContainer.Panel2
            // 
            this.dataViewAndFilterSplitContainer.Panel2.Controls.Add(this.dataSetDataGridView);
            this.dataViewAndFilterSplitContainer.Size = new System.Drawing.Size(894, 501);
            this.dataViewAndFilterSplitContainer.SplitterDistance = 89;
            this.dataViewAndFilterSplitContainer.TabIndex = 0;
            // 
            // sortOrderSelector
            // 
            this.sortOrderSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sortOrderSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortOrderSelector.FormattingEnabled = true;
            this.sortOrderSelector.Items.AddRange(new object[] {
            "- to +",
            "+ to -"});
            this.sortOrderSelector.Location = new System.Drawing.Point(833, 25);
            this.sortOrderSelector.Name = "sortOrderSelector";
            this.sortOrderSelector.Size = new System.Drawing.Size(58, 21);
            this.sortOrderSelector.TabIndex = 19;
            // 
            // booleanComboBox
            // 
            this.booleanComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.booleanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.booleanComboBox.Enabled = false;
            this.booleanComboBox.FormattingEnabled = true;
            this.booleanComboBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.booleanComboBox.Location = new System.Drawing.Point(424, 23);
            this.booleanComboBox.Name = "booleanComboBox";
            this.booleanComboBox.Size = new System.Drawing.Size(91, 21);
            this.booleanComboBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "True/False";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sortCriteriaLabel
            // 
            this.sortCriteriaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sortCriteriaLabel.AutoSize = true;
            this.sortCriteriaLabel.Location = new System.Drawing.Point(738, 6);
            this.sortCriteriaLabel.Name = "sortCriteriaLabel";
            this.sortCriteriaLabel.Size = new System.Drawing.Size(61, 13);
            this.sortCriteriaLabel.TabIndex = 15;
            this.sortCriteriaLabel.Text = "Sort Criteria";
            // 
            // sortCriteriaSelector
            // 
            this.sortCriteriaSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sortCriteriaSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortCriteriaSelector.FormattingEnabled = true;
            this.sortCriteriaSelector.Location = new System.Drawing.Point(708, 25);
            this.sortCriteriaSelector.Name = "sortCriteriaSelector";
            this.sortCriteriaSelector.Size = new System.Drawing.Size(121, 21);
            this.sortCriteriaSelector.TabIndex = 14;
            // 
            // sortButton
            // 
            this.sortButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sortButton.Location = new System.Drawing.Point(730, 59);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 13;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // separatorDateRangeLabel
            // 
            this.separatorDateRangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.separatorDateRangeLabel.AutoSize = true;
            this.separatorDateRangeLabel.Location = new System.Drawing.Point(311, 66);
            this.separatorDateRangeLabel.Name = "separatorDateRangeLabel";
            this.separatorDateRangeLabel.Size = new System.Drawing.Size(10, 13);
            this.separatorDateRangeLabel.TabIndex = 12;
            this.separatorDateRangeLabel.Text = "-";
            this.separatorDateRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateRangeLabel.AutoSize = true;
            this.dateRangeLabel.Location = new System.Drawing.Point(22, 66);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(65, 13);
            this.dateRangeLabel.TabIndex = 11;
            this.dateRangeLabel.Text = "Date Range";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startDatePicker.Enabled = false;
            this.startDatePicker.Location = new System.Drawing.Point(98, 63);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 10;
            // 
            // filteringCriteriaLabel
            // 
            this.filteringCriteriaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filteringCriteriaLabel.AutoSize = true;
            this.filteringCriteriaLabel.Location = new System.Drawing.Point(599, 6);
            this.filteringCriteriaLabel.Name = "filteringCriteriaLabel";
            this.filteringCriteriaLabel.Size = new System.Drawing.Size(78, 13);
            this.filteringCriteriaLabel.TabIndex = 9;
            this.filteringCriteriaLabel.Text = "Filtering Criteria";
            // 
            // filterButton
            // 
            this.filterButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterButton.Location = new System.Drawing.Point(600, 59);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 22);
            this.filterButton.TabIndex = 8;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // stringFilterLabel
            // 
            this.stringFilterLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stringFilterLabel.AutoSize = true;
            this.stringFilterLabel.Location = new System.Drawing.Point(296, 6);
            this.stringFilterLabel.Name = "stringFilterLabel";
            this.stringFilterLabel.Size = new System.Drawing.Size(56, 13);
            this.stringFilterLabel.TabIndex = 7;
            this.stringFilterLabel.Text = "String filter";
            this.stringFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stringFilterTextBox
            // 
            this.stringFilterTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stringFilterTextBox.Enabled = false;
            this.stringFilterTextBox.Location = new System.Drawing.Point(275, 23);
            this.stringFilterTextBox.Name = "stringFilterTextBox";
            this.stringFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.stringFilterTextBox.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.endDatePicker.Enabled = false;
            this.endDatePicker.Location = new System.Drawing.Point(333, 63);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 5;
            // 
            // toTextBox
            // 
            this.toTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.toTextBox.Enabled = false;
            this.toTextBox.Location = new System.Drawing.Point(150, 23);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(78, 20);
            this.toTextBox.TabIndex = 4;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fromTextBox.Enabled = false;
            this.fromTextBox.Location = new System.Drawing.Point(61, 23);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(78, 20);
            this.fromTextBox.TabIndex = 3;
            // 
            // rangeSeparatorLabel
            // 
            this.rangeSeparatorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeSeparatorLabel.AutoSize = true;
            this.rangeSeparatorLabel.Location = new System.Drawing.Point(139, 26);
            this.rangeSeparatorLabel.Name = "rangeSeparatorLabel";
            this.rangeSeparatorLabel.Size = new System.Drawing.Size(10, 13);
            this.rangeSeparatorLabel.TabIndex = 2;
            this.rangeSeparatorLabel.Text = "-";
            // 
            // rangeLabel
            // 
            this.rangeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(122, 6);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(42, 13);
            this.rangeLabel.TabIndex = 1;
            this.rangeLabel.Text = "Range:";
            this.rangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterColumnSelector
            // 
            this.filterColumnSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterColumnSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterColumnSelector.FormattingEnabled = true;
            this.filterColumnSelector.Location = new System.Drawing.Point(575, 25);
            this.filterColumnSelector.Name = "filterColumnSelector";
            this.filterColumnSelector.Size = new System.Drawing.Size(121, 21);
            this.filterColumnSelector.TabIndex = 0;
            this.filterColumnSelector.SelectedValueChanged += new System.EventHandler(this.filterColumnSelector_SelectedValueChanged);
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
            this.dataSetDataGridView.Size = new System.Drawing.Size(894, 408);
            this.dataSetDataGridView.TabIndex = 0;
            // 
            // resetTableButton
            // 
            this.resetTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetTableButton.Location = new System.Drawing.Point(12, 7);
            this.resetTableButton.Name = "resetTableButton";
            this.resetTableButton.Size = new System.Drawing.Size(75, 27);
            this.resetTableButton.TabIndex = 19;
            this.resetTableButton.Text = "Reset Table";
            this.resetTableButton.UseVisualStyleBackColor = true;
            this.resetTableButton.Click += new System.EventHandler(this.resetTableButton_Click);
            // 
            // dataShowingLabel
            // 
            this.dataShowingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataShowingLabel.AutoSize = true;
            this.dataShowingLabel.Location = new System.Drawing.Point(705, 15);
            this.dataShowingLabel.Name = "dataShowingLabel";
            this.dataShowingLabel.Size = new System.Drawing.Size(109, 13);
            this.dataShowingLabel.TabIndex = 3;
            this.dataShowingLabel.Text = "showing xx to yy of zz";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(447, 15);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(56, 13);
            this.pageNumberLabel.TabIndex = 2;
            this.pageNumberLabel.Text = "Page 1/xx";
            // 
            // prevousPageButton
            // 
            this.prevousPageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.prevousPageButton.Location = new System.Drawing.Point(355, 7);
            this.prevousPageButton.Name = "prevousPageButton";
            this.prevousPageButton.Size = new System.Drawing.Size(75, 27);
            this.prevousPageButton.TabIndex = 1;
            this.prevousPageButton.Text = "Previous";
            this.prevousPageButton.UseVisualStyleBackColor = true;
            this.prevousPageButton.Click += new System.EventHandler(this.prevousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nextPageButton.Location = new System.Drawing.Point(517, 8);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(75, 26);
            this.nextPageButton.TabIndex = 0;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // DataViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataViewerSplitContainer);
            this.Name = "DataViewerControl";
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
        private System.Windows.Forms.Label rangeSeparatorLabel;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.ComboBox filterColumnSelector;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label filteringCriteriaLabel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label stringFilterLabel;
        private System.Windows.Forms.Label separatorDateRangeLabel;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sortCriteriaLabel;
        private System.Windows.Forms.ComboBox sortCriteriaSelector;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.ComboBox booleanComboBox;
        private System.Windows.Forms.Button resetTableButton;
        private System.Windows.Forms.ComboBox sortOrderSelector;
    }
}
