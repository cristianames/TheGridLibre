namespace FrbaCommerce.Historial_Cliente
{
    partial class detalleCompraOferta
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
            this.linkPublicacion = new System.Windows.Forms.LinkLabel();
            this.fecha = new System.Windows.Forms.Label();
            this.precio = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.Label();
            this.gano = new System.Windows.Forms.Label();
            this.compraLink = new System.Windows.Forms.LinkLabel();
            this.calificacionLink = new System.Windows.Forms.LinkLabel();
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
            this.label1.Size = new System.Drawing.Size(215, 11);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descripción de la Publicación:";
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
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(12, 38);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(53, 11);
            this.fecha.TabIndex = 15;
            this.fecha.Text = "Fecha ";
            // 
            // precio
            // 
            this.precio.AutoSize = true;
            this.precio.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio.Location = new System.Drawing.Point(12, 15);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(61, 11);
            this.precio.TabIndex = 16;
            this.precio.Text = "Precio ";
            // 
            // cantidad
            // 
            this.cantidad.AutoSize = true;
            this.cantidad.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidad.Location = new System.Drawing.Point(272, 15);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(85, 11);
            this.cantidad.TabIndex = 17;
            this.cantidad.Text = "Cantidad: ";
            // 
            // gano
            // 
            this.gano.AutoSize = true;
            this.gano.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gano.Location = new System.Drawing.Point(108, 15);
            this.gano.Name = "gano";
            this.gano.Size = new System.Drawing.Size(149, 11);
            this.gano.TabIndex = 18;
            this.gano.Text = "¿Ganó la subasta? ";
            // 
            // compraLink
            // 
            this.compraLink.AutoSize = true;
            this.compraLink.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraLink.LinkColor = System.Drawing.Color.Lime;
            this.compraLink.Location = new System.Drawing.Point(15, 314);
            this.compraLink.Name = "compraLink";
            this.compraLink.Size = new System.Drawing.Size(250, 11);
            this.compraLink.TabIndex = 19;
            this.compraLink.TabStop = true;
            this.compraLink.Text = "Tu oferta tiene asociada una compra";
            this.compraLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // calificacionLink
            // 
            this.calificacionLink.AutoSize = true;
            this.calificacionLink.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calificacionLink.LinkColor = System.Drawing.Color.Lime;
            this.calificacionLink.Location = new System.Drawing.Point(16, 298);
            this.calificacionLink.Name = "calificacionLink";
            this.calificacionLink.Size = new System.Drawing.Size(243, 11);
            this.calificacionLink.TabIndex = 20;
            this.calificacionLink.TabStop = true;
            this.calificacionLink.Text = "Ver la calificación de esta compra";
            this.calificacionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.calificacionLink_LinkClicked);
            // 
            // detalleCompraOferta
            // 
            this.AcceptButton = this.linkPublicacion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(922, 335);
            this.Controls.Add(this.calificacionLink);
            this.Controls.Add(this.compraLink);
            this.Controls.Add(this.gano);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.linkPublicacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.atras);
            this.Name = "detalleCompraOferta";
            this.Text = "Detalle de la Operación";
            this.Load += new System.EventHandler(this.detalleCalificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkPublicacion;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label precio;
        private System.Windows.Forms.Label cantidad;
        private System.Windows.Forms.Label gano;
        private System.Windows.Forms.LinkLabel compraLink;
        private System.Windows.Forms.LinkLabel calificacionLink;
    }
}