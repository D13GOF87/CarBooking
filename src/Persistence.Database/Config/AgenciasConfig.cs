using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Persistence.Database.Config
{
    public class AgenciasConfig
    {
        public AgenciasConfig(EntityTypeBuilder<Agencias> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdAgencia);
            entityBuilder.Property(x => x.IdAgencia).IsRequired().ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.NombreAgencia).HasMaxLength(30).IsRequired();
        }
    }
}
