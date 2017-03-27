using LibreriaCamilo.Consultas;
using LibreriaCamilo.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibreriaCamilo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rUsuarios().Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new cUsuarios().Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rClientes().Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new cClientes().Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rProductos().Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new cProductos().Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rFacturas().Show();
        }
    }
}
