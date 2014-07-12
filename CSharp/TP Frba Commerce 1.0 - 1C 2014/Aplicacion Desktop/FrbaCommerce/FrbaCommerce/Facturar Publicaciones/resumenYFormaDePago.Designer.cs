namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class resumenYFormaDePago
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
            this.label1 = new System.Windows.Forms.Label();
            this.botonContinuar = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tarjeta = new System.Windows.Forms.RadioButton();
            this.efectivo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.codigo = new System.Windows.Forms.TextBox();
            this.numtarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resumen de la selección:";
            // 
            // botonContinuar
            // 
            this.botonContinuar.Location = new System.Drawing.Point(364, 293);
            this.botonContinuar.Name = "botonContinuar";
            this.botonContinuar.Size = new System.Drawing.Size(75, 36);
            this.botonContinuar.TabIndex = 2;
            this.botonContinuar.Text = "Generar Factura";
            this.botonContinuar.UseVisualStyleBackColor = true;
            this.botonContinuar.Click += new System.EventHandler(this.botonContinuar_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonAtras.Location = new System.Drawing.Point(363, 335);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(76, 23);
            this.botonAtras.TabIndex = 3;
            this.botonAtras.Text = "Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(427, 178);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(141, 298);
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Size = new System.Drawing.Size(100, 20);
            this.monto.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Monto a pagar:";
            // 
            // tarjeta
            // 
            this.tarjeta.AutoSize = true;
            this.tarjeta.Location = new System.Drawing.Point(276, 334);
            this.tarjeta.Name = "tarjeta";
            this.tarjeta.Size = new System.Drawing.Size(58, 17);
            this.tarjeta.TabIndex = 9;
            this.tarjeta.Text = "Tarjeta";
            this.tarjeta.UseVisualStyleBackColor = true;
            // 
            // efectivo
            // 
            this.efectivo.AutoSize = true;
            this.efectivo.Checked = true;
            this.efectivo.Location = new System.Drawing.Point(187, 334);
            this.efectivo.Name = "efectivo";
            this.efectivo.Size = new System.Drawing.Size(64, 17);
            this.efectivo.TabIndex = 8;
            this.efectivo.TabStop = true;
            this.efectivo.Text = "Efectivo";
            this.efectivo.UseVisualStyleBackColor = true;
            this.efectivo.CheckedChanged += new System.EventHandler(this.efectivo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione forma de pago:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.codigo);
            this.groupBox1.Controls.Add(this.numtarjeta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(16, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 72);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos tarjeta";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "MasterCard",
            "Maestro",
            "VISA",
            "VISA Electron",
            "GridPlus"});
            this.comboBox1.Location = new System.Drawing.Point(219, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(140, 43);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(73, 20);
            this.codigo.TabIndex = 3;
            // 
            // numtarjeta
            // 
            this.numtarjeta.Location = new System.Drawing.Point(140, 18);
            this.numtarjeta.Name = "numtarjeta";
            this.numtarjeta.Size = new System.Drawing.Size(214, 20);
            this.numtarjeta.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Codigo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Numero de tarjeta:";
            // 
            // resumenYFormaDePago
            // 
            this.AcceptButton = this.botonContinuar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaCommerce.Properties.Resources.Fondo_Azul;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.botonAtras;
            this.ClientSize = new System.Drawing.Size(466, 382);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tarjeta);
            this.Controls.Add(this.efectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonContinuar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "resumenYFormaDePago";
            this.Text = "Selección de Publicaciones";
            this.Load += new System.EventHandler(this.PublicacionesRendir_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonContinuar;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton tarjeta;
        private System.Windows.Forms.RadioButton efectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.TextBox numtarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}