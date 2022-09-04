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
    public partial class frmMatricular : System.Web.UI.Page
    {
        //Methods
        //Carga los estudiantes
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
        //Carga las materias abiertas
        private void CargarMaterias(string condicion = "")
        {
            List<OpenSubject> list;
            OpenMatterLogic logica = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarMateriasMatricular(condicion);
                if (list.Count > 0)
                {
                    GrdMaterias.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    GrdMaterias.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Carga los detalles matriculados
        private void CargarDetalles(string v)
        {
            List<StudentEnrollDetail> list;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            try
            {
                list = logic.ListarDetalles(v);
                if (list.Count > 0)
                {
                    GrdDetalles.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    GrdDetalles.DataBind();
                    txtFactEstu.Text = list[0].Bill.ToString();
                }
                else {
                    GrdDetalles.DataSource = new List<StudentEnrollDetail>();
                    GrdDetalles.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Limpia los datos
        private void Limpiar(decimal period = 0, decimal year = 0)
        {
            Session["Id_Mat"] = null;
            Session["Carne"] = null;
            txtIdMateria.Text = string.Empty;
            txtEstudiante.Focus();
            txtFecha.Text = DateTime.Now.ToString("d");
            txtCodigo.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtCupo.Text = string.Empty;
            txtEstudiante.Text = string.Empty;
            txtMateria.Text = string.Empty;
            txtComprobante.Text = string.Empty;
            if (period != 0)
            {
                txtPeriodo.Text = Decimal.ToInt32(period).ToString();
                txtAnio.Text = Decimal.ToInt32(year).ToString();
            }
            GrdDetalles.DataSource = new List<StudentEnrollDetail>();
            GrdDetalles.DataBind();
            lblMatriMonto.Text = string.Empty;
            lblMateMonto.Text = string.Empty;
            
            lblSubMonto.Text = string.Empty;
            
            lblDesMonto.Text = string.Empty;
            
            lblImpMonto.Text = string.Empty;
            lblTotMonto.Text = string.Empty;
        }
        //Carga los costos por carné 
        private void LoadCosts(String license) {

            StudentEnrollDetail detail;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            double descuento, impuesto, subtotal, iva;
            try
            {
                detail = logic.GetDetail(license);//Obtiene los detalles por carné
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
                else {
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

        //*************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            ReferenceValues reference;
            ReferenceValuesLogic referenceLogic = new ReferenceValuesLogic(Config.getConnectionString);
            
            try
            {
                if (!IsPostBack)//si no es postBack carga la lista
                {
                    reference = referenceLogic.GetReferenceValues();
                    if (reference.ActiveEnroll == 0)
                    {
                        Session["_mensaje"] = "Habilite el período de matrícula";
                        Response.Redirect("frmHabilitarMatricula.aspx",false);
                    }
                    else
                    {
                        Limpiar(decimal.Parse(reference.Period.ToString()),
                            decimal.Parse(reference.Year.ToString()));
                        Session["_iva"] = reference.Tax.ToString();
                        CargarEstudiantes();
                        CargarMaterias();
                    }
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar las materias {ex.Message}";
            }
        }
        //Busca estudiantes por nombre
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
        //Selecciona materia abierta
        protected void lnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            OpenSubject openSubject;
            OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
            int code = int.Parse(e.CommandArgument.ToString());

            try
            {
                openSubject = logic.GetOpenSubject(code);
                if (openSubject != null)
                {
                    Session["Id_Mat"] = openSubject.OpenSubjectsCode;
                    txtIdMateria.Text = openSubject.OpenSubjectsCode.ToString();
                    txtMateria.Text = openSubject.Name.ToString();
                    txtCodigo.Text = openSubject.Code.ToString();
                    txtGrupo.Text = openSubject.Group.ToString();
                    txtCupo.Text = openSubject.Quota.ToString();
                    txtCarrera.Text = openSubject.CareerName.ToString();

                }
                else {
                    Session["_mensaje"] = "Error al buscar la materia";
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al buscar la materia {ex.Message}";
            }
        }
        //Busca materia abierta por nombre
        protected void btnBMatA_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameM like '%{txtNMatAbi.Text.Trim()}%'";
                CargarMaterias(condicion);
                string javascript = "MateriaAbierta();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al buscar el Estudiante";
            }
        }
        //Elimina un detalle de matrícula
        protected void lnkEliminarD_Command(object sender, CommandEventArgs e)
        {
            EnrollmentDetails enrollmentDetails;
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
            try
            {
                enrollmentDetails = new EnrollmentDetails();
                enrollmentDetails.OpenMatCode = int.Parse(e.CommandArgument.ToString());
                enrollmentDetails.BillNumber = int.Parse(txtFactEstu.Text);
                if (logic.Eliminar(enrollmentDetails) == 0)
                {
                    Session["_mensajeB"] = "Materia eliminada";
                    CargarDetalles(txtCarne.Text);
                    LoadCosts(Session["Carne"].ToString());
                }
                else {
                    Session["_mensaje"] = $"Error al eliminar detalle";
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al eliminar detalle {ex.Message}";
            }
        }
        //Matricula
        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            //Comprobar existencia
            EnrollmentLogic logic = new EnrollmentLogic(Config.getConnectionString);

            try
            {
                if (logic.Matricular(Session["Carne"].ToString(),
                    int.Parse(Session["Id_Mat"].ToString())) == 0)
                {
                    CargarDetalles(Session["Carne"].ToString());
                    LoadCosts(Session["Carne"].ToString());
                    Session["_mensajeB"] = "Materia matrículada con éxito";
                }
                else {
                    Session["_mensaje"] = "Error al matricular";
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al buscar el Estudiante {ex.Message}";
            }
        }
        //cancela la matrícula
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Response.Redirect("Default.aspx");
        }
        //Limpia los datos
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Factura la matrícula
        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEstudiante.Text))
            {
                Enrollment enrollment;
                EnrollmentLogic logic = new EnrollmentLogic(Config.getConnectionString);
                if (GrdDetalles.Rows.Count > 0)
                {
                    try
                    {
                        enrollment = new Enrollment();
                        enrollment.NumFact = int.Parse(txtFactEstu.Text);
                        enrollment.Meat = Session["Carne"].ToString();
                        enrollment.TypePayment = cboTipoPago.Text;
                        enrollment.PurchasePayment = txtComprobante.Text;

                        if (logic.Modificar(enrollment) > 0){//Válida si pudo modificar

                            //Limpiar();
                            Session["TypePayment"] = enrollment.TypePayment;
                            Session["PurchasePayment"] = enrollment.PurchasePayment;
                            Response.Redirect("frmDetalleFactura.aspx", false);

                        } else {
                            Session["_mensajeB"] = "Error al tramitar factura";
                        }
                    }
                    catch (Exception ex)
                    {

                        Session["_mensaje"] = $"Error al crear la factura {ex.Message}";
                    }
                }
                else {
                    Session["_mensaje"] = "Seleccione la materia";
                }
            }
            else {
                Session["_mensaje"] = "Seleccione el estudiante";
            }
        }
        //Cambia página de grid de estudiantes
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
        //Selecciona un estudiante
        protected void lnkSeleccionarE_Command(object sender, CommandEventArgs e)
        {
            Limpiar();
            Student estudiante;
            StudentLogic studentLogic = new StudentLogic(Config.getConnectionString);
            string carne = e.CommandArgument.ToString();
            try
            {
                estudiante = studentLogic.GetStudent(carne);
                if (estudiante != null) {
                    Session["Carne"] = estudiante.License.ToString();
                    txtEstudiante.Text = $"{estudiante.Name} {estudiante.FLastName} {estudiante.SLastName}";
                    CargarDetalles(estudiante.License);
                    LoadCosts(estudiante.License);
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }
    }
}