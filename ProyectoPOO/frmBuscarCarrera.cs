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
    public partial class frmBuscarCarrera : Form
    {
        //crear un nuevo evento
        public event EventHandler Aceptar;
        int id_carrera = 0;
        public frmBuscarCarrera()
        {
            InitializeComponent();
        }

        private void CargarListaArray(string condicion = "")
        {
            CareersLogic logica = new CareersLogic(Config.getConnectionString);
            List<Careers> lista;
            try
            {
                lista = logica.ListarCareers(condicion);
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
                id_carrera = (int)grdLista.SelectedRows[0].Cells[0].Value;
                Aceptar(id_carrera, null);
                Close();
            }
        }

        //******************************************************//

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("NombreCarrera like '%{0}%'", txtNombre.Text.Trim());
                }
                CargarListaArray(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBuscarCarrera_Load(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }
    }
}
