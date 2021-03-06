﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LibreriaCamiloDb : DbContext
    {

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }



        public LibreriaCamiloDb() : base("ConStr")
        {

        }

    }
}
