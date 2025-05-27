using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregaDatosSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion_Sucursal",
                table: "Sucursales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefono_Sucursal",
                table: "Sucursales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion_Sucursal",
                table: "Sucursales");

            migrationBuilder.DropColumn(
                name: "Telefono_Sucursal",
                table: "Sucursales");
        }
    }
}
