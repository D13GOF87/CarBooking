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
    public interface IMarcasVehiculoService
    {
        Task<DataCollection<MarcasVehiculoDto>> GetAll(int page, int take);
        Task<MarcasVehiculoDto> GetById(int id);
        Task<MarcasVehiculoDto> Crear(CrearMarcaVehiculoDto modelo);
        Task Actualizar(int id, ActualizarMarcaVehiculoDto modelo);
        Task Desactivar(int id);
    }
    public class MarcasVehiculoService:IMarcasVehiculoService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;
        
        public MarcasVehiculoService(AplicacionDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<DataCollection<MarcasVehiculoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<MarcasVehiculoDto>>(
                await _contexto.MarcasVehiculo
                    .OrderBy(x => x.IdMarcaVehiculo)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<MarcasVehiculoDto> GetById(int id)
        {
            return _mapper.Map<MarcasVehiculoDto>(await _contexto.MarcasVehiculo.SingleAsync(x => x.IdMarcaVehiculo == id));
        }

        public async Task<MarcasVehiculoDto> Crear(CrearMarcaVehiculoDto modelo)
        {
            var entry = new MarcasVehiculo
            {
                NombreMarcaVehiculo = modelo.NombreMarcaVehiculo,
                EstadoMarcaVehiculo = 1
            };
            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<MarcasVehiculoDto>(entry);
        }

        public async Task Actualizar(int id, ActualizarMarcaVehiculoDto modelo)
        {
            var entry = await _contexto.MarcasVehiculo.SingleAsync(x => x.IdMarcaVehiculo == id);

            entry.NombreMarcaVehiculo = modelo.NombreMarcaVehiculo;
            entry.EstadoMarcaVehiculo = modelo.EstadoMarcaVehiculo;

            await _contexto.SaveChangesAsync();
        }

        public async Task Desactivar(int id)
        {
            var entry = await _contexto.MarcasVehiculo.SingleAsync(x => x.IdMarcaVehiculo == id);
            entry.EstadoMarcaVehiculo = 0;
            await _contexto.SaveChangesAsync();
        }
    }
}
