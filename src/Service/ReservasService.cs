using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IReservaService
    {
        Task<DataCollection<ReservasDto>> GetAll(int page, int take);

        Task<ReservasDto> GetById(int id);

        Task<ReservasDto> Crear(CrearReservaDto modelo);

        Task Actualizar(int id, ActualizarReservaDto modelo);

        Task Desactivar(int id);
    }
    public class ReservasService : IReservaService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;

        public ReservasService(
            AplicacionDbContext contexto,
            IMapper mapper
        )
        {
            _contexto = contexto;
            _mapper = mapper;
        }
        public async Task<DataCollection<ReservasDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ReservasDto>>(
                await _contexto.Reservas.OrderBy(x => x.IdReserva)
                                    .Include(x => x.ClientesReservas)
                                    .Include(x => x.AgenciasReservas)
                                    .AsQueryable()
                                    .PagedAsync(page, take)
            );
        }
        public async Task<ReservasDto> GetById(int id)
        {
            return _mapper.Map<ReservasDto>(
                await _contexto.Reservas.OrderBy(x => x.IdReserva)
                                    .Include(x => x.ClientesReservas)
                                    .Include(x => x.AgenciasReservas)
                                    .AsQueryable()
                                    .SingleAsync(x => x.IdReserva == id)
            );

        }
        public async Task<ReservasDto> Crear(CrearReservaDto modelo)
        {
            var entry = new Reservas
            {
                FechaInicio = modelo.FechaInicio,
                FechaDevolucion = modelo.FechaDevolucion,
                PrecioTotal = modelo.PrecioTotal,
                IdCliente = modelo.IdCliente,
                IdAgencia = modelo.IdAgencia,
                EstadoReserva = 1
            };

            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();

            return _mapper.Map<ReservasDto>(
                await GetById(entry.IdReserva)
            );
        }

        public async Task Actualizar(int id, ActualizarReservaDto modelo)
        {
            var entry = await _contexto.Reservas.SingleAsync(x => x.IdReserva == id);

            entry.FechaInicio = modelo.FechaInicio;
            entry.FechaDevolucion = modelo.FechaDevolucion;
            entry.PrecioTotal = modelo.PrecioTotal;
            entry.EstadoReserva = modelo.EstadoReserva;

            entry.IdCliente = modelo.IdCliente;
            entry.IdAgencia = modelo.IdAgencia;

            await _contexto.SaveChangesAsync();
        }

        public async Task Desactivar(int id)
        {
            var entry = await _contexto.Reservas.SingleAsync(x => x.IdReserva == id);
            entry.EstadoReserva = 0;
            await _contexto.SaveChangesAsync();
        }


    }
}
