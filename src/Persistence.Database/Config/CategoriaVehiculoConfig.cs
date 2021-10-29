
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
	public class CategoriaVehiculoConfig
	{
		public CategoriaVehiculoConfig(EntityTypeBuilder<CategoriaVehiculo> entityBuilder)
		{
			entityBuilder.HasKey(x => x.IdCategoriaVehiculo);
			entityBuilder.Property(x => x.IdCategoriaVehiculo)
				.IsRequired()
				.ValueGeneratedOnAdd();
			entityBuilder.Property(x => x.NombreCategoria)
				.HasMaxLength(20)
				.IsRequired();				
		}
	}
}
