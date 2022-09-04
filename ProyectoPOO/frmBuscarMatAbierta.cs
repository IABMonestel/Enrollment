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
    public partial class frmBuscarMatAbierta : Form
    {
        //Crear nuevo Evento
        public event EventHandler Aceptar;
        int id_matAbierta = 0;
        public frmBuscarMatAbierta()
        {
            InitializeComponent();
        }
        private void CargarListaArray(string condicion = "")
        {
            OpenMatterLogic logica = new OpenMatterLogic(Config.getConnectionString);
            List<OpenSubject> lista;
            try
            {
                lista = logica.ListarMatAbiertas(condicion);
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
                id_matAbierta = (int)grdLista.SelectedRows[0].Cells[0].Value;
                Aceptar(id_matAbierta, null);
                Close();
            }
        }

        //************************************************//
        private void btnBuscarMateria_Click(object sender, EventArgs e)
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

        private void frmBuscarMatAbierta_Load(object sender, EventArgs e)
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
    }
}
