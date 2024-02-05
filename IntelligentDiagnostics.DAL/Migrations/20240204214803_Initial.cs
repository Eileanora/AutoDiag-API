using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimaryKeyBaseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CarSystemName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ReadingValue = table.Column<int>(type: "int", nullable: true),
                    CarSystemId = table.Column<int>(type: "int", nullable: true),
                    ParameterId = table.Column<int>(type: "int", nullable: true),
                    Reading_UserId = table.Column<int>(type: "int", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryKeyBaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_CarSystemId",
                        column: x => x.CarSystemId,
                        principalTable: "PrimaryKeyBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "PrimaryKeyBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_Reading_UserId",
                        column: x => x.Reading_UserId,
                        principalTable: "PrimaryKeyBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PrimaryKeyBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "PrimaryKeyBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                column: "CarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_ParameterId",
                table: "PrimaryKeyBaseEntity",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_Reading_UserId",
                table: "PrimaryKeyBaseEntity",
                column: "Reading_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_RoleId",
                table: "PrimaryKeyBaseEntity",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_UserId",
                table: "PrimaryKeyBaseEntity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimaryKeyBaseEntity");
        }
    }
}
