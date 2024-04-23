﻿using IntelligentDiagnostician.DataModels.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), ConstantRole.UserRole, ConstantRole.UserRole.ToUpper(), Guid.NewGuid().ToString() }
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), ConstantRole.AdminRole, ConstantRole.AdminRole.ToUpper(), Guid.NewGuid().ToString() }
            );
            
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), ConstantRole.SuperUserRole, ConstantRole.SuperUserRole.ToUpper(), Guid.NewGuid().ToString() }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles] ");
        }
    }
}
