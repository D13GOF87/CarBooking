using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DTOs.Identity;

namespace Persistence.Database.Config
{
	public class ApplicationRoleConfig
	{
		public ApplicationRoleConfig( EntityTypeBuilder<ApplicationRole> entityBuilder)
		{
			entityBuilder.HasMany(e => e.UserRoles)
						 .WithOne(e => e.Role)
						 .HasForeignKey(e => e.RoleId)
						 .IsRequired();
		}
	}
}
