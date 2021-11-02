
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    public class ColoresVehiculoConfig
    {
        public ColoresVehiculoConfig(EntityTypeBuilder<ColoresVehiculo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdColorVehiculo);
            entityBuilder.Property(x => x.IdColorVehiculo).IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.NombreColorVehiculo).HasMaxLength(20).IsRequired();
        }
    }
}
