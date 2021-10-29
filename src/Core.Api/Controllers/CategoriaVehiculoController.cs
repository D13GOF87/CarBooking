using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTOs;
using Service;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
	[ApiController]
	[Route("categoriasVehiculo")]
	public class CategoriaVehiculoController : ControllerBase
	{
		private readonly ICategoriaVehiculoService _categoriaVehiculoService;

		public CategoriaVehiculoController(ICategoriaVehiculoService categoriaVehiculoService)
		{
			_categoriaVehiculoService = categoriaVehiculoService;
		}

		// Ex: categoriasVehiculo/1
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoriaVehiculoDto>> GetById(int id)
		{
			return await _categoriaVehiculoService.GetById(id);
		}

		[HttpPost]
		public async Task<ActionResult> Crear(CrearCategoriaVehiculoDto modelo)
		{
			var result = await _categoriaVehiculoService.Crear(modelo);

			return CreatedAtAction(
				"GetById",
				new { id = result.IdCategoriaVehiculo},
				result
			);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Actualizar(int id, ActualizarCategoriaVehiculoDto modelo)
		{
			await _categoriaVehiculoService.Actualizar(id, modelo);
			return NoContent();
		}
	}
}
