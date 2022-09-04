
namespace Interfaz
{
    partial class frmBuscarMatAbierta
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
            this.btnBuscarMateria = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.CodMatAbierta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCareerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodMatCarre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corequisite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistCarrerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarMateria
            // 
            this.btnBuscarMateria.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarMateria.Location = new System.Drawing.Point(746, 20);
            this.btnBuscarMateria.Name = "btnBuscarMateria";
            this.btnBuscarMateria.Size = new System.Drawing.Size(50, 44);
            this.btnBuscarMateria.TabIndex = 0;
            this.btnBuscarMateria.UseVisualStyleBackColor = true;
            this.btnBuscarMateria.Click += new System.EventHandler(this.btnBuscarMateria_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(758, 544);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 44);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(883, 544);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 44);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(216, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(524, 26);
            this.txtNombre.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodMatAbierta,
            this.CodeCareerMatter,
            this.CodMatCarre,
            this.Nombre,
            this.CodMateria,
            this.Profe,
            this.Aula,
            this.Grupo,
            this.Cupo,
            this.Periodo,
            this.Anio,
            this.Disponible,
            this.CodCarrera,
            this.Exists,
            this.MatterCode,
            this.Requirement,
            this.Corequisite,
            this.ExistCarrerMatter,
            this.CareerName,
            this.Credits,
            this.Erased});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(46, 70);
            this.grdLista.MultiSelect = false;
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(945, 449);
            this.grdLista.TabIndex = 5;
            // 
            // CodMatAbierta
            // 
            this.CodMatAbierta.DataPropertyName = "OpenSubjectsCode";
            this.CodMatAbierta.HeaderText = "Materia Abierta";
            this.CodMatAbierta.Name = "CodMatAbierta";
            this.CodMatAbierta.ReadOnly = true;
            // 
            // CodeCareerMatter
            // 
            this.CodeCareerMatter.DataPropertyName = "CodeCareerMatter";
            this.CodeCareerMatter.HeaderText = "CodeCareerMatter";
            this.CodeCareerMatter.Name = "CodeCareerMatter";
            this.CodeCareerMatter.ReadOnly = true;
            this.CodeCareerMatter.Visible = false;
            // 
            // CodMatCarre
            // 
            this.CodMatCarre.DataPropertyName = "CareerMatterCode";
            this.CodMatCarre.HeaderText = "CodMatCarre";
            this.CodMatCarre.Name = "CodMatCarre";
            this.CodMatCarre.ReadOnly = true;
            this.CodMatCarre.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Name";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // CodMateria
            // 
            this.CodMateria.DataPropertyName = "Code";
            this.CodMateria.HeaderText = "Código";
            this.CodMateria.Name = "CodMateria";
            this.CodMateria.ReadOnly = true;
            // 
            // Profe
            // 
            this.Profe.DataPropertyName = "ProfesorCode";
            this.Profe.HeaderText = "Profe";
            this.Profe.Name = "Profe";
            this.Profe.ReadOnly = true;
            this.Profe.Visible = false;
            // 
            // Aula
            // 
            this.Aula.DataPropertyName = "AulaCode";
            this.Aula.HeaderText = "Aula";
            this.Aula.Name = "Aula";
            this.Aula.ReadOnly = true;
            this.Aula.Visible = false;
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Group";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Cupo
            // 
            this.Cupo.DataPropertyName = "Quota";
            this.Cupo.HeaderText = "Cupo";
            this.Cupo.Name = "Cupo";
            this.Cupo.ReadOnly = true;
            this.Cupo.Visible = false;
            // 
            // Periodo
            // 
            this.Periodo.DataPropertyName = "Period";
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.Name = "Periodo";
            this.Periodo.ReadOnly = true;
            // 
            // Anio
            // 
            this.Anio.DataPropertyName = "Year";
            this.Anio.HeaderText = "Anio";
            this.Anio.Name = "Anio";
            this.Anio.ReadOnly = true;
            // 
            // Disponible
            // 
            this.Disponible.DataPropertyName = "Available";
            this.Disponible.HeaderText = "Disponible";
            this.Disponible.Name = "Disponible";
            this.Disponible.ReadOnly = true;
            this.Disponible.Visible = false;
            // 
            // CodCarrera
            // 
            this.CodCarrera.DataPropertyName = "CareerCode";
            this.CodCarrera.HeaderText = "CodCarrera";
            this.CodCarrera.Name = "CodCarrera";
            this.CodCarrera.ReadOnly = true;
            this.CodCarrera.Visible = false;
            // 
            // Exists
            // 
            this.Exists.DataPropertyName = "Exists";
            this.Exists.HeaderText = "Exists";
            this.Exists.Name = "Exists";
            this.Exists.ReadOnly = true;
            this.Exists.Visible = false;
            // 
            // MatterCode
            // 
            this.MatterCode.DataPropertyName = "MatterCode";
            this.MatterCode.HeaderText = "MatterCode";
            this.MatterCode.Name = "MatterCode";
            this.MatterCode.ReadOnly = true;
            this.MatterCode.Visible = false;
            // 
            // Requirement
            // 
            this.Requirement.DataPropertyName = "Requirement";
            this.Requirement.HeaderText = "Requirement";
            this.Requirement.Name = "Requirement";
            this.Requirement.ReadOnly = true;
            this.Requirement.Visible = false;
            // 
            // Corequisite
            // 
            this.Corequisite.DataPropertyName = "Corequisite";
            this.Corequisite.HeaderText = "Corequisite";
            this.Corequisite.Name = "Corequisite";
            this.Corequisite.ReadOnly = true;
            this.Corequisite.Visible = false;
            // 
            // ExistCarrerMatter
            // 
            this.ExistCarrerMatter.DataPropertyName = "ExistsCarrerMatter";
            this.ExistCarrerMatter.HeaderText = "ExistCarrerMatter";
            this.ExistCarrerMatter.Name = "ExistCarrerMatter";
            this.ExistCarrerMatter.ReadOnly = true;
            this.ExistCarrerMatter.Visible = false;
            // 
            // CareerName
            // 
            this.CareerName.DataPropertyName = "CareerName";
            this.CareerName.HeaderText = "CareerName";
            this.CareerName.Name = "CareerName";
            this.CareerName.ReadOnly = true;
            this.CareerName.Visible = false;
            // 
            // Credits
            // 
            this.Credits.DataPropertyName = "Credits";
            this.Credits.HeaderText = "Credits";
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            this.Credits.Visible = false;
            // 
            // Erased
            // 
            this.Erased.DataPropertyName = "Erased";
            this.Erased.HeaderText = "Erased";
            this.Erased.Name = "Erased";
            this.Erased.ReadOnly = true;
            this.Erased.Visible = false;
            // 
            // frmBuscarMatAbierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnBuscarMateria);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarMatAbierta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frmBuscarMatAbierta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarMateria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodMatAbierta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCareerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodMatCarre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corequisite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistCarrerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
    }
}