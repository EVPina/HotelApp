using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CambioEstructuraUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DNI_Persona",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "Nombre_Persona",
                table: "Empleado",
                newName: "Nombre_Empleado");

            migrationBuilder.RenameColumn(
                name: "Apellido_Persona",
                table: "Empleado",
                newName: "Apellido_Empleado");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Empleado",
                table: "Empleado",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DNI_Empleado",
                table: "Empleado",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Empleado",
                column: "Cod_Empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Cod_Empleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DNI_Empleado",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "Nombre_Empleado",
                table: "Empleado",
                newName: "Nombre_Persona");

            migrationBuilder.RenameColumn(
                name: "Apellido_Empleado",
                table: "Empleado",
                newName: "Apellido_Persona");

            migrationBuilder.AddColumn<int>(
                name: "DNI_Persona",
                table: "Empleado",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "DNI_Persona");
        }
    }
}
