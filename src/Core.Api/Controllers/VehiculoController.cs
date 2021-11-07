using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;
namespace Core.Api.Controllers
{
    [ApiController]
    [Route("vehiculo")]

    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

		public VehiculoController(IVehiculoService vehiculoService)
		{
			_vehiculoService = vehiculoService;
		}

		[HttpGet]
		public async Task<ActionResult<DataCollection<VehiculoDto>>> GetAll(int page, int take = 20)
		{
			return await _vehiculoService.GetAll(page, take);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<VehiculoDto>> GetById(int id)
		{
			return await _vehiculoService.GetById(id);
		}

		[HttpPost]
		public async Task<ActionResult> Crear(CrearVehiculoDto model)
		{
			var result = await _vehiculoService.Crear(model);

			return CreatedAtAction(
				"GetById",
				new { id = result.IdVehiculo },
				result
			);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Actualizar(int id, ActualizarVehiculoDto modelo)
		{
			await _vehiculoService.Actualizar(id, modelo);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Desactivar(int id)
		{
			await _vehiculoService.Desactivar(id);
			return NoContent();
		}
	}
}
