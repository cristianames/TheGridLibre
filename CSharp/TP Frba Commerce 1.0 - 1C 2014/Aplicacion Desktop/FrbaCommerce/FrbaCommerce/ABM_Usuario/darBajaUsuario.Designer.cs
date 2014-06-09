namespace FrbaCommerce.ABM_Usuario
{
    partial class asegurarBorrado
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
            this.labelPregunta = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonProceder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPregunta
            // 
            this.labelPregunta.AutoSize = true;
            this.labelPregunta.Location = new System.Drawing.Point(69, 19);
            this.labelPregunta.Name = "labelPregunta";
            this.labelPregunta.Size = new System.Drawing.Size(89, 13);
            this.labelPregunta.TabIndex = 0;
            this.labelPregunta.Text = "label de pregunta";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(35, 50);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonProceder
            // 
            this.buttonProceder.Location = new System.Drawing.Point(127, 50);
            this.buttonProceder.Name = "buttonProceder";
            this.buttonProceder.Size = new System.Drawing.Size(75, 23);
            this.buttonProceder.TabIndex = 2;
            this.buttonProceder.Text = "Proceder";
            this.buttonProceder.UseVisualStyleBackColor = true;
            // 
            // asegurarBorrado
            // 
            this.AcceptButton = this.buttonCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 447);
            this.Controls.Add(this.buttonProceder);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelPregunta);
            this.Name = "asegurarBorrado";
            this.Text = "Seguro?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPregunta;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonProceder;
    }
}