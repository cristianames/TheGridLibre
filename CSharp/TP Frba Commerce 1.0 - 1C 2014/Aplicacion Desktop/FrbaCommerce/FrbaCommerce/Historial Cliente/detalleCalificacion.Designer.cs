namespace FrbaCommerce.Historial_Cliente
{
    partial class detalleCalificacion
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
            this.atras = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calificador = new System.Windows.Forms.Label();
            this.estrellas = new System.Windows.Forms.Label();
            this.linkPublicacion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // atras
            // 
            this.atras.BackgroundImage = global::FrbaCommerce.Properties.Resources.Boton_Moderno;
            this.atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.atras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atras.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras.Location = new System.Drawing.Point(324, 300);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 8;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(391, 216);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 11);
            this.label1.TabIndex = 11;
            this.label1.Text = "Detalles de la Calificación:";
            // 
            // calificador
            // 
            this.calificador.AutoSize = true;
            this.calificador.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calificador.Location = new System.Drawing.Point(12, 36);
            this.calificador.Name = "calificador";
            this.calificador.Size = new System.Drawing.Size(131, 11);
            this.calificador.TabIndex = 12;
            this.calificador.Text = "Calificador: GRID_";
            // 
            // estrellas
            // 
            this.estrellas.AutoSize = true;
            this.estrellas.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estrellas.Location = new System.Drawing.Point(258, 55);
            this.estrellas.Name = "estrellas";
            this.estrellas.Size = new System.Drawing.Size(82, 11);
            this.estrellas.TabIndex = 13;
            this.estrellas.Text = "Estrellas: ";
            // 
            // linkPublicacion
            // 
            this.linkPublicacion.AutoSize = true;
            this.linkPublicacion.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPublicacion.LinkColor = System.Drawing.Color.Lime;
            this.linkPublicacion.Location = new System.Drawing.Point(258, 36);
            this.linkPublicacion.Name = "linkPublicacion";
            this.linkPublicacion.Size = new System.Drawing.Size(82, 11);
            this.linkPublicacion.TabIndex = 14;
            this.linkPublicacion.TabStop = true;
            this.linkPublicacion.Text = "Publicación";
            this.linkPublicacion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPublicacion_LinkClicked);
            // 
            // detalleCalificacion
            // 
            this.AcceptButton = this.linkPublicacion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(922, 335);
            this.Controls.Add(this.linkPublicacion);
            this.Controls.Add(this.estrellas);
            this.Controls.Add(this.calificador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.atras);
            this.Name = "detalleCalificacion";
            this.Text = "Detalle de la Calificación";
            this.Load += new System.EventHandler(this.detalleCalificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label calificador;
        private System.Windows.Forms.Label estrellas;
        private System.Windows.Forms.LinkLabel linkPublicacion;
    }
}