using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class FacturasProductos
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }


        public Productos Producto { get; set; }
                

        public FacturasProductos()
        {

        }
        public FacturasProductos(int productoId, string descripcion, decimal precio, decimal cantidad)
        {
            this.ProductoId = productoId;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
    }
}
