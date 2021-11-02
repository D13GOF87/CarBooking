using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("coloresVehiculo")]
    public class ColoresVehiculoController : ControllerBase
    {
        private readonly IColoresVehiculoService _coloresVehiculoService;

        public ColoresVehiculoController(IColoresVehiculoService coloresVehiculo)
        {
            _coloresVehiculoService = coloresVehiculo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColoresVehiculoDto>> GetById(int id)
        {
            return await _coloresVehiculoService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearColoresVehiculoDto modelo)
        {
            var result = await _coloresVehiculoService.Crear(modelo);
            return CreatedAtAction(
                "GetById",
                new { id = result.IdColorVehiculo },
                result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarColoresVehiculoDto modelo)
        {
            await _coloresVehiculoService.Actualizar(id, modelo);
            return NoContent();
        }
    }
}
