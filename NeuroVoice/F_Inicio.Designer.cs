namespace NeuroVoice
{
    partial class F_Inicio
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
            this.L_inicio = new System.Windows.Forms.Label();
            this.B_Evaluar = new System.Windows.Forms.Button();
            this.B_Entrenar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_inicio
            // 
            this.L_inicio.AutoSize = true;
            this.L_inicio.Location = new System.Drawing.Point(52, 9);
            this.L_inicio.Name = "L_inicio";
            this.L_inicio.Size = new System.Drawing.Size(107, 13);
            this.L_inicio.TabIndex = 0;
            this.L_inicio.Text = "¿Qué desea realizar?";
            // 
            // B_Evaluar
            // 
            this.B_Evaluar.Location = new System.Drawing.Point(13, 52);
            this.B_Evaluar.Name = "B_Evaluar";
            this.B_Evaluar.Size = new System.Drawing.Size(75, 23);
            this.B_Evaluar.TabIndex = 1;
            this.B_Evaluar.Text = "Evaluar";
            this.B_Evaluar.UseVisualStyleBackColor = true;
            this.B_Evaluar.Click += new System.EventHandler(this.B_Evaluar_Click);
            // 
            // B_Entrenar
            // 
            this.B_Entrenar.Location = new System.Drawing.Point(129, 52);
            this.B_Entrenar.Name = "B_Entrenar";
            this.B_Entrenar.Size = new System.Drawing.Size(75, 23);
            this.B_Entrenar.TabIndex = 2;
            this.B_Entrenar.Text = "Entrenar";
            this.B_Entrenar.UseVisualStyleBackColor = true;
            this.B_Entrenar.Click += new System.EventHandler(this.B_Entrenar_Click);
            // 
            // F_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 87);
            this.Controls.Add(this.B_Entrenar);
            this.Controls.Add(this.B_Evaluar);
            this.Controls.Add(this.L_inicio);
            this.Name = "F_Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FInicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_inicio;
        private System.Windows.Forms.Button B_Evaluar;
        private System.Windows.Forms.Button B_Entrenar;
    }
}