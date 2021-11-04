using System.Collections.Generic;

public class DataCollection<T> where T : class 
{
	public IEnumerable<T> Items { get; set; }

	//Cantidad de registros encontrados
	public int Total { get; set; }

	//Pagina actual que se está navegando
	public int Page { get; set; }

	//Cantidad de páginas en las que se pueden navegar
	public int Pages { get; set; }
}
