using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class MarcasVehiculoDto
    {
        public int IdMarcaVehiculo { get; set; }
        public string NombreMarcaVehiculo { get; set; }
        public int EstadoMarcaVehiculo { get; set; }

    }

    public class CrearMarcaVehiculoDto
    {
        [Required]
        public string NombreMarcaVehiculo { get; set; }
        public int EstadoMarcaVehiculo { get; set; }
    }

    public class ActualizarMarcaVehiculoDto
    {
        public string NombreMarcaVehiculo { get; set; }
        public int EstadoMarcaVehiculo { get; set; }
    }
}
