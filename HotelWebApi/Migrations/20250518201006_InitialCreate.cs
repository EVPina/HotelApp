using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Codigo_Sucursal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre_Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pisos_Sucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Codigo_Sucursal);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    ID_TipoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio_TipoHabitacion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.ID_TipoHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cod_Usuario = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Correo_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cod_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "PisoHabitaciones",
                columns: table => new
                {
                    Id_PisoHabitacion = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_PisoHabitacion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ID_TipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    Estado_TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_Sucursal = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacionID_TipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    SucursalesCodigo_Sucursal = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PisoHabitaciones", x => x.Id_PisoHabitacion);
                    table.ForeignKey(
                        name: "FK_PisoHabitaciones_Sucursales_SucursalesCodigo_Sucursal",
                        column: x => x.SucursalesCodigo_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Codigo_Sucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PisoHabitaciones_TipoHabitacion_TipoHabitacionID_TipoHabitacion",
                        column: x => x.TipoHabitacionID_TipoHabitacion,
                        principalTable: "TipoHabitacion",
                        principalColumn: "ID_TipoHabitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    DNI_Persona = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosCod_Usuario = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.DNI_Persona);
                    table.ForeignKey(
                        name: "FK_Personas_Usuarios_UsuariosCod_Usuario",
                        column: x => x.UsuariosCod_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Cod_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales_Usuarios",
                columns: table => new
                {
                    Id_Sucursales_Usuarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Sucursal = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Cod_Usuario = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    SucursalesCodigo_Sucursal = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    UsuariosCod_Usuario = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales_Usuarios", x => x.Id_Sucursales_Usuarios);
                    table.ForeignKey(
                        name: "FK_Sucursales_Usuarios_Sucursales_SucursalesCodigo_Sucursal",
                        column: x => x.SucursalesCodigo_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Codigo_Sucursal");
                    table.ForeignKey(
                        name: "FK_Sucursales_Usuarios_Usuarios_UsuariosCod_Usuario",
                        column: x => x.UsuariosCod_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Cod_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UsuariosCod_Usuario",
                table: "Personas",
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
                name: "IX_Sucursales_Usuarios_SucursalesCodigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "SucursalesCodigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_UsuariosCod_Usuario",
                table: "Sucursales_Usuarios",
                column: "UsuariosCod_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "PisoHabitaciones");

            migrationBuilder.DropTable(
                name: "Sucursales_Usuarios");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
