using BusinessLogic;
using Entities;
using Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoPOO
{
    public partial class frmAsignarMateriaCarrera : Form
    {
        //
        private frmBuscarMaterias frmBuscarMateria;
        private frmBuscarCarrera frmBuscarCarrera;
        //
        //Objects
        private CareerMatter careerMaterAsig;
        private Matter matterAsig;
        private Matter requirementAsig;
        private Matter corequisiteAsig;
        private Careers careerAsig;
        //
        public frmAsignarMateriaCarrera()
        {
            InitializeComponent();
        }

        //Methods
        private void CargarListaArray(string condicion = "")
        {
            CareerMatterLogic logica = new CareerMatterLogic(Config.getConnectionString);
            List<CareerMatter> lista;
            try
            {
                lista = logica.ListarMateriasCarrera(condicion);
                if (lista.Count > 0)
                {
                    grdLista.DataSource = lista;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Limpiar()
        {
            txtNameMate.Text = string.Empty;
            txtCareer.Text = string.Empty;
            txtCodMat.Text = string.Empty;
            txtCorreq.Text = string.Empty;
            txtReq.Text = string.Empty;
            txtBuscarPorNombre.Text = string.Empty;
        }

        private void LoadMatter(string code)
        {
            Matter matter;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            try
            {
                matter = logica.GetMatter(code);
                if (matter != null)
                {
                    txtNameMate.Text = matter.Name.ToString();
                    txtCodMat.Text = matter.Code.ToString();
                    matterAsig = matter;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadRequeriment(string code)
        {
            Matter matter;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            try
            {
                matter = logica.GetMatter(code);
                if (matter != null)
                {
                    txtReq.Text = matter.Code.ToString();
                    requirementAsig = matter;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void LoadCorequeriment(string code)
        {
            Matter matter;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            try
            {
                matter = logica.GetMatter(code);
                if (matter != null)
                {
                    txtCorreq.Text = matter.Code.ToString();
                    corequisiteAsig = matter;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void CargarCarrera(int idCarrera)
        {
            Careers career;
            CareersLogic logica = new CareersLogic(Config.getConnectionString);
            try
            {
                career = logica.GetCareer(idCarrera);
                if (career != null)
                {
                    txtCareer.Text = career.Name.ToString();
                    careerAsig = career;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /**/
        private void LoadCareerMatter(int idCareerMatter)
        {
            Careers career;
            CareersLogic logica = new CareersLogic(Config.getConnectionString);
            try
            {
                career = logica.GetCareer(idCareerMatter);
                if (career != null)
                {
                    txtCareer.Text = career.Name.ToString();
                    careerAsig = career;
                }
                else
                {
                    CargarListaArray();
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //***************************************************************//

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int result = -1;
            string requisito = null, correquisito = null;
            if (!string.IsNullOrEmpty(txtCodMat.Text.Trim())) {
                if (!string.IsNullOrEmpty(txtCareer.Text.Trim())) {
                    if (!string.IsNullOrEmpty(txtReq.Text.Trim())) {
                        requisito = txtReq.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtCorreq.Text.Trim())) {
                        correquisito = txtCorreq.Text.Trim();
                    }
                    careerMaterAsig = new CareerMatter(-1, careerAsig.Code, careerAsig.Name, matterAsig.Code, requisito,
                        correquisito, true);
                    CareerMatterLogic logic = new CareerMatterLogic(Config.getConnectionString);
                    try
                    {
                        result = logic.Insertar(careerMaterAsig);
                        if (result != -1) {
                            CargarListaArray();
                            MessageBox.Show("Materia asignada con éxito", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show("Error al asignar materia", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    }
                
                }
                else{
                    MessageBox.Show("Seleccione una carrera", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            } else {
                MessageBox.Show("Seleccione una materia","Materia",MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int result = -1;
            string requisito = null, correquisito = null;
            if (!string.IsNullOrEmpty(txtCodMat.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtCareer.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(txtReq.Text.Trim()))
                    {
                        requisito = txtReq.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtCorreq.Text.Trim()))
                    {
                        correquisito = txtCorreq.Text.Trim();
                    }
                    careerMaterAsig = new CareerMatter(-1, careerAsig.Code, careerAsig.Name, matterAsig.Code, requisito,
                        correquisito, true);
                    CareerMatterLogic logic = new CareerMatterLogic(Config.getConnectionString);
                    try
                    {
                        result = logic.Insertar(careerMaterAsig);
                        if (result != -1)
                        {
                            CargarListaArray();
                            MessageBox.Show("Materia asignada con éxito", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al asignar materia", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Seleccione una carrera", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una materia", "Materia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void frmAsignarMateriaCarrera_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaArray();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarMateria_Click(object sender, EventArgs e)
        {
            frmBuscarMateria = new frmBuscarMaterias();
            frmBuscarMateria.Aceptar += new EventHandler(AceptarMateria);
            frmBuscarMateria.Show();
        }

        private void AceptarMateria(object code, EventArgs e)
        {
            try
            {
                string idMatter = code.ToString();
                if (!string.IsNullOrEmpty(idMatter))
                {
                    LoadMatter(idMatter);
                }
                else
                {
                    txtCodMat.Text = string.Empty;
                    txtNameMate.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //

        private void AceptarRequisito(object code, EventArgs e)
        {
            try
            {
                string idMatter = code.ToString();
                if (!string.IsNullOrEmpty(idMatter))
                {
                    LoadRequeriment(idMatter);
                }
                else
                {
                    txtCodMat.Text = string.Empty;
                    txtNameMate.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //

        private void AceptarCorrequisito(object code, EventArgs e)
        {
            try
            {
                string idMatter = code.ToString();
                if (!string.IsNullOrEmpty(idMatter))
                {
                    LoadCorequeriment(idMatter);
                }
                else
                {
                    txtCodMat.Text = string.Empty;
                    txtNameMate.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscarReq_Click(object sender, EventArgs e)
        {
            frmBuscarMateria = new frmBuscarMaterias();
            frmBuscarMateria.Aceptar += new EventHandler(AceptarRequisito);
            frmBuscarMateria.Show();
        }

        private void btnBuscarCorreq_Click(object sender, EventArgs e)
        {
            frmBuscarMateria = new frmBuscarMaterias();
            frmBuscarMateria.Aceptar += new EventHandler(AceptarCorrequisito);
            frmBuscarMateria.Show();
        }

        private void btnBuscarPorCarrera_Click(object sender, EventArgs e)
        {
            frmBuscarCarrera = new frmBuscarCarrera();
            frmBuscarCarrera.Aceptar += new EventHandler(AceptarCarrera);
            frmBuscarCarrera.Show();
        }

        private void AceptarCarrera(object id, EventArgs e)
        {
            try
            {
                int idCarrera = (int)id;
                if (idCarrera != -1)
                {
                    CargarCarrera(idCarrera);
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

        

        private void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtBuscarPorNombre.Text))
                {
                    condicion = string.Format("NombreMateria like '%{0}%'", txtBuscarPorNombre.Text.Trim());
                }
                CargarListaArray(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
