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
                        name: "FK_TiposVehiculo_CategoriasVehiculo_CategoriaVehiculoIdCategoriaVehiculo",
                        column: x => x.IdCategoriaVehiculo,
                        principalTable: "CategoriasVehiculo",
                        principalColumn: "IdCategoriaVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposVehiculo_CategoriaVehiculoIdCategoriaVehiculo",
                table: "TiposVehiculo",
                column: "IdCategoriaVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposVehiculo");

            migrationBuilder.DropTable(
                name: "CategoriasVehiculo");
        }
    }
}
