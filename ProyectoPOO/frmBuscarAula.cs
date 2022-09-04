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
    public partial class frmBuscarAula : Form
    {
        //crear un nuevo evento
        public event EventHandler Aceptar;
        byte id_aula = 0;

        public frmBuscarAula()
        {
            InitializeComponent();
        }

        private void CargarListaArray(string condicion = "")
        {
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            List<Aula> lista;
            try
            {
                lista = logica.ListarAulas(condicion);
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
                id_aula = Convert.ToByte(grdLista.SelectedRows[0].Cells[0].Value);
                Aceptar(id_aula, null);
                Close();
            }
        }

        //************************************************//

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("TipoAula like '%{0}%'", txtNombre.Text.Trim());
                }
                CargarListaArray(condicion);
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

        private void frmBuscarAula_Load(object sender, EventArgs e)
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

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }
    }
}
