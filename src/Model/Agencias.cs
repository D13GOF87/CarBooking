using System.Collections.Generic;

namespace Model
{
    public class Agencias
    {
        public int IdAgencia { get; set; }

        public string NombreAgencia { get; set; }

        public int EstadoAgencia { get; set; }

        //conexion con reservas
        public ICollection<Reservas> Reservas { get; set; }

    }
}
