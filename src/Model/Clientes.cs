using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Identifacion { get; set; }

        public string NombresCliente { get; set; }

        public string ApellidosCliente { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string email { get; set; }

        public int EstadoCliente { get; set; }
    }
}
