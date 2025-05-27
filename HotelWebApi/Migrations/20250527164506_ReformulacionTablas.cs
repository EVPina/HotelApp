using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ReformulacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cod_Clientes = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DNI_Cliente = table.Column<int>(type: "int", nullable: true),
                    Nombre_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cod_Clientes);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Codigo_Sucursal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre_Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Codigo_Sucursal);
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
                    Codigo_Piso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Piso = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Codigo_Sucursal = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Estado_Habitacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PisoHabitaciones", x => x.Codigo_Piso);
                    table.ForeignKey(
                        name: "FK_PisoHabitaciones_Sucursales_Codigo_Sucursal",
                        column: x => x.Codigo_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Codigo_Sucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Cod_Empleado = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DNI_Empleado = table.Column<int>(type: "int", nullable: true),
                    Nombre_Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_Usuario = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Cod_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Usuarios_Cod_Usuario",
                        column: x => x.Cod_Usuario,
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
                    Codigo_Sucursal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Cod_Usuario = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Estado_Sucursales_Usuarios = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales_Usuarios", x => x.Id_Sucursales_Usuarios);
                    table.ForeignKey(
                        name: "FK_Sucursales_Usuarios_Sucursales_Codigo_Sucursal",
                        column: x => x.Codigo_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Codigo_Sucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sucursales_Usuarios_Usuarios_Cod_Usuario",
                        column: x => x.Cod_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Cod_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    ID_TipoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_TipoHabitacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio_TipoHabitacion = table.Column<double>(type: "float", nullable: false),
                    Codigo_Piso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.ID_TipoHabitacion);
                    table.ForeignKey(
                        name: "FK_TipoHabitacion_PisoHabitaciones_Codigo_Piso",
                        column: x => x.Codigo_Piso,
                        principalTable: "PisoHabitaciones",
                        principalColumn: "Codigo_Piso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Cod_Usuario",
                table: "Empleado",
                column: "Cod_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_PisoHabitaciones_Codigo_Sucursal",
                table: "PisoHabitaciones",
                column: "Codigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_Cod_Usuario",
                table: "Sucursales_Usuarios",
                column: "Cod_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Usuarios_Codigo_Sucursal",
                table: "Sucursales_Usuarios",
                column: "Codigo_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_TipoHabitacion_Codigo_Piso",
                table: "TipoHabitacion",
                column: "Codigo_Piso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Sucursales_Usuarios");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "PisoHabitaciones");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
