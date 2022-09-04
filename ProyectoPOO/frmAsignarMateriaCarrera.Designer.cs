
namespace ProyectoPOO
{
    partial class frmAsignarMateriaCarrera
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodMat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarMateria = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarCorreq = new System.Windows.Forms.Button();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.txtCareer = new System.Windows.Forms.TextBox();
            this.txtCorreq = new System.Windows.Forms.TextBox();
            this.txtNameMate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarPorCarrera = new System.Windows.Forms.Button();
            this.btnBuscarReq = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBuscarPorNombre = new System.Windows.Forms.TextBox();
            this.btnBuscarPorNombre = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CodeCareerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corequisite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistsCarrerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1072, 94);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(123, 41);
            this.btnEliminar.TabIndex = 50;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(948, 94);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(123, 41);
            this.btnModificar.TabIndex = 49;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(823, 94);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(123, 41);
            this.btnRegistrar.TabIndex = 48;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodMat);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnBuscarMateria);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscarCorreq);
            this.groupBox1.Controls.Add(this.txtReq);
            this.groupBox1.Controls.Add(this.txtCareer);
            this.groupBox1.Controls.Add(this.txtCorreq);
            this.groupBox1.Controls.Add(this.txtNameMate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarPorCarrera);
            this.groupBox1.Controls.Add(this.btnBuscarReq);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1710, 153);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar Materia a Carrera";
            // 
            // txtCodMat
            // 
            this.txtCodMat.Location = new System.Drawing.Point(98, 40);
            this.txtCodMat.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodMat.Name = "txtCodMat";
            this.txtCodMat.ReadOnly = true;
            this.txtCodMat.Size = new System.Drawing.Size(186, 26);
            this.txtCodMat.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Código:";
            // 
            // btnBuscarMateria
            // 
            this.btnBuscarMateria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarMateria.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarMateria.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarMateria.Location = new System.Drawing.Point(292, 30);
            this.btnBuscarMateria.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarMateria.Name = "btnBuscarMateria";
            this.btnBuscarMateria.Size = new System.Drawing.Size(52, 54);
            this.btnBuscarMateria.TabIndex = 46;
            this.btnBuscarMateria.UseVisualStyleBackColor = false;
            this.btnBuscarMateria.Click += new System.EventHandler(this.btnBuscarMateria_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Correquisito:";
            // 
            // btnBuscarCorreq
            // 
            this.btnBuscarCorreq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarCorreq.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarCorreq.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarCorreq.Location = new System.Drawing.Point(655, 90);
            this.btnBuscarCorreq.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCorreq.Name = "btnBuscarCorreq";
            this.btnBuscarCorreq.Size = new System.Drawing.Size(53, 55);
            this.btnBuscarCorreq.TabIndex = 43;
            this.btnBuscarCorreq.UseVisualStyleBackColor = false;
            this.btnBuscarCorreq.Click += new System.EventHandler(this.btnBuscarCorreq_Click);
            // 
            // txtReq
            // 
            this.txtReq.Location = new System.Drawing.Point(98, 101);
            this.txtReq.Margin = new System.Windows.Forms.Padding(4);
            this.txtReq.Name = "txtReq";
            this.txtReq.ReadOnly = true;
            this.txtReq.Size = new System.Drawing.Size(186, 26);
            this.txtReq.TabIndex = 42;
            // 
            // txtCareer
            // 
            this.txtCareer.Location = new System.Drawing.Point(879, 40);
            this.txtCareer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCareer.Name = "txtCareer";
            this.txtCareer.ReadOnly = true;
            this.txtCareer.Size = new System.Drawing.Size(368, 26);
            this.txtCareer.TabIndex = 40;
            // 
            // txtCorreq
            // 
            this.txtCorreq.Location = new System.Drawing.Point(455, 101);
            this.txtCorreq.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreq.Name = "txtCorreq";
            this.txtCorreq.ReadOnly = true;
            this.txtCorreq.Size = new System.Drawing.Size(192, 26);
            this.txtCorreq.TabIndex = 41;
            // 
            // txtNameMate
            // 
            this.txtNameMate.Location = new System.Drawing.Point(425, 40);
            this.txtNameMate.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameMate.Name = "txtNameMate";
            this.txtNameMate.ReadOnly = true;
            this.txtNameMate.Size = new System.Drawing.Size(372, 26);
            this.txtNameMate.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Requisito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Materia:";
            // 
            // btnBuscarPorCarrera
            // 
            this.btnBuscarPorCarrera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarPorCarrera.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarPorCarrera.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarPorCarrera.Location = new System.Drawing.Point(1255, 29);
            this.btnBuscarPorCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarPorCarrera.Name = "btnBuscarPorCarrera";
            this.btnBuscarPorCarrera.Size = new System.Drawing.Size(48, 49);
            this.btnBuscarPorCarrera.TabIndex = 34;
            this.btnBuscarPorCarrera.UseVisualStyleBackColor = false;
            this.btnBuscarPorCarrera.Click += new System.EventHandler(this.btnBuscarPorCarrera_Click);
            // 
            // btnBuscarReq
            // 
            this.btnBuscarReq.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarReq.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarReq.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarReq.Location = new System.Drawing.Point(292, 91);
            this.btnBuscarReq.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarReq.Name = "btnBuscarReq";
            this.btnBuscarReq.Size = new System.Drawing.Size(52, 54);
            this.btnBuscarReq.TabIndex = 25;
            this.btnBuscarReq.UseVisualStyleBackColor = false;
            this.btnBuscarReq.Click += new System.EventHandler(this.btnBuscarReq_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(805, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Carrera:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1308, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Correquisito:";
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeCareerMatter,
            this.Code,
            this.NameM,
            this.Credits,
            this.Requirement,
            this.Corequisite,
            this.CareerName,
            this.CareerCode,
            this.MatterCode,
            this.ExistsCarrerMatter,
            this.Erased,
            this.Exists});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(132, 277);
            this.grdLista.Margin = new System.Windows.Forms.Padding(4);
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(1093, 381);
            this.grdLista.TabIndex = 51;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBuscarPorNombre);
            this.groupBox2.Controls.Add(this.btnBuscarPorNombre);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(212, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(946, 94);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar";
            // 
            // txtBuscarPorNombre
            // 
            this.txtBuscarPorNombre.Location = new System.Drawing.Point(98, 33);
            this.txtBuscarPorNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarPorNombre.Name = "txtBuscarPorNombre";
            this.txtBuscarPorNombre.Size = new System.Drawing.Size(435, 26);
            this.txtBuscarPorNombre.TabIndex = 43;
            // 
            // btnBuscarPorNombre
            // 
            this.btnBuscarPorNombre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarPorNombre.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarPorNombre.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarPorNombre.Location = new System.Drawing.Point(541, 22);
            this.btnBuscarPorNombre.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarPorNombre.Name = "btnBuscarPorNombre";
            this.btnBuscarPorNombre.Size = new System.Drawing.Size(48, 49);
            this.btnBuscarPorNombre.TabIndex = 42;
            this.btnBuscarPorNombre.UseVisualStyleBackColor = false;
            this.btnBuscarPorNombre.Click += new System.EventHandler(this.btnBuscarPorNombre_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Nombre:";
            // 
            // CodeCareerMatter
            // 
            this.CodeCareerMatter.DataPropertyName = "CodeCareerMatter";
            this.CodeCareerMatter.HeaderText = "CodeCareerMatter";
            this.CodeCareerMatter.Name = "CodeCareerMatter";
            this.CodeCareerMatter.ReadOnly = true;
            this.CodeCareerMatter.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Código";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 150;
            // 
            // NameM
            // 
            this.NameM.DataPropertyName = "Name";
            this.NameM.HeaderText = "Nombre";
            this.NameM.Name = "NameM";
            this.NameM.ReadOnly = true;
            this.NameM.Width = 200;
            // 
            // Credits
            // 
            this.Credits.DataPropertyName = "Credits";
            this.Credits.HeaderText = "Créditos";
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            // 
            // Requirement
            // 
            this.Requirement.DataPropertyName = "Requirement";
            this.Requirement.HeaderText = "Requisito";
            this.Requirement.Name = "Requirement";
            this.Requirement.ReadOnly = true;
            this.Requirement.Width = 200;
            // 
            // Corequisite
            // 
            this.Corequisite.DataPropertyName = "Corequisite";
            this.Corequisite.HeaderText = "Correquisito";
            this.Corequisite.Name = "Corequisite";
            this.Corequisite.ReadOnly = true;
            this.Corequisite.Width = 200;
            // 
            // CareerName
            // 
            this.CareerName.DataPropertyName = "CareerName";
            this.CareerName.HeaderText = "Carrera";
            this.CareerName.Name = "CareerName";
            this.CareerName.ReadOnly = true;
            this.CareerName.Width = 200;
            // 
            // CareerCode
            // 
            this.CareerCode.DataPropertyName = "CareerCode";
            this.CareerCode.HeaderText = "CareerCode";
            this.CareerCode.Name = "CareerCode";
            this.CareerCode.ReadOnly = true;
            this.CareerCode.Visible = false;
            // 
            // MatterCode
            // 
            this.MatterCode.DataPropertyName = "MatterCode";
            this.MatterCode.HeaderText = "MatterCode";
            this.MatterCode.Name = "MatterCode";
            this.MatterCode.ReadOnly = true;
            this.MatterCode.Visible = false;
            // 
            // ExistsCarrerMatter
            // 
            this.ExistsCarrerMatter.DataPropertyName = "ExistsCarrerMatter";
            this.ExistsCarrerMatter.HeaderText = "ExistsCarrerMatter";
            this.ExistsCarrerMatter.Name = "ExistsCarrerMatter";
            this.ExistsCarrerMatter.ReadOnly = true;
            this.ExistsCarrerMatter.Visible = false;
            // 
            // Erased
            // 
            this.Erased.DataPropertyName = "Erased";
            this.Erased.HeaderText = "Erased";
            this.Erased.Name = "Erased";
            this.Erased.ReadOnly = true;
            this.Erased.Visible = false;
            // 
            // Exists
            // 
            this.Exists.DataPropertyName = "Exists";
            this.Exists.HeaderText = "Exists";
            this.Exists.Name = "Exists";
            this.Exists.ReadOnly = true;
            this.Exists.Visible = false;
            // 
            // frmAsignarMateriaCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1354, 671);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAsignarMateriaCarrera";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Materia a Carrera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAsignarMateriaCarrera_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNameMate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarPorCarrera;
        private System.Windows.Forms.Button btnBuscarReq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.TextBox txtCorreq;
        private System.Windows.Forms.TextBox txtCareer;
        private System.Windows.Forms.Button btnBuscarCorreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.TextBox txtCodMat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarMateria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBuscarPorNombre;
        private System.Windows.Forms.Button btnBuscarPorNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCareerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corequisite;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistsCarrerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
    }
}