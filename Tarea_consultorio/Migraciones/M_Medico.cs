using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_consultorio.Migraciones
{
    public class M_Medico
    {

        public int Medico { get; set; }
        public string Tipo { get; set; }
        public int Nulidad { get; set; }
        public int PK_Medicold { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fechaingreso { get; set; }
        public bool Estado { get; set; }
    }

    // Define el contexto de la base de datos
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Medicold> Medicolds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configura la creación de la tabla Medicold
            modelBuilder.Entity<Medicold>()
                .ToTable("Medicold")
                .HasKey(m => m.PK_Medicold);
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