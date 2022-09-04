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
    public partial class frmHabilitarPeriodoMatricula : Form
    {
        private DateTime hoy = DateTime.Today;
        public frmHabilitarPeriodoMatricula()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            ReferenceValues referenceValues;
            ReferenceValuesLogic logica = new ReferenceValuesLogic(Config.getConnectionString);
            try
            {
                referenceValues = logica.GetReferenceValues();
                if (referenceValues != null)
                {
                    rbtActualYear.Text = hoy.Year.ToString();
                    rbtNextYear.Text = (Convert.ToInt32(hoy.Year.ToString()) + 1).ToString();

                    if (referenceValues.ActiveEnroll == 1)
                    {
                        chkHabilitar.Checked = true;
                    }
                    else {
                        chkHabilitar.Checked = false;
                    }
                    if (referenceValues.Year == Convert.ToDecimal(hoy.Year.ToString()))
                    {
                        rbtActualYear.Checked = true;
                    }
                    else {
                        rbtNextYear.Checked = true;
                    }
                    npdPeriodo.Value = referenceValues.Period;
                    txtIVA.Text = referenceValues.Tax.ToString();
                    txtMontoMatri.Text = referenceValues.CostEnroll.ToString();
                }
                else
                {
                    MessageBox.Show("Error al cargar datos", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmHabilitarPeriodoMatricula_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ReferenceValues values = new ReferenceValues();
            ReferenceValuesLogic logica = new ReferenceValuesLogic(Config.getConnectionString);
            int result = -999;
            decimal tax, costEnroll;
            if (chkHabilitar.Checked) {
                values.ActiveEnroll = 1;
            } else {
                values.ActiveEnroll = 0;
            }
            if (rbtActualYear.Checked) {
                values.Year = Convert.ToDecimal(hoy.Year.ToString());
            } else {
                values.Year = Convert.ToDecimal(Convert.ToInt32(hoy.Year.ToString())+1);
            }
            values.Period = npdPeriodo.Value;
            if (!string.IsNullOrEmpty(txtIVA.Text.Trim())) {
                if (decimal.TryParse(txtIVA.Text.Trim(),out tax)) {
                    values.Tax = tax;
                    if (!string.IsNullOrEmpty(txtMontoMatri.Text.Trim()))
                    {
                        if (decimal.TryParse(txtMontoMatri.Text.Trim(), out costEnroll))
                        {
                            values.CostEnroll = costEnroll;
                            try
                            {
                                result = logica.SetReferenceValues(values);
                                if (result != -999)
                                {
                                    MessageBox.Show("Operación realizada con éxito", "Operación realizada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Operación denegada", "Operación denegada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception exc)
                            {

                                MessageBox.Show(exc.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Digite el monto de matrícula como valor numérico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite el monto de matrícula", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    } else {
                    MessageBox.Show("Digite el impuesto como valor numérico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Digite el impuesto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
