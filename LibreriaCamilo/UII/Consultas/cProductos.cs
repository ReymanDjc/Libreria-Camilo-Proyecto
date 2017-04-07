using BLL;
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
    public partial class cProductos : Form
    {
        public cProductos()
        {
            InitializeComponent();
        }

        private void cProductos_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void LlenarCombo()
        {

            FiltrarComboBox.Items.Insert(0, "Todos");
            FiltrarComboBox.Items.Insert(1, "ProductosId");
            FiltrarComboBox.Items.Insert(2, "Descripcion");
            FiltrarComboBox.Items.Insert(3, "Costo");
            FiltrarComboBox.Items.Insert(4, "Precio");
            FiltrarComboBox.DataSource = FiltrarComboBox.Items;
            //FiltrarComboBox.DisplayMember = "Todos";

            if (FiltrarComboBox.Items.Count > 0)
                FiltrarComboBox.SelectedIndex = -1;
        }

        private void Filtrarbutton_Click(object sender, EventArgs e)
        {
            if (FiltrarComboBox.SelectedIndex == 0)
                ProductosdataGridView.DataSource = ProductosBLL.GetListAll();
            else
            if (FiltrarComboBox.SelectedIndex == 1)
            {
                int id = Utilidades.TOINT(FiltrartextBox.Text);
                ProductosdataGridView.DataSource = ProductosBLL.GetList(p => p.ProductoId == id);
            }
            else
            if (FiltrarComboBox.SelectedIndex == 2)
                ProductosdataGridView.DataSource = ProductosBLL.GetList(p => p.Descripcion == FiltrartextBox.Text);
            else
            if (FiltrarComboBox.SelectedIndex == 3)
            {
                int costo = Utilidades.TOINT(FiltrartextBox.Text);
                ProductosdataGridView.DataSource = ProductosBLL.GetList(p => p.Costo == costo);
            }
            else
            if (FiltrarComboBox.SelectedIndex == 4)
            {
                int precio = Utilidades.TOINT(FiltrartextBox.Text);
                ProductosdataGridView.DataSource = ProductosBLL.GetList(p => p.Precio == precio);
            }

        }
    }
}
