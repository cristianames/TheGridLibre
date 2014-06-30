namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FormularioRespuesta
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
            this.textoPregunta = new System.Windows.Forms.RichTextBox();
            this.textoRespuesta = new System.Windows.Forms.RichTextBox();
            this.botonResponder = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.codPublicacion = new System.Windows.Forms.Label();
            this.descripcionPublicacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textoPregunta
            // 
            this.textoPregunta.Location = new System.Drawing.Point(35, 44);
            this.textoPregunta.Name = "textoPregunta";
            this.textoPregunta.Size = new System.Drawing.Size(413, 98);
            this.textoPregunta.TabIndex = 0;
            this.textoPregunta.Text = "";
            // 
            // textoRespuesta
            // 
            this.textoRespuesta.Location = new System.Drawing.Point(35, 148);
            this.textoRespuesta.Name = "textoRespuesta";
            this.textoRespuesta.Size = new System.Drawing.Size(413, 97);
            this.textoRespuesta.TabIndex = 1;
            this.textoRespuesta.Text = "";
            // 
            // botonResponder
            // 
            this.botonResponder.Location = new System.Drawing.Point(468, 148);
            this.botonResponder.Name = "botonResponder";
            this.botonResponder.Size = new System.Drawing.Size(91, 57);
            this.botonResponder.TabIndex = 2;
            this.botonResponder.Text = "Responder";
            this.botonResponder.UseVisualStyleBackColor = true;
            // 
            // botonAtras
            // 
            this.botonAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonAtras.Location = new System.Drawing.Point(468, 222);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(91, 23);
            this.botonAtras.TabIndex = 3;
            this.botonAtras.Text = "Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // codPublicacion
            // 
            this.codPublicacion.AutoSize = true;
            this.codPublicacion.Location = new System.Drawing.Point(35, 13);
            this.codPublicacion.Name = "codPublicacion";
            this.codPublicacion.Size = new System.Drawing.Size(80, 13);
            this.codPublicacion.TabIndex = 4;
            this.codPublicacion.Text = "codPublicacion";
            // 
            // descripcionPublicacion
            // 
            this.descripcionPublicacion.AutoSize = true;
            this.descripcionPublicacion.Location = new System.Drawing.Point(166, 13);
            this.descripcionPublicacion.Name = "descripcionPublicacion";
            this.descripcionPublicacion.Size = new System.Drawing.Size(116, 13);
            this.descripcionPublicacion.TabIndex = 5;
            this.descripcionPublicacion.Text = "descripcionPublicacion";
            // 
            // FormularioRespuesta
            // 
            this.AcceptButton = this.botonResponder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonAtras;
            this.ClientSize = new System.Drawing.Size(844, 513);
            this.Controls.Add(this.descripcionPublicacion);
            this.Controls.Add(this.codPublicacion);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonResponder);
            this.Controls.Add(this.textoRespuesta);
            this.Controls.Add(this.textoPregunta);
            this.Name = "FormularioRespuesta";
            this.Text = "FormularioRespuesta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textoPregunta;
        private System.Windows.Forms.RichTextBox textoRespuesta;
        private System.Windows.Forms.Button botonResponder;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.Label codPublicacion;
        private System.Windows.Forms.Label descripcionPublicacion;
    }
}