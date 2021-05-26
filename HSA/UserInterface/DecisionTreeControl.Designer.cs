
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
            this.accuracyLabelTraining = new System.Windows.Forms.Label();
            this.heigthLimitTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resetTreeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trainingSizeSelector = new System.Windows.Forms.ComboBox();
            this.trainingLabel = new System.Windows.Forms.Label();
            this.testSizeSelector = new System.Windows.Forms.ComboBox();
            this.testSizeLabel = new System.Windows.Forms.Label();
            this.accuracyLabelTest = new System.Windows.Forms.Label();
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
            this.decisionTreeView.Location = new System.Drawing.Point(0, 48);
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
            this.splitContainer2.Panel1.Controls.Add(this.accuracyLabelTraining);
            this.splitContainer2.Panel1.Controls.Add(this.heigthLimitTxtBox);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.resetTreeButton);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.trainingSizeSelector);
            this.splitContainer2.Panel1.Controls.Add(this.trainButton);
            this.splitContainer2.Panel1.Controls.Add(this.trainingLabel);
            this.splitContainer2.Panel1.Controls.Add(this.implementationOption2);
            this.splitContainer2.Panel1.Controls.Add(this.implementationOption1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.testSizeSelector);
            this.splitContainer2.Panel2.Controls.Add(this.testSizeLabel);
            this.splitContainer2.Panel2.Controls.Add(this.accuracyLabelTest);
            this.splitContainer2.Panel2.Controls.Add(this.testingButton);
            this.splitContainer2.Panel2.Controls.Add(this.testingLabel);
            this.splitContainer2.Size = new System.Drawing.Size(282, 547);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 0;
            // 
            // accuracyLabelTraining
            // 
            this.accuracyLabelTraining.AutoSize = true;
            this.accuracyLabelTraining.Location = new System.Drawing.Point(94, 48);
            this.accuracyLabelTraining.Name = "accuracyLabelTraining";
            this.accuracyLabelTraining.Size = new System.Drawing.Size(69, 13);
            this.accuracyLabelTraining.TabIndex = 7;
            this.accuracyLabelTraining.Text = "Accuracy: -%";
            // 
            // heigthLimitTxtBox
            // 
            this.heigthLimitTxtBox.Location = new System.Drawing.Point(132, 147);
            this.heigthLimitTxtBox.Name = "heigthLimitTxtBox";
            this.heigthLimitTxtBox.Size = new System.Drawing.Size(100, 20);
            this.heigthLimitTxtBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Height Limit";
            // 
            // resetTreeButton
            // 
            this.resetTreeButton.Enabled = false;
            this.resetTreeButton.Location = new System.Drawing.Point(42, 226);
            this.resetTreeButton.Name = "resetTreeButton";
            this.resetTreeButton.Size = new System.Drawing.Size(75, 23);
            this.resetTreeButton.TabIndex = 8;
            this.resetTreeButton.Text = "Reset Tree";
            this.resetTreeButton.UseVisualStyleBackColor = true;
            this.resetTreeButton.Click += new System.EventHandler(this.resetTreeButton_Click);
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
            // trainingSizeSelector
            // 
            this.trainingSizeSelector.FormattingEnabled = true;
            this.trainingSizeSelector.Items.AddRange(new object[] {
            "0.5",
            "0.55",
            "0.6",
            "0.65",
            "0.7",
            "0.75",
            "0.8",
            "0.85",
            "0.9",
            "0.95"});
            this.trainingSizeSelector.Location = new System.Drawing.Point(133, 174);
            this.trainingSizeSelector.Name = "trainingSizeSelector";
            this.trainingSizeSelector.Size = new System.Drawing.Size(111, 21);
            this.trainingSizeSelector.TabIndex = 5;
            this.trainingSizeSelector.SelectedIndexChanged += new System.EventHandler(this.trainingSizeSelector_SelectedIndexChanged);
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
            // testSizeSelector
            // 
            this.testSizeSelector.Enabled = false;
            this.testSizeSelector.FormattingEnabled = true;
            this.testSizeSelector.Items.AddRange(new object[] {
            "0.05",
            "0.1",
            "0.15",
            "0.2",
            "0.25",
            "0.3",
            "0.35",
            "0.4",
            "0.45",
            "0.5"});
            this.testSizeSelector.Location = new System.Drawing.Point(133, 140);
            this.testSizeSelector.Name = "testSizeSelector";
            this.testSizeSelector.Size = new System.Drawing.Size(121, 21);
            this.testSizeSelector.TabIndex = 6;
            this.testSizeSelector.SelectedIndexChanged += new System.EventHandler(this.testSizeSelector_SelectedIndexChanged);
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
            // accuracyLabelTest
            // 
            this.accuracyLabelTest.AutoSize = true;
            this.accuracyLabelTest.Location = new System.Drawing.Point(94, 74);
            this.accuracyLabelTest.Name = "accuracyLabelTest";
            this.accuracyLabelTest.Size = new System.Drawing.Size(69, 13);
            this.accuracyLabelTest.TabIndex = 4;
            this.accuracyLabelTest.Text = "Accuracy: -%";
            // 
            // testingButton
            // 
            this.testingButton.Enabled = false;
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
        private System.Windows.Forms.ComboBox trainingSizeSelector;
        private System.Windows.Forms.ComboBox testSizeSelector;
        private System.Windows.Forms.Label testSizeLabel;
        private System.Windows.Forms.Label accuracyLabelTest;
        private System.Windows.Forms.Button testingButton;
        private System.Windows.Forms.Button resetTreeButton;
        private System.Windows.Forms.Label accuracyLabelTraining;
        private System.Windows.Forms.TextBox heigthLimitTxtBox;
        private System.Windows.Forms.Label label2;
    }
}
