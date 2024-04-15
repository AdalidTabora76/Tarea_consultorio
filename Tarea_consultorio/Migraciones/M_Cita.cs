using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tarea_consultorio.Migraciones
{
    internal class M_Cita
    {
        public int CitaId { get; set; }
        public int Fk_Medico { get; set; }
        public int Fk_Pacienteld { get; set; }
        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }
    }

    // Define el contexto de la base de datos
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configura la creación de la tabla Cita
            modelBuilder.Entity<Cita>()
                .ToTable("Cita")
                .HasKey(c => c.CitaId);
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
