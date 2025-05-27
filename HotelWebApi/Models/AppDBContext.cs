using HotelWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Models
{
    public class AppDBContext : DbContext
    {
       public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Usuarios> Usuarios => Set<Usuarios>();
        public DbSet<Empleado> Empleado => Set<Empleado>();
        public DbSet<Sucursales> Sucursales => Set<Sucursales>();
        public DbSet<Sucursales_Usuarios> Sucursales_Usuarios => Set<Sucursales_Usuarios>();
        public DbSet<Piso> PisoHabitaciones => Set<Piso>();
        public DbSet<TipoHabitacion> TipoHabitacion => Set<TipoHabitacion>();
        public DbSet<Clientes> Clientes => Set<Clientes>();
    }
}
