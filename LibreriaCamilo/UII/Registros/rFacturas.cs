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
    public partial class rFacturas : Form
    {
        FacturasProductos Detalle = null;
        Facturas Factura = null;
        int id;


        public rFacturas()
        {
            InitializeComponent();
            Limpiar();
        }

        private void rFacturas_Load(object sender, EventArgs e)
        {
            
        }


        private void Limpiar()
        {
            Detalle = new FacturasProductos();
            Factura = new Facturas();


            FacturaIdmaskedTextBox.Clear();
            ClienteIdmaskedTextBox.Clear();
            NombreClientetextBox.Clear();
            SubTotaltextBox.Clear();
            TotaltextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now;
            ProductoIdmaskedTextBox.Clear();
            DescripcionProductotextBox.Clear();
            ProductodataGridView.DataSource = null;
            CantidadnumericUpDown.Value = 0;
            PreciotextBox.Clear();
            CamposVacioserrorProvider.Clear();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(NombreClientetextBox.Text))
            {
                CamposVacioserrorProvider.SetError(NombreClientetextBox, "Llenar campo.");
                interruptor = false;
            }
            if (ProductodataGridView.DataSource == null)
            {
              //  ProductodataGridView.DataSource == null;
               // string.IsNullOrEmpty(ProductodataGridView.Text)
                CamposVacioserrorProvider.SetError(ProductodataGridView, "Llenar campo.");
                interruptor = false;
            }
           
            return interruptor;
        }

        private Facturas LlenarCampos()
        {
            Factura.NombreCliente = NombreClientetextBox.Text;
            Factura.FacturaId = Utilidades.TOINT(FacturaIdmaskedTextBox.Text);
            Factura.Fecha = FechadateTimePicker.Value;
            Factura.SubTotal = Utilidades.TOINT(SubTotaltextBox.Text);
            Factura.Total = Utilidades.TOINT(TotaltextBox.Text);


            return Factura;
        }

        public void LlenarDataGrid(Facturas factura)
        {
            ProductodataGridView.DataSource = null;
            ProductodataGridView.DataSource = factura.Relacion.ToList();

            this.ProductodataGridView.Columns["Id"].Visible = false;
            this.ProductodataGridView.Columns["FacturaId"].Visible = false;
            this.ProductodataGridView.Columns["Producto"].Visible = false;
        }


        private void NewButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

     

        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Factura = LlenarCampos();

                if (FacturasBLL.Guardar(Factura))
                {
                    ExistenciaProducto(CantidadnumericUpDown.Value);
                    MessageBox.Show("Guardado.");
                    Limpiar();
                }
                else
                    MessageBox.Show("No Guardado.");
            }
        }

        private void ExistenciaProducto(decimal cantidad)
        {
            foreach (DataGridViewRow producto in ProductodataGridView.Rows)
            {
                int id = Convert.ToInt32(producto.Cells[2].Value);
                cantidad = Convert.ToDecimal(producto.Cells[5].Value);

                Detalle.Producto = ProductosBLL.BuscarOtro(id);
                Detalle.Producto.Cantidad -= cantidad;
                ProductosBLL.Modificar(Detalle.Producto);
            }
        }


        private void BuscarFactura()
        {
            if (string.IsNullOrEmpty(FacturaIdmaskedTextBox.Text))
            {
                MessageBox.Show("Inserte un Id.");
                Limpiar();
            }
            else
            {
                Facturas factura = new Facturas();
                int id = Utilidades.TOINT(FacturaIdmaskedTextBox.Text);

                factura = FacturasBLL.Buscar(p => p.FacturaId == id);

                if (factura != null)
                {
                    NombreClientetextBox.Text = factura.NombreCliente;
                    FechadateTimePicker.Value = factura.Fecha;

                    SubTotaltextBox.Text = factura.SubTotal.ToString();
                    SubTotaltextBox.Text = factura.SubTotal.ToString();

                    LlenarDataGrid(factura);
                }
                else
                {
                    MessageBox.Show("La factura no exite.");
                    Limpiar();
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            BuscarFactura();
        }

        private void AgregarProducto()
        {
            if (!string.IsNullOrEmpty(DescripcionProductotextBox.Text))
            {
                if (CantidadnumericUpDown.Value != 0)
                {
                    if (Detalle.Producto.Cantidad >= CantidadnumericUpDown.Value)
                    {
                        if (Factura.Relacion.Count() == 0 || id != Utilidades.TOINT(ProductoIdmaskedTextBox.Text))
                        {
                            Factura.Relacion.Add(new FacturasProductos(Detalle.Producto.ProductoId, Detalle.Producto.Descripcion, Detalle.Producto.Precio, CantidadnumericUpDown.Value));
                            LlenarDataGrid(Factura);

                            CantidadnumericUpDown.Enabled = false;
                            CalculoSubTotal();
                            ProductoIdmaskedTextBox.Clear();

                            id = Detalle.Producto.ProductoId;
                        }
                        else
                        {
                            MessageBox.Show("Producto Ya Existe.");
                            DescripcionProductotextBox.Clear();
                            PreciotextBox.Clear();
                            CantidadnumericUpDown.Text = "0";
                            CantidadnumericUpDown.Enabled = false;
                            ProductoIdmaskedTextBox.Focus();
                        }
                    }
                    else
                    {
                        if (Detalle.Producto.Cantidad <= 0)
                        {
                            MessageBox.Show("No queda producto de ese tipo");
                            ProductoIdmaskedTextBox.Clear();
                            DescripcionProductotextBox.Clear();
                            CantidadnumericUpDown.Text = "0";

                            ProductoIdmaskedTextBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad excede la existencia, se cuenta con (" + Detalle.Producto.Cantidad + ") " + Detalle.Producto.Descripcion + ".");
                            CantidadnumericUpDown.Focus();
                        }
                    }
                }
                else
                {
                    CamposVacioserrorProvider.SetError(CantidadnumericUpDown, "Digite una cantidad diferente de (0).");
                    CantidadnumericUpDown.Focus();
                }
            }
            else
            {
                CamposVacioserrorProvider.SetError(ProductoIdmaskedTextBox, "Busque un producto para poder agregar.");
            }

            ClienteIdmaskedTextBox.Clear();
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void CalculoSubTotal()
        {
            Factura.SubTotal += Detalle.Producto.Precio * CantidadnumericUpDown.Value;
            SubTotaltextBox.Text = Factura.SubTotal.ToString();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FacturaIdmaskedTextBox.Text))
            {
                MessageBox.Show("No se puede eliminar, campos vacios.");
                FacturaIdmaskedTextBox.Clear();
            }
            else
            {
                    int id = Utilidades.TOINT(FacturaIdmaskedTextBox.Text);

                    if (FacturasBLL.Eliminar(FacturasBLL.Buscar(p => p.FacturaId == id)))
                    {
                        Limpiar();
                        MessageBox.Show("Factura eliminada con exito.");
                    }
                    else
                        MessageBox.Show("No se pudo eliminar la factura.");
            }
        }



        private void BuscarProducto()
        {
            if (!string.IsNullOrEmpty(ProductoIdmaskedTextBox.Text))
            {
                int id = Utilidades.TOINT(ProductoIdmaskedTextBox.Text);
                Detalle.Producto = ProductosBLL.Buscar(p => p.ProductoId == id);


                if (Detalle.Producto != null)
                {
                    DescripcionProductotextBox.Text = Detalle.Producto.Descripcion;
                    PreciotextBox.Text = Detalle.Producto.Precio.ToString();
                    CantidadnumericUpDown.Focus();
                }
                else
                {
                    ProductoIdmaskedTextBox.Clear();
                    CamposVacioserrorProvider.SetError(ProductoIdmaskedTextBox, "No existe un producto con ese id.");
                    DescripcionProductotextBox.Clear();
                    PreciotextBox.Clear();
                    ProductoIdmaskedTextBox.Focus();
                }
            }
            else
            {
                DescripcionProductotextBox.Clear();
                CamposVacioserrorProvider.SetError(ProductoIdmaskedTextBox, "Digite el id de un producto.");
                ProductoIdmaskedTextBox.Focus();
            }
        }

        private void ProductosearchButton_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }



        private void BuscarCliente()
        {
            if (!string.IsNullOrEmpty(ClienteIdmaskedTextBox.Text))
            {
                int id = Utilidades.TOINT(ClienteIdmaskedTextBox.Text);
                Clientes cliente = new Clientes();

                cliente = BLL.ClientesBLL.Buscar(p => p.ClienteId == id);

                if (cliente != null)
                {
                    NombreClientetextBox.Text = cliente.Nombres;
                    ProductoIdmaskedTextBox.Focus();
                }
                else
                {
                    ClienteIdmaskedTextBox.Clear();
                    NombreClientetextBox.Clear();
                    CamposVacioserrorProvider.SetError(ClienteIdmaskedTextBox, "Id no Existente.");
                    ClienteIdmaskedTextBox.Focus();
                }
            }
            else
            {
                CamposVacioserrorProvider.SetError(ClienteIdmaskedTextBox, "Ingrese un Id.");
                NombreClientetextBox.Clear();
                ClienteIdmaskedTextBox.Focus();
            }
        }

        private void ClientesearchButton_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }
    }
}
