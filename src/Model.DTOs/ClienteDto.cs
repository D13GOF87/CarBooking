using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ClienteDto
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

    public class CrearClienteDto
    {
        [Required]
        public string Identifacion { get; set; }
        [Required]
        public string NombresCliente { get; set; }
        [Required]
        public string ApellidosCliente { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string email { get; set; }

        public int EstadoCliente { get; set; }

    }

    public class ActualizarClienteDto
    {
        public string Identifacion { get; set; }

        public string NombresCliente { get; set; }

        public string ApellidosCliente { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string email { get; set; }

        public int EstadoCliente { get; set; }

    }
}
