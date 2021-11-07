using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("marcaVehiculo")]
    public class MarcasVehiculoController : ControllerBase
    {
        private readonly IMarcasVehiculoService _marcasVehiculoService;

        public MarcasVehiculoController(IMarcasVehiculoService marcasVehiculo)
        {
            _marcasVehiculoService = marcasVehiculo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarcasVehiculoDto>> GetById(int id)
        {
            return await _marcasVehiculoService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearMarcaVehiculoDto modelo)
        {
            var result = await _marcasVehiculoService.Crear(modelo);
            return CreatedAtAction(
                "GetById",
                new { id = result.IdMarcaVehiculo},
                result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarMarcaVehiculoDto modelo)
        {
            await _marcasVehiculoService.Actualizar(id, modelo);
            return NoContent();
        }
    }
}
