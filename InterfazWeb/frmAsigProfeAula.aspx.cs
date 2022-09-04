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
    public partial class frmAsigProfeAula : System.Web.UI.Page
    {
        //Methods
        //Limpia los datos
        private void Limpiar()
        { 
            txtIdP.Text = string.Empty;
            txtNombreP.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtIdA.Text = string.Empty;
            //Limpiar variables de sessión
            Session["Id_Profe"] = null;
            Session["Id_Aula"] = null;
            //
        }
        //carga lista de profesores
        private void CargarProfesores(string condicion = "", string orden = "FLastName")
        {
            List<Profesor> list;
            LogicaProfesor logica = new LogicaProfesor(Config.getConnectionString);
            try
            {
                list = logica.ListarProfesores(condicion, orden);
                if (list.Count > 0)
                {
                    grdProfes.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdProfes.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //carga lista de aulas
        private void CargarAulas(string condicion = "", string orden = "Tipo")
        {
            List<Aula> list;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            try
            {
                list = logica.ListarAulas(condicion, orden);
                if (list.Count > 0)
                {
                    grdAulas.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdAulas.DataBind();
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
            OpenSubject openSubject;
            Aula aula;
            Profesor profe;
            LogicaAula logicaAula = new LogicaAula(Config.getConnectionString);
            LogicaProfesor logicaProfesor = new LogicaProfesor(Config.getConnectionString);
            OpenMatterLogic openMatterLogic = new OpenMatterLogic(Config.getConnectionString);

            try
            {
                if (!IsPostBack)//si no es postBack carga la lista
                { 
                    CargarAulas();
                    CargarProfesores();

                    if (Session["Id_MatAbierta"] != null)//verifica a cual materia se le va a asignar datos
                    {
                        openSubject = openMatterLogic.GetOpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()));
                        txtidMateriaA.Text = openSubject.OpenSubjectsCode.ToString();
                        txtMateria.Text = openSubject.Name.ToString();
                        txtCodMat.Text = openSubject.Code.ToString();
                        txtCupo.Text = openSubject.Quota.ToString();
                        txtCarrera.Text = openSubject.CareerName.ToString();
                        if (openSubject.ProfesorCode != 0) {//verifica si tiene profesor
                            Session["Id_Profe"] = openSubject.ProfesorCode;
                        }
                        if (openSubject.AulaCode != 0)//verifica si tiene aula
                        {
                            Session["Id_Aula"] = openSubject.AulaCode;
                        }
                    }
                    else
                    {
                        Session["Id_Aula"] = null;
                        Session["Id_Profe"] = null;
                    }

                    if (Session["Id_Profe"] != null)
                    {//obtiene datos del profesor
                        profe = logicaProfesor.ObtenerProfesor(int.Parse(Session["Id_Profe"].ToString()));

                        txtIdP.Text = profe.Id;
                        txtNombreP.Text = profe.Name + " " + profe.FLastName + " " + profe.SLastName;
                        
                    }
                    else {
                        txtIdP.Text = string.Empty;
                        txtNombreP.Text = string.Empty;
                    }
                    if (Session["Id_Aula"] != null)
                    {//obtiene datos del aula
                        aula = logicaAula.ObtenerAula(byte.Parse(Session["Id_Aula"].ToString()));
                        //Capacidad de aula
                        txtIdA.Text = aula.Numero.ToString();
                        txtTipo.Text = aula.Tipo;
                    }
                    else {
                        txtIdA.Text = string.Empty;
                        txtTipo.Text = string.Empty;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar datos {ex.Message}";
            }
        }
        //cambia indice de página de aulas
        protected void GrdAulas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAulas.PageIndex = e.NewPageIndex;
                CargarAulas();
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar las Aulas {ex.Message}";
            }
        }
        //cambia indice de página de profesores
        protected void GrdProfesores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdProfes.PageIndex = e.NewPageIndex;
                CargarProfesores();
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar los Profesores {ex.Message}";
            }
        }
        //asigna el profesor
        protected void btnAsigP_Click(object sender, EventArgs e)
        {
            Profesor profesor;
            LogicaProfesor logic = new LogicaProfesor(Config.getConnectionString);
            OpenMatterLogic logicOpenMat = new OpenMatterLogic(Config.getConnectionString);

            try
            {//obtiene datos del profesor
                profesor = logic.ObtenerProfesor(int.Parse(Session["Id_Profe"].ToString()));
                //comprueba si asigno el profesor
                if (logicOpenMat.AsignarProfesor(int.Parse(Session["Id_MatAbierta"].ToString())
                    , profesor.Codigo) != -1) {
                    Session["_mensajeB"] = "Profesor asignado";
                }
                else {//no lo pudo asignar carga datos del que tenía
                    OpenSubject openSubject = logicOpenMat.GetOpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()));
                    profesor = logic.ObtenerProfesor(openSubject.ProfesorCode);

                    if (profesor != null)//tenia profesor
                    {
                        txtIdP.Text = profesor.Id;
                        txtNombreP.Text = profesor.Name + " " + profesor.FLastName + " " + profesor.SLastName;
                        
                    }
                    else//no tenía profesor
                    {
                        txtIdP.Text = string.Empty;
                        txtNombreP.Text = string.Empty;
                        
                    }

                    Session["_mensaje"] = "Error al asignar los Profesores";
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al asignar los Profesor {ex.Message}";                
            }
        }
        //desasigna un profesor
        protected void btnEliP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdP.Text))
            {
                OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                try
                {//comprueba si fue posible desasignar profesor
                    if (logic.DesasignarProfe(int.Parse(Session["Id_MatAbierta"].ToString())) != -1)
                    {

                        Session["_mensajeB"] = "Operación realizada con éxito";
                        txtNombreP.Text = String.Empty;
                        txtIdP.Text = String.Empty;
                    }
                    else {
                        Session["_mensaje"] = "Error al quitar profesor";
                    }
                }
                catch (Exception ex)
                {

                    Session["_mensaje"] = $"Error al quitar profesor {ex.Message}";
                }
            }
            else
            {
                Session["_mensaje"] = "Error, debe asignar el Profesor";
            }
        }
        //asigna un aula
        protected void btnAsigA_Click(object sender, EventArgs e)
        {
            Aula aula;
            LogicaAula logic = new LogicaAula(Config.getConnectionString);
            OpenMatterLogic logicOpenMat = new OpenMatterLogic(Config.getConnectionString);
            try
            {//obtiene datos del aula
                aula = logic.ObtenerAula(byte.Parse(Session["Id_Aula"].ToString()));
                OpenSubject openSubject = logicOpenMat.GetOpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()));
                if (openSubject.Quota<= aula.Capacidad)//verifica capacidad del aula
                {
                    if (logicOpenMat.AsignarAula(int.Parse(Session["Id_MatAbierta"].ToString())
                    , aula.Codigo) != -1)//verifica si la pudo asignar
                    {
                        //aula = logic.ObtenerAula(byte.Parse(openSubject.AulaCode.ToString()));

                        if (aula != null)//carga datos del aula
                        {
                            //Capacidad de aula
                            txtIdA.Text = aula.Numero.ToString();
                            txtTipo.Text = aula.Tipo;
                        }
                        else
                        {
                            txtIdA.Text = string.Empty;
                            txtTipo.Text = string.Empty;
                        }
                        Session["_mensajeB"] = "Aula asignada";
                    }
                    else
                    {//carga datos de aula asignada previamente
                        openSubject = logicOpenMat.GetOpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()));
                        aula = logic.ObtenerAula(byte.Parse(openSubject.AulaCode.ToString()));

                        if (aula != null)//carga datos del aula
                        {
                            txtIdA.Text = aula.Numero.ToString();
                            txtTipo.Text = aula.Tipo;

                        }
                        else
                        {
                            txtIdA.Text = string.Empty;
                            txtTipo.Text = string.Empty;
                        }
                        Session["_mensaje"] = "Error al asignar el aula";
                    }
                }
                else
                {
                    txtIdA.Text = string.Empty;
                    txtTipo.Text = string.Empty;
                    Session["_mensaje"] = "Error al asignar el aula";
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al asignar los Aulas {ex.Message}";
            }
        }
        //elimina el aula
        protected void btnEliA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdA.Text))
            {
                OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                try
                {//desasigna el aula
                    if (logic.DesasignarAula(int.Parse(Session["Id_MatAbierta"].ToString())) != -1)
                    {

                        Session["_mensajeB"] = "Operación realizada con éxito";
                        txtIdA.Text = String.Empty;
                        txtTipo.Text = String.Empty;
                    }
                    else
                    {
                        Session["_mensaje"] = "Error al quitar aula";
                    }
                }
                catch (Exception ex)
                {

                    Session["_mensaje"] = $"Error al quitar aula {ex.Message}";
                }
            }
            else
            {
                Session["_mensaje"] = "Error, debe asignar el Aula";
            }
        }
        //retrocede a página de abrir materia
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Session["Id_Profe"] = null;
            Session["Id_Aula"] = null;
            Response.Redirect("frmAbrirMaterias.aspx");
        }
        //redirecciona al menú principal
        protected void btnMenuP_Click(object sender, EventArgs e)
        {
            Limpiar();
            Response.Redirect("Default.aspx");
        }
        //busca profesor por nombre
        protected void btnBProfe_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameP like '%{txtNProfe.Text.Trim()}%'";
                CargarProfesores(condicion);
                string javascript = "AbrirModalP();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al buscar el profesor";
            }
        }
        //busca aula por tipos
        protected void btnBAula_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"Tipo like '%{txtTipoA.Text.Trim()}%'";
                CargarAulas(condicion);
                string javascript = "AbrirModalA();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al buscar el aula {ex.Message}";
            }
        }
        //selecciona un aula 
        protected void lnkSeleccionarAula_Command(object sender, CommandEventArgs e)
        {
            Aula aula;
            LogicaAula logic = new LogicaAula(Config.getConnectionString);
            try
            {
                aula = logic.ObtenerAula(byte.Parse(e.CommandArgument.ToString()));
                if (aula != null) {
                    txtIdA.Text = aula.Numero.ToString();
                    txtTipo.Text = aula.Tipo.ToString();
                    Session["Id_Aula"] = aula.Codigo;
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar el aula {ex.Message}";
            }
        }
        //selecciona un profesor
        protected void lnkSeleccionarP_Command(object sender, CommandEventArgs e)
        {
            Profesor profesor;
            LogicaProfesor logic = new LogicaProfesor(Config.getConnectionString);
            try
            {
                profesor = logic.ObtenerProfesor(int.Parse(e.CommandArgument.ToString()));
                if (profesor != null)
                {
                    txtIdP.Text = profesor.Id.ToString();
                    txtNombreP.Text = profesor.Name.ToString() + " " +
                        profesor.FLastName.ToString() + profesor.SLastName.ToString();
                    Session["Id_Profe"] = profesor.Codigo;
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al cargar el aula {ex.Message}";
            }
        }
        //muetra el detalle de la materia
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDetalleMateria.aspx");
        }

        
    }
}