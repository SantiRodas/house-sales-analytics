
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.dataViewerSplitContainer.Size = new System.Drawing.Size(900, 553);
            this.dataViewerSplitContainer.SplitterDistance = 509;
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
            this.dataViewAndFilterSplitContainer.Panel1.Controls.Add(this.label1);
            this.dataViewAndFilterSplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataViewAndFilterSplitContainer_Panel1_Paint);
            // 
            // dataViewAndFilterSplitContainer.Panel2
            // 
            this.dataViewAndFilterSplitContainer.Panel2.Controls.Add(this.dataSetDataGridView);
            this.dataViewAndFilterSplitContainer.Size = new System.Drawing.Size(900, 509);
            this.dataViewAndFilterSplitContainer.SplitterDistance = 87;
            this.dataViewAndFilterSplitContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.dataSetDataGridView.Size = new System.Drawing.Size(900, 418);
            this.dataSetDataGridView.TabIndex = 0;
            this.dataSetDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSetDataGridView_CellContentClick);
            // 
            // dataShowingLabel
            // 
            this.dataShowingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataShowingLabel.AutoSize = true;
            this.dataShowingLabel.Location = new System.Drawing.Point(720, 15);
            this.dataShowingLabel.Name = "dataShowingLabel";
            this.dataShowingLabel.Size = new System.Drawing.Size(109, 13);
            this.dataShowingLabel.TabIndex = 3;
            this.dataShowingLabel.Text = "showing xx to yy of zz";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(449, 15);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(56, 13);
            this.pageNumberLabel.TabIndex = 2;
            this.pageNumberLabel.Text = "Page 1/xx";
            // 
            // prevousPageButton
            // 
            this.prevousPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.prevousPageButton.Location = new System.Drawing.Point(358, 10);
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
            this.nextPageButton.Location = new System.Drawing.Point(520, 11);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(75, 24);
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
            this.Size = new System.Drawing.Size(900, 553);
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
        private System.Windows.Forms.Label label1;
    }
}
