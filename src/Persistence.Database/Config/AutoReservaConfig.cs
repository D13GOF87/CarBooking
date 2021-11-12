using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
	public class AutoReservaConfig
	{
		public AutoReservaConfig(EntityTypeBuilder<AutoReserva> entityBuilder)
		{
			entityBuilder.HasKey(x => x.IdAutoReserva);
			entityBuilder.Property(x => x.IdAutoReserva)
				.IsRequired()
				.ValueGeneratedOnAdd();

			entityBuilder.HasOne(x => x.Reserva)
				.WithMany(x => x.AutosReserva)
				.HasForeignKey(x => x.IdReserva);

			entityBuilder.HasOne(x => x.Vehiculo)
				.WithMany(x => x.AutosReserva)
				.HasForeignKey(x => x.IdVehiculo);

		}
	}
}
