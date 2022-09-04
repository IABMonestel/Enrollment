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
    public partial class frmBuscarMaterias : Form
    {
        public event EventHandler Aceptar;
        private string id_materia = string.Empty;

        public frmBuscarMaterias()
        {
            InitializeComponent();
        }

        private void CargarListaArray(string condicion = "")
        {
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            List<Matter> lista;
            try
            {
                lista = logica.ListarMaterias(condicion);
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

                id_materia = grdLista.SelectedRows[0].Cells[0].Value.ToString();
                Aceptar(id_materia,null);
                Close();
            }
        }

    //*************************************************************//
    private void frmBuscarMaterias_Load(object sender, EventArgs e)
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
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("NombreMateria like '%{0}%'", txtNombre.Text.Trim());
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
