﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente{ get; set; }



        public virtual ICollection<FacturasProductos> Relacion { get; set; }


        public Facturas()
        {
            this.Relacion = new HashSet<FacturasProductos>();
        }
















       /* public Facturas(int facturaId, int clienteId, DateTime fecha, float subTotal, float total)
        {

            this.FacturaId = facturaId;
            this.ClienteId = clienteId;
            this.Fecha = fecha;
            this.SubTotal = subTotal;
            this.Total = total;
            Productos = new List<FacturasProductos>();

        }*/

    }
}
