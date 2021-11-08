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
    public interface IAgenciasService
    {
        Task<DataCollection<AgenciasDto>> GetAll(int page, int take);
        Task<AgenciasDto> GetById(int id);
        Task<AgenciasDto> Crear(CrearAgenciasDto modelo);
        Task Actualizar(int id, ActualizarAgenciasDto modelo);
        Task Desactivar(int id);
    }
    public class AgenciasService : IAgenciasService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;

        public AgenciasService(AplicacionDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<DataCollection<AgenciasDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<AgenciasDto>>(
                await _contexto.Agencias.OrderBy(x => x.IdAgencia)
                                    .AsQueryable()
                                    .PagedAsync(page, take)
            );
        }
        public async Task<AgenciasDto> GetById(int id)
        {
            return _mapper.Map<AgenciasDto>(await _contexto.Agencias.SingleAsync(x => x.IdAgencia == id));
        }

        public async Task<AgenciasDto> Crear(CrearAgenciasDto modelo)
        {
            var entry = new Agencias
            {
                NombreAgencia = modelo.NombreAgencia,
                EstadoAgencia = 1
            };
            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<AgenciasDto>(entry);
        }

        public async Task Actualizar(int id, ActualizarAgenciasDto modelo)
        {
            var entry = await _contexto.Agencias.SingleAsync(x => x.IdAgencia == id);
            entry.NombreAgencia = modelo.NombreAgencia;
            entry.EstadoAgencia = modelo.EstadoAgencia;

            await _contexto.SaveChangesAsync();
        }

        public async Task Desactivar(int id)
        {
            var entry = await _contexto.Agencias.SingleAsync(x => x.IdAgencia == id);
            entry.EstadoAgencia = 0;
            await _contexto.SaveChangesAsync();
        }


    }
}
