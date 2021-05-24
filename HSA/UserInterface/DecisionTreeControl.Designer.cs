
namespace HSA.UserInterface
{
    partial class DecisionTreeControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.decisionTreeView = new System.Windows.Forms.TreeView();
            this.implementationOption1 = new System.Windows.Forms.RadioButton();
            this.implementationOption2 = new System.Windows.Forms.RadioButton();
            this.trainButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.trainingLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.testSizeLabel = new System.Windows.Forms.Label();
            this.efficiencyLabel = new System.Windows.Forms.Label();
            this.testingButton = new System.Windows.Forms.Button();
            this.testingLabel = new System.Windows.Forms.Label();
            this.treeVisualizerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // decisionTreeView
            // 
            this.decisionTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decisionTreeView.FullRowSelect = true;
            this.decisionTreeView.Location = new System.Drawing.Point(3, 48);
            this.decisionTreeView.Name = "decisionTreeView";
            this.decisionTreeView.ShowNodeToolTips = true;
            this.decisionTreeView.Size = new System.Drawing.Size(605, 499);
            this.decisionTreeView.TabIndex = 0;
            // 
            // implementationOption1
            // 
            this.implementationOption1.AutoSize = true;
            this.implementationOption1.Location = new System.Drawing.Point(70, 74);
            this.implementationOption1.Name = "implementationOption1";
            this.implementationOption1.Size = new System.Drawing.Size(120, 17);
            this.implementationOption1.TabIndex = 1;
            this.implementationOption1.TabStop = true;
            this.implementationOption1.Text = "Own implementation";
            this.implementationOption1.UseVisualStyleBackColor = true;
            // 
            // implementationOption2
            // 
            this.implementationOption2.AutoSize = true;
            this.implementationOption2.Location = new System.Drawing.Point(66, 107);
            this.implementationOption2.Name = "implementationOption2";
            this.implementationOption2.Size = new System.Drawing.Size(130, 17);
            this.implementationOption2.TabIndex = 2;
            this.implementationOption2.TabStop = true;
            this.implementationOption2.Text = "Library Implementation";
            this.implementationOption2.UseVisualStyleBackColor = true;
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(132, 226);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 23);
            this.trainButton.TabIndex = 4;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.selectImplementationButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeVisualizerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.decisionTreeView);
            this.splitContainer1.Size = new System.Drawing.Size(894, 547);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer2.Panel1.Controls.Add(this.trainButton);
            this.splitContainer2.Panel1.Controls.Add(this.trainingLabel);
            this.splitContainer2.Panel1.Controls.Add(this.implementationOption2);
            this.splitContainer2.Panel1.Controls.Add(this.implementationOption1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer2.Panel2.Controls.Add(this.testSizeLabel);
            this.splitContainer2.Panel2.Controls.Add(this.efficiencyLabel);
            this.splitContainer2.Panel2.Controls.Add(this.testingButton);
            this.splitContainer2.Panel2.Controls.Add(this.testingLabel);
            this.splitContainer2.Size = new System.Drawing.Size(282, 547);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reset Tree";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Training size \r\n(% of original data set):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0.5",
            "0.55",
            "0.6",
            "0.65",
            "0.7",
            "0.75",
            "0.8",
            "0.85",
            "0.9",
            "0.95",
            "1"});
            this.comboBox2.Location = new System.Drawing.Point(133, 174);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(111, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // trainingLabel
            // 
            this.trainingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.trainingLabel.AutoSize = true;
            this.trainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingLabel.Location = new System.Drawing.Point(88, 12);
            this.trainingLabel.Name = "trainingLabel";
            this.trainingLabel.Size = new System.Drawing.Size(87, 24);
            this.trainingLabel.TabIndex = 3;
            this.trainingLabel.Text = "Training";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0.1",
            "0.15",
            "0.2",
            "0.25",
            "0.3",
            "0.35",
            "0.4",
            "0.45",
            "0.5"});
            this.comboBox1.Location = new System.Drawing.Point(133, 140);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // testSizeLabel
            // 
            this.testSizeLabel.AutoSize = true;
            this.testSizeLabel.Location = new System.Drawing.Point(4, 135);
            this.testSizeLabel.Name = "testSizeLabel";
            this.testSizeLabel.Size = new System.Drawing.Size(113, 26);
            this.testSizeLabel.TabIndex = 5;
            this.testSizeLabel.Text = "Test size \r\n(% of original data set):";
            this.testSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // efficiencyLabel
            // 
            this.efficiencyLabel.AutoSize = true;
            this.efficiencyLabel.Location = new System.Drawing.Point(94, 74);
            this.efficiencyLabel.Name = "efficiencyLabel";
            this.efficiencyLabel.Size = new System.Drawing.Size(73, 13);
            this.efficiencyLabel.TabIndex = 4;
            this.efficiencyLabel.Text = "Efficiency: 0%";
            // 
            // testingButton
            // 
            this.testingButton.Location = new System.Drawing.Point(97, 214);
            this.testingButton.Name = "testingButton";
            this.testingButton.Size = new System.Drawing.Size(75, 23);
            this.testingButton.TabIndex = 3;
            this.testingButton.Text = "Test";
            this.testingButton.UseVisualStyleBackColor = true;
            this.testingButton.Click += new System.EventHandler(this.testingButton_Click);
            // 
            // testingLabel
            // 
            this.testingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.testingLabel.AutoSize = true;
            this.testingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testingLabel.Location = new System.Drawing.Point(93, 22);
            this.testingLabel.Name = "testingLabel";
            this.testingLabel.Size = new System.Drawing.Size(79, 24);
            this.testingLabel.TabIndex = 2;
            this.testingLabel.Text = "Testing";
            // 
            // treeVisualizerLabel
            // 
            this.treeVisualizerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.treeVisualizerLabel.AutoSize = true;
            this.treeVisualizerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVisualizerLabel.Location = new System.Drawing.Point(229, 12);
            this.treeVisualizerLabel.Name = "treeVisualizerLabel";
            this.treeVisualizerLabel.Size = new System.Drawing.Size(151, 24);
            this.treeVisualizerLabel.TabIndex = 1;
            this.treeVisualizerLabel.Text = "Tree Visualizer";
            // 
            // DecisionTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DecisionTreeControl";
            this.Size = new System.Drawing.Size(894, 547);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView decisionTreeView;
        private System.Windows.Forms.RadioButton implementationOption1;
        private System.Windows.Forms.RadioButton implementationOption2;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label trainingLabel;
        private System.Windows.Forms.Label testingLabel;
        private System.Windows.Forms.Label treeVisualizerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label testSizeLabel;
        private System.Windows.Forms.Label efficiencyLabel;
        private System.Windows.Forms.Button testingButton;
        private System.Windows.Forms.Button button1;
    }
}
