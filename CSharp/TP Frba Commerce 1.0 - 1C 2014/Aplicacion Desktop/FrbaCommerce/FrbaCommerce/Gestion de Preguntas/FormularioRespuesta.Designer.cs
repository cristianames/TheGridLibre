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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioRespuesta));
            this.textoPregunta = new System.Windows.Forms.RichTextBox();
            this.textoRespuesta = new System.Windows.Forms.RichTextBox();
            this.botonResponder = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.linkPublicacion = new System.Windows.Forms.LinkLabel();
            this.infoRespuesta = new System.Windows.Forms.Label();
            this.labelRespuesta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textoPregunta
            // 
            this.textoPregunta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPregunta.Location = new System.Drawing.Point(14, 36);
            this.textoPregunta.Name = "textoPregunta";
            this.textoPregunta.ReadOnly = true;
            this.textoPregunta.Size = new System.Drawing.Size(413, 64);
            this.textoPregunta.TabIndex = 0;
            this.textoPregunta.Text = "";
            // 
            // textoRespuesta
            // 
            this.textoRespuesta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoRespuesta.Location = new System.Drawing.Point(14, 146);
            this.textoRespuesta.MaxLength = 255;
            this.textoRespuesta.Name = "textoRespuesta";
            this.textoRespuesta.Size = new System.Drawing.Size(413, 64);
            this.textoRespuesta.TabIndex = 1;
            this.textoRespuesta.Text = "";
            // 
            // botonResponder
            // 
            this.botonResponder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonResponder.BackgroundImage")));
            this.botonResponder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonResponder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonResponder.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonResponder.Location = new System.Drawing.Point(334, 226);
            this.botonResponder.Name = "botonResponder";
            this.botonResponder.Size = new System.Drawing.Size(91, 23);
            this.botonResponder.TabIndex = 2;
            this.botonResponder.Text = "Responder";
            this.botonResponder.UseVisualStyleBackColor = true;
            this.botonResponder.Click += new System.EventHandler(this.botonResponder_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonAtras.BackgroundImage")));
            this.botonAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAtras.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAtras.Location = new System.Drawing.Point(17, 226);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(91, 23);
            this.botonAtras.TabIndex = 3;
            this.botonAtras.Text = "Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // linkPublicacion
            // 
            this.linkPublicacion.AutoSize = true;
            this.linkPublicacion.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPublicacion.LinkColor = System.Drawing.Color.Lime;
            this.linkPublicacion.Location = new System.Drawing.Point(248, 9);
            this.linkPublicacion.Name = "linkPublicacion";
            this.linkPublicacion.Size = new System.Drawing.Size(173, 11);
            this.linkPublicacion.TabIndex = 4;
            this.linkPublicacion.TabStop = true;
            this.linkPublicacion.Text = "Mira aqui la publicación";
            this.linkPublicacion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPublicacion_LinkClicked);
            // 
            // infoRespuesta
            // 
            this.infoRespuesta.AutoSize = true;
            this.infoRespuesta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoRespuesta.Location = new System.Drawing.Point(248, 122);
            this.infoRespuesta.Name = "infoRespuesta";
            this.infoRespuesta.Size = new System.Drawing.Size(173, 11);
            this.infoRespuesta.TabIndex = 5;
            this.infoRespuesta.Text = "Límite de 255 caracteres";
            // 
            // labelRespuesta
            // 
            this.labelRespuesta.AutoSize = true;
            this.labelRespuesta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRespuesta.Location = new System.Drawing.Point(14, 122);
            this.labelRespuesta.Name = "labelRespuesta";
            this.labelRespuesta.Size = new System.Drawing.Size(68, 11);
            this.labelRespuesta.TabIndex = 6;
            this.labelRespuesta.Text = "Respuesta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 11);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pregunta";
            // 
            // FormularioRespuesta
            // 
            this.AcceptButton = this.botonResponder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.botonAtras;
            this.ClientSize = new System.Drawing.Size(863, 513);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRespuesta);
            this.Controls.Add(this.infoRespuesta);
            this.Controls.Add(this.linkPublicacion);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonResponder);
            this.Controls.Add(this.textoRespuesta);
            this.Controls.Add(this.textoPregunta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioRespuesta";
            this.ShowIcon = false;
            this.Text = "Formulario de Respuestas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textoPregunta;
        private System.Windows.Forms.RichTextBox textoRespuesta;
        private System.Windows.Forms.Button botonResponder;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.LinkLabel linkPublicacion;
        private System.Windows.Forms.Label infoRespuesta;
        private System.Windows.Forms.Label labelRespuesta;
        private System.Windows.Forms.Label label2;
    }
}