using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class frmDetalleFactura : System.Web.UI.Page
    {
        //carga los datos de una factura cancelada de un estudiante
        private void CargarDatos() {
            
            Student student;
            StudentLogic logicS = new StudentLogic(Config.getConnectionString);

            ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);
            ReferenceValues referenceAsig;

            if (Session["Carne"] != null)//comprueba el carné
            {
                //carga los detalles de factura
                CargarDetalles(Session["Carne"].ToString());
                //carga los costos de matrícula
                LoadCosts(Session["Carne"].ToString());
                referenceAsig = logic.GetReferenceValues();
                lblNPeriod.Text = referenceAsig.Period.ToString();
                lblNFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lblNAnio.Text = DateTime.Now.Year.ToString();
                student = logicS.GetStudent(Session["Carne"].ToString());
                lblNombre.Text = student.Name + " " + student.FLastName + " " + student.FLastName;
                lblNCarne.Text = Session["Carne"].ToString();
                lblNTipoPago.Text = Session["TypePayment"].ToString();
                lblNComprobante.Text = Session["PurchasePayment"].ToString();
            }
            else {
                Response.Redirect("frmMatricular.aspx", false);
            }
        }

        //***//
        //carga los detalles de factura de estudiante por carné
        private void CargarDetalles(string v)
        {
            List<StudentEnrollDetail> list;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            try
            {
                list = logic.ListarDetallesF(v);
                if (list.Count > 0)
                {
                    GrdDetalles.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    GrdDetalles.DataBind();
                    lblNumFact.Text = list[0].Bill.ToString();
                }
                else
                {
                    GrdDetalles.DataSource = new List<StudentEnrollDetail>();
                    GrdDetalles.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //***//
        //carga los costos de matrícula
        private void LoadCosts(String license)
        {
            StudentEnrollDetail detail;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            double descuento, impuesto, subtotal, iva;
            try
            {
                detail = logic.GetDetailF(license);//obtiene detalles facturados
                if (detail != null)
                {
                    iva = Convert.ToDouble(Session["_iva"].ToString());

                    lblMatriMonto.Text = detail.CostEnroll.ToString();
                    lblMatriMonto.ForeColor = System.Drawing.Color.Red;
                    lblMateMonto.Text = detail.CostMatter.ToString();
                    lblMateMonto.ForeColor = System.Drawing.Color.Red;
                    subtotal = Convert.ToDouble(detail.CostEnroll + detail.CostMatter);
                    lblSubMonto.Text = (subtotal).ToString();
                    lblSubMonto.ForeColor = System.Drawing.Color.Red;
                    descuento = subtotal * Convert.ToDouble(detail.Discount);
                    lblDesMonto.Text = descuento.ToString();
                    lblDesMonto.ForeColor = System.Drawing.Color.Red;
                    impuesto = subtotal * (iva / 100);
                    lblImpMonto.Text = impuesto.ToString();
                    lblImpMonto.ForeColor = System.Drawing.Color.Red;
                    lblTotMonto.Text = (subtotal - descuento + impuesto).ToString(); //+impuesto
                    lblTotMonto.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    lblMatriMonto.Text = string.Empty;
                    lblMateMonto.Text = string.Empty;
                    lblSubMonto.Text = string.Empty;
                    lblDesMonto.Text = string.Empty;
                    lblImpMonto.Text = string.Empty;
                    lblTotMonto.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //*************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//si no es postBack carga la lista
            {
                try
                {
                    CargarDatos();
                }
                catch (Exception ex)
                {

                    Session["_mensaje"] = $"Error al cargar datos {ex.Message}";
                }
            }
        }
    }
}