
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs.Identity;
using Persistence.Database.Config;

namespace Persistence.Database
{
	public class AplicacionDbContext : IdentityDbContext
	{
		public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
		{

		}

		public DbSet<CategoriaVehiculo> CategoriasVehiculo { get; set; }

		public DbSet<TipoVehiculo> TiposVehiculo { get; set; }

		public DbSet<ColoresVehiculo> ColoresVehiculo { get; set; }
		public DbSet<MarcasVehiculo> MarcasVehiculo { get; set; }
		public DbSet<Agencias> Agencias { get; set; }
		public DbSet<Clientes> Clientes { get; set; }
		public DbSet<Vehiculo> Vehiculos { get; set; }
		public DbSet<Reservas> Reservas { get; set; }


		//Sobrecargo el metodo para la creación de las entidades
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//Llamo a las configuraciones creadas previamnete en Config de la persistencia
			new CategoriaVehiculoConfig(builder.Entity<CategoriaVehiculo>());
			new TipoVehiculoConfig(builder.Entity<TipoVehiculo>());
			new ColoresVehiculoConfig(builder.Entity<ColoresVehiculo>());
			new MarcasVehiculoConfig(builder.Entity<MarcasVehiculo>());
			new AgenciasConfig(builder.Entity<Agencias>());
			new ClientesConfig(builder.Entity<Clientes>());
			new VehiculoConfig(builder.Entity<Vehiculo>());
			new ReservasConfig(builder.Entity<Reservas>());
			new AutoReservaConfig(builder.Entity<AutoReserva>());

			//Configuracion Usuarios
			new ApplicationUserConfig(builder.Entity<ApplicationUser>());
			new ApplicationRoleConfig(builder.Entity<ApplicationRole>());
		}
	}
}
