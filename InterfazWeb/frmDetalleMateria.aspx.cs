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
    public partial class frmDetalleMateria : System.Web.UI.Page
    {
        //Methods
        //Carga los datos de la materia
        private void CargarMateria() {
            OpenSubject matter;
            OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);

            Profesor profesor;
            LogicaProfesor logicaP = new LogicaProfesor(Config.getConnectionString); ;

            Aula aula;
            LogicaAula logicaA = new LogicaAula(Config.getConnectionString);
            string requisito, profe="No asignado", aulaN= "No asigando";
            try
            {//obtiene datos de materia abierta
                matter = logic.GetOpenSubjectD(int.Parse(Session["Id_MatAbierta"].ToString()));
                if (matter != null) {
                    ltlNombre.Text = $"Materia: {matter.Name}";
                    ltlCodigo.Text = $"Código: {matter.Code}";
                    ltlCarrera.Text = $"Carrera: {matter.CareerName}";
                    if (matter.Requirement == string.Empty) {
                        requisito = "No asignado";
                    }
                    else {
                        requisito = matter.Requirement.ToString();
                    }
                    ltlRequisito.Text = $"Requisito: {requisito}";
                    if (matter.ProfesorCode == 0) {
                        profe = "No asignado";
                    }
                    else {//obtiene datos del profesor
                        profesor = logicaP.ObtenerProfesor(matter.ProfesorCode);
                        if (profesor != null) {
                            profe = $"{profesor.Name} {profesor.FLastName} {profesor.SLastName}";
                        }
                        
                    }
                    ltlProfesor.Text = $"Profesor: {profe}";

                    if (matter.AulaCode == 0)
                    {
                        aulaN = "No asignado";
                    }
                    else
                    {//carga datos de aula
                        aula = logicaA.ObtenerAula(Convert.ToByte(matter.AulaCode));
                        if (aula != null)
                        {
                            aulaN = $"# {aula.Numero} {aula.Tipo} Capacidad: {aula.Capacidad}";
                        }

                    }
                    ltlAula.Text = $"Aula: {aulaN}";
                    ltlGrupo.Text = $"Grupo: {matter.Group}";
                    ltlCupo.Text = $"Cupo: {matter.Quota}";
                    ltlPeriodo.Text = $"Periodo: {matter.Period}";
                    ltlAnio.Text = $"Año: {matter.Year}";
                    //Carga horarios de materia abierta
                    CargarHorarios(matter.OpenSubjectsCode);
                }
                //else{}
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"No fue posible obtener los datos de la materia + {ex.Message}";
                Response.Redirect("frmAbrirMaterias.aspx", false);
            }
        
        }
        //Carga los horarios
        private void CargarHorarios(int condicion = 0)
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

        //*************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["_mensaje"] = null;
                if (Session["Id_MatAbierta"] != null)
                {
                    CargarMateria();
                }
                else
                {
                    Session["_mensaje"] = "No fue posible obtener los datos de la materia";
                    Response.Redirect("frmAbrirMaterias.aspx", false);
                }
            }
        }
        //Vuelve a página abrir materias
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAbrirMaterias.aspx");
        }
    }
}