using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initaddsystemcartable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "systemCars",
                columns: table => new
                {
                    SystemCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemCarName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemCars", x => x.SystemCarId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "systemCars");
        }
    }
}
