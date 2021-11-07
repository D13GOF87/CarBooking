
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
    public interface IVehiculoService
    {
        Task<DataCollection<VehiculoDto>> GetAll(int page, int take);

        Task<VehiculoDto> GetById(int id);

        Task<VehiculoDto> Crear(CrearVehiculoDto modelo);

        Task Actualizar(int id, ActualizarVehiculoDto modelo);

        Task Desactivar(int id);
    }
    public class VehiculoService : IVehiculoService
    {
        private readonly AplicacionDbContext _contexto;
        private readonly IMapper _mapper;
        public VehiculoService(
            AplicacionDbContext contexto,
            IMapper mapper
        )
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<DataCollection<VehiculoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<VehiculoDto>>(
                await _contexto.Vehiculos.OrderBy(x => x.IdVehiculo)
                                    .Include(x => x.TipoVehiculo)
                                    .Include(x => x.ColoresVehiculo)
                                    .Include(x => x.MarcasVehiculo)
                                    .AsQueryable()
                                    .PagedAsync(page, take)
            );
        }

        public async Task<VehiculoDto> GetById(int id)
        {
            return _mapper.Map<VehiculoDto>(
                await _contexto.Vehiculos.OrderBy(x => x.IdVehiculo)
                                    .Include(x => x.TipoVehiculo)
                                    .Include(x => x.ColoresVehiculo)
                                    .Include(x => x.MarcasVehiculo)
                                    .AsQueryable()
                                    .SingleAsync(x => x.IdVehiculo == id)
            );
        }

        public async Task<VehiculoDto> Crear(CrearVehiculoDto modelo)
        {
            var entry = new Vehiculo
            {
                PlacaVehiculo = modelo.PlacaVehiculo,
                PrecioDiarioVehiculo = modelo.PrecioDiarioVehiculo,
                ImagenVehiculo = modelo.ImagenVehiculo,
                AnioVehiculo = modelo.AnioVehiculo,
                KilometrajeVehiculo = modelo.KilometrajeVehiculo,
                NumeroPuertasVehiculo = modelo.NumeroPuertasVehiculo,
                CapacidadMotorVehiculo = modelo.CapacidadMotorVehiculo,
                TransmisionVehiculo = modelo.TransmisionVehiculo,
                CapacidadPasajerosVehiculo = modelo.CapacidadPasajerosVehiculo,
                RastreoSatelital = modelo.RastreoSatelital,

                EstadoVehiculos = 1,

                IdColorVehiculo = modelo.IdColorVehiculo,
                IdMarcaVehiculo = modelo.IdMarcaVehiculo,
                IdTipoVehiculo = modelo.IdTipoVehiculo
            };

            await _contexto.AddAsync(entry);
            await _contexto.SaveChangesAsync();

            return _mapper.Map<VehiculoDto>(
                await GetById(entry.IdVehiculo)
            );
        }

        public async Task Actualizar(int id, ActualizarVehiculoDto modelo)
        {
            var entry = await _contexto.Vehiculos.SingleAsync(x => x.IdVehiculo == id);

            entry.PlacaVehiculo = modelo.PlacaVehiculo;
            entry.PrecioDiarioVehiculo = modelo.PrecioDiarioVehiculo;
            entry.ImagenVehiculo = modelo.ImagenVehiculo;
            entry.AnioVehiculo = modelo.AnioVehiculo;
            entry.KilometrajeVehiculo = modelo.KilometrajeVehiculo;
            entry.NumeroPuertasVehiculo = modelo.NumeroPuertasVehiculo;
            entry.CapacidadMotorVehiculo = modelo.CapacidadMotorVehiculo;
            entry.TransmisionVehiculo = modelo.TransmisionVehiculo;
            entry.CapacidadPasajerosVehiculo = modelo.CapacidadPasajerosVehiculo;
            entry.RastreoSatelital = modelo.RastreoSatelital;
            
            entry.EstadoVehiculos = 1;

            entry.IdColorVehiculo = modelo.IdColorVehiculo;
            entry.IdMarcaVehiculo = modelo.IdMarcaVehiculo;
            entry.IdTipoVehiculo = modelo.IdTipoVehiculo;



            await _contexto.SaveChangesAsync();
        }


        public async Task Desactivar(int id)
        {
            var entry = await _contexto.Vehiculos.SingleAsync(x => x.IdVehiculo == id);
            entry.EstadoVehiculos = 0;
            await _contexto.SaveChangesAsync();
        }

    }
}
