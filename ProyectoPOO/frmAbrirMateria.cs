using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class frmAbrirMateria : Form
    {
        //Atributos
        private frmBuscarMatCarr frmMatCarrera;//Buscar materias por carrera
        private frmBuscarProfesor frmBuscarProfesor;//Busca un profesor
        private frmBuscarAula frmBuscarAula;//Busca un aula
        private frmBuscarMatAbierta frmMatAbierta;//Busca materias abiertas
        private frmVerHorarios frmVerHorarios; //Muestra horarios
        private CareerMatter careerMatterAsig;//Materia carrera a insertar
        private OpenSubject openSubjectSelected = null;//Materia abierta seleccionada
        private Profesor profesorAsig = null;//Profesor seleccionado
        private Aula aulaAsig = null;//Aula seleccionada
        private char diaAsig;//Día de horario seleccionado
        private DateTime hoy = DateTime.Today;//Fecha de hoy para establecer periodos de matrícula
        //public event EventHandler Id_MatAbierta;

        public frmAbrirMateria()
        {
            InitializeComponent();
        }
        //Methods
        private void Limpiar()//limpia los campos 
        {
            txtTipoAula.Text = string.Empty;
            txtNumAula.Text = string.Empty;
            txtNombreProfesor.Text = string.Empty;
            txtIdProfesor.Text = string.Empty;
            txtMatAbier.Text = string.Empty;
            txtCodMatAbi.Text = string.Empty;
            txtCosto .Text = string.Empty;
            txtGrupo.Text = string.Empty;
            btnAbrir.Visible = true;
            btnModiMatCarr.Visible = false;
            btnAgregarHorario.Visible = false;
            openSubjectSelected = null;
            rbtActYear.Text = hoy.Year.ToString();
            rbtNxtYear.Text = (Convert.ToInt32(rbtActYear.Text) + 1).ToString();            
            profesorAsig = null;
            aulaAsig = null;
            btnEliminar.Visible = false;
            btnVerHorarios.Visible = false;
            rbtActYear.Checked = true;
            dtpHoraInicio.MinDate = Convert.ToDateTime("06:00:00");
            dtpHoraFin.MinDate = dtpHoraInicio.Value.AddHours(1);
            dtpHoraInicio.Value = dtpHoraInicio.MinDate;
            dtpHoraFin.Value = dtpHoraFin.MinDate;
        }
        private void CargarMateriaCarrera(int id)//Carga los datos de la materia carrera
        {
            CareerMatter careerMatter;
            CareerMatterLogic logica = new CareerMatterLogic(Config.getConnectionString);
            try
            {
                careerMatter = logica.ObtenerMateriaCarrera(id);
                careerMatterAsig = careerMatter;//Asignar variable global
                if (careerMatter != null)
                {
                    txtMatAbier.Text = careerMatter.Name.ToString();
                    if (openSubjectSelected != null)
                    {
                        openSubjectSelected.CodeCareerMatter = careerMatterAsig.CodeCareerMatter;
                    }
                }
                else
                {
                    //CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarProfesor(int id)//Carga datos de profesor
        {
            Profesor profesor;
            LogicaProfesor logica = new LogicaProfesor(Config.getConnectionString);
            try
            {
                profesor = logica.ObtenerProfesor(id);
                profesorAsig = profesor; //variable global a asignar
                if (profesor != null)
                {
                    txtNombreProfesor.Text = profesor.Name.ToString() + " " + profesor.FLastName.ToString(); ;
                    txtIdProfesor.Text = profesor.Id.ToString();
                }
                else
                {
                    //CargarListaArray();
                    MessageBox.Show("Error al cargar profesor", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarAula(byte id)//Carga datos del aula
        {
            Aula aula;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            try
            {
                aula = logica.ObtenerAula(id);
                aulaAsig = aula; //variable global a asignar
                if (aula != null)
                {
                    txtNumAula.Text = aula.Numero.ToString();
                    txtTipoAula.Text = aula.Tipo.ToString();
                }
                else
                {
                    //CargarListaArray();
                    MessageBox.Show("Error al cargar el aula", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //
        private void CargarMatAbierta(int idMatAbierta)//Carga datos de la materia abierta
        {
            OpenSubject openSubject;
            OpenMatterLogic logica = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                openSubject = logica.GetOpenSubject(idMatAbierta);
                openSubjectSelected = openSubject; //variable global a asignar
                if (openSubject != null)
                {
                    txtCodMatAbi.Text = openSubject.OpenSubjectsCode.ToString();
                    txtMatAbier.Text = openSubject.Name.ToString();
                    txtGrupo.Text = openSubject.Group.ToString();
                    npdCupo.Text = openSubject.Quota.ToString();
                    txtCosto.Text = openSubject.Cost.ToString();
                    ndl_Periodo.Text = openSubject.Period.ToString();
                    if (openSubject.Year == hoy.Year)
                    {
                        rbtActYear.Checked = true;
                    }
                    else {
                        rbtNxtYear.Checked = true;
                    }
                    CargarAula(Convert.ToByte(openSubject.AulaCode));
                    CargarProfesor(openSubject.ProfesorCode);
                    btnAbrir.Visible = false;
                    btnModiMatCarr.Visible = true;
                    btnEliminar.Visible = true;
                    btnVerHorarios.Visible = true;
                    btnAgregarHorario.Visible = true;
                }
                else
                {
                    //CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //*****************************************//
        private void btnAbrir_Click(object sender, EventArgs e)//Abre una materia
        {
            byte  cupo, periodo;
            short anio;
            decimal costo;

            if (!string.IsNullOrEmpty(txtMatAbier.Text)) {
                
                    
                        if (!string.IsNullOrEmpty(txtCosto.Text) && decimal.TryParse(txtCosto.Text, out costo) && costo >0 )
                        {
                            periodo = Convert.ToByte(ndl_Periodo.Value);
                    cupo = Convert.ToByte(npdCupo.Value);

                    if (rbtActYear.Checked)
                            {
                                anio = (short)Convert.ToInt32(hoy.Year.ToString());
                            }
                            else
                            {
                                anio = (short)Convert.ToInt32(hoy.Year.ToString());
                                anio += 1;
                            }
                            if (cboDia.SelectedItem != null)
                            {
                                if (dtpHoraInicio.Value <= dtpHoraFin.Value ) {
                                    OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                                    OpenSubject openSubject = new OpenSubject(-1, careerMatterAsig.CodeCareerMatter, -1, -1, 0, cupo, costo, periodo, anio, true);
                                    Schedule schedule = new Schedule(-1, diaAsig, dtpHoraInicio.Value.ToString(), dtpHoraFin.Value.ToString(), true);
                                    int result = -999;
                                    try
                                    {
                                        result = logic.Insertar(openSubject, schedule);
                                        MessageBox.Show(logic.Mensaje);
                                    }
                                    catch (Exception exc) {
                                          MessageBox.Show(exc.Message, "ERROR",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    if (result != -999) {
                                        btnAbrir.Visible = false;
                                        btnModiMatCarr.Visible = true;
                                        btnAgregarHorario.Visible = true;
                                        btnEliminar.Visible = true;
                                        openSubjectSelected = openSubject;
                                        txtCodMatAbi.Text = result.ToString();
                                        btnVerHorarios.Visible = true;
                                        openSubjectSelected.OpenSubjectsCode = result;
                                    }
                                }
                                else {
                                    dtpHoraFin.Focus();
                                    MessageBox.Show("La hora de fin debe ser mayor a la hora de inicio", "Horario",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                cboDia.Focus();
                                MessageBox.Show("Debe indicar un día", "Día",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            txtCosto.Focus();
                            MessageBox.Show("Debe indicar un costo", "Costo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                
            }             
            else {
                txtMatAbier.Focus();
                MessageBox.Show("Debe seleccionar una materia","Seleccione una materia",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarMatCarr_Click(object sender, EventArgs e)
        {
            frmMatCarrera = new frmBuscarMatCarr();
            frmMatCarrera.Aceptar += new EventHandler(Aceptar);
            frmMatCarrera.Show();
        }

        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idMateriaCarrera = (int)id;
                if (idMateriaCarrera != -1)
                {
                    CargarMateriaCarrera(idMateriaCarrera);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscarIdProfesor_Click(object sender, EventArgs e)
        {
            frmBuscarProfesor = new frmBuscarProfesor();
            frmBuscarProfesor.Aceptar += new EventHandler(AceptarPro);
            frmBuscarProfesor.Show();
        }

        private void AceptarPro(object id, EventArgs e)
        {
            try
            {
                int idProfesor = (int)id;
                if (idProfesor != -1)
                {
                    CargarProfesor(idProfesor);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscarNumAula_Click(object sender, EventArgs e)
        {
            frmBuscarAula = new frmBuscarAula();
            frmBuscarAula.Aceptar += new EventHandler(AceptarAula);
            frmBuscarAula.Show();
        }

        private void AceptarAula(object id, EventArgs e)
        {
            try
            {
                byte idAula = Convert.ToByte(id);
                if (idAula != 0)
                {
                    CargarAula(idAula);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmAbrirMateria_Load(object sender, EventArgs e)
        {
            Limpiar();            
        }

        private void cboDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDia.SelectedItem.ToString().Equals("Lunes"))
            {
                diaAsig = 'L';
            }
            else if ((cboDia.SelectedItem.ToString() == "Martes"))
            {
                diaAsig = 'K';
            }
            else if ((cboDia.SelectedItem.ToString() == "Miércoles"))
            {
                diaAsig = 'M';
            }
            else if ((cboDia.SelectedItem.ToString() == "Jueves"))
            {
                diaAsig = 'J';
            }
            else if ((cboDia.SelectedItem.ToString() == "Viernes"))
            {
                diaAsig = 'V';
            }
            else
            {
                diaAsig = 'S';
            }
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpHoraFin.MinDate = dtpHoraInicio.Value.AddHours(1);
            dtpHoraFin.Value = dtpHoraInicio.Value.AddHours(1);
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (cboDia.SelectedItem != null)
            {
                if (openSubjectSelected != null)
                {
                    try
                    {
                        ScheduleLogic logic = new ScheduleLogic(Config.getConnectionString);
                        Schedule schedule = new Schedule(openSubjectSelected.OpenSubjectsCode, diaAsig, dtpHoraInicio.Value.ToString(), dtpHoraFin.Value.ToString(), true);

                        result = logic.InsertarSP(schedule);
                        if (result != -999)
                        {
                            MessageBox.Show("Horario agregado con éxito", "Información", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar horario", "Información", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exc)
                    {

                        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Debe abrir una materia", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else {
                cboDia.Focus();
                MessageBox.Show("Debe indicar un día", "Día",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAsignarPro_Click(object sender, EventArgs e)
        {
            if (openSubjectSelected != null ) {
                if (profesorAsig != null)
                {
                    OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                    try
                    {
                        logic.AsignarProfesor(openSubjectSelected.OpenSubjectsCode, profesorAsig.Codigo);
                        MessageBox.Show(logic.Mensaje, "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione de nuevo el profesor", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Debe abrir la materia", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAsignarAula_Click(object sender, EventArgs e)
        {
            if (openSubjectSelected != null )
            {
                if (aulaAsig != null) {

                    if (openSubjectSelected.Quota <= aulaAsig.Capacidad) {
                        OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                        try
                        {
                            logic.AsignarAula(openSubjectSelected.OpenSubjectsCode, aulaAsig.Codigo);
                            MessageBox.Show(logic.Mensaje, "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("Cupo mayor a capacidad del aula", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione de nuevo el aula", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe abrir la materia", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscMateAbierta_Click(object sender, EventArgs e)
        {
            frmMatAbierta = new frmBuscarMatAbierta();
            frmMatAbierta.Aceptar += new EventHandler(AceptarMatAbierta);
            frmMatAbierta.Show();
        }

        private void AceptarMatAbierta(object id, EventArgs e)
        {
            try
            {
                int idMatAbierta = (int)(id);
                if (idMatAbierta != 0)
                {
                    CargarMatAbierta(idMatAbierta);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnModiMatCarr_Click(object sender, EventArgs e)
        {
            byte cupo, periodo;
            short anio;
            decimal costo;

            if (!string.IsNullOrEmpty(txtMatAbier.Text))
            {
                
                    
                        if (!string.IsNullOrEmpty(txtCosto.Text) && decimal.TryParse(txtCosto.Text, out costo) && costo > 0)
                        {
                            periodo = Convert.ToByte(ndl_Periodo.Value);
                            cupo = Convert.ToByte(npdCupo.Value);
                            if (rbtActYear.Checked)
                            {
                                anio = (short)Convert.ToInt32(hoy.Year.ToString());
                            }
                            else
                            {
                                anio = (short)Convert.ToInt32(hoy.Year.ToString());
                                anio += 1;
                            }
                            if (cboDia.SelectedItem != null)
                            {
                                if (dtpHoraInicio.Value < dtpHoraFin.Value)
                                {
                                    OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                                    OpenSubject openSubject = new OpenSubject(openSubjectSelected.OpenSubjectsCode, openSubjectSelected.CareerMatterCode, -1, -1, 0, cupo, costo, periodo, anio, true);
                                    Schedule schedule = new Schedule(-1, diaAsig, dtpHoraInicio.Value.ToString(), dtpHoraFin.Value.ToString(), true);
                                    int result = -999;
                                    try
                                    {
                                      result = logic.Insertar(openSubject, schedule);
                                      if (result != -999)
                                      {
                                        btnAbrir.Visible = false;
                                        btnModiMatCarr.Visible = true;
                                        btnAgregarHorario.Visible = true;
                                        btnVerHorarios.Visible = true;
                                        openSubjectSelected = openSubject;
                                        txtCodMatAbi.Text = result.ToString();
                                        openSubjectSelected.OpenSubjectsCode = result;
                                        MessageBox.Show("Materia modificada con éxito", "Mensaje",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else {
                                           MessageBox.Show("Error al modificar materia", "ERROR",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    catch (Exception exc)
                                    {
                                        MessageBox.Show(exc.Message, "ERROR",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }                                            
                                }
                                else
                                {
                                    dtpHoraFin.Focus();
                                    MessageBox.Show("La hora de fin debe ser mayor a la hora de inicio", "Horario",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                             cboDia.Focus();
                             MessageBox.Show("Debe indicar un día", "Día",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            txtCosto.Focus();
                            MessageBox.Show("Debe indicar un costo", "Costo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                
            }
            else
            {
                txtMatAbier.Focus();
                MessageBox.Show("Debe seleccionar una materia", "Seleccione una materia",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
            int result;
            if (openSubjectSelected != null)
            {
                if (MessageBox.Show("Desea ELIMINAR?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        result = logic.EliminarSP(openSubjectSelected.OpenSubjectsCode);
                        if (result != -999) {
                            Limpiar();
                        }
                        MessageBox.Show(logic.Mensaje, "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
            else {
                MessageBox.Show("Seleccione una materia abierta", "Seleccione una materia",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnVerHorarios_Click(object sender, EventArgs e)
        {

            frmVerHorarios = new frmVerHorarios(openSubjectSelected.OpenSubjectsCode);
            frmVerHorarios.Show();
        }
    }
}
