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
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClienteIdtextBox.Text))
            {
                MessageBox.Show("Id Vacio.");
                Limpiar();

            }
            else
            {
                int id = Utilidades.TOINT(ClienteIdtextBox.Text);
                var cliente = new Clientes();

                cliente = ClientesBLL.Buscar(p => p.ClienteId == id);

                if (cliente != null)
                {
                    NombretextBox.Text = cliente.Nombres;
                    DirecciontextBox.Text = cliente.Direccion;
                    EmailtextBox.Text = cliente.Email;
                    TelefonomaskedTextBox.Text = cliente.Telefono;
                }
                else
                {
                    MessageBox.Show("No existe.");
                    Limpiar();
                }
            }
        }

        private void rClientes_Load(object sender, EventArgs e)
        {

        }




        private void Limpiar()
        {
            ClienteIdtextBox.Clear();
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            EmailtextBox.Clear();
            TelefonomaskedTextBox.Clear();
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
            if (string.IsNullOrEmpty(DirecciontextBox.Text))
            {
                CamposVacioserrorProvider.SetError(DirecciontextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(EmailtextBox.Text))
            {
                CamposVacioserrorProvider.SetError(EmailtextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(TelefonomaskedTextBox.Text))
            {
                CamposVacioserrorProvider.SetError(TelefonomaskedTextBox, "Llenar campo.");
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
                var cliente = new Clientes();

                cliente.ClienteId = Utilidades.TOINT(ClienteIdtextBox.Text);
                cliente.Nombres = NombretextBox.Text;
                cliente.Direccion = DirecciontextBox.Text;
                cliente.Email = EmailtextBox.Text;
                cliente.Telefono = TelefonomaskedTextBox.Text;

                if (cliente != null)
                {

                    if (ClientesBLL.Guardar(cliente))
                        MessageBox.Show("Guardado.");
                    else
                        MessageBox.Show("No Guardado.");
                }

                Limpiar();
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClienteIdtextBox.Text))
            {
                MessageBox.Show("No se puede eliminar, campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(ClienteIdtextBox.Text);

                if (ClientesBLL.Eliminar(ClientesBLL.Buscar(p => p.ClienteId == id)))
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