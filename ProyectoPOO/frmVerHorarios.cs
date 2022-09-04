using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class frmVerHorarios : Form
    {
        int id_mat_Abi;
        public frmVerHorarios(object id)
        {
            InitializeComponent();
            id_mat_Abi = (int)id;
        }

        private void EliminarHorario()
        {
            Schedule schedule = new Schedule();
            if (grdLista.SelectedRows.Count > 0)
            {
                ScheduleLogic logic = new ScheduleLogic(Config.getConnectionString);
                schedule.OpenSubjectCode = (int)grdLista.SelectedRows[0].Cells[0].Value; ;
                schedule.Dia = (char)grdLista.SelectedRows[0].Cells[1].Value;
                schedule.StartTime = grdLista.SelectedRows[0].Cells[2].Value.ToString();
                schedule.EndTime = grdLista.SelectedRows[0].Cells[3].Value.ToString();
                logic.EliminarHorario(schedule);
            }
            else {
                MessageBox.Show("Seleccione un horario", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListaArray(int condicion)
        {
            ScheduleLogic logica = new ScheduleLogic(Config.getConnectionString);
            List<Schedule> lista;
            try
            {
                lista = logica.ListarScheduler(condicion);
                if (lista.Count > 0)
                {
                    grdLista.DataSource = lista;
                }
                else {
                    grdLista.Columns.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmVerHorarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaArray(id_mat_Abi);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea ELIMINAR?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    EliminarHorario();
                    CargarListaArray(id_mat_Abi);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
