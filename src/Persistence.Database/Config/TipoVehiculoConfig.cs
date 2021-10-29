
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
	public class TipoVehiculoConfig
	{
		public TipoVehiculoConfig(EntityTypeBuilder<TipoVehiculo> entityBuilder)
		{
			entityBuilder.HasKey(x => x.IdTipoVehiculo);
			entityBuilder.Property(x => x.IdTipoVehiculo)
				.IsRequired()
				.ValueGeneratedOnAdd();
			entityBuilder.Property(x => x.NombreTipo)
				.HasMaxLength(20)
				.IsRequired();
		}
	}
}
