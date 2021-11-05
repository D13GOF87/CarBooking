using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    public class ClientesConfig
    {
        public ClientesConfig(EntityTypeBuilder<Clientes> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCliente);
            entityBuilder.Property(x => x.IdCliente).IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.Identifacion).HasMaxLength(10).IsRequired();
            entityBuilder.Property(x => x.NombresCliente).HasMaxLength(30).IsRequired();
            entityBuilder.Property(x => x.ApellidosCliente).HasMaxLength(30).IsRequired();
            entityBuilder.Property(x => x.Direccion).HasMaxLength(40).IsRequired();
            entityBuilder.Property(x => x.Telefono).HasMaxLength(15).IsRequired();
            entityBuilder.Property(x => x.email).HasMaxLength(30).IsRequired();
        }
    }
}
