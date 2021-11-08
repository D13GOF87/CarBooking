using System;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ReservasDto
    {
        public int IdReserva { get; set; }
        public float PrecioTotal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int EstadoReserva { get; set; }

        //fks
        public ClienteDto ClientesReservas { get; set; }
        public AgenciasDto AgenciasReservas { get; set; }

    }
    public class CrearReservaDto
    {
        [Required]
        public int IdReserva { get; set; }
        [Required]
        public float PrecioTotal { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaDevolucion { get; set; }
        [Required]
        public int EstadoReserva { get; set; }

        //fk obligatorias
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdAgencia { get; set; }

    }
    public class ActualizarReservaDto
    {

        public int IdReserva { get; set; }

        public float PrecioTotal { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public int EstadoReserva { get; set; }

        //fk obligatorias

        public int IdCliente { get; set; }

        public int IdAgencia { get; set; }

    }

    public class DesactivarReservaDto
    {
        public int EstadoReserva { get; set; }
    }
}
