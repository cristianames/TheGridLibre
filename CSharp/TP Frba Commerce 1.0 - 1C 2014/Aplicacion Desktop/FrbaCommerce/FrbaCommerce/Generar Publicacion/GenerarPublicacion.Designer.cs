namespace FrbaCommerce.Generar_Publicacion
{
    partial class GenerarPublicacion
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
            this.radioCompra = new System.Windows.Forms.RadioButton();
            this.radioSubasta = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtRubro = new System.Windows.Forms.Button();
            this.groupBoxVisibilidad = new System.Windows.Forms.GroupBox();
            this.labelInicio = new System.Windows.Forms.Label();
            this.labelPrecioPublicar = new System.Windows.Forms.Label();
            this.labelComision = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.botonBorrador = new System.Windows.Forms.Button();
            this.botonPublicar = new System.Windows.Forms.Button();
            this.botonRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxVisibilidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCompra
            // 
            this.radioCompra.AutoSize = true;
            this.radioCompra.Checked = true;
            this.radioCompra.Location = new System.Drawing.Point(203, 35);
            this.radioCompra.Name = "radioCompra";
            this.radioCompra.Size = new System.Drawing.Size(133, 17);
            this.radioCompra.TabIndex = 0;
            this.radioCompra.TabStop = true;
            this.radioCompra.Text = "Compra Inmediata";
            this.radioCompra.UseVisualStyleBackColor = true;
            this.radioCompra.CheckedChanged += new System.EventHandler(this.radioCompra_CheckedChanged);
            // 
            // radioSubasta
            // 
            this.radioSubasta.AutoSize = true;
            this.radioSubasta.Location = new System.Drawing.Point(358, 35);
            this.radioSubasta.Name = "radioSubasta";
            this.radioSubasta.Size = new System.Drawing.Size(71, 17);
            this.radioSubasta.TabIndex = 1;
            this.radioSubasta.Text = "Subasta";
            this.radioSubasta.UseVisualStyleBackColor = true;
            this.radioSubasta.CheckedChanged += new System.EventHandler(this.radioSubasta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de publicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion del articulo:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(414, 117);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(12, 233);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(47, 13);
            this.labelPrecio.TabIndex = 6;
            this.labelPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(329, 233);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 21);
            this.txtPrecio.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Visibilidad:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(308, 306);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stock:";
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Location = new System.Drawing.Point(6, 33);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(136, 13);
            this.labelVencimiento.TabIndex = 12;
            this.labelVencimiento.Text = "Fecha de vencimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Preguntas";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboBox2.Location = new System.Drawing.Point(308, 351);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(309, 267);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 17;
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(15, 396);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(145, 23);
            this.txtRubro.TabIndex = 18;
            this.txtRubro.Text = "Seleccionar rubros";
            this.txtRubro.UseVisualStyleBackColor = true;
            // 
            // groupBoxVisibilidad
            // 
            this.groupBoxVisibilidad.Controls.Add(this.labelComision);
            this.groupBoxVisibilidad.Controls.Add(this.labelPrecioPublicar);
            this.groupBoxVisibilidad.Controls.Add(this.labelInicio);
            this.groupBoxVisibilidad.Controls.Add(this.labelVencimiento);
            this.groupBoxVisibilidad.Location = new System.Drawing.Point(15, 458);
            this.groupBoxVisibilidad.Name = "groupBoxVisibilidad";
            this.groupBoxVisibilidad.Size = new System.Drawing.Size(414, 137);
            this.groupBoxVisibilidad.TabIndex = 19;
            this.groupBoxVisibilidad.TabStop = false;
            this.groupBoxVisibilidad.Text = "Datos Visibilidad";
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(6, 62);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(96, 13);
            this.labelInicio.TabIndex = 14;
            this.labelInicio.Text = "Fecha de inicio:";
            // 
            // labelPrecioPublicar
            // 
            this.labelPrecioPublicar.AutoSize = true;
            this.labelPrecioPublicar.Location = new System.Drawing.Point(6, 89);
            this.labelPrecioPublicar.Name = "labelPrecioPublicar";
            this.labelPrecioPublicar.Size = new System.Drawing.Size(119, 13);
            this.labelPrecioPublicar.TabIndex = 15;
            this.labelPrecioPublicar.Text = "Precio por publicar:";
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.Location = new System.Drawing.Point(6, 111);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(145, 13);
            this.labelComision.TabIndex = 16;
            this.labelComision.Text = "Porcentaje de comision:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(229, 397);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 21);
            this.textBox1.TabIndex = 20;
            // 
            // botonBorrador
            // 
            this.botonBorrador.Location = new System.Drawing.Point(261, 601);
            this.botonBorrador.Name = "botonBorrador";
            this.botonBorrador.Size = new System.Drawing.Size(75, 42);
            this.botonBorrador.TabIndex = 21;
            this.botonBorrador.Text = "Guardar borrador";
            this.botonBorrador.UseVisualStyleBackColor = true;
            // 
            // botonPublicar
            // 
            this.botonPublicar.Location = new System.Drawing.Point(354, 601);
            this.botonPublicar.Name = "botonPublicar";
            this.botonPublicar.Size = new System.Drawing.Size(75, 42);
            this.botonPublicar.TabIndex = 22;
            this.botonPublicar.Text = "Publicar";
            this.botonPublicar.UseVisualStyleBackColor = true;
            // 
            // botonRegresar
            // 
            this.botonRegresar.Location = new System.Drawing.Point(24, 601);
            this.botonRegresar.Name = "botonRegresar";
            this.botonRegresar.Size = new System.Drawing.Size(75, 41);
            this.botonRegresar.TabIndex = 23;
            this.botonRegresar.Text = "Regresar";
            this.botonRegresar.UseVisualStyleBackColor = true;
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 655);
            this.Controls.Add(this.botonRegresar);
            this.Controls.Add(this.botonPublicar);
            this.Controls.Add(this.botonBorrador);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBoxVisibilidad);
            this.Controls.Add(this.txtRubro);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioSubasta);
            this.Controls.Add(this.radioCompra);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxVisibilidad.ResumeLayout(false);
            this.groupBoxVisibilidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCompra;
        private System.Windows.Forms.RadioButton radioSubasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button txtRubro;
        private System.Windows.Forms.GroupBox groupBoxVisibilidad;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Label labelComision;
        private System.Windows.Forms.Label labelPrecioPublicar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button botonBorrador;
        private System.Windows.Forms.Button botonPublicar;
        private System.Windows.Forms.Button botonRegresar;

    }
}