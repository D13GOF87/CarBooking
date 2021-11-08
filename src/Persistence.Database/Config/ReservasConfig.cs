using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    public class ReservasConfig
    {
        public ReservasConfig(EntityTypeBuilder<Reservas> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdReserva);
            entityBuilder.Property(x => x.IdReserva).IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.FechaInicio).HasMaxLength(10).IsRequired();
            entityBuilder.Property(x => x.FechaDevolucion).HasMaxLength(10).IsRequired();
            entityBuilder.Property(x => x.PrecioTotal).HasMaxLength(8).IsRequired();

            //fks
            entityBuilder.HasOne(x => x.ClientesReservas)
                .WithMany(x => x.Reservas)
                .HasForeignKey(x => x.IdCliente)
                .IsRequired();
            entityBuilder.HasOne(x => x.AgenciasReservas)
               .WithMany(x => x.Reservas)
               .HasForeignKey(x => x.IdAgencia)
               .IsRequired();
        }
    }
}
