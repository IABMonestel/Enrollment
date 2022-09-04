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
    public partial class frmConsultarMatricula : System.Web.UI.Page
    {
        //Methods
        //limpia datos  
        private void Limpiar() {
            lblNumFact.Text = string.Empty;
            lblNPeriod.Text = string.Empty;
            lblNFecha.Text = string.Empty;
            lblNAnio.Text = string.Empty;            
            lblNombre.Text = string.Empty;
            lblNCarne.Text = string.Empty;
            lblNTipoPago.Text = string.Empty;
            lblNComprobante.Text = string.Empty;
            lblMatriMonto.Text = string.Empty;
            lblMatriMonto.ForeColor = System.Drawing.Color.Red;
            lblMateMonto.Text = string.Empty;
            lblMateMonto.ForeColor = System.Drawing.Color.Red;
            lblSubMonto.Text = string.Empty;
            lblSubMonto.ForeColor = System.Drawing.Color.Red;
            lblDesMonto.Text = string.Empty;
            lblDesMonto.ForeColor = System.Drawing.Color.Red;
            lblImpMonto.Text = string.Empty;
            lblImpMonto.ForeColor = System.Drawing.Color.Red;
            lblTotMonto.Text = string.Empty; ; //+impuesto
            lblTotMonto.ForeColor = System.Drawing.Color.Red;
        }
        //carga lista de matrícula
        private void CargarEstudiantes(string condicion = "")
        {
            List<Student> list;
            StudentLogic logica = new StudentLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarStudent(condicion, "");
                if (list.Count > 0)
                {
                    grdEstudiante.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdEstudiante.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //carga los datos
        private void CargarDatos(string carne)
        {
            Student student;
            StudentLogic logicS = new StudentLogic(Config.getConnectionString);

            ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);
            ReferenceValues referenceAsig;

            Enrollment enrollment;
            EnrollmentLogic logicE = new EnrollmentLogic(Config.getConnectionString);

            if (!string.IsNullOrEmpty(carne))
            {
                CargarDetalles(carne);//carga detalles de estudiante

                if (!string.IsNullOrEmpty(lblNumFact.Text))
                {
                    enrollment = logicE.Obtener(int.Parse(lblNumFact.Text));
                    referenceAsig = logic.GetReferenceValues();
                    lblNPeriod.Text = referenceAsig.Period.ToString();
                    Session["_iva"] = referenceAsig.Tax;
                    LoadCosts(carne);//carga los costos del estudiante
                    lblNFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    lblNAnio.Text = DateTime.Now.Year.ToString();
                    student = logicS.GetStudent(carne);
                    lblNombre.Text = student.Name + " " + student.FLastName + " " + student.SLastName;
                    lblNCarne.Text = carne;
                    lblNTipoPago.Text = enrollment.TypePayment;
                    lblNComprobante.Text = enrollment.PurchasePayment;
                }
                else {
                    Session["_mensaje"] = $"Error, estudiante no posee factura cancelada";
                }
            }
            else
            {
                Session["_mensaje"] = $"Error al cargar datos";
            }
        }

        //***//
        //carga detalles de matrícula
        private void CargarDetalles(string v)
        {
            List<StudentEnrollDetail> list;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            try
            {
                list = logic.ListarDetallesF(v);//lista detalles facturados
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
        //carga los costos de estudiante por carne
        private void LoadCosts(String license)
        {

            StudentEnrollDetail detail;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            double descuento, impuesto, subtotal, iva;
            try
            {
                detail = logic.GetDetailF(license);//obtiene detalles de facturas canceladas
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
                    //CargarDatos();
                    Limpiar();
                    CargarEstudiantes();

                }
                catch (Exception ex)
                {

                    Session["_mensaje"] = $"Error al cargar datos {ex.Message}";
                }
            }
        }
        //busca estudiantes por nombre
        protected void btnBEstu_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameS like '%{txtNombreS.Text.Trim()}%'";
                CargarEstudiantes(condicion);
                string javascript = "AbrirModalE();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception)
            {
                Session["_mensaje"] = "Error al buscar el Estudiante";
            }
        }
        //selecciona un estudiante de la lista y carga datos
        protected void lnkSeleccionarE_Command(object sender, CommandEventArgs e)
        {
            Limpiar();
            Student estudiante;
            StudentLogic studentLogic = new StudentLogic(Config.getConnectionString);
            string carne = e.CommandArgument.ToString();
            try
            {
                estudiante = studentLogic.GetStudent(carne);
                if (estudiante != null)
                {
                    //Session["Carne"] = estudiante.License.ToString();
                    txtEstudiante.Text = $"{estudiante.Name} {estudiante.FLastName} {estudiante.SLastName}";
                    //CargarDetalles(estudiante.License);
                    //LoadCosts(estudiante.License);
                    CargarDatos(estudiante.License);
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }
        //Cambia el índice de página de lista de estudiantes
        protected void grdEstudiante_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdEstudiante.PageIndex = e.NewPageIndex;
                CargarEstudiantes();
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }

    }
}