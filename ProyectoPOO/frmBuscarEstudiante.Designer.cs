
namespace Interfaz
{
    partial class frmBuscarEstudiante
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.License = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.District = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherSigns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdmisionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscar.Location = new System.Drawing.Point(832, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 42);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(814, 537);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 40);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(917, 537);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(280, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(546, 26);
            this.txtNombre.TabIndex = 4;
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.License,
            this.Id,
            this.NameE,
            this.FLastName,
            this.SLastName,
            this.Discount,
            this.Province,
            this.Canton,
            this.District,
            this.OtherSigns,
            this.AdmisionDate,
            this.State,
            this.Phone,
            this.Email,
            this.Erased,
            this.Exists});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(12, 85);
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(1045, 435);
            this.grdLista.TabIndex = 5;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            // 
            // License
            // 
            this.License.DataPropertyName = "License";
            this.License.HeaderText = "Carné";
            this.License.Name = "License";
            this.License.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 150;
            // 
            // NameE
            // 
            this.NameE.DataPropertyName = "Name";
            this.NameE.HeaderText = "Nombre";
            this.NameE.Name = "NameE";
            this.NameE.ReadOnly = true;
            this.NameE.Width = 150;
            // 
            // FLastName
            // 
            this.FLastName.DataPropertyName = "FLastName";
            this.FLastName.HeaderText = "Primer Apellido";
            this.FLastName.Name = "FLastName";
            this.FLastName.ReadOnly = true;
            this.FLastName.Width = 150;
            // 
            // SLastName
            // 
            this.SLastName.DataPropertyName = "SLastName";
            this.SLastName.HeaderText = "Segundo Apellido";
            this.SLastName.Name = "SLastName";
            this.SLastName.ReadOnly = true;
            this.SLastName.Width = 150;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Descuento";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Province
            // 
            this.Province.DataPropertyName = "Province";
            this.Province.HeaderText = "Provincia";
            this.Province.Name = "Province";
            this.Province.ReadOnly = true;
            // 
            // Canton
            // 
            this.Canton.DataPropertyName = "Canton";
            this.Canton.HeaderText = "Canton";
            this.Canton.Name = "Canton";
            this.Canton.ReadOnly = true;
            this.Canton.Visible = false;
            // 
            // District
            // 
            this.District.DataPropertyName = "District";
            this.District.HeaderText = "District";
            this.District.Name = "District";
            this.District.ReadOnly = true;
            this.District.Visible = false;
            // 
            // OtherSigns
            // 
            this.OtherSigns.DataPropertyName = "OthersSigns";
            this.OtherSigns.HeaderText = "OtherSigns";
            this.OtherSigns.Name = "OtherSigns";
            this.OtherSigns.ReadOnly = true;
            this.OtherSigns.Visible = false;
            // 
            // AdmisionDate
            // 
            this.AdmisionDate.DataPropertyName = "AdmissionDate";
            this.AdmisionDate.HeaderText = "AdmisionDate";
            this.AdmisionDate.Name = "AdmisionDate";
            this.AdmisionDate.ReadOnly = true;
            this.AdmisionDate.Visible = false;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "Estado";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
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
            // frmBuscarEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1072, 600);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnBuscar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarEstudiante";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.frmBuscarEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn License;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Province;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canton;
        private System.Windows.Forms.DataGridViewTextBoxColumn District;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherSigns;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdmisionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
    }
}