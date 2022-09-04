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
    public partial class frmListadoMaterias : System.Web.UI.Page
    {//limpia los campos
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
        }
        //Carga las materias
        private void CargarMaterias(string condicion = "")
        {
            List<Matter> list;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarMaterias(condicion, "");
                if (list.Count > 0)
                {
                    grdLista.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdLista.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Elimina una materia
        private int DeleteMateria(string code)
        {
            int resultado = -1;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            try
            {
                resultado = logica.DeleteMatter(code);
                Limpiar();
                CargarMaterias();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //*************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Limpiar();
                    CargarMaterias();
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar las materias {ex.Message}";
            }
        }
        //Busca materia por nombre
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameM like '%{txtNombre.Text}%'";
                CargarMaterias(condicion);
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los clientes {ex.Message}";
            }
        }
        //Abre página para agregar materia
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("Matter_Code");
            Response.Redirect("frmMaterias.aspx");
        }
        //Cambia indice de página para ver materias
        protected void GrdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLista.PageIndex = e.NewPageIndex;
                CargarMaterias();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los clientes {ex.Message}";
            }
        }
        //Elimina la materia
        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (DeleteMateria(e.CommandArgument.ToString()) != -1)
                {
                    Session["_mensajeB"] = "Materia eliminada";
                }
                else {
                    Session["_mensaje"] = "Error al eliminar materia";
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al eliminar la materia {ex.Message}";
            }
        }              
        //Abre ventana para modificar materia
        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["Matter_Code"] = e.CommandArgument.ToString();
            Response.Redirect("frmMaterias.aspx");
        }
    }
}