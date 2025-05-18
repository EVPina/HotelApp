using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Models
{
    public class AppDBContext : DbContext
    {
       public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Usuarios> Usuarios => Set<Usuarios>();
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Sucursales> Sucursales => Set<Sucursales>();
        public DbSet<Sucursales_Usuarios> Sucursales_Usuarios => Set<Sucursales_Usuarios>();
        public DbSet<PisoHabitaciones> PisoHabitaciones => Set<PisoHabitaciones>();
        public DbSet<TipoHabitacion> TipoHabitacion => Set<TipoHabitacion>();
    }
}
