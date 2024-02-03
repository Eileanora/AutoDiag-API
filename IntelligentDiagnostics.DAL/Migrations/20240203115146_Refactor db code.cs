using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Refactordbcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_errors_users_UserId",
                table: "errors");

            migrationBuilder.DropForeignKey(
                name: "FK_readings_parameters_ParameterId",
                table: "readings");

            migrationBuilder.DropForeignKey(
                name: "FK_readings_systemCars_SystemCarId",
                table: "readings");

            migrationBuilder.DropForeignKey(
                name: "FK_readings_users_UserId",
                table: "readings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_systemCars",
                table: "systemCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_readings",
                table: "readings");

            migrationBuilder.DropIndex(
                name: "IX_readings_ParameterId",
                table: "readings");

            migrationBuilder.DropIndex(
                name: "IX_readings_SystemCarId",
                table: "readings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parameters",
                table: "parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_errors",
                table: "errors");

            migrationBuilder.DropIndex(
                name: "IX_errors_UserId",
                table: "errors");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "systemCars",
                newName: "SystemCars");

            migrationBuilder.RenameTable(
                name: "readings",
                newName: "Readings");

            migrationBuilder.RenameTable(
                name: "parameters",
                newName: "Parameters");

            migrationBuilder.RenameTable(
                name: "errors",
                newName: "Errors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "SystemCarName",
                table: "SystemCars",
                newName: "CarSystemName");

            migrationBuilder.RenameColumn(
                name: "SystemCarId",
                table: "SystemCars",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "SystemCarId",
                table: "Readings",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "ReadingDateTime",
                table: "Readings",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ReadingId",
                table: "Readings",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_readings_UserId",
                table: "Readings",
                newName: "IX_Readings_UserId");

            migrationBuilder.RenameColumn(
                name: "ParameterName",
                table: "Parameters",
                newName: "SensorName");

            migrationBuilder.RenameColumn(
                name: "ParameterId",
                table: "Parameters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "ErrorDateTime",
                table: "Errors",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ErrorId",
                table: "Errors",
                newName: "ModifiedBy");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "SystemCars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SystemCars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SystemCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SystemCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Readings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CarSystemId",
                table: "Readings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Readings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Parameters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Parameters",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Parameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Parameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Parameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Errors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Errors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Errors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemCars",
                table: "SystemCars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Readings",
                table: "Readings",
                column: "ParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Errors",
                table: "Errors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_CarSystemId",
                table: "Readings",
                column: "CarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Errors_Users_UserId",
                table: "Errors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Parameters_ParameterId",
                table: "Readings",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_SystemCars_CarSystemId",
                table: "Readings",
                column: "CarSystemId",
                principalTable: "SystemCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Users_UserId",
                table: "Readings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errors_Users_UserId",
                table: "Errors");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Parameters_ParameterId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_SystemCars_CarSystemId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Users_UserId",
                table: "Readings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemCars",
                table: "SystemCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Readings",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_CarSystemId",
                table: "Readings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Errors",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SystemCars");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemCars");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SystemCars");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SystemCars");

            migrationBuilder.DropColumn(
                name: "CarSystemId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Errors");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "SystemCars",
                newName: "systemCars");

            migrationBuilder.RenameTable(
                name: "Readings",
                newName: "readings");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "parameters");

            migrationBuilder.RenameTable(
                name: "Errors",
                newName: "errors");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "systemCars",
                newName: "SystemCarId");

            migrationBuilder.RenameColumn(
                name: "CarSystemName",
                table: "systemCars",
                newName: "SystemCarName");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "readings",
                newName: "ReadingDateTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "readings",
                newName: "SystemCarId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "readings",
                newName: "ReadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Readings_UserId",
                table: "readings",
                newName: "IX_readings_UserId");

            migrationBuilder.RenameColumn(
                name: "SensorName",
                table: "parameters",
                newName: "ParameterName");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "parameters",
                newName: "ParameterId");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "errors",
                newName: "ErrorDateTime");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "errors",
                newName: "ErrorId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SystemCarId",
                table: "systemCars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingId",
                table: "readings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ParameterId",
                table: "parameters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ErrorId",
                table: "errors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_systemCars",
                table: "systemCars",
                column: "SystemCarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_readings",
                table: "readings",
                column: "ReadingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parameters",
                table: "parameters",
                column: "ParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_errors",
                table: "errors",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_readings_ParameterId",
                table: "readings",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_readings_SystemCarId",
                table: "readings",
                column: "SystemCarId");

            migrationBuilder.CreateIndex(
                name: "IX_errors_UserId",
                table: "errors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_errors_users_UserId",
                table: "errors",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_readings_parameters_ParameterId",
                table: "readings",
                column: "ParameterId",
                principalTable: "parameters",
                principalColumn: "ParameterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_readings_systemCars_SystemCarId",
                table: "readings",
                column: "SystemCarId",
                principalTable: "systemCars",
                principalColumn: "SystemCarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_readings_users_UserId",
                table: "readings",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
