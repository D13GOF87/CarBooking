using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
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

		[HttpGet]
		public async Task<ActionResult<DataCollection<CategoriaVehiculoDto>>> GetAll(int page, int take = 20)
		{
			return await _categoriaVehiculoService.GetAll(page, take);
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

		[HttpDelete("{id}")]
		public async Task<ActionResult> Desactivar(int id)
		{
			await _categoriaVehiculoService.Desactivar(id);
			return NoContent();
		}
	}
}
