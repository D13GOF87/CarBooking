using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ColoresVehiculoDto
    {
        public int IdColorVehiculo { get; set; }
        public string NombreColorVehiculo { get; set; }
        public int EstadoColorVehiculo { get; set; }
    }

    public class CrearColoresVehiculoDto
    {
        [Required]
        public string NombreColorVehiculo { get; set; }
        public int EstadoColorVehiculo { get; set; }
    }
    
    public class ActualizarColoresVehiculoDto
    {
        public string NombreColorVehiculo { get; set; }
        public int EstadoColorVehiculo { get; set; }
    }
    public class DesactivarColoresVehiculoDto
    {
        public int EstadoColorVehiculo { get; set; }
    }
}
