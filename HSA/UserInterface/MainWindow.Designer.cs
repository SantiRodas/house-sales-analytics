
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
            this.dataViewerControl = new HSA.UserInterface.DataViewerControl();
            this.graphicsTab = new System.Windows.Forms.TabPage();
            this.chartsControl1 = new HSA.UserInterface.ChartsControl();
            this.decisionTreeTab = new System.Windows.Forms.TabPage();
            this.decisionTreeControl = new HSA.UserInterface.DecisionTreeControl();
            this.predictTab = new System.Windows.Forms.TabPage();
            this.predictControl = new HSA.UserInterface.PredictControl();
            this.mainWindowTabs.SuspendLayout();
            this.dataViewTab.SuspendLayout();
            this.graphicsTab.SuspendLayout();
            this.decisionTreeTab.SuspendLayout();
            this.predictTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWindowTabs
            // 
            this.mainWindowTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainWindowTabs.Controls.Add(this.dataViewTab);
            this.mainWindowTabs.Controls.Add(this.graphicsTab);
            this.mainWindowTabs.Controls.Add(this.decisionTreeTab);
            this.mainWindowTabs.Controls.Add(this.predictTab);
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
            this.dataViewTab.Controls.Add(this.dataViewerControl);
            this.dataViewTab.Location = new System.Drawing.Point(104, 4);
            this.dataViewTab.Name = "dataViewTab";
            this.dataViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataViewTab.Size = new System.Drawing.Size(900, 553);
            this.dataViewTab.TabIndex = 0;
            this.dataViewTab.Text = "Data Viewer";
            this.dataViewTab.UseVisualStyleBackColor = true;
            // 
            // dataViewerControl
            // 
            this.dataViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewerControl.Location = new System.Drawing.Point(3, 3);
            this.dataViewerControl.Name = "dataViewerControl";
            this.dataViewerControl.Size = new System.Drawing.Size(894, 547);
            this.dataViewerControl.TabIndex = 0;
            // 
            // graphicsTab
            // 
            this.graphicsTab.Controls.Add(this.chartsControl1);
            this.graphicsTab.Location = new System.Drawing.Point(104, 4);
            this.graphicsTab.Name = "graphicsTab";
            this.graphicsTab.Padding = new System.Windows.Forms.Padding(3);
            this.graphicsTab.Size = new System.Drawing.Size(900, 553);
            this.graphicsTab.TabIndex = 1;
            this.graphicsTab.Text = "Graphics";
            this.graphicsTab.UseVisualStyleBackColor = true;
            // 
            // chartsControl1
            // 
            this.chartsControl1.AutoScroll = true;
            this.chartsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartsControl1.Location = new System.Drawing.Point(3, 3);
            this.chartsControl1.Name = "chartsControl1";
            this.chartsControl1.Size = new System.Drawing.Size(894, 547);
            this.chartsControl1.TabIndex = 0;
            // 
            // decisionTreeTab
            // 
            this.decisionTreeTab.Controls.Add(this.decisionTreeControl);
            this.decisionTreeTab.Location = new System.Drawing.Point(104, 4);
            this.decisionTreeTab.Name = "decisionTreeTab";
            this.decisionTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.decisionTreeTab.Size = new System.Drawing.Size(900, 553);
            this.decisionTreeTab.TabIndex = 2;
            this.decisionTreeTab.Text = "Decision Tree";
            this.decisionTreeTab.UseVisualStyleBackColor = true;
            // 
            // decisionTreeControl
            // 
            this.decisionTreeControl.DecisionTree = null;
            this.decisionTreeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decisionTreeControl.Location = new System.Drawing.Point(3, 3);
            this.decisionTreeControl.Name = "decisionTreeControl";
            this.decisionTreeControl.Size = new System.Drawing.Size(894, 547);
            this.decisionTreeControl.TabIndex = 0;
            // 
            // predictTab
            // 
            this.predictTab.Controls.Add(this.predictControl);
            this.predictTab.Location = new System.Drawing.Point(104, 4);
            this.predictTab.Name = "predictTab";
            this.predictTab.Padding = new System.Windows.Forms.Padding(3);
            this.predictTab.Size = new System.Drawing.Size(900, 553);
            this.predictTab.TabIndex = 3;
            this.predictTab.Text = "Predict";
            this.predictTab.UseVisualStyleBackColor = true;
            // 
            // predictControl
            // 
            this.predictControl.Location = new System.Drawing.Point(0, 0);
            this.predictControl.Name = "predictControl";
            this.predictControl.Size = new System.Drawing.Size(894, 547);
            this.predictControl.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.mainWindowTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSA";
            this.mainWindowTabs.ResumeLayout(false);
            this.dataViewTab.ResumeLayout(false);
            this.graphicsTab.ResumeLayout(false);
            this.decisionTreeTab.ResumeLayout(false);
            this.predictTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainWindowTabs;
        private System.Windows.Forms.TabPage dataViewTab;
        private System.Windows.Forms.TabPage graphicsTab;
        private DataViewerControl dataViewerControl;
        private ChartsControl chartsControl1;
        private System.Windows.Forms.TabPage decisionTreeTab;
        private DecisionTreeControl decisionTreeControl;
        private System.Windows.Forms.TabPage predictTab;
        private PredictControl predictControl;
    }
}

