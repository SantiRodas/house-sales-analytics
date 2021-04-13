
namespace ValleTemperatures
{
    partial class TableShow
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MunicipioCombo = new System.Windows.Forms.ComboBox();
            this.ZonaText = new System.Windows.Forms.TextBox();
            this.numeroMin = new System.Windows.Forms.NumericUpDown();
            this.numeroMax = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMunicipio = new System.Windows.Forms.Button();
            this.btnZona = new System.Windows.Forms.Button();
            this.btnTemperaturas = new System.Windows.Forms.Button();
            this.BorrarFiltro = new System.Windows.Forms.Button();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroMax)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowMap);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Show charts";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ShowCharts);
            // 
            // dgv
            // 
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgv.Location = new System.Drawing.Point(24, 111);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1245, 394);
            this.dgv.TabIndex = 3;
            // 
            // Cod
            // 
            this.Cod.HeaderText = "Codigo Estacion";
            this.Cod.Name = "Cod";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Codigo Sensor";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha Observacion";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Valor observado";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nombre Estacion";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Departamento";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Municipio";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Zona Hidrografica";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Latitud";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Longitud";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Descripción Sensor";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Unidad Medida";
            this.Column12.Name = "Column12";
            // 
            // MunicipioCombo
            // 
            this.MunicipioCombo.FormattingEnabled = true;
            this.MunicipioCombo.Items.AddRange(new object[] {
            "Alcalá",
            "Ansermanuevo",
            "Argelia",
            "Buenaventura",
            "Buga",
            "Caicedonia",
            "Cali",
            "Cartago",
            "Cumbre",
            "Dagua",
            "Florida",
            "Ginebra",
            "Jamundí",
            "Palmira",
            "Restrepo",
            "Sevilla",
            "Trujillo",
            "Tuluá"});
            this.MunicipioCombo.Location = new System.Drawing.Point(351, 36);
            this.MunicipioCombo.Name = "MunicipioCombo";
            this.MunicipioCombo.Size = new System.Drawing.Size(188, 21);
            this.MunicipioCombo.TabIndex = 4;
            this.MunicipioCombo.Text = "Municipio";
            // 
            // ZonaText
            // 
            this.ZonaText.Location = new System.Drawing.Point(586, 37);
            this.ZonaText.Name = "ZonaText";
            this.ZonaText.Size = new System.Drawing.Size(188, 20);
            this.ZonaText.TabIndex = 5;
            this.ZonaText.Text = "Zona Hidrografica";
            // 
            // numeroMin
            // 
            this.numeroMin.Location = new System.Drawing.Point(896, 38);
            this.numeroMin.Name = "numeroMin";
            this.numeroMin.Size = new System.Drawing.Size(120, 20);
            this.numeroMin.TabIndex = 6;
            // 
            // numeroMax
            // 
            this.numeroMax.Location = new System.Drawing.Point(1101, 38);
            this.numeroMax.Name = "numeroMax";
            this.numeroMax.Size = new System.Drawing.Size(120, 20);
            this.numeroMax.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(779, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1003, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Intervalo temperaturas ";
            // 
            // btnMunicipio
            // 
            this.btnMunicipio.Location = new System.Drawing.Point(376, 72);
            this.btnMunicipio.Name = "btnMunicipio";
            this.btnMunicipio.Size = new System.Drawing.Size(133, 23);
            this.btnMunicipio.TabIndex = 10;
            this.btnMunicipio.Text = "Filtrar por municipio";
            this.btnMunicipio.UseVisualStyleBackColor = true;
            this.btnMunicipio.Click += new System.EventHandler(this.btnMunicipio_Click);
            // 
            // btnZona
            // 
            this.btnZona.Location = new System.Drawing.Point(600, 72);
            this.btnZona.Name = "btnZona";
            this.btnZona.Size = new System.Drawing.Size(160, 23);
            this.btnZona.TabIndex = 11;
            this.btnZona.Text = "Filtrar por zona hidrografica";
            this.btnZona.UseVisualStyleBackColor = true;
            this.btnZona.Click += new System.EventHandler(this.btnZona_Click);
            // 
            // btnTemperaturas
            // 
            this.btnTemperaturas.Location = new System.Drawing.Point(958, 72);
            this.btnTemperaturas.Name = "btnTemperaturas";
            this.btnTemperaturas.Size = new System.Drawing.Size(191, 23);
            this.btnTemperaturas.TabIndex = 12;
            this.btnTemperaturas.Text = "Filtrar por intervalo de temperaturas";
            this.btnTemperaturas.UseVisualStyleBackColor = true;
            this.btnTemperaturas.Click += new System.EventHandler(this.btnTemperaturas_Click);
            // 
            // BorrarFiltro
            // 
            this.BorrarFiltro.Location = new System.Drawing.Point(531, 516);
            this.BorrarFiltro.Name = "BorrarFiltro";
            this.BorrarFiltro.Size = new System.Drawing.Size(146, 58);
            this.BorrarFiltro.TabIndex = 13;
            this.BorrarFiltro.Text = "Borrar filtros";
            this.BorrarFiltro.UseVisualStyleBackColor = true;
            this.BorrarFiltro.Click += new System.EventHandler(this.BorrarFiltro_Click);
            // 
            // TableShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 586);
            this.Controls.Add(this.BorrarFiltro);
            this.Controls.Add(this.btnTemperaturas);
            this.Controls.Add(this.btnZona);
            this.Controls.Add(this.btnMunicipio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeroMax);
            this.Controls.Add(this.numeroMin);
            this.Controls.Add(this.ZonaText);
            this.Controls.Add(this.MunicipioCombo);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TableShow";
            this.Text = "ChartShow";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox MunicipioCombo;
        private System.Windows.Forms.TextBox ZonaText;
        private System.Windows.Forms.NumericUpDown numeroMin;
        private System.Windows.Forms.NumericUpDown numeroMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMunicipio;
        private System.Windows.Forms.Button btnZona;
        private System.Windows.Forms.Button btnTemperaturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button BorrarFiltro;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}

