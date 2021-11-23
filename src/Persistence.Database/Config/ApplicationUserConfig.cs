using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DTOs.Identity;

namespace Persistence.Database.Config
{
	public class ApplicationUserConfig
	{
		public ApplicationUserConfig( EntityTypeBuilder<ApplicationUser> entityBuilder)
		{
			entityBuilder.HasMany(e => e.UserRoles)
						 .WithOne(e => e.User)
						 .HasForeignKey(e => e.UserId)
						 .IsRequired();
		}
	}
}
