
namespace HSA.UserInterface
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainWindowTabs = new System.Windows.Forms.TabControl();
            this.dataViewTab = new System.Windows.Forms.TabPage();
            this.dataViewerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.dataViewAndFilterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.dataSetDataGridView = new System.Windows.Forms.DataGridView();
            this.dataShowingLabel = new System.Windows.Forms.Label();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.prevousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.graphicsTab = new System.Windows.Forms.TabPage();
            this.mainWindowTabs.SuspendLayout();
            this.dataViewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerSplitContainer)).BeginInit();
            this.dataViewerSplitContainer.Panel1.SuspendLayout();
            this.dataViewerSplitContainer.Panel2.SuspendLayout();
            this.dataViewerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAndFilterSplitContainer)).BeginInit();
            this.dataViewAndFilterSplitContainer.Panel2.SuspendLayout();
            this.dataViewAndFilterSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainWindowTabs
            // 
            this.mainWindowTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainWindowTabs.Controls.Add(this.dataViewTab);
            this.mainWindowTabs.Controls.Add(this.graphicsTab);
            this.mainWindowTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainWindowTabs.ItemSize = new System.Drawing.Size(40, 100);
            this.mainWindowTabs.Location = new System.Drawing.Point(0, 0);
            this.mainWindowTabs.Multiline = true;
            this.mainWindowTabs.Name = "mainWindowTabs";
            this.mainWindowTabs.SelectedIndex = 0;
            this.mainWindowTabs.Size = new System.Drawing.Size(1008, 561);
            this.mainWindowTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainWindowTabs.TabIndex = 0;
            // 
            // dataViewTab
            // 
            this.dataViewTab.Controls.Add(this.dataViewerSplitContainer);
            this.dataViewTab.Location = new System.Drawing.Point(104, 4);
            this.dataViewTab.Name = "dataViewTab";
            this.dataViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataViewTab.Size = new System.Drawing.Size(900, 553);
            this.dataViewTab.TabIndex = 0;
            this.dataViewTab.Text = "Data Viewer";
            this.dataViewTab.UseVisualStyleBackColor = true;
            // 
            // dataViewerSplitContainer
            // 
            this.dataViewerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewerSplitContainer.IsSplitterFixed = true;
            this.dataViewerSplitContainer.Location = new System.Drawing.Point(3, 3);
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
            this.dataViewerSplitContainer.SplitterDistance = 504;
            this.dataViewerSplitContainer.TabIndex = 0;
            // 
            // dataViewAndFilterSplitContainer
            // 
            this.dataViewAndFilterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewAndFilterSplitContainer.IsSplitterFixed = true;
            this.dataViewAndFilterSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.dataViewAndFilterSplitContainer.Name = "dataViewAndFilterSplitContainer";
            this.dataViewAndFilterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // dataViewAndFilterSplitContainer.Panel2
            // 
            this.dataViewAndFilterSplitContainer.Panel2.Controls.Add(this.dataSetDataGridView);
            this.dataViewAndFilterSplitContainer.Size = new System.Drawing.Size(894, 504);
            this.dataViewAndFilterSplitContainer.SplitterDistance = 87;
            this.dataViewAndFilterSplitContainer.TabIndex = 0;
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
            this.dataSetDataGridView.Size = new System.Drawing.Size(894, 413);
            this.dataSetDataGridView.TabIndex = 0;
            // 
            // dataShowingLabel
            // 
            this.dataShowingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataShowingLabel.AutoSize = true;
            this.dataShowingLabel.Location = new System.Drawing.Point(717, 15);
            this.dataShowingLabel.Name = "dataShowingLabel";
            this.dataShowingLabel.Size = new System.Drawing.Size(119, 13);
            this.dataShowingLabel.TabIndex = 3;
            this.dataShowingLabel.Text = "showing xx to yy of zz";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(446, 15);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(55, 13);
            this.pageNumberLabel.TabIndex = 2;
            this.pageNumberLabel.Text = "Page 1/xx";
            // 
            // prevousPageButton
            // 
            this.prevousPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.prevousPageButton.Location = new System.Drawing.Point(355, 10);
            this.prevousPageButton.Name = "prevousPageButton";
            this.prevousPageButton.Size = new System.Drawing.Size(75, 24);
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
            this.nextPageButton.Size = new System.Drawing.Size(75, 23);
            this.nextPageButton.TabIndex = 0;
            this.nextPageButton.Text = "Next";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // graphicsTab
            // 
            this.graphicsTab.Location = new System.Drawing.Point(104, 4);
            this.graphicsTab.Name = "graphicsTab";
            this.graphicsTab.Padding = new System.Windows.Forms.Padding(3);
            this.graphicsTab.Size = new System.Drawing.Size(900, 553);
            this.graphicsTab.TabIndex = 1;
            this.graphicsTab.Text = "Graphics";
            this.graphicsTab.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.mainWindowTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSA";
            this.mainWindowTabs.ResumeLayout(false);
            this.dataViewTab.ResumeLayout(false);
            this.dataViewerSplitContainer.Panel1.ResumeLayout(false);
            this.dataViewerSplitContainer.Panel2.ResumeLayout(false);
            this.dataViewerSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewerSplitContainer)).EndInit();
            this.dataViewerSplitContainer.ResumeLayout(false);
            this.dataViewAndFilterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewAndFilterSplitContainer)).EndInit();
            this.dataViewAndFilterSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainWindowTabs;
        private System.Windows.Forms.TabPage dataViewTab;
        private System.Windows.Forms.TabPage graphicsTab;
        private System.Windows.Forms.SplitContainer dataViewerSplitContainer;
        private System.Windows.Forms.SplitContainer dataViewAndFilterSplitContainer;
        private System.Windows.Forms.DataGridView dataSetDataGridView;
        private System.Windows.Forms.Label dataShowingLabel;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button prevousPageButton;
        private System.Windows.Forms.Button nextPageButton;
    }
}

