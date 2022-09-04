
namespace Interfaz
{
    partial class frmHabilitarPeriodoMatricula
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
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.npdPeriodo = new System.Windows.Forms.NumericUpDown();
            this.rbtNextYear = new System.Windows.Forms.RadioButton();
            this.rbtActualYear = new System.Windows.Forms.RadioButton();
            this.chkHabilitar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtMontoMatri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMontoMatri);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIVA);
            this.groupBox1.Controls.Add(this.npdPeriodo);
            this.groupBox1.Controls.Add(this.rbtNextYear);
            this.groupBox1.Controls.Add(this.rbtActualYear);
            this.groupBox1.Controls.Add(this.chkHabilitar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matrícula";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(265, 159);
            this.txtIVA.MaxLength = 2;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(100, 26);
            this.txtIVA.TabIndex = 8;
            // 
            // npdPeriodo
            // 
            this.npdPeriodo.Location = new System.Drawing.Point(265, 116);
            this.npdPeriodo.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.npdPeriodo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npdPeriodo.Name = "npdPeriodo";
            this.npdPeriodo.Size = new System.Drawing.Size(120, 26);
            this.npdPeriodo.TabIndex = 7;
            this.npdPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npdPeriodo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtNextYear
            // 
            this.rbtNextYear.AutoSize = true;
            this.rbtNextYear.Location = new System.Drawing.Point(390, 65);
            this.rbtNextYear.Name = "rbtNextYear";
            this.rbtNextYear.Size = new System.Drawing.Size(14, 13);
            this.rbtNextYear.TabIndex = 6;
            this.rbtNextYear.TabStop = true;
            this.rbtNextYear.UseVisualStyleBackColor = true;
            // 
            // rbtActualYear
            // 
            this.rbtActualYear.AutoSize = true;
            this.rbtActualYear.Location = new System.Drawing.Point(265, 65);
            this.rbtActualYear.Name = "rbtActualYear";
            this.rbtActualYear.Size = new System.Drawing.Size(14, 13);
            this.rbtActualYear.TabIndex = 5;
            this.rbtActualYear.TabStop = true;
            this.rbtActualYear.UseVisualStyleBackColor = true;
            // 
            // chkHabilitar
            // 
            this.chkHabilitar.AutoSize = true;
            this.chkHabilitar.Location = new System.Drawing.Point(265, 22);
            this.chkHabilitar.Name = "chkHabilitar";
            this.chkHabilitar.Size = new System.Drawing.Size(15, 14);
            this.chkHabilitar.TabIndex = 4;
            this.chkHabilitar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Periodo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "I.V.A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Habilitar:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(443, 285);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(102, 35);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtMontoMatri
            // 
            this.txtMontoMatri.Location = new System.Drawing.Point(265, 200);
            this.txtMontoMatri.MaxLength = 12;
            this.txtMontoMatri.Name = "txtMontoMatri";
            this.txtMontoMatri.Size = new System.Drawing.Size(151, 26);
            this.txtMontoMatri.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Monto Matrícula:";
            // 
            // frmHabilitarPeriodoMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmHabilitarPeriodoMatricula";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Periodo Matricula";
            this.Load += new System.EventHandler(this.frmHabilitarPeriodoMatricula_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npdPeriodo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.NumericUpDown npdPeriodo;
        private System.Windows.Forms.RadioButton rbtNextYear;
        private System.Windows.Forms.RadioButton rbtActualYear;
        private System.Windows.Forms.CheckBox chkHabilitar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtMontoMatri;
        private System.Windows.Forms.Label label5;
    }
}