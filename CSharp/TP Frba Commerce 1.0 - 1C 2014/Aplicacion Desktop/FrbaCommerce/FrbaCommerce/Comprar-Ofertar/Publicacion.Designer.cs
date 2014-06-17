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
            this.infoDescripcion = new System.Windows.Forms.RichTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.infoPrecio = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.montoOferta = new System.Windows.Forms.TextBox();
            this.botonPreguntar = new System.Windows.Forms.Button();
            this.botonOfertar = new System.Windows.Forms.Button();
            this.botonComprar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.campoPregunta = new System.Windows.Forms.RichTextBox();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.WarningLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // infoDescripcion
            // 
            this.infoDescripcion.Location = new System.Drawing.Point(24, 16);
            this.infoDescripcion.Name = "infoDescripcion";
            this.infoDescripcion.ReadOnly = true;
            this.infoDescripcion.Size = new System.Drawing.Size(319, 151);
            this.infoDescripcion.TabIndex = 0;
            this.infoDescripcion.Text = "";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(459, 200);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
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
            this.infoPrecio.Location = new System.Drawing.Point(355, 16);
            this.infoPrecio.Name = "infoPrecio";
            this.infoPrecio.ReadOnly = true;
            this.infoPrecio.Size = new System.Drawing.Size(224, 151);
            this.infoPrecio.TabIndex = 2;
            this.infoPrecio.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Unidades deseadas:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monto a ofertar:      $";
            // 
            // montoOferta
            // 
            this.montoOferta.Location = new System.Drawing.Point(459, 232);
            this.montoOferta.Name = "montoOferta";
            this.montoOferta.Size = new System.Drawing.Size(120, 20);
            this.montoOferta.TabIndex = 5;
            this.montoOferta.TextChanged += new System.EventHandler(this.montoOferta_TextChanged);
            // 
            // botonPreguntar
            // 
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
            this.botonComprar.Location = new System.Drawing.Point(482, 268);
            this.botonComprar.Name = "botonComprar";
            this.botonComprar.Size = new System.Drawing.Size(75, 47);
            this.botonComprar.TabIndex = 8;
            this.botonComprar.Text = "Comprar";
            this.botonComprar.UseVisualStyleBackColor = true;
            this.botonComprar.Click += new System.EventHandler(this.botonComprar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Haz tu pregunta:";
            // 
            // campoPregunta
            // 
            this.campoPregunta.Location = new System.Drawing.Point(24, 199);
            this.campoPregunta.Name = "campoPregunta";
            this.campoPregunta.Size = new System.Drawing.Size(319, 84);
            this.campoPregunta.TabIndex = 10;
            this.campoPregunta.Text = "";
            // 
            // botonCancelar
            // 
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
            this.WarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.Location = new System.Drawing.Point(357, 178);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(104, 16);
            this.WarningLabel.TabIndex = 12;
            this.WarningLabel.Text = "WarningLabel";
            // 
            // Publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 354);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.campoPregunta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.botonComprar);
            this.Controls.Add(this.botonOfertar);
            this.Controls.Add(this.botonPreguntar);
            this.Controls.Add(this.montoOferta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoPrecio);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.infoDescripcion);
            this.Name = "Publicacion";
            this.Text = "Publicacion";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox infoDescripcion;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox infoPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox montoOferta;
        private System.Windows.Forms.Button botonPreguntar;
        private System.Windows.Forms.Button botonOfertar;
        private System.Windows.Forms.Button botonComprar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox campoPregunta;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label WarningLabel;
    }
}