using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SecambiaEstadoHabitacionyPiso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado_Habitacion",
                table: "PisoHabitaciones",
                newName: "Estado_Piso");

            migrationBuilder.AddColumn<double>(
                name: "Precio_EstadoHabitacion",
                table: "TipoHabitacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio_EstadoHabitacion",
                table: "TipoHabitacion");

            migrationBuilder.RenameColumn(
                name: "Estado_Piso",
                table: "PisoHabitaciones",
                newName: "Estado_Habitacion");
        }
    }
}
