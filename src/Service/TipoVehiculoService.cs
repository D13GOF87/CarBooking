
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
	public interface ITipoVehiculoService
	{
		Task<DataCollection<TipoVehiculoDto>> GetAll(int page, int take);

		Task<TipoVehiculoDto> GetById(int id);

		Task<TipoVehiculoDto> Crear(CrearTipoVehiculoDto modelo);

		Task Actualizar(int id, ActulizarTipoVehiculoDto modelo);

		Task Desactivar(int id);
	}

	public class TipoVehiculoService : ITipoVehiculoService
	{
		private readonly AplicacionDbContext _contexto;
		private readonly IMapper _mapper;

		public TipoVehiculoService(
			AplicacionDbContext contexto, 
			IMapper mapper
		)
		{
			_contexto = contexto;
			_mapper = mapper;
		}

		public async Task<DataCollection<TipoVehiculoDto>> GetAll(int page, int take)
		{
			return _mapper.Map<DataCollection<TipoVehiculoDto>>(
				await _contexto.TiposVehiculo.OrderBy(x => x.IdTipoVehiculo)
									.Include(x => x.CategoriaVehiculo)
									.AsQueryable()
									.PagedAsync(page, take)
			);
		}

		public async Task<TipoVehiculoDto> GetById(int id)
		{
			return _mapper.Map<TipoVehiculoDto>(
				await _contexto.TiposVehiculo.OrderBy(x => x.IdTipoVehiculo)
									.Include(x => x.CategoriaVehiculo)
									.AsQueryable()
									.SingleAsync(x => x.IdTipoVehiculo == id)
			);
		}

		public async Task<TipoVehiculoDto> Crear(CrearTipoVehiculoDto modelo) 
		{
			var entry = new TipoVehiculo
			{
				NombreTipo = modelo.NombreTipo,
				IdCategoriaVehiculo = modelo.IdCategoriaVehiculo,
				EstadoTipoVehiculo = 1
			};

			await _contexto.AddAsync(entry);
			await _contexto.SaveChangesAsync();

			return _mapper.Map<TipoVehiculoDto>(
				await GetById(entry.IdTipoVehiculo)
			);
		}

		public async Task Actualizar(int id, ActulizarTipoVehiculoDto modelo)
		{
			var entry = await _contexto.TiposVehiculo.SingleAsync(x => x.IdTipoVehiculo == id);
			
			entry.IdCategoriaVehiculo = modelo.IdCategoriaVehiculo;
			entry.NombreTipo = modelo.NombreTipo;
			entry.EstadoTipoVehiculo = modelo.EstadoTipoVehiculo;

			await _contexto.SaveChangesAsync();
		}

		public async Task Desactivar(int id)
		{
			var entry = await _contexto.TiposVehiculo.SingleAsync(x => x.IdTipoVehiculo == id);
			entry.EstadoTipoVehiculo = 0;
			await _contexto.SaveChangesAsync();

		}
	}
}
