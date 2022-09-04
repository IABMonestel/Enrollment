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
    public partial class frmBuscarEstudiante : Form
    {
        //crear un nuevo evento
        public event EventHandler Aceptar;
        string carne = string.Empty;

        public frmBuscarEstudiante()
        {
            InitializeComponent();
        }
        private void CargarListaArray(string condicion = "")
        {
            StudentLogic logica = new StudentLogic(Config.getConnectionString);
            List<Student> lista;
            try
            {
                lista = logica.ListarStudent(condicion);
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
                carne = grdLista.SelectedRows[0].Cells[0].Value.ToString();
                Aceptar(carne, null);
                Close();
            }
        }

        //******************************************************//
        private void frmBuscarEstudiante_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("NombreEstudiante like '%{0}%'", txtNombre.Text.Trim());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }
    }
}
