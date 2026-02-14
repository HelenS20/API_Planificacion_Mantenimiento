using API_Planificación_Mantenimiento.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Planificación_Mantenimiento.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }

}
