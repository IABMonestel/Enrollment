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
    public partial class frmBusMatAbiMatri : Form
    {
        public event EventHandler Aceptar;
        int id_mat = 0;
        public frmBusMatAbiMatri()
        {
            InitializeComponent();
        }

        private void CargarListaArray(string condicion = "")
        {
            OpenMatterLogic logica = new OpenMatterLogic(Config.getConnectionString);
            List<OpenSubject> lista;
            try
            {
                lista = logica.ListarMateriasProfeAula(condicion);
                if (lista.Count > 0)
                {
                    grdLista.DataSource = lista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Seleccionar()
        {
            if (grdLista.SelectedRows.Count > 0)
            {
                id_mat = (int)grdLista.SelectedRows[0].Cells[0].Value;
                Aceptar(id_mat, null);
                Close();
            }
        }
        //*********************************************//

        private void frmBusMatAbiMatri_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaArray();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    condicion = string.Format("NombreMateria like '%{0}%'", txtBuscar.Text.Trim());
                }
                CargarListaArray(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            Seleccionar();
            
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }
    }
}
