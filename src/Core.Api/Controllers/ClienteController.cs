using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        public ClienteController(IClientesService clientes)
        {
            _clientesService = clientes;
        }
        [HttpGet("id")]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            return await _clientesService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearClienteDto modelo)
        {
            var result = await _clientesService.Crear(modelo);
            return CreatedAtAction(
                "GetById",
                new { id = result.IdCliente },
                result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ActualizarClienteDto modelo)
        {
            await _clientesService.ActualizarCliente(id, modelo);
            return NoContent();
        }

    }
}

