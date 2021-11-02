
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    class MarcasVehiculoConfig
    {
        public MarcasVehiculoConfig(EntityTypeBuilder<MarcasVehiculo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMarcaVehiculo);
            entityBuilder.Property(x => x.IdMarcaVehiculo).IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.NombreMarcaVehiculo).HasMaxLength(20).IsRequired();
        }
    }
}
