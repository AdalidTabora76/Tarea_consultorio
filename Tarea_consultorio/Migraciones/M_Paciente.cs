using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tarea_consultorio.Migraciones
{
    internal class M_Paciente
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }

    // Define el contexto de la base de datos
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configura la creación de la tabla Pacientes
            modelBuilder.Entity<Paciente>()
                .ToTable("Pacientes")
                .HasKey(p => p.PacienteId);
        }
    }

    // En tu programa principal o método de inicialización, puedes usar migraciones de EF para aplicar los cambios en la base de datos
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia del contexto
            using (var context = new ApplicationDbContext())
            {
                // Aplicar migraciones
                var migrator = new System.Data.Entity.Migrations.DbMigrator(new Migrations.Configuration());
                migrator.Update();
            }
        }
    }
}
