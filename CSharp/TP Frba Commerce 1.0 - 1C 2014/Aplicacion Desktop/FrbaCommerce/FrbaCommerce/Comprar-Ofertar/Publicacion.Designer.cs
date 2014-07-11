namespace FrbaCommerce.Comprar_Ofertar
{
    partial class Publicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publicacion));
            this.infoDescripcion = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.infoPrecio = new System.Windows.Forms.RichTextBox();
            this.labelUnidades = new System.Windows.Forms.Label();
            this.labelMonto = new System.Windows.Forms.Label();
            this.montoOferta = new System.Windows.Forms.TextBox();
            this.botonPreguntar = new System.Windows.Forms.Button();
            this.botonOfertar = new System.Windows.Forms.Button();
            this.botonComprar = new System.Windows.Forms.Button();
            this.labelPregunta = new System.Windows.Forms.Label();
            this.campoPregunta = new System.Windows.Forms.RichTextBox();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.WarningLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // infoDescripcion
            // 
            this.infoDescripcion.BackColor = System.Drawing.Color.SteelBlue;
            this.infoDescripcion.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoDescripcion.Location = new System.Drawing.Point(24, 16);
            this.infoDescripcion.Name = "infoDescripcion";
            this.infoDescripcion.ReadOnly = true;
            this.infoDescripcion.Size = new System.Drawing.Size(319, 151);
            this.infoDescripcion.TabIndex = 0;
            this.infoDescripcion.Text = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(482, 200);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(97, 18);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // infoPrecio
            // 
            this.infoPrecio.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoPrecio.Location = new System.Drawing.Point(355, 16);
            this.infoPrecio.Name = "infoPrecio";
            this.infoPrecio.ReadOnly = true;
            this.infoPrecio.Size = new System.Drawing.Size(224, 151);
            this.infoPrecio.TabIndex = 2;
            this.infoPrecio.Text = "";
            // 
            // labelUnidades
            // 
            this.labelUnidades.AutoSize = true;
            this.labelUnidades.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnidades.Location = new System.Drawing.Point(352, 202);
            this.labelUnidades.Name = "labelUnidades";
            this.labelUnidades.Size = new System.Drawing.Size(131, 11);
            this.labelUnidades.TabIndex = 3;
            this.labelUnidades.Text = "Unidades deseadas:";
            this.labelUnidades.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelMonto
            // 
            this.labelMonto.AutoSize = true;
            this.labelMonto.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonto.Location = new System.Drawing.Point(352, 235);
            this.labelMonto.Name = "labelMonto";
            this.labelMonto.Size = new System.Drawing.Size(166, 11);
            this.labelMonto.TabIndex = 4;
            this.labelMonto.Text = "Monto a ofertar:      $";
            // 
            // montoOferta
            // 
            this.montoOferta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoOferta.Location = new System.Drawing.Point(482, 232);
            this.montoOferta.Name = "montoOferta";
            this.montoOferta.Size = new System.Drawing.Size(97, 18);
            this.montoOferta.TabIndex = 5;
            this.montoOferta.TextChanged += new System.EventHandler(this.montoOferta_TextChanged);
            // 
            // botonPreguntar
            // 
            this.botonPreguntar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonPreguntar.BackgroundImage")));
            this.botonPreguntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonPreguntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPreguntar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPreguntar.Location = new System.Drawing.Point(223, 292);
            this.botonPreguntar.Name = "botonPreguntar";
            this.botonPreguntar.Size = new System.Drawing.Size(120, 23);
            this.botonPreguntar.TabIndex = 6;
            this.botonPreguntar.Text = "Preguntar";
            this.botonPreguntar.UseVisualStyleBackColor = true;
            this.botonPreguntar.Click += new System.EventHandler(this.button1_Click);
            // 
            // botonOfertar
            // 
            this.botonOfertar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonOfertar.BackgroundImage")));
            this.botonOfertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonOfertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonOfertar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonOfertar.Location = new System.Drawing.Point(381, 268);
            this.botonOfertar.Name = "botonOfertar";
            this.botonOfertar.Size = new System.Drawing.Size(75, 47);
            this.botonOfertar.TabIndex = 7;
            this.botonOfertar.Text = "Ofertar";
            this.botonOfertar.UseVisualStyleBackColor = true;
            this.botonOfertar.Click += new System.EventHandler(this.botonOfertar_Click);
            // 
            // botonComprar
            // 
            this.botonComprar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonComprar.BackgroundImage")));
            this.botonComprar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonComprar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonComprar.Location = new System.Drawing.Point(482, 268);
            this.botonComprar.Name = "botonComprar";
            this.botonComprar.Size = new System.Drawing.Size(75, 47);
            this.botonComprar.TabIndex = 8;
            this.botonComprar.Text = "Comprar";
            this.botonComprar.UseVisualStyleBackColor = true;
            this.botonComprar.Click += new System.EventHandler(this.botonComprar_Click);
            // 
            // labelPregunta
            // 
            this.labelPregunta.AutoSize = true;
            this.labelPregunta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPregunta.Location = new System.Drawing.Point(21, 181);
            this.labelPregunta.Name = "labelPregunta";
            this.labelPregunta.Size = new System.Drawing.Size(117, 11);
            this.labelPregunta.TabIndex = 9;
            this.labelPregunta.Text = "Haz tu pregunta:";
            // 
            // campoPregunta
            // 
            this.campoPregunta.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoPregunta.Location = new System.Drawing.Point(24, 199);
            this.campoPregunta.MaxLength = 255;
            this.campoPregunta.Name = "campoPregunta";
            this.campoPregunta.Size = new System.Drawing.Size(319, 84);
            this.campoPregunta.TabIndex = 10;
            this.campoPregunta.Text = "";
            // 
            // botonCancelar
            // 
            this.botonCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonCancelar.BackgroundImage")));
            this.botonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCancelar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCancelar.Location = new System.Drawing.Point(24, 292);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(120, 23);
            this.botonCancelar.TabIndex = 11;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.Location = new System.Drawing.Point(357, 178);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(115, 13);
            this.WarningLabel.TabIndex = 12;
            this.WarningLabel.Text = "WarningLabel";
            // 
            // Publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(863, 513);
            this.ControlBox = false;
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.campoPregunta);
            this.Controls.Add(this.labelPregunta);
            this.Controls.Add(this.botonComprar);
            this.Controls.Add(this.botonOfertar);
            this.Controls.Add(this.botonPreguntar);
            this.Controls.Add(this.montoOferta);
            this.Controls.Add(this.labelMonto);
            this.Controls.Add(this.labelUnidades);
            this.Controls.Add(this.infoPrecio);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.infoDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Publicacion";
            this.ShowIcon = false;
            this.Text = "Publicacion";
            this.Load += new System.EventHandler(this.Publicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox infoDescripcion;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox infoPrecio;
        private System.Windows.Forms.Label labelUnidades;
        private System.Windows.Forms.Label labelMonto;
        private System.Windows.Forms.TextBox montoOferta;
        private System.Windows.Forms.Button botonPreguntar;
        private System.Windows.Forms.Button botonOfertar;
        private System.Windows.Forms.Button botonComprar;
        private System.Windows.Forms.Label labelPregunta;
        private System.Windows.Forms.RichTextBox campoPregunta;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label WarningLabel;
    }
}