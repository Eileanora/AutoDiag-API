using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTroubleCodeColumnsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TroubleCodes",
                newName: "ProblemDescription");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "TroubleCodes",
                newName: "ProblemCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProblemDescription",
                table: "TroubleCodes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProblemCode",
                table: "TroubleCodes",
                newName: "Code");
        }
    }
}
