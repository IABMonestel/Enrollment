
namespace Interfaz
{
    partial class frmAbrirMateria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.npdCupo = new System.Windows.Forms.NumericUpDown();
            this.rbtNxtYear = new System.Windows.Forms.RadioButton();
            this.rbtActYear = new System.Windows.Forms.RadioButton();
            this.ndl_Periodo = new System.Windows.Forms.NumericUpDown();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscMateAbierta = new System.Windows.Forms.Button();
            this.txtMatAbier = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnVerHorarios = new System.Windows.Forms.Button();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
            this.cboDia = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModiMatCarr = new System.Windows.Forms.Button();
            this.btnBuscarMatCarr = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtCodMatAbi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarIdProfesor = new System.Windows.Forms.Button();
            this.txtNombreProfesor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAsignarPro = new System.Windows.Forms.Button();
            this.txtIdProfesor = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarNumAula = new System.Windows.Forms.Button();
            this.txtTipoAula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAsignarAula = new System.Windows.Forms.Button();
            this.txtNumAula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndl_Periodo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.npdCupo);
            this.groupBox1.Controls.Add(this.rbtNxtYear);
            this.groupBox1.Controls.Add(this.rbtActYear);
            this.groupBox1.Controls.Add(this.ndl_Periodo);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnBuscMateAbierta);
            this.groupBox1.Controls.Add(this.txtMatAbier);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnModiMatCarr);
            this.groupBox1.Controls.Add(this.btnBuscarMatCarr);
            this.groupBox1.Controls.Add(this.txtCosto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGrupo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAbrir);
            this.groupBox1.Controls.Add(this.txtCodMatAbi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(37, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1205, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abrir Materia";
            // 
            // npdCupo
            // 
            this.npdCupo.Location = new System.Drawing.Point(125, 129);
            this.npdCupo.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.npdCupo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.npdCupo.Name = "npdCupo";
            this.npdCupo.Size = new System.Drawing.Size(120, 26);
            this.npdCupo.TabIndex = 1;
            this.npdCupo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rbtNxtYear
            // 
            this.rbtNxtYear.AutoSize = true;
            this.rbtNxtYear.Location = new System.Drawing.Point(239, 234);
            this.rbtNxtYear.Name = "rbtNxtYear";
            this.rbtNxtYear.Size = new System.Drawing.Size(14, 13);
            this.rbtNxtYear.TabIndex = 5;
            this.rbtNxtYear.TabStop = true;
            this.rbtNxtYear.UseVisualStyleBackColor = true;
            // 
            // rbtActYear
            // 
            this.rbtActYear.AutoSize = true;
            this.rbtActYear.Location = new System.Drawing.Point(122, 234);
            this.rbtActYear.Name = "rbtActYear";
            this.rbtActYear.Size = new System.Drawing.Size(14, 13);
            this.rbtActYear.TabIndex = 4;
            this.rbtActYear.TabStop = true;
            this.rbtActYear.UseVisualStyleBackColor = true;
            // 
            // ndl_Periodo
            // 
            this.ndl_Periodo.Location = new System.Drawing.Point(125, 203);
            this.ndl_Periodo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ndl_Periodo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndl_Periodo.Name = "ndl_Periodo";
            this.ndl_Periodo.Size = new System.Drawing.Size(120, 26);
            this.ndl_Periodo.TabIndex = 3;
            this.ndl_Periodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndl_Periodo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1100, 199);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 33);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscMateAbierta
            // 
            this.btnBuscMateAbierta.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscMateAbierta.Location = new System.Drawing.Point(1045, 195);
            this.btnBuscMateAbierta.Name = "btnBuscMateAbierta";
            this.btnBuscMateAbierta.Size = new System.Drawing.Size(47, 41);
            this.btnBuscMateAbierta.TabIndex = 12;
            this.btnBuscMateAbierta.UseVisualStyleBackColor = true;
            this.btnBuscMateAbierta.Click += new System.EventHandler(this.btnBuscMateAbierta_Click);
            // 
            // txtMatAbier
            // 
            this.txtMatAbier.Location = new System.Drawing.Point(126, 61);
            this.txtMatAbier.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatAbier.Name = "txtMatAbier";
            this.txtMatAbier.ReadOnly = true;
            this.txtMatAbier.Size = new System.Drawing.Size(331, 26);
            this.txtMatAbier.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Materia:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(854, 200);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(84, 33);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnVerHorarios);
            this.groupBox4.Controls.Add(this.dtpHoraFin);
            this.groupBox4.Controls.Add(this.dtpHoraInicio);
            this.groupBox4.Controls.Add(this.btnAgregarHorario);
            this.groupBox4.Controls.Add(this.cboDia);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(530, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(562, 155);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Horario";
            // 
            // btnVerHorarios
            // 
            this.btnVerHorarios.Location = new System.Drawing.Point(449, 59);
            this.btnVerHorarios.Name = "btnVerHorarios";
            this.btnVerHorarios.Size = new System.Drawing.Size(96, 28);
            this.btnVerHorarios.TabIndex = 14;
            this.btnVerHorarios.Text = "Consultar";
            this.btnVerHorarios.UseVisualStyleBackColor = true;
            this.btnVerHorarios.Click += new System.EventHandler(this.btnVerHorarios_Click);
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(120, 91);
            this.dtpHoraFin.MinDate = new System.DateTime(2021, 10, 28, 0, 0, 0, 0);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Size = new System.Drawing.Size(229, 26);
            this.dtpHoraFin.TabIndex = 8;
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(120, 59);
            this.dtpHoraInicio.MinDate = new System.DateTime(2021, 10, 28, 0, 0, 0, 0);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(229, 26);
            this.dtpHoraInicio.TabIndex = 7;
            this.dtpHoraInicio.ValueChanged += new System.EventHandler(this.dtpHoraInicio_ValueChanged);
            // 
            // btnAgregarHorario
            // 
            this.btnAgregarHorario.Location = new System.Drawing.Point(449, 96);
            this.btnAgregarHorario.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.Size = new System.Drawing.Size(96, 30);
            this.btnAgregarHorario.TabIndex = 15;
            this.btnAgregarHorario.Text = "Agregar";
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            this.btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
            // 
            // cboDia
            // 
            this.cboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDia.FormattingEnabled = true;
            this.cboDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.cboDia.Location = new System.Drawing.Point(120, 25);
            this.cboDia.Name = "cboDia";
            this.cboDia.Size = new System.Drawing.Size(191, 28);
            this.cboDia.TabIndex = 6;
            this.cboDia.SelectedIndexChanged += new System.EventHandler(this.cboDia_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "Hora Inicio:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Hora Fin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Día:";
            // 
            // btnModiMatCarr
            // 
            this.btnModiMatCarr.Location = new System.Drawing.Point(942, 199);
            this.btnModiMatCarr.Margin = new System.Windows.Forms.Padding(4);
            this.btnModiMatCarr.Name = "btnModiMatCarr";
            this.btnModiMatCarr.Size = new System.Drawing.Size(96, 33);
            this.btnModiMatCarr.TabIndex = 11;
            this.btnModiMatCarr.Text = "Modificar";
            this.btnModiMatCarr.UseVisualStyleBackColor = true;
            this.btnModiMatCarr.Click += new System.EventHandler(this.btnModiMatCarr_Click);
            // 
            // btnBuscarMatCarr
            // 
            this.btnBuscarMatCarr.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarMatCarr.Location = new System.Drawing.Point(465, 54);
            this.btnBuscarMatCarr.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarMatCarr.Name = "btnBuscarMatCarr";
            this.btnBuscarMatCarr.Size = new System.Drawing.Size(47, 41);
            this.btnBuscarMatCarr.TabIndex = 0;
            this.btnBuscarMatCarr.UseVisualStyleBackColor = true;
            this.btnBuscarMatCarr.Click += new System.EventHandler(this.btnBuscarMatCarr_Click);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(126, 165);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosto.MaxLength = 10;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(127, 26);
            this.txtCosto.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 234);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Año:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 205);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Periodo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 170);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Costo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 135);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Cupo:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(126, 95);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrupo.MaxLength = 2;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(127, 26);
            this.txtGrupo.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Grupo:";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(755, 199);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(92, 33);
            this.btnAbrir.TabIndex = 9;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // txtCodMatAbi
            // 
            this.txtCodMatAbi.Location = new System.Drawing.Point(126, 28);
            this.txtCodMatAbi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodMatAbi.Name = "txtCodMatAbi";
            this.txtCodMatAbi.ReadOnly = true;
            this.txtCodMatAbi.Size = new System.Drawing.Size(127, 26);
            this.txtCodMatAbi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarIdProfesor);
            this.groupBox2.Controls.Add(this.txtNombreProfesor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnAsignarPro);
            this.groupBox2.Controls.Add(this.txtIdProfesor);
            this.groupBox2.Controls.Add(this.Nombre);
            this.groupBox2.Location = new System.Drawing.Point(37, 297);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(623, 98);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asignar Profesor";
            // 
            // btnBuscarIdProfesor
            // 
            this.btnBuscarIdProfesor.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarIdProfesor.Location = new System.Drawing.Point(391, 14);
            this.btnBuscarIdProfesor.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarIdProfesor.Name = "btnBuscarIdProfesor";
            this.btnBuscarIdProfesor.Size = new System.Drawing.Size(48, 49);
            this.btnBuscarIdProfesor.TabIndex = 16;
            this.btnBuscarIdProfesor.UseVisualStyleBackColor = true;
            this.btnBuscarIdProfesor.Click += new System.EventHandler(this.btnBuscarIdProfesor_Click);
            // 
            // txtNombreProfesor
            // 
            this.txtNombreProfesor.Location = new System.Drawing.Point(100, 61);
            this.txtNombreProfesor.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreProfesor.Name = "txtNombreProfesor";
            this.txtNombreProfesor.ReadOnly = true;
            this.txtNombreProfesor.Size = new System.Drawing.Size(282, 26);
            this.txtNombreProfesor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Id:";
            // 
            // btnAsignarPro
            // 
            this.btnAsignarPro.Location = new System.Drawing.Point(447, 26);
            this.btnAsignarPro.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsignarPro.Name = "btnAsignarPro";
            this.btnAsignarPro.Size = new System.Drawing.Size(96, 30);
            this.btnAsignarPro.TabIndex = 17;
            this.btnAsignarPro.Text = "Asignar";
            this.btnAsignarPro.UseVisualStyleBackColor = true;
            this.btnAsignarPro.Click += new System.EventHandler(this.btnAsignarPro_Click);
            // 
            // txtIdProfesor
            // 
            this.txtIdProfesor.Location = new System.Drawing.Point(100, 27);
            this.txtIdProfesor.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdProfesor.Name = "txtIdProfesor";
            this.txtIdProfesor.ReadOnly = true;
            this.txtIdProfesor.Size = new System.Drawing.Size(282, 26);
            this.txtIdProfesor.TabIndex = 1;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(19, 65);
            this.Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(69, 20);
            this.Nombre.TabIndex = 0;
            this.Nombre.Text = "Nombre:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarNumAula);
            this.groupBox3.Controls.Add(this.txtTipoAula);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAsignarAula);
            this.groupBox3.Controls.Add(this.txtNumAula);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(676, 297);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(566, 98);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar Aula";
            // 
            // btnBuscarNumAula
            // 
            this.btnBuscarNumAula.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarNumAula.Location = new System.Drawing.Point(255, 23);
            this.btnBuscarNumAula.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarNumAula.Name = "btnBuscarNumAula";
            this.btnBuscarNumAula.Size = new System.Drawing.Size(44, 44);
            this.btnBuscarNumAula.TabIndex = 18;
            this.btnBuscarNumAula.UseVisualStyleBackColor = true;
            this.btnBuscarNumAula.Click += new System.EventHandler(this.btnBuscarNumAula_Click);
            // 
            // txtTipoAula
            // 
            this.txtTipoAula.Location = new System.Drawing.Point(91, 60);
            this.txtTipoAula.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoAula.Name = "txtTipoAula";
            this.txtTipoAula.ReadOnly = true;
            this.txtTipoAula.Size = new System.Drawing.Size(156, 26);
            this.txtTipoAula.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo:";
            // 
            // btnAsignarAula
            // 
            this.btnAsignarAula.Location = new System.Drawing.Point(317, 23);
            this.btnAsignarAula.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsignarAula.Name = "btnAsignarAula";
            this.btnAsignarAula.Size = new System.Drawing.Size(96, 30);
            this.btnAsignarAula.TabIndex = 19;
            this.btnAsignarAula.Text = "Asignar";
            this.btnAsignarAula.UseVisualStyleBackColor = true;
            this.btnAsignarAula.Click += new System.EventHandler(this.btnAsignarAula_Click);
            // 
            // txtNumAula
            // 
            this.txtNumAula.Location = new System.Drawing.Point(91, 26);
            this.txtNumAula.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumAula.Name = "txtNumAula";
            this.txtNumAula.ReadOnly = true;
            this.txtNumAula.Size = new System.Drawing.Size(156, 26);
            this.txtNumAula.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Número:";
            // 
            // frmAbrirMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1354, 423);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAbrirMateria";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abrir Materia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAbrirMateria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndl_Periodo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtCodMatAbi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreProfesor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAsignarPro;
        private System.Windows.Forms.TextBox txtIdProfesor;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTipoAula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAsignarAula;
        private System.Windows.Forms.TextBox txtNumAula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscarMatCarr;
        private System.Windows.Forms.Button btnBuscarIdProfesor;
        private System.Windows.Forms.Button btnBuscarNumAula;
        private System.Windows.Forms.Button btnModiMatCarr;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Button btnAgregarHorario;
        private System.Windows.Forms.ComboBox cboDia;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscMateAbierta;
        private System.Windows.Forms.TextBox txtMatAbier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVerHorarios;
        private System.Windows.Forms.NumericUpDown ndl_Periodo;
        private System.Windows.Forms.RadioButton rbtNxtYear;
        private System.Windows.Forms.RadioButton rbtActYear;
        private System.Windows.Forms.NumericUpDown npdCupo;
    }
}