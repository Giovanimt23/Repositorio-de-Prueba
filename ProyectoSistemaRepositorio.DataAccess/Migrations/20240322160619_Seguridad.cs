using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSistemaRepositorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NombreCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PreguntaSecreta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RespuestaSecreta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9731), new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9747), new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9748) });

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9750), new DateTime(2024, 3, 22, 11, 6, 19, 141, DateTimeKind.Local).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2534), new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2554), new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2557), new DateTime(2024, 3, 22, 11, 6, 19, 142, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "TipoVehiculo",
                keyColumn: "IdTipoVehiculo",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 143, DateTimeKind.Local).AddTicks(2953), new DateTime(2024, 3, 22, 11, 6, 19, 143, DateTimeKind.Local).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "TipoVehiculo",
                keyColumn: "IdTipoVehiculo",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 22, 11, 6, 19, 143, DateTimeKind.Local).AddTicks(2986), new DateTime(2024, 3, 22, 11, 6, 19, 143, DateTimeKind.Local).AddTicks(2987) });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(172), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(187) });

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "IdMarca",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(194), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(195) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2022), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2031), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "Modelo",
                keyColumn: "IdModelo",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2033), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "TipoVehiculo",
                keyColumn: "IdTipoVehiculo",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "TipoVehiculo",
                keyColumn: "IdTipoVehiculo",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5826) });
        }
    }
}
