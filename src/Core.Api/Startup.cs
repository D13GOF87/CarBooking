using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Database;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<AplicacionDbContext>(
				opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
			);

			//Uso de los servicios
			services.AddTransient<ICategoriaVehiculoService, CategoriaVehiculoService>();
			services.AddTransient<ITipoVehiculoService, TipoVehiculoService>();
			services.AddTransient<IAgenciasService, AgenciasService>();
			services.AddTransient<IColoresVehiculoService, ColoresVehiculoService>();
			services.AddTransient<IMarcasVehiculoService, MarcasVehiculoService>();
			services.AddTransient<IClientesService, ClientesService>();
			services.AddTransient<IVehiculoService, VehiculoService>();
			services.AddTransient<IReservaService, ReservasService>();




			services.AddAutoMapper(typeof(Startup));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
