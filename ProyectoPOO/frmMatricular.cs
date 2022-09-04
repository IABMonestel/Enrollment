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
    public partial class frmMatricular : Form
    {
        //variables globales
        
        private frmBusMatAbiMatri frmBusMatAbiMatri;//Ventana para buscar materias abiertas
        private frmBuscarEstudiante frmBuscarEstudiante;//Ventana para buscar estudiantes

        //Objects
        private ReferenceValues values;//Cargar valores de referencia de matrícula
        private Student studentSelected;//Estudiante seleccionado para matricular
        private OpenSubject openSubjectSelected;//Materia abierta a matricular
        private StudentEnrollDetail studentEnrollDetailSelected;//Detalles de matrícula del estudiante

        public frmMatricular(ReferenceValues values)
        {
            this.values = values;//Carga los valores de referencia
            InitializeComponent();
        }
        //metodo de limpiar
        private void Limpiar()
        {
            LimpiarMateria();//Limpia los campos de materia

            txtNombre.Text = string.Empty;
            txtMonto.Text = values.CostEnroll.ToString();
            txtMonto.Enabled = false;
            cboTipoPago.SelectedItem = null;
            txtDescuento.Text = string.Empty;
            txtCarne.Text = string.Empty;
            txtId.Text = string.Empty;
            txtEstado.Text = string.Empty;
            //grdLista
            txtNombre.Focus();
            //Objects
            openSubjectSelected = null;
            studentSelected = null;
            //datagrid
            grdLista.DataSource = new List<StudentEnrollDetail>();
            txtMonto.Enabled = true;
            lblMontoDescuento.Text = string.Empty;
            lblMontoMaterias.Text = string.Empty;
            lblMontoMatricula.Text = values.CostEnroll.ToString();
            lblMontoSubTotal.Text = string.Empty;
            lblMontoTotal.Text = string.Empty;
            lblDesc.Text = string.Empty;
            lblImp.Text = string.Empty;

        }

        private void LimpiarMateria() {
            txtMateria.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtCupo.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtPeriod.Text = values.Period.ToString();
            txtYear.Text = values.Year.ToString();
            txtMonto.Text = values.CostEnroll.ToString("C");
            lblMontoImpuesto.Text = values.Tax.ToString();
            txtCarrera.Text = string.Empty;
        }

        private void LoadStudent(string licenseStudent)//Carga un estudiante seleccionado
        {
            Student student;
            StudentLogic logica = new StudentLogic(Config.getConnectionString);
            try
            {
                student = logica.GetStudent(licenseStudent);
                
                if (student != null)
                {
                    txtCarne.Text = student.License.ToString();
                    txtNombre.Text = student.Name.ToString() + " " + student.FLastName.ToString() + " " + student.SLastName.ToString();
                    txtId.Text = student.Id.ToString();
                    txtEstado.Text = student.State.ToString();
                    studentSelected = student;
                    txtDescuento.Text = studentSelected.Discount.ToString();
                    ListarDetalles(studentSelected.License);
                }
                else
                {
                    MessageBox.Show("El estudiante no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadOpenSubject(int idOpenSubject)//Carga una materia abierta
        {
            OpenSubject openSubject;
            OpenMatterLogic logica = new OpenMatterLogic(Config.getConnectionString);
            try
            {
                openSubject = logica.GetOpenSubjectProfeAula(idOpenSubject);

                if (openSubject != null)
                {
                    txtMateria.Text = openSubject.Name.ToString();
                    txtGrupo.Text = openSubject.Group.ToString();
                    txtCupo.Text = openSubject.Quota.ToString();
                    txtCosto.Text = openSubject.Cost.ToString();
                    txtPeriod.Text = openSubject.Period.ToString();
                    txtYear.Text = openSubject.Year.ToString();
                    txtCarrera.Text = openSubject.CareerName.ToString();                    
                    openSubjectSelected = openSubject;//
                    //if (studentSelected != null) {
                    //    txtMonto.Text = studentEnrollDetailSelected.CostEnroll.ToString("C");
                    //}
                    //else
                    //{
                    //    txtMonto.Text = string.Empty;
                    //}
                    cboTipoPago.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("La materia no se encuentra en la base de datos", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ListarDetalles(string condicion = "")//Muestra la lista de detalles de matrícula
        {
            EnrollDetailLogic logica = new EnrollDetailLogic(Config.getConnectionString);
            List<StudentEnrollDetail> lista;
            try
            {
                lista = logica.ListarDetalles(condicion);
                if (lista.Count > 0)
                {
                    grdLista.DataSource = lista;

                    CargarMontos(studentSelected.License);
                }
                else
                {
                    grdLista.DataSource = new List<StudentEnrollDetail>();
                    //
                    lblMontoDescuento.Text = string.Empty;
                    lblMontoMaterias.Text = string.Empty;
                    
                    lblMontoTotal.Text = string.Empty;
                    lblMontoSubTotal.Text = string.Empty;
                                    }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarMontos(string license)//Carga los montos según detalles de matrícula del estudiante
        {
            EnrollDetailLogic logica = new EnrollDetailLogic(Config.getConnectionString);
            StudentEnrollDetail studentEnrollDetail;
            decimal descuento;
            try
            {
                studentEnrollDetail = logica.GetDetail(license);
                if (studentEnrollDetail != null)
                {
                    decimal subtotal = 0;
                    studentEnrollDetailSelected = studentEnrollDetail;
                    
                    lblMontoMaterias.Text = studentEnrollDetail.CostMatter.ToString("C");                    
                    subtotal = (studentEnrollDetail.CostMatter + values.CostEnroll);
                    lblMontoSubTotal.Text = (subtotal).ToString("C");
                    lblMontoDescuento.Text = studentEnrollDetail.Discount.ToString();
                    descuento = (subtotal * studentEnrollDetail.Discount);
                    lblDesc.Text = descuento.ToString("C");
                    lblImp.Text = (subtotal * ((Convert.ToDecimal(lblMontoImpuesto.Text)) / 100)
                        ).ToString("C");
                    lblMontoTotal.Text = ((subtotal+(subtotal* (Convert.ToDecimal(lblMontoImpuesto.Text)/100)
                        )) - descuento).ToString("C");
                }
                else
                {
                    grdLista.DataSource = new List<StudentEnrollDetail>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //**********************************************************//
        private void frmMatricular_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscarMat_Click(object sender, EventArgs e)
        {
            frmBusMatAbiMatri = new frmBusMatAbiMatri();
            frmBusMatAbiMatri.Aceptar += new EventHandler(Aceptar);
            frmBusMatAbiMatri.Show();
        }

        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idOpenSubject = (int)id;
                if (idOpenSubject != 0)
                {
                    LoadOpenSubject(idOpenSubject);
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

        private void btnBusEstudiante_Click(object sender, EventArgs e)
        {
            frmBuscarEstudiante = new frmBuscarEstudiante();
            frmBuscarEstudiante.Aceptar += new EventHandler(AceptarEstudiante);
            frmBuscarEstudiante.Show();
        }

        private void AceptarEstudiante(object id, EventArgs e)
        {
            try
            {
                string licenseStudent = id.ToString();
                if (!string.IsNullOrEmpty(licenseStudent))
                {
                    LoadStudent(licenseStudent);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)//Elimina un detalle de matrícula
        {
            int fact = -1, result = -1, cod_mat_abi = -1;
            EnrollmentDetails enrollmentDetail;

            if (grdLista.SelectedRows.Count > 0)
            {
                fact = (int)grdLista.SelectedRows[0].Cells[0].Value;
                cod_mat_abi = (int)grdLista.SelectedRows[0].Cells[8].Value;
                if (fact != -1)
                {
                    if (cod_mat_abi != -1)
                    {
                        enrollmentDetail = new EnrollmentDetails();
                        enrollmentDetail.BillNumber = fact;
                        enrollmentDetail.OpenMatCode = cod_mat_abi;
                        EnrollDetailLogic logic = new EnrollDetailLogic(Config.getConnectionString);
                        if (MessageBox.Show("Desea ELIMINAR?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            try
                            {
                                result = logic.Eliminar(enrollmentDetail);
                                if (result != -1)
                                {
                                    MessageBox.Show("Materia retirada con éxito", "Error", MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                    ListarDetalles(studentSelected.License);

                                }
                                else
                                {
                                    MessageBox.Show("Error al retirar materia. Intente de nuevo.", "Error", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                }
                            }


                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código de materia inválido", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Factura inválida", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una materia a retirar", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
            }
        }

        private void btnMatricular_Click(object sender, EventArgs e)//Matricula
        {
            decimal monto,descuento;
            int choqueHorarios = -999, requisitos = -999;
            if (openSubjectSelected != null)
            {
                if (studentSelected != null) {
                    monto = values.CostEnroll;
                            
                                if (!string.IsNullOrEmpty(txtDescuento.Text.Trim())) {
                                    if (decimal.TryParse(txtDescuento.Text.Trim(), out descuento)) {
                                        OpenMatterLogic logic = new OpenMatterLogic(Config.getConnectionString);
                                        choqueHorarios = logic.CompChoqHoraOtrasMat(openSubjectSelected.OpenSubjectsCode,studentSelected.License);
                                        if (choqueHorarios != -999) {
                                            //Matricular
                                            EnrollmentLogic logicEnroll = new EnrollmentLogic(Config.getConnectionString);
                                            requisitos = logicEnroll.Matricular(studentSelected.License,monto,"Otro",
                                                openSubjectSelected.OpenSubjectsCode,descuento, openSubjectSelected.Period, openSubjectSelected.Year);

                                            if (requisitos != -999)
                                            {
                                                //limpiar campos de materia
                                                LimpiarMateria();
                                                MessageBox.Show("Matrícula realizada con éxito", "Atención", MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                                //mostrar detalles de matrícula de estudiante
                                                ListarDetalles(studentSelected.License);
                                            }
                                            else {
                                                MessageBox.Show("No puede matricular, estudiante no comple con requisitos", "Error", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                            }
                                        }
                                        else {
                                            Limpiar();
                                            MessageBox.Show("No puede matricular, existe choque de horario", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                        }
                                    } else {
                                        txtDescuento.Focus();
                                        MessageBox.Show("Indique el descuento en valor numérico", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    }
                                } else {
                                    txtDescuento.Focus();
                                    MessageBox.Show("Indique el descuento", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                }      
                }                 
                else {
                    MessageBox.Show("Debe seleccione un estudiante", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Debe seleccionar la materia a matricular", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }        

        private void btnCancelar_Click(object sender, EventArgs e)//Cancela los montos de matrícula modificando el estado de factura
        {
            int fact = -1, result = -1;
            string license = string.Empty;
            Enrollment enrollment;
            if (cboTipoPago.SelectedItem != null)
            {
                if (grdLista.Rows.Count > 0) {
                    fact = (int)grdLista.Rows[0].Cells[0].Value;
                    if (fact != -1) {

                        enrollment = new Enrollment();
                        EnrollmentLogic logicEnroll = new EnrollmentLogic(Config.getConnectionString);
                        enrollment.NumFact = fact;
                        enrollment.Meat = txtCarne.Text;
                        enrollment.TypePayment = cboTipoPago.Text;
                        try
                        {
                            result = logicEnroll.Modificar(enrollment);
                        }
                        catch (Exception exc)
                        {

                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        }
                        
                        if (result != -1)
                        {
                            MessageBox.Show("Factura: " + fact.ToString() + " de estudiante: " + txtCarne.Text + " cancelada.");
                            ListarDetalles(studentSelected.License);
                        }
                        else {
                            MessageBox.Show("Error al cancelar factura", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("Factura inválida", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("Seleccione un estudiante", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
            }
            else
            {
                cboTipoPago.Focus();
                MessageBox.Show("Indique un tipo de pago", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }//clase
}
