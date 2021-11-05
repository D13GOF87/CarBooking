using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
	public class TipoVehiculoDto
	{

		public int IdTipoVehiculo { get; set; }

		public int IdCategoriaVehiculo { get; set; }

		public CategoriaVehiculoDto CategoriaVehiculo { get; set; }

		public string NombreTipo { get; set; }

		public int EstadoTipoVehiculo { get; set; }
	}

	public class CrearTipoVehiculoDto
	{
		[Required]
		public int IdCategoriaVehiculo { get; set; }

		[Required]
		public string NombreTipo { get; set; }

		public int EstadoTipoVehiculo { get; set; }

	}
}
