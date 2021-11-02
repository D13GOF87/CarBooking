
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using System.Threading.Tasks;

namespace Service
{
    public interface IMarcasVehiculoService
    {
        Task<MarcasVehiculoDto> GetById(int id);
        Task<MarcasVehiculoDto> Crear(CrearMarcaVehiculoDto modelo);
        Task Actualizar(int id, ActualizarMarcaVehiculoDto modelo);
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


    }
}
