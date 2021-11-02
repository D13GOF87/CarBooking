using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using System.Threading.Tasks;

namespace Service
{
	public interface ICategoriaVehiculoService 
	{
		Task<CategoriaVehiculoDto> GetById(int id);

		Task<CategoriaVehiculoDto> Crear(CrearCategoriaVehiculoDto modelo);

		Task Actualizar(int id, ActualizarCategoriaVehiculoDto modelo);

		Task Desactivar(int id);
	}

	public class CategoriaVehiculoService : ICategoriaVehiculoService
	{
		private readonly AplicacionDbContext _contexto;
		private readonly IMapper _mapper;

		public CategoriaVehiculoService( 
			AplicacionDbContext contexto, 
			IMapper mapper
		)
		{
			_contexto = contexto;
			_mapper = mapper;
		}

		public async Task<CategoriaVehiculoDto> GetById(int id)
		{
			return _mapper.Map<CategoriaVehiculoDto>(
				await _contexto.CategoriasVehiculo.SingleAsync(x => x.IdCategoriaVehiculo == id)
			);
		}

		public async Task<CategoriaVehiculoDto> Crear(CrearCategoriaVehiculoDto modelo)
		{
			var entry = new CategoriaVehiculo
			{
				NombreCategoria = modelo.NombreCategoria,
				EstadoCategoriaVehiculo = 1
			};

			await _contexto.AddAsync(entry);
			await _contexto.SaveChangesAsync();

			return _mapper.Map<CategoriaVehiculoDto>(entry);
		}

		public async Task Actualizar(int id, ActualizarCategoriaVehiculoDto modelo)
		{
			var entry = await _contexto.CategoriasVehiculo.SingleAsync(x => x.IdCategoriaVehiculo == id);

			entry.NombreCategoria = modelo.NombreCategoria;
			entry.EstadoCategoriaVehiculo = modelo.EstadoCategoriaVehiculo;
			await _contexto.SaveChangesAsync();
		}

		public async Task Desactivar(int id)
		{
			var entry = await _contexto.CategoriasVehiculo.SingleAsync(x => x.IdCategoriaVehiculo == id);
			entry.EstadoCategoriaVehiculo = 0;
			await _contexto.SaveChangesAsync();
		}
	}
}
