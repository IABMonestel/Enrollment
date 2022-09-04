using BusinessLogic;
using Entities;
using Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoPOO
{
    public partial class frmMantenimientoAulas : Form
    {
        private Aula aulaAsig;

        public frmMantenimientoAulas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtCodigoAula.Text = string.Empty;
            cboTipo.SelectedItem = string.Empty;
            nudNumAula.Value = 1;
            nudCapacidad.Value = 10;
            btnBuscarCodigo.Focus();
            aulaAsig = null;
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

        private void CargarAula(byte id)
        {
            Aula aula;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            try
            {
                aula = logica.ObtenerAula(id);
                if (aula != null)
                {
                    txtCodigoAula.Text = aula.Codigo.ToString();
                    cboTipo.SelectedItem = aula.Tipo.ToString();
                    nudNumAula.Value = aula.Numero;
                    nudCapacidad.Value = aula.Capacidad;
                    aulaAsig = aula;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("El cliente no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //************************************************************//
        private void frmMantenimientoAulas_Load(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                CargarListaArray();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (aulaAsig != null)
            {
                if (cboTipo.SelectedItem.ToString() != string.Empty)
                {
                    Aula aula = new Aula(-1, cboTipo.SelectedItem.ToString(), Convert.ToByte(nudNumAula.Value),
                        Convert.ToByte(nudCapacidad.Value), true);
                    LogicaAula logic = new LogicaAula(Config.getConnectionString);
                    try
                    {
                        result = logic.Insertar(aula);
                        if (result != -1)
                        {
                            aulaAsig = aula;
                            MessageBox.Show("Aula creada con éxito", "Aula Creada", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            CargarListaArray();
                            CargarAula(Convert.ToByte(aula.Codigo));
                        }
                        else
                        {
                            MessageBox.Show("Error al crear el aula", "ERROR", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exc)
                    {

                        MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el tipo de aula", "Tipo de aula", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Aula ya creada. Seleccione modificar, o limpiar campos para crear una nueva"
                    , "ERROR", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (cboTipo.SelectedItem.ToString() != string.Empty)
            {
                Aula aula = new Aula(aulaAsig.Codigo, cboTipo.SelectedItem.ToString(), Convert.ToByte(nudNumAula.Value),
                    Convert.ToByte(nudCapacidad.Value), true);
                LogicaAula logic = new LogicaAula(Config.getConnectionString);
                try
                {
                    result = logic.Insertar(aula);
                    if (result != -1)
                    {
                        aulaAsig = aula;
                        MessageBox.Show("Aula modificada con éxito", "Aula Creada", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        CargarListaArray();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el aula", "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de aula", "Tipo de aula", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            Aula aula;
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(txtCodigoAula.Text))
                {
                    aula = logica.ObtenerAula(Convert.ToByte(txtCodigoAula.Text));
                    if (aula != null)
                    {
                        resultado = logica.Delete(aula);
                        MessageBox.Show(logica.Mensaje, "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        CargarListaArray();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El aula no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Limpiar();
                        CargarListaArray();
                    }
                }
                else
                {
                    grdLista.Focus();
                    MessageBox.Show("Debe seleccionar un aula antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtTipo.Text))
                {
                    condicion = string.Format("TipoAula like '%{0}%'", txtTipo.Text.Trim());
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
            short id = 0;
            try
            {
                id = (short)grdLista.SelectedRows[0].Cells[0].Value;
                CargarAula(Convert.ToByte(id));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
