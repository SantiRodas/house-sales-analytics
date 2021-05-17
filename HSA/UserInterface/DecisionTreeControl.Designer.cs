
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectImplementationButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // decisionTreeView
            // 
            this.decisionTreeView.Location = new System.Drawing.Point(24, 20);
            this.decisionTreeView.Name = "decisionTreeView";
            this.decisionTreeView.Size = new System.Drawing.Size(472, 506);
            this.decisionTreeView.TabIndex = 0;
          
            // 
            // implementationOption1
            // 
            this.implementationOption1.AutoSize = true;
            this.implementationOption1.Location = new System.Drawing.Point(38, 29);
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
            this.implementationOption2.Location = new System.Drawing.Point(38, 62);
            this.implementationOption2.Name = "implementationOption2";
            this.implementationOption2.Size = new System.Drawing.Size(130, 17);
            this.implementationOption2.TabIndex = 2;
            this.implementationOption2.TabStop = true;
            this.implementationOption2.Text = "Library Implementation";
            this.implementationOption2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the implementation";
            // 
            // selectImplementationButton
            // 
            this.selectImplementationButton.Location = new System.Drawing.Point(66, 94);
            this.selectImplementationButton.Name = "selectImplementationButton";
            this.selectImplementationButton.Size = new System.Drawing.Size(75, 23);
            this.selectImplementationButton.TabIndex = 4;
            this.selectImplementationButton.Text = "Select";
            this.selectImplementationButton.UseVisualStyleBackColor = true;
            this.selectImplementationButton.Click += new System.EventHandler(this.selectImplementationButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.selectImplementationButton);
            this.panel1.Controls.Add(this.implementationOption1);
            this.panel1.Controls.Add(this.implementationOption2);
            this.panel1.Location = new System.Drawing.Point(598, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 120);
            this.panel1.TabIndex = 5;
            // 
            // DecisionTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.decisionTreeView);
            this.Name = "DecisionTreeControl";
            this.Size = new System.Drawing.Size(894, 547);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView decisionTreeView;
        private System.Windows.Forms.RadioButton implementationOption1;
        private System.Windows.Forms.RadioButton implementationOption2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectImplementationButton;
        private System.Windows.Forms.Panel panel1;
    }
}
