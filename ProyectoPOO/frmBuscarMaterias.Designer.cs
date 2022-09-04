
namespace Interfaz
{
    partial class frmBuscarMaterias
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grdLista = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::Interfaz.Properties.Resources.magnifier_1_icon_icons_com_56924;
            this.button1.Location = new System.Drawing.Point(452, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 48);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(311, 443);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 32);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(404, 443);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
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
            this.Code,
            this.NameM,
            this.Credits,
            this.Erased,
            this.Exists});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(12, 94);
            this.grdLista.Name = "grdLista";
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(495, 333);
            this.grdLista.TabIndex = 4;
            this.grdLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLista_CellDoubleClick);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(82, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 26);
            this.txtNombre.TabIndex = 5;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Width = 150;
            // 
            // NameM
            // 
            this.NameM.DataPropertyName = "Name";
            this.NameM.HeaderText = "Nombre";
            this.NameM.Name = "NameM";
            this.NameM.Width = 200;
            // 
            // Credits
            // 
            this.Credits.DataPropertyName = "Credits";
            this.Credits.HeaderText = "Créditos";
            this.Credits.Name = "Credits";
            // 
            // Erased
            // 
            this.Erased.DataPropertyName = "Erased";
            this.Erased.HeaderText = "Erased";
            this.Erased.Name = "Erased";
            this.Erased.Visible = false;
            // 
            // Exists
            // 
            this.Exists.DataPropertyName = "Exists";
            this.Exists.HeaderText = "Exists";
            this.Exists.Name = "Exists";
            this.Exists.Visible = false;
            // 
            // frmBuscarMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(522, 496);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBuscarMaterias";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Materias";
            this.Load += new System.EventHandler(this.frmBuscarMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
    }
}