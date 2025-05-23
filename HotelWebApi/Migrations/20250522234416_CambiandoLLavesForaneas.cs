using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CambiandoLLavesForaneas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Usuarios_UsuariosCod_Usuario",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_PisoHabitaciones_Sucursales_SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PisoHabitaciones_TipoHabitacion_TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Usuarios_Sucursales_SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Usuarios_Usuarios_UsuariosCod_Usuario",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_Usuarios_SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_Usuarios_UsuariosCod_Usuario",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_PisoHabitaciones_SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones");

            migrationBuilder.DropIndex(
                name: "IX_PisoHabitaciones_TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Personas_UsuariosCod_Usuario",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuariosCod_Usuario",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropColumn(
                name: "SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones");

            migrationBuilder.DropColumn(
                name: "TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones");

            migrationBuilder.DropColumn(
                name: "UsuariosCod_Usuario",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo_Sucursal",
                table: "Sucursales_Usuarios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo_Sucursal",
                table: "PisoHabitaciones",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cod_Usuario",
                table: "Personas",
                type: "nvarchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_Cod_Usuario",
                table: "Sucursales_Usuarios",
                column: "Cod_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_Codigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "Codigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_PisoHabitaciones_Codigo_Sucursal",
                table: "PisoHabitaciones",
                column: "Codigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_PisoHabitaciones_ID_TipoHabitacion",
                table: "PisoHabitaciones",
                column: "ID_TipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Cod_Usuario",
                table: "Personas",
                column: "Cod_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Usuarios_Cod_Usuario",
                table: "Personas",
                column: "Cod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Cod_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PisoHabitaciones_Sucursales_Codigo_Sucursal",
                table: "PisoHabitaciones",
                column: "Codigo_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Codigo_Sucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PisoHabitaciones_TipoHabitacion_ID_TipoHabitacion",
                table: "PisoHabitaciones",
                column: "ID_TipoHabitacion",
                principalTable: "TipoHabitacion",
                principalColumn: "ID_TipoHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Usuarios_Sucursales_Codigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "Codigo_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Codigo_Sucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Usuarios_Usuarios_Cod_Usuario",
                table: "Sucursales_Usuarios",
                column: "Cod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Cod_Usuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Usuarios_Cod_Usuario",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_PisoHabitaciones_Sucursales_Codigo_Sucursal",
                table: "PisoHabitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PisoHabitaciones_TipoHabitacion_ID_TipoHabitacion",
                table: "PisoHabitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Usuarios_Sucursales_Codigo_Sucursal",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Usuarios_Usuarios_Cod_Usuario",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_Usuarios_Cod_Usuario",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_Usuarios_Codigo_Sucursal",
                table: "Sucursales_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_PisoHabitaciones_Codigo_Sucursal",
                table: "PisoHabitaciones");

            migrationBuilder.DropIndex(
                name: "IX_PisoHabitaciones_ID_TipoHabitacion",
                table: "PisoHabitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Cod_Usuario",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "Codigo_Sucursal",
                table: "Sucursales_Usuarios",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuariosCod_Usuario",
                table: "Sucursales_Usuarios",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo_Sucursal",
                table: "PisoHabitaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");

            migrationBuilder.AddColumn<string>(
                name: "SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cod_Usuario",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)");

            migrationBuilder.AddColumn<string>(
                name: "UsuariosCod_Usuario",
                table: "Personas",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "SucursalesCodigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_UsuariosCod_Usuario",
                table: "Sucursales_Usuarios",
                column: "UsuariosCod_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_PisoHabitaciones_SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones",
                column: "SucursalesCodigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_PisoHabitaciones_TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones",
                column: "TipoHabitacionID_TipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UsuariosCod_Usuario",
                table: "Personas",
                column: "UsuariosCod_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Usuarios_UsuariosCod_Usuario",
                table: "Personas",
                column: "UsuariosCod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Cod_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PisoHabitaciones_Sucursales_SucursalesCodigo_Sucursal",
                table: "PisoHabitaciones",
                column: "SucursalesCodigo_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Codigo_Sucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PisoHabitaciones_TipoHabitacion_TipoHabitacionID_TipoHabitacion",
                table: "PisoHabitaciones",
                column: "TipoHabitacionID_TipoHabitacion",
                principalTable: "TipoHabitacion",
                principalColumn: "ID_TipoHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Usuarios_Sucursales_SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "SucursalesCodigo_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Codigo_Sucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Usuarios_Usuarios_UsuariosCod_Usuario",
                table: "Sucursales_Usuarios",
                column: "UsuariosCod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Cod_Usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
