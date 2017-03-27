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
    public partial class cClientes : Form
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void cClientes_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void LlenarCombo()
        {

            FiltrarComboBox.Items.Insert(0, "Todos");
            FiltrarComboBox.Items.Insert(1, "ClientesId");
            FiltrarComboBox.Items.Insert(2, "Nombres");
            FiltrarComboBox.Items.Insert(3, "Direccion");
            FiltrarComboBox.Items.Insert(4, "Email");
            FiltrarComboBox.DataSource = FiltrarComboBox.Items;
            //FiltrarComboBox.DisplayMember = "Todos";

            if (FiltrarComboBox.Items.Count > 0)
                FiltrarComboBox.SelectedIndex = -1;
        }

        private void Filtrarbutton_Click(object sender, EventArgs e)
        {
            if (FiltrarComboBox.SelectedIndex == 0)
                ClientesdataGridView.DataSource = ClientesBLL.GetListAll();
            else
            if (FiltrarComboBox.SelectedIndex == 1)
            {
                int id = Utilidades.TOINT(FiltrartextBox.Text);
                ClientesdataGridView.DataSource = ClientesBLL.GetList(p => p.ClienteId == id);
            } 
            else
            if (FiltrarComboBox.SelectedIndex == 2)
                ClientesdataGridView.DataSource = ClientesBLL.GetList(p => p.Nombres == FiltrartextBox.Text);
            else
            if (FiltrarComboBox.SelectedIndex == 3)
                ClientesdataGridView.DataSource = ClientesBLL.GetList(p => p.Direccion == FiltrartextBox.Text);
            else
            if (FiltrarComboBox.SelectedIndex == 4)
                ClientesdataGridView.DataSource = ClientesBLL.GetList(p => p.Email == FiltrartextBox.Text);
                
        }
    }
}
