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
    public partial class frmListadoAulas : System.Web.UI.Page
    {
        //limpia los campos
        private void Limpiar()
        {
            txtTipo.Text = string.Empty;
            txtTipo.Focus();
        }
        //Carga las aulas
        private void CargarAulas(string condicion = "")
        {
            List<Aula> list;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            try
            {
                list = logica.ListarAulas(condicion, "");
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

        //Elimina un aula
        private int DeleteAula(int code)
        {
            int resultado = -1;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            try
            {
                resultado = logica.Delete(code);
                Limpiar();
                CargarAulas();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Limpiar();
                    CargarAulas();
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar las aulas {ex.Message}";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"Tipo like '%{txtTipo.Text}%'";
                CargarAulas(condicion);
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los clientes {ex.Message}";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("Aula_Code");
            Response.Redirect("frmAulas.aspx");
        }

        //Cambia indice de página para ver aulas
        protected void GrdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLista.PageIndex = e.NewPageIndex;
                CargarAulas();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar las aulas {ex.Message}";
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["Aula_Code"] = e.CommandArgument.ToString();
            Response.Redirect("frmAulas.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (DeleteAula(int.Parse(e.CommandArgument.ToString())) != -1)
                {
                    Session["_mensajeB"] = "Aula eliminada";
                }
                else
                {
                    Session["_mensaje"] = "Error al eliminar aula";
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al eliminar el aula {ex.Message}";
            }
        }
    }
}