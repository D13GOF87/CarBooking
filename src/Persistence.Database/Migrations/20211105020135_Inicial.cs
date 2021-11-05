using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdCategoriaVehiculo = table.Column<int>(type: "int", nullable: false),
                    CategoriaVehiculoIdCategoriaVehiculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVehiculo", x => x.IdTipoVehiculo);
                    table.ForeignKey(
                        name: "FK_TiposVehiculo_CategoriasVehiculo_CategoriaVehiculoIdCategoriaVehiculo",
                        column: x => x.CategoriaVehiculoIdCategoriaVehiculo,
                        principalTable: "CategoriasVehiculo",
                        principalColumn: "IdCategoriaVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposVehiculo_CategoriaVehiculoIdCategoriaVehiculo",
                table: "TiposVehiculo",
                column: "CategoriaVehiculoIdCategoriaVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
