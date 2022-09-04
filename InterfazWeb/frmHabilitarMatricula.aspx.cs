using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using Entities;

namespace InterfazWeb
{
    public partial class frmHabilitarMatricula : System.Web.UI.Page
    {
        private DateTime hoy = DateTime.Today;
        //Carga datos de referencia
        private void CargarDatos() {
            ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);
            ReferenceValues referenceAsig;

            try
            {
                referenceAsig = logic.GetReferenceValues();
                if (referenceAsig != null) {
                    if (referenceAsig.ActiveEnroll == 1)
                    {
                        chkHabilitarMatricula.Checked = true;
                    }
                    else {
                        chkHabilitarMatricula.Checked = false;
                    }
                    if (referenceAsig.Year == hoy.Year) {
                        rbtnAnioActual.Checked = true;
                        rbtnAnioActual.Text = hoy.Year.ToString();
                        rbtnSigAnio.Text = (hoy.Year + 1).ToString();
                    } else {
                        rbtnSigAnio.Checked = true;
                        rbtnSigAnio.Text = (hoy.Year + 1 ).ToString();
                        rbtnAnioActual.Text = hoy.Year.ToString();
                    }
                    txtPeriod.Text = Decimal.ToInt32(referenceAsig.Period).ToString();
                    //Session["Period"] = txtPeriod.Text;
                    txtMontoMatricula.Text = Decimal.ToInt32(referenceAsig.CostEnroll).ToString();
                    txtIVA.Text = Decimal.ToInt32(referenceAsig.Tax).ToString();
                    chkHabilitarMatricula.Focus();
                } //else {
                
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }


        //************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Limpiar();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los datos {ex.Message}";
            }
        }
        //Actualiza datos de referencia
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            decimal active, year, period, tax, cost;
            //ReferenceValues setReference = new ReferenceValues();
            if (chkHabilitarMatricula.Checked)
            {
                active = 1;
            }
            else {
                active = 0;
            }
            if (rbtnAnioActual.Checked)
            {
                year = hoy.Year;
            }
            else {
                year = (hoy.Year + 1);
            }
            if (decimal.TryParse(txtPeriod.Text.Trim(), out period) && period < 4 && period >0)
            {
                if (decimal.TryParse(txtMontoMatricula.Text.Trim(), out cost) && cost > 0) {
                    if (decimal.TryParse(txtIVA.Text.Trim(),out tax) && tax > 0 && tax < 100) {
                        ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);
                        ReferenceValues reference = new ReferenceValues(active,year,period,tax,cost);
                        try
                        {
                            if (logic.SetReferenceValues(reference) != -1)
                            {
                                Session["_mensajeB"] = "Valores actualizados con éxito";
                                Session["_reference"] = reference;
                                CargarDatos();
                            }
                            else {
                                Session["_mensaje"] = "Error al actualizar los datos";
                            }
                        }
                        catch (Exception)
                        {
                            Session["_mensaje"] = "Error al actualizar los datos";
                        }               
                    } else {
                        Session["_mensaje"] = $"Error, el impuesto debe ser un valor mayor entre 1 y 99";
                    }

                } else {
                    Session["_mensaje"] = $"Error, costo de matrícula debe ser un valor mayor a 0";
                }
            }
            else {
                Session["_mensaje"] = $"Error, el periodo debe ser un valor entero entre 1 y 3";
            }
        }
        //Check de radio button
        protected void rbtnAnioActual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAnioActual.Checked == true)
            {
                rbtnSigAnio.Checked = false;
            }
            else {
                rbtnSigAnio.Checked = true;
            }
        }
        //check de radio button
        protected void rbtnSigAnio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSigAnio.Checked == true)
            {
                rbtnAnioActual.Checked = false;
            }
            else
            {
                rbtnAnioActual.Checked = true;
            }
        }
    }
}