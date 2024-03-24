using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSistemaRepositorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracionCampoPDF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlPdf",
                table: "RegistroVehicular",
                type: "nvarchar(max)",
                nullable: true);
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlPdf",
                table: "RegistroVehicular");

        }
    }
}
