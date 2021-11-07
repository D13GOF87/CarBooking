using System.Collections.Generic;

namespace Model
{
    public class MarcasVehiculo
    {
        public int IdMarcaVehiculo { get; set; }
        public string NombreMarcaVehiculo { get; set; }
        public int EstadoMarcaVehiculo { get; set; }

        //aqui va la conexion con vehiculos
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
