using System.Collections.Generic;

namespace Model
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        //no estoy seguro si es float o double
        public float PrecioDiarioVehiculo { get; set; }
        //este es varchar de 200 no?
        public string ImagenVehiculo { get; set; }
        public string AnioVehiculo{ get; set; }
        public string KilometrajeVehiculo{ get; set; }
        public int NumeroPuertasVehiculo { get; set; }
        public string CapacidadMotorVehiculo { get; set; }
        public string TransmisionVehiculo { get; set; }
        public string CapacidadPasajerosVehiculo { get; set; }
        public string RastreoSatelital{ get; set; }
        public int EstadoVehiculos{ get; set; }

        //fks
        public int IdColorVehiculo { get; set; }
        public ColoresVehiculo ColoresVehiculo { get; set; }
           public int IdMarcaVehiculo { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public MarcasVehiculo MarcasVehiculo { get; set; }

        public ICollection<AutoReserva> AutosReserva { get; set; }
    }
}
