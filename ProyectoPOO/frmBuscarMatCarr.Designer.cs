
namespace Interfaz
{
    partial class frmBuscarMatCarr
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
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistsCarrerMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.career = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corequisito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeight = 26;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.CareerCode,
            this.MatterCode,
            this.ExistsCarrerMatter,
            this.Credits,
            this.Erased,
            this.Exists,
            this.dataGridViewTextBoxColumn1,
            this.name,
            this.career,
            this.requisito,
            this.corequisito});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(7, 94);
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(970, 408);
            this.grdLista.TabIndex = 5;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "Code";
            this.code.HeaderText = "Código";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // CareerCode
            // 
            this.CareerCode.DataPropertyName = "CareerCode";
            this.CareerCode.HeaderText = "Column1";
            this.CareerCode.Name = "CareerCode";
            this.CareerCode.ReadOnly = true;
            this.CareerCode.Visible = false;
            // 
            // MatterCode
            // 
            this.MatterCode.DataPropertyName = "CodeCareerMatter";
            this.MatterCode.HeaderText = "CodigoMateria";
            this.MatterCode.Name = "MatterCode";
            this.MatterCode.ReadOnly = true;
            this.MatterCode.Visible = false;
            // 
            // ExistsCarrerMatter
            // 
            this.ExistsCarrerMatter.DataPropertyName = "ExistsCarrerMatter";
            this.ExistsCarrerMatter.HeaderText = "ExisteMateriaCarrera";
            this.ExistsCarrerMatter.Name = "ExistsCarrerMatter";
            this.ExistsCarrerMatter.ReadOnly = true;
            this.ExistsCarrerMatter.Visible = false;
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
            // Exists
            // 
            this.Exists.DataPropertyName = "Exists";
            this.Exists.HeaderText = "Exists";
            this.Exists.Name = "Exists";
            this.Exists.ReadOnly = true;
            this.Exists.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MatterCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "MatterCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 275;
            // 
            // career
            // 
            this.career.DataPropertyName = "CareerName";
            this.career.HeaderText = "Carrera";
            this.career.Name = "career";
            this.career.ReadOnly = true;
            this.career.Width = 250;
            // 
            // requisito
            // 
            this.requisito.DataPropertyName = "Requirement";
            this.requisito.HeaderText = "Requisito";
            this.requisito.Name = "requisito";
            this.requisito.ReadOnly = true;
            this.requisito.Width = 150;
            // 
            // corequisito
            // 
            this.corequisito.DataPropertyName = "Corequisite";
            this.corequisito.HeaderText = "Correquisito";
            this.corequisito.Name = "corequisito";
            this.corequisito.ReadOnly = true;
            this.corequisito.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdLista);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(998, 568);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(834, 522);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 39);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(726, 522);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 39);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscar.Location = new System.Drawing.Point(757, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(44, 44);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(224, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(518, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // frmBuscarMatCarr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarMatCarr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frmBuscarMatCarr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistsCarrerMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn career;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisito;
        private System.Windows.Forms.DataGridViewTextBoxColumn corequisito;
    }
}