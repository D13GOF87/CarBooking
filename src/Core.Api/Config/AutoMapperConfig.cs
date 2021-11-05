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
			CreateMap<CategoriaVehiculo, CategoriaVehiculoDto>();
			CreateMap<ColoresVehiculo, ColoresVehiculoDto>();
			CreateMap<MarcasVehiculo, MarcasVehiculoDto>();
			CreateMap<Agencias, AgenciasDto>();
			CreateMap<Clientes, ClienteDto>();

			CreateMap<DataCollection<CategoriaVehiculo>, DataCollection<CategoriaVehiculoDto>>();
		}
	}
}
