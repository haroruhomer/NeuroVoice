namespace NeuroVoice
{
    partial class F_Evaluar
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Evaluar));
            this.label1 = new System.Windows.Forms.Label();
            this.L_Examinar = new System.Windows.Forms.Label();
            this.B_Examinar = new System.Windows.Forms.Button();
            this.L_Archivo = new System.Windows.Forms.Label();
            this.WMP_Reproductor = new AxWMPLib.AxWindowsMediaPlayer();
            this.B_Reconocer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WMP_Reproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "EVALUACIÓN";
            // 
            // L_Examinar
            // 
            this.L_Examinar.AutoSize = true;
            this.L_Examinar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Examinar.Location = new System.Drawing.Point(12, 68);
            this.L_Examinar.Name = "L_Examinar";
            this.L_Examinar.Size = new System.Drawing.Size(121, 13);
            this.L_Examinar.TabIndex = 1;
            this.L_Examinar.Text = "Seleccione Archivo:";
            // 
            // B_Examinar
            // 
            this.B_Examinar.Location = new System.Drawing.Point(139, 63);
            this.B_Examinar.Name = "B_Examinar";
            this.B_Examinar.Size = new System.Drawing.Size(75, 23);
            this.B_Examinar.TabIndex = 2;
            this.B_Examinar.Text = "Examinar...";
            this.B_Examinar.UseVisualStyleBackColor = true;
            this.B_Examinar.Click += new System.EventHandler(this.B_Examinar_Click);
            // 
            // L_Archivo
            // 
            this.L_Archivo.AutoSize = true;
            this.L_Archivo.Location = new System.Drawing.Point(12, 95);
            this.L_Archivo.Name = "L_Archivo";
            this.L_Archivo.Size = new System.Drawing.Size(60, 13);
            this.L_Archivo.TabIndex = 3;
            this.L_Archivo.Text = "Sin archivo";
            this.L_Archivo.Visible = false;
            // 
            // WMP_Reproductor
            // 
            this.WMP_Reproductor.AllowDrop = true;
            this.WMP_Reproductor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WMP_Reproductor.Enabled = true;
            this.WMP_Reproductor.Location = new System.Drawing.Point(0, 215);
            this.WMP_Reproductor.Name = "WMP_Reproductor";
            this.WMP_Reproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP_Reproductor.OcxState")));
            this.WMP_Reproductor.Size = new System.Drawing.Size(291, 47);
            this.WMP_Reproductor.TabIndex = 4;
            this.WMP_Reproductor.Visible = false;
            // 
            // B_Reconocer
            // 
            this.B_Reconocer.Location = new System.Drawing.Point(99, 186);
            this.B_Reconocer.Name = "B_Reconocer";
            this.B_Reconocer.Size = new System.Drawing.Size(75, 23);
            this.B_Reconocer.TabIndex = 5;
            this.B_Reconocer.Text = "Reconocer";
            this.B_Reconocer.UseVisualStyleBackColor = true;
            this.B_Reconocer.Visible = false;
            this.B_Reconocer.Click += new System.EventHandler(this.B_Reconocer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "L";
            // 
            // F_Evaluar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.B_Reconocer);
            this.Controls.Add(this.WMP_Reproductor);
            this.Controls.Add(this.L_Archivo);
            this.Controls.Add(this.B_Examinar);
            this.Controls.Add(this.L_Examinar);
            this.Controls.Add(this.label1);
            this.Name = "F_Evaluar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluación";
            this.Load += new System.EventHandler(this.F_Evaluar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WMP_Reproductor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_Examinar;
        private System.Windows.Forms.Button B_Examinar;
        private System.Windows.Forms.Label L_Archivo;
        private AxWMPLib.AxWindowsMediaPlayer WMP_Reproductor;
        private System.Windows.Forms.Button B_Reconocer;
        private System.Windows.Forms.Label label2;

    }
}

