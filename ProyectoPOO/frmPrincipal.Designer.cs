
namespace ProyectoPOO
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMateriaCarrera = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMatricular = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCarreras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEstudiantes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProfesores = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarPeriodoMatrículaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.mantenimientoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitarPeriodoMatrículaToolStripMenuItem,
            this.tsmiMateriaCarrera,
            this.abrirMateriaToolStripMenuItem,
            this.tsmiMatricular,
            this.tsmiSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // tsmiMateriaCarrera
            // 
            this.tsmiMateriaCarrera.Name = "tsmiMateriaCarrera";
            this.tsmiMateriaCarrera.Size = new System.Drawing.Size(216, 22);
            this.tsmiMateriaCarrera.Text = "Agregar Materia a Carrera";
            this.tsmiMateriaCarrera.Click += new System.EventHandler(this.tsmiMateriaCarrera_Click);
            // 
            // abrirMateriaToolStripMenuItem
            // 
            this.abrirMateriaToolStripMenuItem.Name = "abrirMateriaToolStripMenuItem";
            this.abrirMateriaToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.abrirMateriaToolStripMenuItem.Text = "Abrir Materia";
            this.abrirMateriaToolStripMenuItem.Click += new System.EventHandler(this.abrirMateriaToolStripMenuItem_Click);
            // 
            // tsmiMatricular
            // 
            this.tsmiMatricular.Name = "tsmiMatricular";
            this.tsmiMatricular.Size = new System.Drawing.Size(216, 22);
            this.tsmiMatricular.Text = "Matricular";
            this.tsmiMatricular.Click += new System.EventHandler(this.tsmiMatricular_Click);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(216, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aulasToolStripMenuItem,
            this.tsmiCarreras,
            this.tsmiEstudiantes,
            this.tsmiMaterias,
            this.tsmiProfesores});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // aulasToolStripMenuItem
            // 
            this.aulasToolStripMenuItem.Name = "aulasToolStripMenuItem";
            this.aulasToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aulasToolStripMenuItem.Text = "Aulas";
            this.aulasToolStripMenuItem.Click += new System.EventHandler(this.aulasToolStripMenuItem_Click);
            // 
            // tsmiCarreras
            // 
            this.tsmiCarreras.Name = "tsmiCarreras";
            this.tsmiCarreras.Size = new System.Drawing.Size(134, 22);
            this.tsmiCarreras.Text = "Carreras";
            this.tsmiCarreras.Click += new System.EventHandler(this.tsmiCarreras_Click);
            // 
            // tsmiEstudiantes
            // 
            this.tsmiEstudiantes.Name = "tsmiEstudiantes";
            this.tsmiEstudiantes.Size = new System.Drawing.Size(134, 22);
            this.tsmiEstudiantes.Text = "Estudiantes";
            this.tsmiEstudiantes.Click += new System.EventHandler(this.tsmiEstudiantes_Click);
            // 
            // tsmiMaterias
            // 
            this.tsmiMaterias.Name = "tsmiMaterias";
            this.tsmiMaterias.Size = new System.Drawing.Size(134, 22);
            this.tsmiMaterias.Text = "Materias";
            this.tsmiMaterias.Click += new System.EventHandler(this.tsmiMaterias_Click);
            // 
            // tsmiProfesores
            // 
            this.tsmiProfesores.Name = "tsmiProfesores";
            this.tsmiProfesores.Size = new System.Drawing.Size(134, 22);
            this.tsmiProfesores.Text = "Profesores";
            this.tsmiProfesores.Click += new System.EventHandler(this.tsmiProfesores_Click);
            // 
            // habilitarPeriodoMatrículaToolStripMenuItem
            // 
            this.habilitarPeriodoMatrículaToolStripMenuItem.Name = "habilitarPeriodoMatrículaToolStripMenuItem";
            this.habilitarPeriodoMatrículaToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.habilitarPeriodoMatrículaToolStripMenuItem.Text = "Habilitar Periodo Matrícula";
            this.habilitarPeriodoMatrículaToolStripMenuItem.Click += new System.EventHandler(this.habilitarPeriodoMatrículaToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiMatricular;
        private System.Windows.Forms.ToolStripMenuItem tsmiMateriaCarrera;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEstudiantes;
        private System.Windows.Forms.ToolStripMenuItem tsmiCarreras;
        private System.Windows.Forms.ToolStripMenuItem tsmiProfesores;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem aulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitarPeriodoMatrículaToolStripMenuItem;
    }
}

