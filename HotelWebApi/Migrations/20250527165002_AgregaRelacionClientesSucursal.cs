using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregaRelacionClientesSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo_Sucursal",
                table: "Clientes",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Codigo_Sucursal",
                table: "Clientes",
                column: "Codigo_Sucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Sucursales_Codigo_Sucursal",
                table: "Clientes",
                column: "Codigo_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Codigo_Sucursal",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Sucursales_Codigo_Sucursal",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Codigo_Sucursal",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Codigo_Sucursal",
                table: "Clientes");
        }
    }
}
