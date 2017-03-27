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

namespace LibreriaCamilo.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
            
        }

        private void rUsuarios_Load(object sender, EventArgs e)
        {
        
        }

        private void Limpiar()
        {
            UsuarioIdtextBox.Clear();
            NombretextBox.Clear();
            ClavetextBox.Clear();
            ConfirmartextBox.Clear();
            CamposVacioserrorProvider.Clear();


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
            if (string.IsNullOrEmpty(ConfirmartextBox.Text))
            {
                CamposVacioserrorProvider.SetError(ConfirmartextBox, "Llenar campo.");
                interruptor = false;
            }

            return interruptor;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Llenar campos vacios.");
                Limpiar();
            }
            else
            {
                var usuario = new Usuarios();

                usuario.UsuarioId = Utilidades.TOINT(UsuarioIdtextBox.Text);
                usuario.Nombres = NombretextBox.Text;
                usuario.Clave = ClavetextBox.Text;
                usuario.ConfirmarClave = ConfirmartextBox.Text;

                if (usuario != null)
                {

                    if (UsuariosBLL.Guardar(usuario))
                        MessageBox.Show("Guardado.");
                    else
                        MessageBox.Show("No Guardado.");
                }

                Limpiar();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsuarioIdtextBox.Text))
            {
                MessageBox.Show("Id Vacio.");
                Limpiar();

            }
            else
            {
                int id = Utilidades.TOINT(UsuarioIdtextBox.Text);
                var usuario = new Usuarios();

                usuario = UsuariosBLL.Buscar(p => p.UsuarioId == id);

                if (usuario != null)
                {
                    NombretextBox.Text = usuario.Nombres;
                    ClavetextBox.Text = usuario.Clave;
                    ConfirmartextBox.Text = usuario.ConfirmarClave;
                }
                else
                {
                    MessageBox.Show("No existe.");
                    Limpiar();
                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsuarioIdtextBox.Text))
            {
                MessageBox.Show("No se puede eliminar, campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(UsuarioIdtextBox.Text);

                if (UsuariosBLL.Eliminar(UsuariosBLL.Buscar(p => p.UsuarioId == id)))
                {
                    Limpiar();
                    MessageBox.Show("El Usuario se elimino con exito.");
                }
                else
                {
                    MessageBox.Show("El Usuario no se pudo eliminar.");
                }
            }
        }



    }
}