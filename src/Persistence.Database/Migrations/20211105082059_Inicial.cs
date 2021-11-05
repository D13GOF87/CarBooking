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

            migrationBuilder.CreateIndex(
                name: "IX_TiposVehiculo_IdCategoriaVehiculo",
                table: "TiposVehiculo",
                column: "IdCategoriaVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
