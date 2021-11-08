using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("reservas")]

    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
		[HttpGet]
		public async Task<ActionResult<DataCollection<ReservasDto>>> GetAll(int page, int take = 20)
		{
			return await _reservaService.GetAll(page, take);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ReservasDto>> GetById(int id)
		{
			return await _reservaService.GetById(id);
		}

		[HttpPost]
		public async Task<ActionResult> Crear(CrearReservaDto model)
		{
			var result = await _reservaService.Crear(model);

			return CreatedAtAction(
				"GetById",
				new { id = result.IdReserva },
				result
			);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Actualizar(int id, ActualizarReservaDto modelo)
		{
			await _reservaService.Actualizar(id, modelo);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Desactivar(int id)
		{
			await _reservaService.Desactivar(id);
			return NoContent();
		}
	}
}
