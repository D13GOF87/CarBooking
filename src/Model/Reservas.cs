

using System;

namespace Model
{
    public class Reservas
    {
        public int IdReserva { get; set; }
        public float PrecioTotal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int EstadoReserva { get; set; }

        //fks
        public int IdCliente { get; set; }
        public Clientes ClientesReservas { get; set; }
        public int IdAgencia { get; set; }
        public Agencias AgenciasReservas { get; set; }

    }
}
