using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_consultorio.CapaDatos;

namespace Tarea_consultorio.CapaNegocio
{
    public class CN_Medicos
    {
        public int Medico { get; set; }
        public string Tipo { get; set; }
        public int Nulidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }

    public class MedicoldBusinessLayer
    {
        private MedicoldDataLayer dataLayer;

        public MedicoldBusinessLayer(string connectionString)
        {
            dataLayer = new MedicoldDataLayer(connectionString);
        }

        public void InsertMedicold(Medicold medicold)
        {
            dataLayer.InsertMedicold(medicold);
        }

        public void UpdateMedicold(Medicold medicold)
        {
            dataLayer.UpdateMedicold(medicold);
        }

        public void DeleteMedicold(int medicoId)
        {
            dataLayer.DeleteMedicold(medicoId);
        }

        public Medicold GetMedicold(int medicoId)
        {
            return dataLayer.GetMedicold(medicoId);
        }

        public List<Medicold> GetAllMedicolds()
        {
            return dataLayer.GetAllMedicolds();
        }
    }
}
