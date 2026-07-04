using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkUp.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                schema: "Identity",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                schema: "Identity",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                schema: "Identity",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Telefono",
                schema: "Identity",
                table: "users");
        }
    }
}
