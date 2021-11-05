using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using System.Threading.Tasks;

namespace Service
{
    public interface IClientesService
    {
        Task<ClienteDto> GetById(int id);
        Task<ClienteDto> Crear(CrearClienteDto modelo);
        Task ActualizarCliente(int id, ActualizarClienteDto modelo);
    }
    public class ClientesService : IClientesService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;

        public ClientesService(AplicacionDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task ActualizarCliente(int id, ActualizarClienteDto modelo)
        {
            var entry = await _contexto.Clientes.SingleAsync(x => x.IdCliente == id);
            entry.Identifacion = modelo.Identifacion;
            entry.NombresCliente = modelo.NombresCliente;
            entry.ApellidosCliente = modelo.ApellidosCliente;
            entry.Telefono = modelo.Telefono;
            entry.Direccion = modelo.Direccion;
            entry.email = modelo.email;
            entry.EstadoCliente = modelo.EstadoCliente;


            await _contexto.SaveChangesAsync();
        }

        public async Task<ClienteDto> Crear(CrearClienteDto modelo)
        {
            var entry = new Clientes
            {
                Identifacion = modelo.Identifacion,
                NombresCliente = modelo.NombresCliente,
                ApellidosCliente = modelo.ApellidosCliente,
                Telefono = modelo.Telefono,
                Direccion = modelo.Direccion,
                email = modelo.email,
                EstadoCliente = 1
            };
            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<ClienteDto>(entry);
        }

        public async Task<ClienteDto> GetById(int id)
        {
            return _mapper.Map<ClienteDto>(await _contexto.Clientes.SingleAsync(x => x.IdCliente == id));
        }
    }
}
