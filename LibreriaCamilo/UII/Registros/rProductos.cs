using BLL;
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
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();

        }

        private void rProductos_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            ProductoIdtextBox.Clear();
            DescripciontextBox.Clear();
            CostomaskedtextBox.Clear();
            PreciomaskedtextBox.Clear();
            CantidadmaskedtextBox.Clear();
            CamposVacioserrorProvider.Clear();

            DescripciontextBox.Focus();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                CamposVacioserrorProvider.SetError(DescripciontextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(CostomaskedtextBox.Text))
            {
                CamposVacioserrorProvider.SetError(CostomaskedtextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(PreciomaskedtextBox.Text))
            {
                CamposVacioserrorProvider.SetError(PreciomaskedtextBox, "Llenar campo.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(CantidadmaskedtextBox.Text))
            {
                CamposVacioserrorProvider.SetError(CantidadmaskedtextBox, "Llenar campo.");
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
            var producto = new Productos();

            if (!Validar())
            {
                MessageBox.Show("Llenar campos vacios.");
                
            }
            else
            {
                
                producto.ProductoId = Utilidades.TOINT(ProductoIdtextBox.Text);
                producto.Descripcion = DescripciontextBox.Text;
                producto.Costo = Utilidades.TOINT(CostomaskedtextBox.Text);
                producto.Precio = Utilidades.TOINT(PreciomaskedtextBox.Text);
                producto.Cantidad = Utilidades.TOINT(CantidadmaskedtextBox.Text);

                if (Utilidades.TOINT(ProductoIdtextBox.Text) != producto.ProductoId)
                {
                    ProductosBLL.Modificar(producto);
                        MessageBox.Show("Guardado.");
                }
                else 
                {
                    if (ProductosBLL.Guardar(producto))
                        MessageBox.Show("Guardado.");
                    else
                        MessageBox.Show("No Guardado.");
                }
                Limpiar();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductoIdtextBox.Text))
            {
                MessageBox.Show("Id Vacio.");
                Limpiar();

            }
            else
            {
                int id = Utilidades.TOINT(ProductoIdtextBox.Text);
                var producto = new Productos();

                producto = ProductosBLL.Buscar(p => p.ProductoId == id);

                if (producto != null)
                {
                    DescripciontextBox.Text = producto.Descripcion;
                    CostomaskedtextBox.Text = Convert.ToString(producto.Costo);
                    PreciomaskedtextBox.Text = Convert.ToString(producto.Precio);
                    CantidadmaskedtextBox.Text = Convert.ToString(producto.Cantidad);
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
            if (string.IsNullOrEmpty(ProductoIdtextBox.Text))
            {
                MessageBox.Show("No se puede eliminar, campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(ProductoIdtextBox.Text);

                if (ProductosBLL.Eliminar(ProductosBLL.Buscar(p => p.ProductoId == id)))
                {
                    Limpiar();
                    MessageBox.Show("El Produto se elimino con exito.");
                }
                else
                {
                    MessageBox.Show("El Producto no se pudo eliminar.");
                }
            }
        }
    }
}
