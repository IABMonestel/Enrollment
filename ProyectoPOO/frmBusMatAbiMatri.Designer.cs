
namespace Interfaz
{
    partial class frmBusMatAbiMatri
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenSubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corequisite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerMatterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfesorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AulaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCareerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistsCarrerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscar.Location = new System.Drawing.Point(839, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(45, 44);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(234, 39);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(589, 26);
            this.txtBuscar.TabIndex = 2;
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.OpenSubjectCode,
            this.NameM,
            this.Credits,
            this.Requirement,
            this.Corequisite,
            this.CareerName,
            this.CareerMatterCode,
            this.ProfesorCode,
            this.AulaCode,
            this.Group,
            this.Quota,
            this.Cost,
            this.Period,
            this.Year,
            this.Available,
            this.CodeCareerMatter,
            this.CareerCode,
            this.MatterCode,
            this.ExistsCarrerMatter,
            this.Erased,
            this.Exists});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(12, 80);
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(1005, 465);
            this.grdLista.TabIndex = 3;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(769, 551);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(116, 40);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(901, 551);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Cod";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // OpenSubjectCode
            // 
            this.OpenSubjectCode.DataPropertyName = "OpenSubjectsCode";
            this.OpenSubjectCode.HeaderText = "Código";
            this.OpenSubjectCode.Name = "OpenSubjectCode";
            this.OpenSubjectCode.ReadOnly = true;
            this.OpenSubjectCode.Visible = false;
            // 
            // NameM
            // 
            this.NameM.DataPropertyName = "Name";
            this.NameM.HeaderText = "Nombre";
            this.NameM.Name = "NameM";
            this.NameM.ReadOnly = true;
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
            // 
            // Corequisite
            // 
            this.Corequisite.DataPropertyName = "Corequisite";
            this.Corequisite.HeaderText = "Correquisito";
            this.Corequisite.Name = "Corequisite";
            this.Corequisite.ReadOnly = true;
            // 
            // CareerName
            // 
            this.CareerName.DataPropertyName = "CareerName";
            this.CareerName.HeaderText = "Carrera";
            this.CareerName.Name = "CareerName";
            this.CareerName.ReadOnly = true;
            // 
            // CareerMatterCode
            // 
            this.CareerMatterCode.DataPropertyName = "CareerMatterCode";
            this.CareerMatterCode.HeaderText = "CareerMatterCode";
            this.CareerMatterCode.Name = "CareerMatterCode";
            this.CareerMatterCode.ReadOnly = true;
            this.CareerMatterCode.Visible = false;
            // 
            // ProfesorCode
            // 
            this.ProfesorCode.DataPropertyName = "ProfesorCode";
            this.ProfesorCode.HeaderText = "ProfesorCode";
            this.ProfesorCode.Name = "ProfesorCode";
            this.ProfesorCode.ReadOnly = true;
            this.ProfesorCode.Visible = false;
            // 
            // AulaCode
            // 
            this.AulaCode.DataPropertyName = "AulaCode";
            this.AulaCode.HeaderText = "AulaCode";
            this.AulaCode.Name = "AulaCode";
            this.AulaCode.ReadOnly = true;
            this.AulaCode.Visible = false;
            // 
            // Group
            // 
            this.Group.DataPropertyName = "Group";
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            // 
            // Quota
            // 
            this.Quota.DataPropertyName = "Quota";
            this.Quota.HeaderText = "Cupo";
            this.Quota.Name = "Quota";
            this.Quota.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Costo";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.DataPropertyName = "Period";
            this.Period.HeaderText = "Periodo";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Año";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // Available
            // 
            this.Available.DataPropertyName = "Available";
            this.Available.HeaderText = "Disponible";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            this.Available.Visible = false;
            // 
            // CodeCareerMatter
            // 
            this.CodeCareerMatter.DataPropertyName = "CodeCareerMatter";
            this.CodeCareerMatter.HeaderText = "CodeCareerMatter";
            this.CodeCareerMatter.Name = "CodeCareerMatter";
            this.CodeCareerMatter.ReadOnly = true;
            this.CodeCareerMatter.Visible = false;
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
            // frmBusMatAbiMatri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBusMatAbiMatri";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frmBusMatAbiMatri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenSubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corequisite;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerMatterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfesorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AulaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCareerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistsCarrerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
    }
}