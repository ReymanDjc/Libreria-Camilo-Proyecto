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
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void cUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void LlenarCombo()
        {
            
            FiltrarComboBox.Items.Insert(0, "Todos");
            FiltrarComboBox.Items.Insert(1, "Nombres");
            FiltrarComboBox.Items.Insert(2, "UsuarioId");
            FiltrarComboBox.DataSource = FiltrarComboBox.Items;
           // FiltrarComboBox.DisplayMember = "Todos";

            if (FiltrarComboBox.Items.Count > 0)
                FiltrarComboBox.SelectedIndex = -1;
        }

        private void Filtrarbutton_Click(object sender, EventArgs e)
        {
            if (FiltrarComboBox.SelectedIndex == 0)
                UsuariosdataGridView.DataSource = UsuariosBLL.GetListAll();
            else
            if (FiltrarComboBox.SelectedIndex == 1)
                UsuariosdataGridView.DataSource = UsuariosBLL.GetList(p => p.Nombres == FiltrartextBox.Text);
            else
            if (FiltrarComboBox.SelectedIndex == 2)
            {
                int id = Utilidades.TOINT(FiltrartextBox.Text);
                UsuariosdataGridView.DataSource = UsuariosBLL.GetList(p => p.UsuarioId == id);
            }
               

        }
    }
}
