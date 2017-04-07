using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibreriaCamilo.Consultas
{
    public partial class cFactura : Form
    {
        public List<Entidades.Facturas> Lista { get; set; }

        public cFactura()
        {
            InitializeComponent();
        }

        private void cFactura_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void LlenarCombo()
        {

            FiltrarComboBox.Items.Insert(0, "Todos");
            FiltrarComboBox.Items.Insert(1, "FacturaId");
            FiltrarComboBox.Items.Insert(2, "Nombre del Cliente");
            FiltrarComboBox.Items.Insert(3, "Fecha");
            FiltrarComboBox.DataSource = FiltrarComboBox.Items;
            //FiltrarComboBox.DisplayMember = "Todos";

            if (FiltrarComboBox.Items.Count > 0)
                FiltrarComboBox.SelectedIndex = -1;
        }

        private void Filtrarbutton_Click(object sender, EventArgs e)
        {
            if (FiltrarComboBox.SelectedIndex == 0)
            {
                Lista = BLL.FacturasBLL.GetListAll();
            }
            if (FiltrarComboBox.SelectedIndex == 3)
            {
                Lista = BLL.FacturasBLL.GetList(p => p.Fecha >= DesdedateTimePicker.Value.Date && p.Fecha <= HastadateTimePicker.Value.Date);
            }
            else if (FiltrarComboBox.SelectedIndex != 0 && FiltrarComboBox.SelectedIndex != 3)
            {
                if (string.IsNullOrEmpty(FiltrartextBox.Text))
                {
                    CamposVacioserrorProvider.SetError(FiltrartextBox, "Por favor llenar este campo.");

                }
                else
                {
                    if (FiltrarComboBox.SelectedIndex == 2)
                    {
                        //Lista = BLL.FacturasBLL.GetList(p => p.ClienteId == FiltrartextBox.Text);
                    }
                    if (FiltrarComboBox.SelectedIndex == 1)
                    {
                        int id = Utilidades.TOINT(FiltrartextBox.Text);
                        Lista = BLL.FacturasBLL.GetList(p => p.FacturaId == id);
                    }
                }
            }

            FacturasdataGridView.DataSource = Lista;
            this.FacturasdataGridView.Columns["Relacion"].Visible = false;
        }

        private void FiltrartextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FacturasdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
