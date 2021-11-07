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
    public interface IColoresVehiculoService
    {
        Task<DataCollection<ColoresVehiculoDto>> GetAll(int page, int take);
        Task<ColoresVehiculoDto> GetById(int id);
        Task<ColoresVehiculoDto> Crear(CrearColoresVehiculoDto modelo);
        Task Actualizar(int id, ActualizarColoresVehiculoDto modelo);
        Task Desactivar(int id);
    }

    public class ColoresVehiculoService : IColoresVehiculoService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;

        public ColoresVehiculoService(AplicacionDbContext contexto,IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }
        public async Task<DataCollection<ColoresVehiculoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ColoresVehiculoDto>>(
                await _contexto.ColoresVehiculo
                    .OrderBy(x => x.IdColorVehiculo)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<ColoresVehiculoDto> GetById(int id)
        {
            return _mapper.Map<ColoresVehiculoDto>(await _contexto.ColoresVehiculo.SingleAsync(x => x.IdColorVehiculo == id));
        }

        public async Task<ColoresVehiculoDto> Crear(CrearColoresVehiculoDto modelo)
        {
            var entry = new ColoresVehiculo
            {
                NombreColorVehiculo = modelo.NombreColorVehiculo,
                EstadoColorVehiculo = 1
            };

            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();

            return _mapper.Map<ColoresVehiculoDto>(entry);
        }

        public async Task Actualizar(int id, ActualizarColoresVehiculoDto modelo)
        {
            var entry = await _contexto.ColoresVehiculo.SingleAsync(x => x.IdColorVehiculo == id);
            
            entry.NombreColorVehiculo = modelo.NombreColorVehiculo;
            entry.EstadoColorVehiculo = modelo.EstadoColorVehiculo;
            
            await _contexto.SaveChangesAsync();
        }

        public async Task Desactivar(int id)
        {

            var entry = await _contexto.ColoresVehiculo.SingleAsync(x => x.IdColorVehiculo == id);
            entry.IdColorVehiculo = 0;
            await _contexto.SaveChangesAsync();
        }
    }
}
