using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    IdAgencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAgencia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstadoAgencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.IdAgencia);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasVehiculo",
                columns: table => new
                {
                    IdCategoriaVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoCategoriaVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasVehiculo", x => x.IdCategoriaVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombresCliente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ApellidosCliente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstadoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "ColoresVehiculo",
                columns: table => new
                {
                    IdColorVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreColorVehiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoColorVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColoresVehiculo", x => x.IdColorVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "MarcasVehiculo",
                columns: table => new
                {
                    IdMarcaVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMarcaVehiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoMarcaVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasVehiculo", x => x.IdMarcaVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "TiposVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoTipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVehiculo", x => x.IdTipoVehiculo);
                    table.ForeignKey(
                        name: "FK_TiposVehiculo_CategoriasVehiculo_IdCategoriaVehiculo",
                        column: x => x.IdCategoriaVehiculo,
                        principalTable: "CategoriasVehiculo",
                        principalColumn: "IdCategoriaVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioTotal = table.Column<float>(type: "real", maxLength: 8, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    EstadoReserva = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdAgencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Agencias_IdAgencia",
                        column: x => x.IdAgencia,
                        principalTable: "Agencias",
                        principalColumn: "IdAgencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PrecioDiarioVehiculo = table.Column<float>(type: "real", maxLength: 8, nullable: false),
                    ImagenVehiculo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AnioVehiculo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    KilometrajeVehiculo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NumeroPuertasVehiculo = table.Column<int>(type: "int", nullable: false),
                    CapacidadMotorVehiculo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TransmisionVehiculo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CapacidadPasajerosVehiculo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RastreoSatelital = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EstadoVehiculos = table.Column<int>(type: "int", nullable: false),
                    IdColorVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdMarcaVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_ColoresVehiculo_IdColorVehiculo",
                        column: x => x.IdColorVehiculo,
                        principalTable: "ColoresVehiculo",
                        principalColumn: "IdColorVehiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_MarcasVehiculo_IdMarcaVehiculo",
                        column: x => x.IdMarcaVehiculo,
                        principalTable: "MarcasVehiculo",
                        principalColumn: "IdMarcaVehiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TiposVehiculo_IdTipoVehiculo",
                        column: x => x.IdTipoVehiculo,
                        principalTable: "TiposVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoReserva",
                columns: table => new
                {
                    IdAutoReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReserva", x => x.IdAutoReserva);
                    table.ForeignKey(
                        name: "FK_AutoReserva_Reservas_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoReserva_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoReserva_IdReserva",
                table: "AutoReserva",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_AutoReserva_IdVehiculo",
                table: "AutoReserva",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdAgencia",
                table: "Reservas",
                column: "IdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdCliente",
                table: "Reservas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TiposVehiculo_IdCategoriaVehiculo",
                table: "TiposVehiculo",
                column: "IdCategoriaVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdColorVehiculo",
                table: "Vehiculos",
                column: "IdColorVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdMarcaVehiculo",
                table: "Vehiculos",
                column: "IdMarcaVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdTipoVehiculo",
                table: "Vehiculos",
                column: "IdTipoVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoReserva");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ColoresVehiculo");

            migrationBuilder.DropTable(
                name: "MarcasVehiculo");

            migrationBuilder.DropTable(
                name: "TiposVehiculo");

            migrationBuilder.DropTable(
                name: "CategoriasVehiculo");
        }
    }
}
