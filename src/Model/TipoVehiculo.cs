using System.Collections.Generic;

namespace Model
{
	public class TipoVehiculo
	{
		public int IdTipoVehiculo { get; set; }

		public string NombreTipo { get; set; }

		public int EstadoTipoVehiculo { get; set; }

		public int IdCategoriaVehiculo { get; set; }
		public CategoriaVehiculo CategoriaVehiculo { get; set; }
		//fk

		public ICollection<Vehiculo> Vehiculos { get; set; }
	}
}
