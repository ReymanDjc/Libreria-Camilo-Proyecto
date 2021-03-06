﻿using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibreriaCamilo.Extra
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            NombretextBox.Clear();
            ClavetextBox.Clear();
            NombretextBox.Focus();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                CamposVacioserrorProvider.SetError(NombretextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(ClavetextBox.Text))
            {
                CamposVacioserrorProvider.SetError(ClavetextBox, "Llenar campo.");
                interruptor = false;
            }
          
            return interruptor;
        }
            
        private void Entrarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = null;
            if (NombretextBox.Text == "admin")
            {
                usuario = new Usuarios(1, "Admin", "1234");
            }
            else
            {
                usuario = UsuariosBLL.Buscar(p => p.Nombres == NombretextBox.Text);
            }
            if (usuario != null)
            {
                if (ClavetextBox.Text == usuario.Clave)
                {
                   Limpiar();
                    this.Hide();
                    new MainForm().Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta...");
                    NombretextBox.Clear();
                    ClavetextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Usuario no Existe..");
                NombretextBox.Clear();
                ClavetextBox.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClavetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void enter()
        {
            Usuarios usuario = null;
            if (NombretextBox.Text == "admin")
            {
                usuario = new Usuarios(1, "Admin", "1234");
            }
            else
            {
                usuario = UsuariosBLL.Buscar(p => p.Nombres == NombretextBox.Text);
            }
            if (usuario != null)
            {
                if (ClavetextBox.Text == usuario.Clave)
                {
                    Limpiar();
                    this.Hide();
                    new MainForm().Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta...");
                    NombretextBox.Clear();
                    ClavetextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Usuario no Existe..");
                NombretextBox.Clear();
                ClavetextBox.Clear();
            }
        }

        private void ClavetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                enter();
            }
        }
    }
}
