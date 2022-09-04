
namespace ProyectoPOO
{
    partial class frmMantenimientoAulas
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
            this.nudNumAula = new System.Windows.Forms.NumericUpDown();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.nudCapacidad = new System.Windows.Forms.NumericUpDown();
            this.txtCodigoAula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumAula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudNumAula);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Controls.Add(this.nudCapacidad);
            this.groupBox1.Controls.Add(this.txtCodigoAula);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(586, 110);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Aula";
            // 
            // nudNumAula
            // 
            this.nudNumAula.Location = new System.Drawing.Point(95, 71);
            this.nudNumAula.Margin = new System.Windows.Forms.Padding(4);
            this.nudNumAula.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumAula.Name = "nudNumAula";
            this.nudNumAula.Size = new System.Drawing.Size(95, 26);
            this.nudNumAula.TabIndex = 39;
            this.nudNumAula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNumAula.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboTipo
            // 
            this.cboTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "Taller",
            "Laboratorio",
            "Salón"});
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Taller",
            "Laboratorio",
            "Salón"});
            this.cboTipo.Location = new System.Drawing.Point(364, 26);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(154, 28);
            this.cboTipo.TabIndex = 38;
            // 
            // nudCapacidad
            // 
            this.nudCapacidad.Location = new System.Drawing.Point(300, 71);
            this.nudCapacidad.Margin = new System.Windows.Forms.Padding(4);
            this.nudCapacidad.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudCapacidad.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCapacidad.Name = "nudCapacidad";
            this.nudCapacidad.Size = new System.Drawing.Size(63, 26);
            this.nudCapacidad.TabIndex = 37;
            this.nudCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCapacidad.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtCodigoAula
            // 
            this.txtCodigoAula.Location = new System.Drawing.Point(95, 26);
            this.txtCodigoAula.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoAula.Name = "txtCodigoAula";
            this.txtCodigoAula.ReadOnly = true;
            this.txtCodigoAula.Size = new System.Drawing.Size(197, 26);
            this.txtCodigoAula.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Número:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Capacidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Tipo:";
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarCodigo.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(471, 138);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(47, 50);
            this.btnBuscarCodigo.TabIndex = 23;
            this.btnBuscarCodigo.UseVisualStyleBackColor = false;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(471, 546);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 29);
            this.btnEliminar.TabIndex = 46;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(371, 545);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 45;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(269, 545);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(92, 30);
            this.btnRegistrar.TabIndex = 44;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // grdLista
            // 
            this.grdLista.AllowUserToAddRows = false;
            this.grdLista.AllowUserToDeleteRows = false;
            this.grdLista.AllowUserToResizeColumns = false;
            this.grdLista.AllowUserToResizeRows = false;
            this.grdLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Tipo,
            this.Numero,
            this.Capacidad,
            this.Existe});
            this.grdLista.Location = new System.Drawing.Point(26, 195);
            this.grdLista.Name = "grdLista";
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(546, 343);
            this.grdLista.TabIndex = 47;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 200;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            // 
            // Capacidad
            // 
            this.Capacidad.DataPropertyName = "Capacidad";
            this.Capacidad.HeaderText = "Capacidad";
            this.Capacidad.Name = "Capacidad";
            // 
            // Existe
            // 
            this.Existe.DataPropertyName = "Existe";
            this.Existe.HeaderText = "Existe";
            this.Existe.Name = "Existe";
            this.Existe.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "Tipo:";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(110, 150);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(354, 26);
            this.txtTipo.TabIndex = 49;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(170, 546);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(91, 29);
            this.btnLimpiar.TabIndex = 50;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmMantenimientoAulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(618, 603);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscarCodigo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoAulas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aulas";
            this.Load += new System.EventHandler(this.frmMantenimientoAulas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumAula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudCapacidad;
        private System.Windows.Forms.TextBox txtCodigoAula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.NumericUpDown nudNumAula;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Button btnLimpiar;
    }
}