using System.Collections.Generic;
using System.Linq;

namespace Service.Commons
{
	public class DataCollection<T> where T : class
	{
		public bool HasItems
		{
			get
			{
				return Items != null && Items.Any();
			}
		}

		public IEnumerable<T> Items { get; set; }

		//Cantidad de registros encontrados
		public int Total { get; set; }

		//Pagina actual que se está navegando
		public int Page { get; set; }

		//Cantidad de páginas en las que se pueden navegar
		public int Pages { get; set; }
	}
}
