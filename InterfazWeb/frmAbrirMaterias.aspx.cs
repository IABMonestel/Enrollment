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
    public partial class frmAbrirMaterias : System.Web.UI.Page
    {
        //Methods
        //Limpia los datos
        private void Limpiar() {//método para reestablecer valores
            txtidMateriaC.Text = string.Empty;
            txtMateria.Text = string.Empty;
            txtMateria.Focus();
            txtCupo.Text = string.Empty;
            txtCost.Text = string.Empty;
            GrdLista.DataSource = new List<Schedule>();
            GrdLista.DataBind();
            rbAnioActual.Text = DateTime.Today.Year.ToString();
            rbAnioActual.Checked = true;
            rbAnioSig.Text = (DateTime.Today.Year + 1).ToString();
            txt6am.Text = Convert.ToDateTime("06:00").ToString("HH:mm");
            txtHoraE.Text = txt6am.Text;
            txtHoraS.Text = "07:00";
            Session["Id_MatAbierta"] = null;
        }
        //Carga los horarios
        private void CargarHorarios(int condicion = 0)//Carga los horarios según una materia abierta
        {
            List<Schedule> list;
            ScheduleLogic logica = new ScheduleLogic(Config.getConnectionString);
            try
            {
                list = logica.ListarScheduler(condicion);
                if (list.Count > 0)
                {
                    GrdLista.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    GrdLista.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Carga las materias
        private void CargarMaterias(string condicion = "", string orden = "NameM" )//Cargas las materias carreras que se pueden abrir
        {
            List<CareerMatter> list;
            CareerMatterLogic logicaC = new CareerMatterLogic(Config.getConnectionString);
            try
            {
                list = logicaC.ListarMateriasCarrera(condicion, orden);
                if (list.Count > 0)
                {
                    grdMaterias.DataSource = list;
                    //GrdLista.DataMember = DS.Tables[0].TableName;
                    grdMaterias.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Carga la lista de materias abiertas
        private void CargarMateriasAbi(string condicion = "", string orden = "NameM")//Carga las materias abiertas para modificar
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

        //*************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenSubject matAbierta;
            OpenMatterLogic logicaMA = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                if (!IsPostBack)//si no es postBack carga la lista
                {
                    txt6am.Text = "06:00";//para que verifique hora de entrada
                    CargarMaterias();
                    CargarMateriasAbi();
                    Session["_mensaje"] = null;
                    if (Session["Id_MatAbierta"] != null)
                    {//Carga datos de una materia abierta guardada en sesión
                        matAbierta = logicaMA.GetOpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()));
                        txtidMateriaC.Text = matAbierta.CodeCareerMatter.ToString();
                        txtMateria.Text = matAbierta.Name.ToString();
                        txtidMateriaC.Text = matAbierta.CareerMatterCode.ToString();
                        txtMateria.Focus();
                        txtCupo.Text = matAbierta.Quota.ToString();
                        txtCost.Text = Decimal.ToInt32(matAbierta.Cost).ToString();
                        txtGrupo.Text = matAbierta.Group.ToString();
                        cboPeriodo.Text = matAbierta.Period.ToString();
                        
                        rbAnioActual.Text = DateTime.Today.Year.ToString();
                        
                        rbAnioSig.Text = (DateTime.Today.Year + 1).ToString();
                        if (matAbierta.Year == DateTime.Today.Year)
                        {
                            rbAnioActual.Checked = true;
                            rbAnioSig.Checked = false;
                        }
                        else
                        {
                            rbAnioSig.Checked = true;
                            rbAnioActual.Checked = false;
                        }

                        CargarHorarios(int.Parse(Session["Id_MatAbierta"].ToString()));
                    }
                    else
                    {
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar datos {ex.Message}";
            }
        }
        //Cambia el índice de página de un gridview
        protected void GrdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdLista.PageIndex = e.NewPageIndex;
                CargarHorarios();
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar los horarios {ex.Message}";
            }
        }

        //Abre la materia
        protected void btnAbrir_Click(object sender, EventArgs e)
        {
            short year = short.Parse(DateTime.Today.Year.ToString());
            int codMateAbi = -1;
            DateTime minValue = Convert.ToDateTime(txt6am.Text);
            DateTime horaE = Convert.ToDateTime(txtHoraE.Text);
            DateTime horaS = Convert.ToDateTime(txtHoraS.Text);
            
            if (rbAnioSig.Checked)
            {
                year += 1;
            }                   
            //Crea objeto materia abierta con datos del formulario
            OpenSubject matter = new OpenSubject(-1,int.Parse(txtidMateriaC.Text),0,0,0,byte.Parse(txtCupo.Text),
                decimal.Parse(txtCost.Text),byte.Parse(cboPeriodo.SelectedValue),year,true);
            //Carga los datos del horario
            Schedule schedule = new Schedule(-1,-1,char.Parse(cboDia.SelectedValue),txtHoraE.Text,txtHoraS.Text,true);
            //Capa lógica que ingresa la materia
            OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
            //Comprueba valores de horario
            if (horaE >= minValue && horaS >= horaE.AddHours(1))
            {
                if (Session["Id_MatAbierta"] == null)
                {
                    try
                    {//inserta la materia
                        codMateAbi = logic.Insertar(matter, schedule);
                        if (codMateAbi != -1)//verifica si proceso fue exitoso
                        {
                            Session["_mensajeB"] = "Materia creada con éxito";

                            CargarHorarios(codMateAbi);
                            CargarMateriasAbi();
                            Session["Id_MatAbierta"] = codMateAbi;
                            matter = logic.GetOpenSubject(codMateAbi);
                            txtGrupo.Text = matter.Group.ToString();

                        }
                        else
                        {
                            Session["_mensaje"] = "Error al abrir materia";
                        }
                    }
                    catch (Exception ex)
                    {
                        Session["_mensaje"] = $"Error al abrir materia {ex.Message}";
                    }
                }
                else
                {
                    //Schedule a ingresar
                    //carga horario con datos de formulario;
                    Schedule newSchedule = new Schedule(-1, int.Parse(Session["Id_MatAbierta"].ToString()),
                        char.Parse(cboDia.SelectedValue), txtHoraE.Text, txtHoraS.Text, true);
                    //capa logica para ingresar horarios
                    ScheduleLogic slogic = new ScheduleLogic(Config.getConnectionString);
                    try
                    {
                        if (slogic.UpdateSP(newSchedule) != -1)//comprueba si pudo ingresar horario
                        {
                            Session["_mensajeB"] = "Horario actualizado";
                            CargarHorarios(int.Parse(Session["Id_MatAbierta"].ToString()));
                        }
                        else
                        {
                            Session["_mensaje"] = "Error al actualizar horario";
                        }
                    }
                    catch (Exception ex)
                    {

                        Session["_mensaje"] = $"Error al actualizar horario {ex.Message}";
                    }
                }
            }
            else {
                Session["_mensaje"] = "La hora de entrada debe ser mayor o igual a las 6 am";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        //Elimina una materia abierta no matriculada
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
            if (Session["Id_MatAbierta"] != null)//comprueba que exista información de una materia en session
            {
                try
                {
                    if (logic.EliminarSP(int.Parse(Session["Id_MatAbierta"].ToString())) == 0)
                    {//comprueba si pudo eliminar
                        Session["_mensajeB"] = "Materia eliminada";
                        CargarMateriasAbi();
                        Limpiar();
                    }
                    else {
                        Session["_mensaje"] = "Error al eliminar materia";
                    }
                }
                catch (Exception)
                {
                    Session["_mensaje"] = "Error al eliminar materia";
                }
            }
            else {
                Session["_mensaje"] = "Error al eliminar materia";
            }
        }
        //redirecciona a pagina de ingresar profesor y aula, actualiza datos de materia
        protected void btnSig_Click(object sender, EventArgs e)
        {
            if (Session["Id_MatAbierta"] != null)//comprueba que existan datos de materia en sesion
            {
                //Cargar Id de materia abierta
                OpenSubject openSubject;
                Schedule schedule = new Schedule(-1, -1, 'L', "08:00:00", "08:00:00", false);//Horario vacío para modificar materia existente
                OpenMatterLogic logicOpenSubject = new OpenMatterLogic(Config.getConnectionString);
                int codMateAbi = -1;
                short year = short.Parse(DateTime.Today.Year.ToString());
                if (rbAnioSig.Checked)
                {
                    year += 1;
                }

                //Actualizar
                try
                {
                    openSubject = new OpenSubject(int.Parse(Session["Id_MatAbierta"].ToString()),
                        int.Parse(txtidMateriaC.Text), -1, -1, byte.Parse(txtGrupo.Text),
                        byte.Parse(txtCupo.Text), decimal.Parse(txtCost.Text), byte.Parse(cboPeriodo.SelectedValue),
                        year, true);
                    if (logicOpenSubject.Insertar(openSubject, schedule) != -1)//comprueba si actualizo
                    {
                        //Operación realizada
                        Session["_mensajeB"] = "Materia actualizada con éxito";

                        codMateAbi = int.Parse(Session["Id_MatAbierta"].ToString());
                        openSubject = logicOpenSubject.GetOpenSubject(codMateAbi);
                        txtGrupo.Text = openSubject.Group.ToString();
                        Response.Redirect("frmAsigProfeAula.aspx",false);
                    }
                    else
                    {
                        Session["_mensaje"] = "Error al actualizar materia";
                    }
                }
                catch (Exception ex)
                {

                    Session["_mensaje"] = $"Error al actualizar materia {ex.Message}";
                }
                
            }
            else {
                Session["_mensaje"] = "Error debe abrir o seleccionar una materia abierta";
            }
        }

        //Busca materia carrera por nombre

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $"NameM like '%{txtNombreMateria.Text.Trim()}%'";
                CargarMaterias(condicion);
                string javascript = "AbrirModal();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception)
            {

                Session["_mensaje"] = "Error al buscar la materia";
            }
        }
        //Busca materia abierta por nombre
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
        //selecciona una materia abierta para cargar datos
        protected void lnkSeleccionarMatA_Command(object sender, CommandEventArgs e) {
            int id = int.Parse(e.CommandArgument.ToString());
            OpenSubject openSubject;
            OpenMatterLogic openMatterLogic = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                openSubject = openMatterLogic.GetOpenSubject(id);//obtiene la materia 
                if (openSubject != null)
                {//carga los datos
                    txtidMateriaC.Text = openSubject.CareerMatterCode.ToString();
                    txtMateria.Text = openSubject.Name;
                    if (openSubject.ProfesorCode == 0)//verifica si tiene profesor
                    {
                        
                        Session["Id_Profe"] = null;
                    }
                    else {
                        Session["Id_Profe"] = openSubject.ProfesorCode;
                    }

                    if (openSubject.AulaCode == 0)//verifica si tiene aula
                    {
                        Session["Id_Aula"] = null;
                    }
                    else {
                        Session["Id_Aula"] = openSubject.AulaCode;
                    }
                    //No me carga el costo por conversion de tipo
                    txtCost.Text = Decimal.ToInt32(openSubject.Cost).ToString();
                    txtGrupo.Text = openSubject.Group.ToString();
                    txtCupo.Text = openSubject.Quota.ToString();
                    if (openSubject.Year == DateTime.Today.Year)
                    {
                        rbAnioActual.Checked = true;
                        rbAnioSig.Checked = false;
                    }
                    else { 
                        rbAnioSig.Checked = true;
                        rbAnioActual.Checked = false;
                    }
                    if (openSubject.Period == 1)
                    {
                        cboPeriodo.Text = "1";
                    }
                    else if (openSubject.Period == 2) {
                        cboPeriodo.SelectedValue = "2";
                    }
                    else {
                        cboPeriodo.SelectedIndex = 2;
                    }
                    CargarHorarios(id);
                    Session["Id_MatAbierta"] = id;
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al Seleccionar la materia {ex.Message}";
            }
            
        }

        //selecciona una materia carrera
            protected void lnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            CareerMatter careerMatter;
            CareerMatterLogic logicaC = new CareerMatterLogic(Config.getConnectionString);
            try
            {
                careerMatter = logicaC.ObtenerMateriaCarrera(id);//obtiene la materia carrera
                if (careerMatter != null)
                {//carga datos
                    txtidMateriaC.Text = careerMatter.CodeCareerMatter.ToString();
                    txtMateria.Text = careerMatter.Name;
                    txtGrupo.Text = string.Empty;
                    txtCupo.Text = string.Empty;    
                    txtCost.Text = string.Empty;
                    GrdLista.DataSource = new List<Schedule>();
                    GrdLista.DataBind();
                    Session["Id_MatAbierta"] = null;
                }
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al Seleccionar la materia {ex.Message}";
            }
        }
        //elimina un horario
        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            ScheduleLogic sLogic = new ScheduleLogic(Config.getConnectionString);
            Schedule schedule = new Schedule();
            try
            {
                schedule.OpenSubjectCode = int.Parse(Session["Id_MatAbierta"].ToString());
                schedule.Id = id;
                if (sLogic.Delete(schedule) == 0)//comprueba si elimino horario
                {
                    CargarHorarios(int.Parse(Session["Id_MatAbierta"].ToString()));
                    Session["_mensajeB"] = "Horario eliminado";
                }
                else if (sLogic.Delete(schedule) == 1) {
                    Session["_mensaje"] = "Debe ingresar un horario";
                    GrdLista.DataSource = new List<Schedule>();
                    GrdLista.DataBind();
                    Session["Id_MatAbierta"] = null;
                    CargarMateriasAbi();
                }
                else {
                    Session["_mensaje"] = "Error al eliminar horario";
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al eliminar horario {ex.Message}";
            }
        }
        //cambia el índice de página de materias
        protected void grdMaterias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdLista.PageIndex = e.NewPageIndex;
                CargarMaterias();
                string javascript = "AbrirModal();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al cargar las materias {ex.Message}";
            }
        }
    }
}