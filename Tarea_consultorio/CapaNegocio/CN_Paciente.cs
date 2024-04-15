using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_consultorio.CapaDatos;
using Tarea_consultorio.Migraciones;

namespace Tarea_consultorio.CapaNegocio
{
    
    public class CN_Paciente
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }

    public class PacienteBusinessLayer
    {
        private PacienteDataLayer dataLayer;

        public PacienteBusinessLayer(string connectionString)
        {
            dataLayer = new PacienteDataLayer(connectionString);
        }

        public void InsertPaciente(Paciente paciente)
        {
            dataLayer.InsertPaciente(paciente);
        }

        public void UpdatePaciente(Paciente paciente)
        {
            dataLayer.UpdatePaciente(paciente);
        }

        public void DeletePaciente(int pacienteId)
        {
            dataLayer.DeletePaciente(pacienteId);
        }

        public Paciente GetPaciente(int pacienteId)
        {
            return dataLayer.GetPaciente(pacienteId);
        }

        public List<Paciente> GetAllPacientes()
        {
            return dataLayer.GetAllPacientes();
        }
    }
}
