using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CambiaEstadoHabiacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio_EstadoHabitacion",
                table: "TipoHabitacion");

            migrationBuilder.AddColumn<string>(
                name: "Estado_TipoHabitacion",
                table: "TipoHabitacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado_TipoHabitacion",
                table: "TipoHabitacion");

            migrationBuilder.AddColumn<double>(
                name: "Precio_EstadoHabitacion",
                table: "TipoHabitacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
