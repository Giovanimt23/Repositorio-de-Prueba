using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoSistemaRepositorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    IdConductor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.IdConductor);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculo", x => x.IdTipoVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TipovehiculoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_Marca_TipoVehiculo_TipovehiculoId",
                        column: x => x.TipovehiculoId,
                        principalTable: "TipoVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    IdModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroDAsiento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "IdModelo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_TipoVehiculo_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "TipoVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroVehicular",
                columns: table => new
                {
                    IdRegistroVehicular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "DATE", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "DATE", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVehicular", x => x.IdRegistroVehicular);
                    table.ForeignKey(
                        name: "FK_RegistroVehicular_Conductor_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductor",
                        principalColumn: "IdConductor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroVehicular_Vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoVehiculo",
                columns: new[] { "IdTipoVehiculo", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "UsuarioCreacion", "UsuarioModificacion" },
                values: new object[,]
                {
                    { 1, "Automovil", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(6520), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(6525), "administrador", "administrador" },
                    { 2, "MotoTaxi", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(6530), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(6531), "administrador", "administrador" }
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "IdMarca", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "TipovehiculoId", "UrlImagen", "UsuarioCreacion", "UsuarioModificacion" },
                values: new object[,]
                {
                    { 1, "Toyota", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(954), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(969), 1, "link", "administrador", "administrador" },
                    { 2, "Kia", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(974), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(975), 1, "link", "administrador", "administrador" },
                    { 3, "Hyunday", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(977), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(977), 1, "link", "administrador", "administrador" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "IdModelo", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "MarcaId", "UsuarioCreacion", "UsuarioModificacion" },
                values: new object[,]
                {
                    { 1, "Corrola", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2801), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2805), 1, "administrador", "administrador" },
                    { 2, "Sportage", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2810), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2810), 1, "administrador", "administrador" },
                    { 3, "Santa Fe", true, new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2812), new DateTime(2024, 3, 15, 1, 11, 48, 434, DateTimeKind.Local).AddTicks(2813), 1, "administrador", "administrador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marca_TipovehiculoId",
                table: "Marca",
                column: "TipovehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaId",
                table: "Modelo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVehicular_ConductorId",
                table: "RegistroVehicular",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVehicular_VehiculoId",
                table: "RegistroVehicular",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_MarcaId",
                table: "Vehiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ModeloId",
                table: "Vehiculo",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_TipoVehiculoId",
                table: "Vehiculo",
                column: "TipoVehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroVehicular");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");
        }
    }
}
