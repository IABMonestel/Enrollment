using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class frmCerrarMateria : System.Web.UI.Page
    {
        //Carga la materia seleccionada
        private void CargarLista(string condicion = "")
        {
            string condicionBase = "OpenMatCode =";
            DataSet DS;
            EnrollDetailLogic logica = new EnrollDetailLogic(Config.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(condicion))
                {
                    condicionBase = $"{condicionBase} {condicion}";
                }
                DS = logica.ListarDetallesM(condicionBase);
                if (DS != null)
                {
                    GrdLista.DataSource = DS;
                    GrdLista.DataMember = DS.Tables[0].TableName;
                    GrdLista.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //carga lista de materias abiertas
        private void CargarMateriasAbi(string condicion = "", string orden = "NameM")
        {
            List<OpenSubject> list;
            OpenMatterLogic logicaMA = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                list = logicaMA.ListarMatAbiertas(condicion, orden);
                if (list.Count > 0)
                {
                    grdMatAbi.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdMatAbi.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //******************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) {

                    CargarMateriasAbi();
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar datos {ex.Message}";
            }
        }
        //busca materia abierta por código
        protected void btnBMatA_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameM like '%{txtNMatAbi.Text.Trim()}%'";
                CargarMateriasAbi(condicion);
                string javascript = "MateriaAbierta();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception)
            {
                Session["_mensaje"] = "Error al buscar la materia";
            }
        }
        //Selecciona una materia abierta
        protected void lnkSeleccionarMatA_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            OpenSubject openSubject;
            OpenMatterLogic openMatterLogic = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                openSubject = openMatterLogic.GetOpenSubject(id);
                if (openSubject != null)
                {
                    //txtidMateriaC.Text = openSubject.CareerMatterCode.ToString();
                    txtMateria.Text = openSubject.Name;
                    txtCodigo.Text = openSubject.Code;
                    //No me carga el costo
                    txtCost.Text = Decimal.ToInt32(openSubject.Cost).ToString();
                    txtGrupo.Text = openSubject.Group.ToString();
                    txtCupo.Text = openSubject.Quota.ToString();
                    txtAnio.Text = openSubject.Year.ToString();
                    
                    txtPeriod.Text = openSubject.Period.ToString();
                    
                    //CargarHorarios(id);
                    Session["Id_MatAbierta"] = id;
                    CargarLista(id.ToString());
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al Seleccionar la materia {ex.Message}";
            }
        }
        //Establece fila para seleccionar
        protected void GrdLista_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdLista.EditIndex = e.NewEditIndex;
            CargarLista(Session["Id_MatAbierta"].ToString());
        }
        //Cancela el modo de edición
        protected void GrdLista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdLista.EditIndex = -1;
            CargarLista(Session["Id_MatAbierta"].ToString());
        }
        //Actualiza nota
        protected void GrdLista_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string nota = (GrdLista.Rows[e.RowIndex].FindControl("txtNota")
                as TextBox).Text.Trim();
            string billNumber = (GrdLista.Rows[e.RowIndex].FindControl("txtBillNumber")
                as TextBox).Text.Trim();
            GrdLista.EditIndex = -1;
            decimal nota1;
            EnrollmentDetails details = new EnrollmentDetails();
            EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);

            if (decimal.TryParse(nota, out nota1) && nota1 < 101 && nota1 > -1)
            {
                try
                {
                    details.OpenMatCode = int.Parse(Session["Id_MatAbierta"].ToString());
                    details.BillNumber = int.Parse(billNumber);
                    details.FinalNote = decimal.Parse(nota);

                    if (logic.Modificar(details) == 0)//modifica la nota
                    {
                        Session["_mensajeB"] = $"Actualizado con éxito";
                        CargarMateriasAbi();
                    }
                    else
                    {
                        Session["_mensaje"] = "Error al actualizar";
                    }

                    CargarLista(Session["Id_MatAbierta"].ToString());

                }
                catch (Exception ex)
                {
                    Session["_mensaje"] = $"Error al actualizar la materia {ex.Message}";
                }
            }
            else {
                Session["_mensaje"] = "La nota debe ser un valor entre 0 y 100";
            }

            CargarLista(Session["Id_MatAbierta"].ToString());

        }
    }
}