using System.Collections.Generic;

namespace Model
{
    public class ColoresVehiculo
    {
        public int IdColorVehiculo { get; set; }
        public string NombreColorVehiculo { get; set; }

        public int EstadoColorVehiculo { get; set; }

        //aqui va la conexion con vehiculos
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
