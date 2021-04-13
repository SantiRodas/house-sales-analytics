using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ValleTemperatures.ui;
using Control = ValleTemperatures.ui.Control;

namespace ValleTemperatures
{
    public partial class TableShow : Form
    {
        private Control c = new Control();
        public TableShow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            OpenFileDialog fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string absolutePathFile = fileExplorer.FileName;


                    if (absolutePathFile.Contains(".csv"))
                    {

                        List<string[]> rowsDvg = c.LoadData(absolutePathFile);

                        dgv.AllowUserToAddRows = false;
                        ShowGrid(rowsDvg);
                        this.Show();
                        this.BringToFront();

                    }
                    else
                    {
                        MessageBox.Show("Error, no se puede leer el archivo seleccionado.");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }
        }

    

        private void ShowGrid(List<string[]> rowsDvg)
        {
            dgv.Rows.Clear();

            foreach (string[] line in rowsDvg)
            {

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dgv);

                for (int i = 0; i < 12; i++)
                {
                    dataGridViewRow.Cells[i].Value = line[i];
                    if (i == 11)
                    {
                        dgv.Rows.Add(dataGridViewRow);
                    }

                }

            }
        }

        private void ShowMap(object sender, EventArgs e)
        {
            MapShow map = new MapShow(c.Coordenadas());
            map.Show();
            MessageBox.Show("Se ha generado el mapa con los sensores");
        }

        private void ShowCharts(object sender, EventArgs e)
        {
            ChartShow chart = new ChartShow(c.RetrieveTempData(), c.RetrieveZonaData(), c.RetrieveCantidadData());
            chart.Show();
            MessageBox.Show("Se han generado las graficas");
        }

        private void btnMunicipio_Click(object sender, EventArgs e)
        {
            string comboBoxText = MunicipioCombo.GetItemText(MunicipioCombo.SelectedItem);

            if (comboBoxText.Equals("Municipio"))
            {
                MessageBox.Show("Error: No se ha seleccionado ningun municipio");
            }
            else
            {
                List<string[]> rowsDvg = c.FilterByMun(comboBoxText);

                dgv.AllowUserToAddRows = false;
                ShowGrid(rowsDvg);
                this.Show();
                this.BringToFront();
            }
        }

        private void btnZona_Click(object sender, EventArgs e)
        {
            string textBoxText = ZonaText.Text;

            if (textBoxText.Equals("Zona Hidrografica"))
            {
                MessageBox.Show("Error: No se ha introducido ninguna zona hidrografica");
            }
            else
            {
                List<string[]> rowsDvg = c.FilterByZona(textBoxText);

                dgv.AllowUserToAddRows = false;
                ShowGrid(rowsDvg);
                this.Show();
                this.BringToFront();
            }
        }

        private void btnTemperaturas_Click(object sender, EventArgs e)
        {
            double minValue = Decimal.ToDouble(numeroMin.Value);
            double maxValue = Decimal.ToDouble(numeroMax.Value);

            List<string[]> rowsDvg = c.FilterByRange(minValue, maxValue);

            dgv.AllowUserToAddRows = false;
            ShowGrid(rowsDvg);
            this.Show();
            this.BringToFront();
            
        }

        private void BorrarFiltro_Click(object sender, EventArgs e)
        {
            List<string[]> rowsDvg = c.GetOriginalRecords();

            dgv.AllowUserToAddRows = false;
            ShowGrid(rowsDvg);
            this.Show();
            this.BringToFront();
        }
    }
}
