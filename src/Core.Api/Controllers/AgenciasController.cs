using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("agencias")]
        public class AgenciasController : ControllerBase
        {
            private readonly IAgenciasService _agenciasService;
    
        public AgenciasController(IAgenciasService agencias)
        {
            _agenciasService = agencias;
        }

        [HttpGet("id")]
        public async Task<ActionResult<AgenciasDto>> GetById(int id)
        {
            return await _agenciasService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearAgenciasDto modelo)
        {
            var result = await _agenciasService.Crear(modelo);
            return CreatedAtAction(
                "GetById",
                new { id = result.IdAgencia },
                result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarAgenciasDto modelo)
        {
            await _agenciasService.Actualizar(id, modelo);
            return NoContent();
        }

    }
}
