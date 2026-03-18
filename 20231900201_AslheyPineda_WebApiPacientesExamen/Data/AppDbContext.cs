using _20231900201_AslheyPineda_WebApiPacientesExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace _20231900201_AslheyPineda_WebApiPacientesExamen.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}