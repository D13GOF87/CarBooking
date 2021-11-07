using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
	[ApiController]
	[Route("tiposVehiculo")]

	public class TipoVehiculoController : ControllerBase
	{
		private readonly ITipoVehiculoService _tipoVehicleService;

		public TipoVehiculoController(ITipoVehiculoService tipoVehicleService)
		{
			_tipoVehicleService = tipoVehicleService;
		}

		[HttpGet]
		public async Task<ActionResult<DataCollection<TipoVehiculoDto>>> GetAll(int page, int take = 20)
		{
			return await _tipoVehicleService.GetAll(page, take);
		}

		//Ex: TiposVehiculo/1
		[HttpGet("{id}")]
		public async Task<ActionResult<TipoVehiculoDto>> GetById(int id)
		{
			return await _tipoVehicleService.GetById(id);
		}

		[HttpPost]
		public async Task<ActionResult> Crear(CrearTipoVehiculoDto model)
		{
			var result = await _tipoVehicleService.Crear(model);

			return CreatedAtAction(
				"GetById",
				new { id = result.IdTipoVehiculo },
				result
			);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Actualizar(int id, ActulizarTipoVehiculoDto modelo)
		{
			await _tipoVehicleService.Actualizar(id, modelo);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Desactivar(int id)
		{
			await _tipoVehicleService.Desactivar(id);
			return NoContent();
		}
	}
}
