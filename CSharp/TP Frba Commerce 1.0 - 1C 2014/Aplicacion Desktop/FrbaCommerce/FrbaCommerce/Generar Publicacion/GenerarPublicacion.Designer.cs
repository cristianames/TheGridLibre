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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarPublicacion));
            this.radioCompra = new System.Windows.Forms.RadioButton();
            this.radioSubasta = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.visibilidadComboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.preguntasComboBox = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtRubro = new System.Windows.Forms.Button();
            this.groupBoxVisibilidad = new System.Windows.Forms.GroupBox();
            this.labelComision = new System.Windows.Forms.Label();
            this.labelPrecioPublicar = new System.Windows.Forms.Label();
            this.labelInicio = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.botonBorrador = new System.Windows.Forms.Button();
            this.botonPublicar = new System.Windows.Forms.Button();
            this.botonRegresar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelActivas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxVisibilidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCompra
            // 
            this.radioCompra.AutoSize = true;
            this.radioCompra.Checked = true;
            this.radioCompra.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCompra.Location = new System.Drawing.Point(292, 45);
            this.radioCompra.Name = "radioCompra";
            this.radioCompra.Size = new System.Drawing.Size(135, 15);
            this.radioCompra.TabIndex = 0;
            this.radioCompra.TabStop = true;
            this.radioCompra.Text = "Compra Inmediata";
            this.radioCompra.UseVisualStyleBackColor = true;
            this.radioCompra.CheckedChanged += new System.EventHandler(this.radioCompra_CheckedChanged);
            // 
            // radioSubasta
            // 
            this.radioSubasta.AutoSize = true;
            this.radioSubasta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSubasta.Location = new System.Drawing.Point(292, 23);
            this.radioSubasta.Name = "radioSubasta";
            this.radioSubasta.Size = new System.Drawing.Size(72, 15);
            this.radioSubasta.TabIndex = 1;
            this.radioSubasta.Text = "Subasta";
            this.radioSubasta.UseVisualStyleBackColor = true;
            this.radioSubasta.CheckedChanged += new System.EventHandler(this.radioSubasta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 11);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de publicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 11);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion del articulo:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(15, 66);
            this.richTextBox1.MaxLength = 255;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(413, 100);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecio.Location = new System.Drawing.Point(6, 178);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(96, 11);
            this.labelPrecio.TabIndex = 6;
            this.labelPrecio.Text = "Precio unit.:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(129, 176);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(74, 18);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 11);
            this.label3.TabIndex = 8;
            this.label3.Text = "Visibilidad:";
            // 
            // visibilidadComboBox1
            // 
            this.visibilidadComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visibilidadComboBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visibilidadComboBox1.FormattingEnabled = true;
            this.visibilidadComboBox1.Location = new System.Drawing.Point(306, 175);
            this.visibilidadComboBox1.Name = "visibilidadComboBox1";
            this.visibilidadComboBox1.Size = new System.Drawing.Size(121, 19);
            this.visibilidadComboBox1.TabIndex = 9;
            this.visibilidadComboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 11);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stock:";
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Location = new System.Drawing.Point(25, 39);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(152, 11);
            this.labelVencimiento.TabIndex = 12;
            this.labelVencimiento.Text = "Fecha de vencimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(210, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 11);
            this.label6.TabIndex = 14;
            this.label6.Text = "Preguntas";
            // 
            // preguntasComboBox
            // 
            this.preguntasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preguntasComboBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preguntasComboBox.FormattingEnabled = true;
            this.preguntasComboBox.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.preguntasComboBox.Location = new System.Drawing.Point(306, 196);
            this.preguntasComboBox.Name = "preguntasComboBox";
            this.preguntasComboBox.Size = new System.Drawing.Size(121, 19);
            this.preguntasComboBox.TabIndex = 15;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(112, 195);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(92, 18);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // txtRubro
            // 
            this.txtRubro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtRubro.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRubro.Location = new System.Drawing.Point(15, 221);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(145, 19);
            this.txtRubro.TabIndex = 18;
            this.txtRubro.Text = "Seleccionar rubros";
            this.txtRubro.UseVisualStyleBackColor = true;
            this.txtRubro.Click += new System.EventHandler(this.txtRubro_Click);
            // 
            // groupBoxVisibilidad
            // 
            this.groupBoxVisibilidad.Controls.Add(this.labelComision);
            this.groupBoxVisibilidad.Controls.Add(this.labelPrecioPublicar);
            this.groupBoxVisibilidad.Controls.Add(this.labelInicio);
            this.groupBoxVisibilidad.Controls.Add(this.labelVencimiento);
            this.groupBoxVisibilidad.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVisibilidad.Location = new System.Drawing.Point(15, 247);
            this.groupBoxVisibilidad.Name = "groupBoxVisibilidad";
            this.groupBoxVisibilidad.Size = new System.Drawing.Size(414, 100);
            this.groupBoxVisibilidad.TabIndex = 19;
            this.groupBoxVisibilidad.TabStop = false;
            this.groupBoxVisibilidad.Text = "Datos Visibilidad";
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.Location = new System.Drawing.Point(25, 76);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(166, 11);
            this.labelComision.TabIndex = 16;
            this.labelComision.Text = "Porcentaje de comision:";
            // 
            // labelPrecioPublicar
            // 
            this.labelPrecioPublicar.AutoSize = true;
            this.labelPrecioPublicar.Location = new System.Drawing.Point(25, 58);
            this.labelPrecioPublicar.Name = "labelPrecioPublicar";
            this.labelPrecioPublicar.Size = new System.Drawing.Size(145, 11);
            this.labelPrecioPublicar.TabIndex = 15;
            this.labelPrecioPublicar.Text = "Precio por publicar:";
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(25, 21);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(117, 11);
            this.labelInicio.TabIndex = 14;
            this.labelInicio.Text = "Fecha de inicio:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(167, 222);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(262, 18);
            this.textBox1.TabIndex = 20;
            // 
            // botonBorrador
            // 
            this.botonBorrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonBorrador.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBorrador.Location = new System.Drawing.Point(261, 352);
            this.botonBorrador.Name = "botonBorrador";
            this.botonBorrador.Size = new System.Drawing.Size(75, 36);
            this.botonBorrador.TabIndex = 21;
            this.botonBorrador.Text = "Guardar borrador";
            this.botonBorrador.UseVisualStyleBackColor = true;
            this.botonBorrador.Click += new System.EventHandler(this.botonBorrador_Click);
            // 
            // botonPublicar
            // 
            this.botonPublicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonPublicar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPublicar.Location = new System.Drawing.Point(353, 352);
            this.botonPublicar.Name = "botonPublicar";
            this.botonPublicar.Size = new System.Drawing.Size(75, 36);
            this.botonPublicar.TabIndex = 22;
            this.botonPublicar.Text = "Publicar";
            this.botonPublicar.UseVisualStyleBackColor = true;
            this.botonPublicar.Click += new System.EventHandler(this.botonPublicar_Click);
            // 
            // botonRegresar
            // 
            this.botonRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonRegresar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRegresar.Location = new System.Drawing.Point(167, 353);
            this.botonRegresar.Name = "botonRegresar";
            this.botonRegresar.Size = new System.Drawing.Size(75, 35);
            this.botonRegresar.TabIndex = 23;
            this.botonRegresar.Text = "Regresar";
            this.botonRegresar.UseVisualStyleBackColor = true;
            this.botonRegresar.Click += new System.EventHandler(this.botonRegresar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 11);
            this.label5.TabIndex = 24;
            this.label5.Text = "Total por comisiones:";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(15, 366);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(26, 11);
            this.total.TabIndex = 25;
            this.total.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 11);
            this.label7.TabIndex = 26;
            this.label7.Text = "$";
            // 
            // labelActivas
            // 
            this.labelActivas.AutoSize = true;
            this.labelActivas.Location = new System.Drawing.Point(15, 8);
            this.labelActivas.Name = "labelActivas";
            this.labelActivas.Size = new System.Drawing.Size(236, 11);
            this.labelActivas.TabIndex = 27;
            this.labelActivas.Text = "Publicaciones Gratuitas Activas: ";
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1420, 688);
            this.Controls.Add(this.labelActivas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botonRegresar);
            this.Controls.Add(this.botonPublicar);
            this.Controls.Add(this.botonBorrador);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBoxVisibilidad);
            this.Controls.Add(this.txtRubro);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.preguntasComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.visibilidadComboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioSubasta);
            this.Controls.Add(this.radioCompra);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.EnabledChanged += new System.EventHandler(this.GenerarPublicacion_EnabledChanged);
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
        private System.Windows.Forms.ComboBox visibilidadComboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.ComboBox preguntasComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelActivas;

    }
}