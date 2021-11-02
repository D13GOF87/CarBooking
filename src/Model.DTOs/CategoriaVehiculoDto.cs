using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
	public class CategoriaVehiculoDto
	{
		public int IdCategoriaVehiculo { get; set; }

		public string NombreCategoria { get; set; }

		public int EstadoCategoriaVehiculo { get; set; }
	}

	public class CrearCategoriaVehiculoDto
	{
		[Required]
		public string NombreCategoria { get; set; }

		public int EstadoCategoriaVehiculo { get; set; }
	}

	public class ActualizarCategoriaVehiculoDto
	{
		public string NombreCategoria { get; set; }

		public int EstadoCategoriaVehiculo { get; set; }
	}

	public class DesactivarCategoriaVehiculoDto
	{
		public int EstadoCategoriaVehiculo { get; set; }
	}
}
