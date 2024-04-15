using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_consultorio.CapaDatos;

namespace Tarea_consultorio.CapaNegocio
{
    public class CN_Cita
    {
        public int CitaId { get; set; }
        public int Fk_Medico { get; set; }
        public int Fk_Pacienteld { get; set; }
        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }
    }

    public class CitaBusinessLayer
    {
        private CitaDataLayer dataLayer;

        public CitaBusinessLayer(string connectionString)
        {
            dataLayer = new CitaDataLayer(connectionString);
        }

        public void InsertCita(Cita cita)
        {
            dataLayer.InsertCita(cita);
        }

        public void UpdateCita(Cita cita)
        {
            dataLayer.UpdateCita(cita);
        }

        public void DeleteCita(int citaId)
        {
            dataLayer.DeleteCita(citaId);
        }

        public Cita GetCita(int citaId)
        {
            return dataLayer.GetCita(citaId);
        }

        public List<Cita> GetAllCitas()
        {
            return dataLayer.GetAllCitas();
        }
    }
}
