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
    public partial class frmListadoMateriasCarreras : System.Web.UI.Page
    {
        //Methods
        //Limpia los campos
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
        }
        //Carga las materias carreras
        private void CargarMaterias(string condicion = "")
        {
            List<CareerMatter> list;
            CareerMatterLogic logica = new CareerMatterLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarMateriasCarrera(condicion, "");
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

        //**************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)//si no es postBack carga la lista
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
        //Busca materias por nombre
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameM like '%{txtNombre.Text}%'";
                CargarMaterias(condicion);
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar las materias {ex.Message}";
            }
        }
        //Cambia indice de página de lista de materias carreras
        protected void GrdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLista.PageIndex = e.NewPageIndex;
                CargarMaterias();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar las materias {ex.Message}";
            }
        }
    }
}