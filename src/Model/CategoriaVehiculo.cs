using System.Collections.Generic;

namespace Model
{
	public class CategoriaVehiculo
	{
		public int IdCategoriaVehiculo { get; set; }

		public string NombreCategoria { get; set; }

		public int EstadoCategoriaVehiculo { get; set; }

		public ICollection<TipoVehiculo> TiposVehiculos { get; set; }
	}
}
