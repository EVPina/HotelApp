﻿// <auto-generated />
using HotelWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelWebApi.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250527164506_ReformulacionTablas")]
    partial class ReformulacionTablas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelWebApi.Models.Clientes", b =>
                {
                    b.Property<string>("Cod_Clientes")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Apellido_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DNI_Cliente")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_Clientes");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HotelWebApi.Models.Empleado", b =>
                {
                    b.Property<string>("Cod_Empleado")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Apellido_Empleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cod_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("DNI_Empleado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Empleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_Empleado");

                    b.HasIndex("Cod_Usuario");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("HotelWebApi.Models.Piso", b =>
                {
                    b.Property<int>("Codigo_Piso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Piso"));

                    b.Property<string>("Codigo_Sucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Estado_Habitacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombre_Piso")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Codigo_Piso");

                    b.HasIndex("Codigo_Sucursal");

                    b.ToTable("PisoHabitaciones");
                });

            modelBuilder.Entity("HotelWebApi.Models.Sucursales", b =>
                {
                    b.Property<string>("Codigo_Sucursal")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Nombre_Sucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo_Sucursal");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("HotelWebApi.Models.Sucursales_Usuarios", b =>
                {
                    b.Property<int>("Id_Sucursales_Usuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Sucursales_Usuarios"));

                    b.Property<string>("Cod_Usuario")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Codigo_Sucursal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Estado_Sucursales_Usuarios")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id_Sucursales_Usuarios");

                    b.HasIndex("Cod_Usuario");

                    b.HasIndex("Codigo_Sucursal");

                    b.ToTable("Sucursales_Usuarios");
                });

            modelBuilder.Entity("HotelWebApi.Models.TipoHabitacion", b =>
                {
                    b.Property<int>("ID_TipoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_TipoHabitacion"));

                    b.Property<int>("Codigo_Piso")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_TipoHabitacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio_TipoHabitacion")
                        .HasColumnType("float");

                    b.HasKey("ID_TipoHabitacion");

                    b.HasIndex("Codigo_Piso");

                    b.ToTable("TipoHabitacion");
                });

            modelBuilder.Entity("HotelWebApi.Models.Usuarios", b =>
                {
                    b.Property<string>("Cod_Usuario")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Correo_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HotelWebApi.Models.Empleado", b =>
                {
                    b.HasOne("HotelWebApi.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("Cod_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("HotelWebApi.Models.Piso", b =>
                {
                    b.HasOne("HotelWebApi.Models.Sucursales", "Sucursales")
                        .WithMany()
                        .HasForeignKey("Codigo_Sucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("HotelWebApi.Models.Sucursales_Usuarios", b =>
                {
                    b.HasOne("HotelWebApi.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("Cod_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelWebApi.Models.Sucursales", "Sucursales")
                        .WithMany()
                        .HasForeignKey("Codigo_Sucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursales");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("HotelWebApi.Models.TipoHabitacion", b =>
                {
                    b.HasOne("HotelWebApi.Models.Piso", "piso")
                        .WithMany()
                        .HasForeignKey("Codigo_Piso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("piso");
                });
#pragma warning restore 612, 618
        }
    }
}
