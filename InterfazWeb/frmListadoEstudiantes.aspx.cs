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
    public partial class frmListadoEstudiantes : System.Web.UI.Page
    {
        //Methods
        //Limpia los campos
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
        }
        //carga la lista de estudiantes
        private void CargarEstudiantes(string condicion = "")
        {
            List<Student> list;
            StudentLogic logica = new StudentLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarStudent(condicion, "");
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
        //************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)//si no es postBack carga la lista
                {
                    Limpiar();
                    CargarEstudiantes();
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }
        //Busca estudiante por nombre
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameS like '%{txtNombre.Text}%'";
                CargarEstudiantes(condicion);
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }
        //Muestra el cambio de página en el grid
        protected void GrdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdLista.PageIndex = e.NewPageIndex;
                CargarEstudiantes();
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar los estudiantes {ex.Message}";
            }
        }
    }
}