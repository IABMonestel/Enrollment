using BusinessLogic;
using Entities;
using Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOO
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiEstudiantes_Click(object sender, EventArgs e)
        {
            frmMantenimientoEstudiantes mantenimientoEstudiantes = new frmMantenimientoEstudiantes();
            mantenimientoEstudiantes.MdiParent = this;
            mantenimientoEstudiantes.Show();
        }

        private void tsmiProfesores_Click(object sender, EventArgs e)
        {
            frmMantenimientoProfesores mantenimientoProfesores = new frmMantenimientoProfesores();
            mantenimientoProfesores.MdiParent = this;
            mantenimientoProfesores.Show();

        }

        private void tsmiMaterias_Click(object sender, EventArgs e)
        {
            frmMantenimientoMaterias mantenimientoMaterias = new frmMantenimientoMaterias();
            mantenimientoMaterias.MdiParent = this;
            mantenimientoMaterias.Show();
        }

        private void tsmiCarreras_Click(object sender, EventArgs e)
        {
            frmMantenimientoCarreras mantenimientoCarreras = new frmMantenimientoCarreras();
            mantenimientoCarreras.MdiParent = this;
            mantenimientoCarreras.Show();
        }

        private void aulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoAulas mantenimientoAulas = new frmMantenimientoAulas();
            mantenimientoAulas.MdiParent = this;
            mantenimientoAulas.Show();
        }

        private void tsmiMateriaCarrera_Click(object sender, EventArgs e)
        {
            frmAsignarMateriaCarrera materiaCarrera = new frmAsignarMateriaCarrera();
            materiaCarrera.MdiParent = this;
            materiaCarrera.Show();
        }

        private void abrirMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbrirMateria materiaAbierta = new frmAbrirMateria();
            materiaAbierta.MdiParent = this;
            materiaAbierta.Show();
        }

        private void tsmiMatricular_Click(object sender, EventArgs e)
        {
            
            ReferenceValues values = new ReferenceValues();
            ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);

            try
            {
                values = logic.GetReferenceValues();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,
                    "No periodo de matrícula", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (values.ActiveEnroll == 1)
            {
                frmMatricular matricular = new frmMatricular(values);
                matricular.MdiParent = this;
                matricular.Show();
            }
            else {
                MessageBox.Show("No se pueden realizar matrículas. Habilite el periodo de matrícula",
                    "No periodo de matrícula", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void habilitarPeriodoMatrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHabilitarPeriodoMatricula habilitar = new frmHabilitarPeriodoMatricula();
            habilitar.MdiParent = this;
            habilitar.Show();
        }
    }
}
