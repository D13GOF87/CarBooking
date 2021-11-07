using AutoMapper;
using Model;
using Model.DTOs;
using Service.Commons;

namespace Core.Api.Config
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			//Mapeos para clases a Clases DTOs
			CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
			CreateMap<TipoVehiculo, TipoVehiculoDto>();
			CreateMap<ColoresVehiculo, ColoresVehiculoDto>();
			CreateMap<MarcasVehiculo, MarcasVehiculoDto>();
			CreateMap<Agencias, AgenciasDto>();
			CreateMap<Clientes, ClienteDto>();
			CreateMap<Vehiculo, VehiculoDto>();

			//Mapeos para paginación
			CreateMap<DataCollection<CategoriaVehiculo>, DataCollection<CategoriaVehiculoDto>>();
			CreateMap<DataCollection<TipoVehiculo>, DataCollection<TipoVehiculoDto>>();			
			CreateMap<DataCollection<ColoresVehiculo>, DataCollection<ColoresVehiculoDto>>();			
			CreateMap<DataCollection<MarcasVehiculo>, DataCollection<MarcasVehiculoDto>>();			
			CreateMap<DataCollection<Agencias>, DataCollection<AgenciasDto>>();			
			CreateMap<DataCollection<Clientes>, DataCollection<ClienteDto>>();			
			CreateMap<DataCollection<Vehiculo>, DataCollection<VehiculoDto>>();			
		}
	}
}
