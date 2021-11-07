
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class VehiculoDto
    {
        public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public float PrecioDiarioVehiculo { get; set; }
        public string ImagenVehiculo { get; set; }
        public string AnioVehiculo { get; set; }
        public string KilometrajeVehiculo { get; set; }
        public int NumeroPuertasVehiculo { get; set; }
        public string CapacidadMotorVehiculo { get; set; }
        public string TransmisionVehiculo { get; set; }
        public string CapacidadPasajerosVehiculo { get; set; }
        public string RastreoSatelital { get; set; }
        public int EstadoVehiculos { get; set; }

        //fks
        public ColoresVehiculoDto ColoresVehiculo { get; set; }
        public TipoVehiculoDto TipoVehiculo { get; set; }
        public MarcasVehiculoDto MarcasVehiculo { get; set; }
    }
    public class CrearVehiculoDto
    {

        //todos son obligatorios??
        [Required]
        public string PlacaVehiculo { get; set; }
        [Required]//aqui deberia ir [Column(TypeName = "decimal(8, 2)")]??
        public float PrecioDiarioVehiculo { get; set; }
        
        public string ImagenVehiculo { get; set; }
        [Required]
        public string AnioVehiculo { get; set; }
        [Required]
        public string KilometrajeVehiculo { get; set; }
        [Required]
        public int NumeroPuertasVehiculo { get; set; }
        [Required]
        public string CapacidadMotorVehiculo { get; set; }
        [Required]
        public string TransmisionVehiculo { get; set; }
        [Required]
        public string CapacidadPasajerosVehiculo { get; set; }
        [Required]
        public string RastreoSatelital { get; set; }
        
        public int EstadoVehiculos { get; set; }
        //aqui van los id de las fk
        [Required]
        public int IdColorVehiculo { get; set; }
        [Required]
        public int IdMarcaVehiculo { get; set; }
        [Required]
        public int IdTipoVehiculo { get; set; }
    }

    public class ActualizarVehiculoDto
    {
        public string PlacaVehiculo { get; set; }
        public float PrecioDiarioVehiculo { get; set; }
        public string ImagenVehiculo { get; set; }
        public string AnioVehiculo { get; set; }
        public string KilometrajeVehiculo { get; set; }
        public int NumeroPuertasVehiculo { get; set; }
        public string CapacidadMotorVehiculo { get; set; }
        public string TransmisionVehiculo { get; set; }
        public string CapacidadPasajerosVehiculo { get; set; }
        public string RastreoSatelital { get; set; }
        public int EstadoVehiculos { get; set; }
        //aqui van los id de las fk
        public int IdColorVehiculo { get; set; }
        public int IdMarcaVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }

    }

    public class DesactivarVehiculoDto
    {
        public int EstadoVehiculos { get; set; }
    }


}
