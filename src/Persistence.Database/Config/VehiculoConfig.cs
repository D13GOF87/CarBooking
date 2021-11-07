
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    public class VehiculoConfig
    {
        public VehiculoConfig(EntityTypeBuilder<Vehiculo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdVehiculo);
            entityBuilder.Property(x => x.IdVehiculo)
                .IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.PlacaVehiculo)
                .HasMaxLength(8).IsRequired();
            entityBuilder.Property(x => x.PrecioDiarioVehiculo)
                .HasMaxLength(8).IsRequired();
            entityBuilder.Property(x => x.ImagenVehiculo)
                .HasMaxLength(200);
            entityBuilder.Property(x => x.AnioVehiculo)
                .HasMaxLength(4).IsRequired();
            entityBuilder.Property(x => x.KilometrajeVehiculo)
                .HasMaxLength(8).IsRequired();
            entityBuilder.Property(x => x.NumeroPuertasVehiculo)
                .IsRequired();
            entityBuilder.Property(x => x.CapacidadMotorVehiculo)
                .HasMaxLength(10).IsRequired();
            entityBuilder.Property(x => x.TransmisionVehiculo)
                .HasMaxLength(2).IsRequired();
            entityBuilder.Property(x => x.CapacidadPasajerosVehiculo)
                .HasMaxLength(15).IsRequired();
            entityBuilder.Property(x => x.RastreoSatelital)
                .HasMaxLength(1).IsRequired();

            //fk
            entityBuilder.HasOne(x => x.TipoVehiculo)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.IdTipoVehiculo)
                .IsRequired();
            entityBuilder.HasOne(x => x.ColoresVehiculo)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.IdColorVehiculo)
                .IsRequired();
            entityBuilder.HasOne(x => x.MarcasVehiculo)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.IdMarcaVehiculo)
                .IsRequired();

        }
    }
}
