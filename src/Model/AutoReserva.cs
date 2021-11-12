namespace Model
{
	public class AutoReserva
	{
		public int IdAutoReserva { get; set; }

		public int IdVehiculo { get; set; }
		public Vehiculo Vehiculo { get; set; }

		public int IdReserva { get; set; }

		public Reservas Reserva { get; set; }
	}
}
