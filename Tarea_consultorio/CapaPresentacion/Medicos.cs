using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea_consultorio.CapaNegocio;
using Tarea_consultorio.Migraciones;

namespace Tarea_consultorio.CapaPresentacion
{
    public partial class Medicos : Form
    {
        private Medicos medicos;
        public Medicos()
        {
            InitializeComponent();
            medicos = new Medicos();
        }

        private void Medicos_Load(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            int medico = int.Parse(txtmedicos.Text);
            string nombre = txtnombres.Text;
            string apellido= txtapellido.Text;
            DateTime fechaIngreso = DateTime.Parse(dtpfecha.Text);
            bool estado = chkestado.Checked;


            Medicos nuevoMedico = new Medicos
            {
                Medico = medico,
               
               
                Nombres = nombres,
                Apellidos = apellidos,
                FechaIngreso = fechaIngreso,
                Estado = estado
            };
            int Insertmedico = medicos.InsertMedicold(nuevoMedico);

        }

       
    }
}
