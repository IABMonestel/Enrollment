using Entities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class frmBuscarProfesor : Form
    {
        //crear un nuevo evento
        public event EventHandler Aceptar;
        int id_profesor = 0;
        public frmBuscarProfesor()
        {
            InitializeComponent();
        }
        //Methods
        private void CargarListaArray(string condicion = "")
        {
            LogicaProfesor logica = new LogicaProfesor(Config.getConnectionString);
            List<Profesor> lista;
            try
            {
                lista = logica.ListarProfesores(condicion);
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
                id_profesor = (int)grdLista.SelectedRows[0].Cells[0].Value;
                Aceptar(id_profesor, null);
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
                    condicion = string.Format("NombreProfesor like '%{0}%'", txtNombre.Text.Trim());
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

        private void frmBuscarProfesor_Load(object sender, EventArgs e)
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

       

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }
    }
}
