using IntelligentDiagnostician.DataModels.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddata_superuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), ConstantRole.SuperUserRole, ConstantRole.SuperUserRole.ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Name",
                keyValue: ConstantRole.SuperUserRole);
        }

    }
}
