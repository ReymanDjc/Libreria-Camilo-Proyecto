using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public Usuarios()
        {

        }
        public Usuarios(int usuarioId, string nombre,string clave)
        {
            this.UsuarioId = usuarioId;
            this.Nombres = nombre;
            this.Clave = clave;
        }
    }
    
}
