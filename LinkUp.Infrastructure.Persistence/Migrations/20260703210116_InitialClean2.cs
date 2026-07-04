using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialClean2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicaciones_PublicacionId1",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PublicacionId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PublicacionId1",
                table: "Comentarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicacionId1",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacionId1",
                table: "Comentarios",
                column: "PublicacionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicaciones_PublicacionId1",
                table: "Comentarios",
                column: "PublicacionId1",
                principalTable: "Publicaciones",
                principalColumn: "Id");
        }
    }
}
