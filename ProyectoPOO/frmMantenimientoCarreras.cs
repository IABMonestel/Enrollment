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
    public partial class frmMantenimientoCarreras : Form
    {
        //Objects
        private Careers careerAsig;
        public frmMantenimientoCarreras()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            nudCredits.Value = 1;
            careerAsig = null;
        }

        private void CargarListaArray(string condicion = "")
        {
            CareersLogic logic = new CareersLogic(Config.getConnectionString);
            List<Careers> lista;
            try
            {
                lista = logic.ListarCareers(condicion);
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

        private void LoadCareer(int id)
        {
            Careers career;
            CareersLogic logic  = new CareersLogic(Config.getConnectionString);
            try
            {
                career = logic.GetCareer(id);
                if (career != null)
                {
                    txtCodigo.Text = career.Code.ToString();
                    txtNombre.Text = career.Name.ToString();
                    nudCredits.Value = career.Credits;
                    cboGrade.SelectedItem = career.Degree.ToString();
                    careerAsig = career;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La carrera no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //************************************************//

        private void frmMantenimientoCarreras_Load(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                CargarListaArray();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            CareersLogic logic = new CareersLogic(Config.getConnectionString);
            Careers career;
            int resultado, careerCode = -1;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) &&
                    cboGrade.SelectedItem != null)
                {
                    career = logic.GetCareer(careerCode);
                    if (career == null)
                    {
                        career = new Careers(-1, txtNombre.Text, (short)nudCredits.Value, cboGrade.SelectedItem.ToString(),true);
                        resultado = logic.Insertar(career);
                    }
                    else
                    {
                        //modificar
                        resultado = logic.Insertar(careerAsig);
                    }
                    if (resultado > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Operación realizada satisfactoriamente", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarListaArray();
                    }
                    else
                    {
                        MessageBox.Show("No se realizó ninguna modificación", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos son obligatorios",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CareersLogic logic = new CareersLogic(Config.getConnectionString);
            Careers career;
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    career = logic.GetCareer(int.Parse(txtCodigo.Text));
                    if (career != null)
                    {
                        resultado = logic.Delete(career);
                        MessageBox.Show(logic.Mensaje, "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        CargarListaArray();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Limpiar();
                        CargarListaArray();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)grdLista.SelectedRows[0].Cells[0].Value;
                LoadCareer(id);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
