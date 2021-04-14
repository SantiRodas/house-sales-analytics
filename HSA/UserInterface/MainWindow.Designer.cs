
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
            this.graphicsTab = new System.Windows.Forms.TabPage();
            this.mainWindowTabs.SuspendLayout();
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
            this.dataViewTab.Location = new System.Drawing.Point(104, 4);
            this.dataViewTab.Name = "dataViewTab";
            this.dataViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataViewTab.Size = new System.Drawing.Size(900, 553);
            this.dataViewTab.TabIndex = 0;
            this.dataViewTab.Text = "Data Viewer";
            this.dataViewTab.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainWindowTabs;
        private System.Windows.Forms.TabPage dataViewTab;
        private System.Windows.Forms.TabPage graphicsTab;
    }
}

