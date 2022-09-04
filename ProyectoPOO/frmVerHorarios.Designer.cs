
namespace Interfaz
{
    partial class frmVerHorarios
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
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).BeginInit();
            this.SuspendLayout();
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
            this.Exists,
            this.Dia,
            this.HoraInicio,
            this.HoraFin});
            this.grdLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLista.Location = new System.Drawing.Point(12, 12);
            this.grdLista.Name = "grdLista";
            this.grdLista.ReadOnly = true;
            this.grdLista.RowTemplate.Height = 25;
            this.grdLista.Size = new System.Drawing.Size(644, 294);
            this.grdLista.TabIndex = 0;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "OpenSubjectCode";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // Exists
            // 
            this.Exists.DataPropertyName = "Exists";
            this.Exists.HeaderText = "Exists";
            this.Exists.Name = "Exists";
            this.Exists.ReadOnly = true;
            this.Exists.Visible = false;
            // 
            // Dia
            // 
            this.Dia.DataPropertyName = "Dia";
            this.Dia.HeaderText = "Día";
            this.Dia.Name = "Dia";
            this.Dia.ReadOnly = true;
            this.Dia.Width = 200;
            // 
            // HoraInicio
            // 
            this.HoraInicio.DataPropertyName = "StartTime";
            this.HoraInicio.HeaderText = "Inicio";
            this.HoraInicio.Name = "HoraInicio";
            this.HoraInicio.ReadOnly = true;
            this.HoraInicio.Width = 200;
            // 
            // HoraFin
            // 
            this.HoraFin.DataPropertyName = "EndTime";
            this.HoraFin.HeaderText = "Fin";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.ReadOnly = true;
            this.HoraFin.Width = 200;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(491, 312);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 38);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmVerHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(671, 362);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grdLista);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmVerHorarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.frmVerHorarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exists;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.Button btnEliminar;
    }
}