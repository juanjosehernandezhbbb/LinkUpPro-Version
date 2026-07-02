using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amistades_AspNetUsers_Usuario1Id",
                table: "Amistades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amistades_AspNetUsers_Usuario2Id",
                table: "Amistades");

            migrationBuilder.DropForeignKey(
                name: "FK_Ataques_AspNetUsers_AtacanteId",
                table: "Ataques");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcos_AspNetUsers_PropietarioId",
                table: "Barcos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_AspNetUsers_AutorId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_AspNetUsers_ActorId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_AspNetUsers_DestinatarioId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_AspNetUsers_GanadorId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_AspNetUsers_Jugador1Id",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_AspNetUsers_Jugador2Id",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_AspNetUsers_TurnoActualUsuarioId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_AspNetUsers_AutorId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reacciones_AspNetUsers_UsuarioId",
                table: "Reacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAmistad_AspNetUsers_EmisorId",
                table: "SolicitudesAmistad");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAmistad_AspNetUsers_ReceptorId",
                table: "SolicitudesAmistad");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Ataques_PartidaId",
                table: "Ataques");

            migrationBuilder.DropIndex(
                name: "IX_Amistades_Usuario1Id_Usuario2Id",
                table: "Amistades");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Reacciones",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Publicaciones",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "EstaEliminada",
                table: "Publicaciones",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Notificaciones",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "FechaEliminacion",
                table: "Amistades",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Amistades",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SolicitudesAmistad",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SolicitudesAmistad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SolicitudesAmistad",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reacciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reacciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publicaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Partidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Partidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Partidas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notificaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Notificaciones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comentarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comentarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PublicacionId1",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comentarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CeldasBarco",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CeldasBarco",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CeldasBarco",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Barcos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Barcos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Barcos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ataques",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ataques",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PartidaBattleshipId",
                table: "Ataques",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Ataques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Amistades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfilUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacionId1",
                table: "Comentarios",
                column: "PublicacionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_PartidaBattleshipId",
                table: "Ataques",
                column: "PartidaBattleshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_PartidaId_AtacanteId_Fila_Columna",
                table: "Ataques",
                columns: new[] { "PartidaId", "AtacanteId", "Fila", "Columna" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amistades_Usuario1Id_Usuario2Id",
                table: "Amistades",
                columns: new[] { "Usuario1Id", "Usuario2Id" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Amistades_ApplicationUser_Usuario1Id",
                table: "Amistades",
                column: "Usuario1Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amistades_ApplicationUser_Usuario2Id",
                table: "Amistades",
                column: "Usuario2Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_ApplicationUser_AtacanteId",
                table: "Ataques",
                column: "AtacanteId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_Partidas_PartidaBattleshipId",
                table: "Ataques",
                column: "PartidaBattleshipId",
                principalTable: "Partidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcos_ApplicationUser_PropietarioId",
                table: "Barcos",
                column: "PropietarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_ApplicationUser_AutorId",
                table: "Comentarios",
                column: "AutorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicaciones_PublicacionId1",
                table: "Comentarios",
                column: "PublicacionId1",
                principalTable: "Publicaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_ApplicationUser_ActorId",
                table: "Notificaciones",
                column: "ActorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_ApplicationUser_DestinatarioId",
                table: "Notificaciones",
                column: "DestinatarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_ApplicationUser_GanadorId",
                table: "Partidas",
                column: "GanadorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_ApplicationUser_Jugador1Id",
                table: "Partidas",
                column: "Jugador1Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_ApplicationUser_Jugador2Id",
                table: "Partidas",
                column: "Jugador2Id",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_ApplicationUser_TurnoActualUsuarioId",
                table: "Partidas",
                column: "TurnoActualUsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_ApplicationUser_AutorId",
                table: "Publicaciones",
                column: "AutorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reacciones_ApplicationUser_UsuarioId",
                table: "Reacciones",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAmistad_ApplicationUser_EmisorId",
                table: "SolicitudesAmistad",
                column: "EmisorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAmistad_ApplicationUser_ReceptorId",
                table: "SolicitudesAmistad",
                column: "ReceptorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amistades_ApplicationUser_Usuario1Id",
                table: "Amistades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amistades_ApplicationUser_Usuario2Id",
                table: "Amistades");

            migrationBuilder.DropForeignKey(
                name: "FK_Ataques_ApplicationUser_AtacanteId",
                table: "Ataques");

            migrationBuilder.DropForeignKey(
                name: "FK_Ataques_Partidas_PartidaBattleshipId",
                table: "Ataques");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcos_ApplicationUser_PropietarioId",
                table: "Barcos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_ApplicationUser_AutorId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicaciones_PublicacionId1",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_ApplicationUser_ActorId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_ApplicationUser_DestinatarioId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_ApplicationUser_GanadorId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_ApplicationUser_Jugador1Id",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_ApplicationUser_Jugador2Id",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_ApplicationUser_TurnoActualUsuarioId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_ApplicationUser_AutorId",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reacciones_ApplicationUser_UsuarioId",
                table: "Reacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAmistad_ApplicationUser_EmisorId",
                table: "SolicitudesAmistad");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAmistad_ApplicationUser_ReceptorId",
                table: "SolicitudesAmistad");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PublicacionId1",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Ataques_PartidaBattleshipId",
                table: "Ataques");

            migrationBuilder.DropIndex(
                name: "IX_Ataques_PartidaId_AtacanteId_Fila_Columna",
                table: "Ataques");

            migrationBuilder.DropIndex(
                name: "IX_Amistades_Usuario1Id_Usuario2Id",
                table: "Amistades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SolicitudesAmistad");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SolicitudesAmistad");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SolicitudesAmistad");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reacciones");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reacciones");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PublicacionId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CeldasBarco");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CeldasBarco");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CeldasBarco");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Barcos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Barcos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Barcos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "PartidaBattleshipId",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Amistades");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reacciones",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Publicaciones",
                newName: "EstaEliminada");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Publicaciones",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Notificaciones",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Amistades",
                newName: "FechaEliminacion");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Amistades",
                newName: "FechaCreacion");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoPerfilUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_PartidaId",
                table: "Ataques",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Amistades_Usuario1Id_Usuario2Id",
                table: "Amistades",
                columns: new[] { "Usuario1Id", "Usuario2Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Amistades_AspNetUsers_Usuario1Id",
                table: "Amistades",
                column: "Usuario1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amistades_AspNetUsers_Usuario2Id",
                table: "Amistades",
                column: "Usuario2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_AspNetUsers_AtacanteId",
                table: "Ataques",
                column: "AtacanteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcos_AspNetUsers_PropietarioId",
                table: "Barcos",
                column: "PropietarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_AspNetUsers_AutorId",
                table: "Comentarios",
                column: "AutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_AspNetUsers_ActorId",
                table: "Notificaciones",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_AspNetUsers_DestinatarioId",
                table: "Notificaciones",
                column: "DestinatarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_AspNetUsers_GanadorId",
                table: "Partidas",
                column: "GanadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_AspNetUsers_Jugador1Id",
                table: "Partidas",
                column: "Jugador1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_AspNetUsers_Jugador2Id",
                table: "Partidas",
                column: "Jugador2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_AspNetUsers_TurnoActualUsuarioId",
                table: "Partidas",
                column: "TurnoActualUsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_AspNetUsers_AutorId",
                table: "Publicaciones",
                column: "AutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reacciones_AspNetUsers_UsuarioId",
                table: "Reacciones",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAmistad_AspNetUsers_EmisorId",
                table: "SolicitudesAmistad",
                column: "EmisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAmistad_AspNetUsers_ReceptorId",
                table: "SolicitudesAmistad",
                column: "ReceptorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
