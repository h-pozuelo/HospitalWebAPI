using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
