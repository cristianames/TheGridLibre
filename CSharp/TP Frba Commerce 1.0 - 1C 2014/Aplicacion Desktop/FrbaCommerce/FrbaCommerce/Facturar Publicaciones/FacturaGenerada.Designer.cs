namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FacturaGenerada
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.TextBox();
            this.efectivoBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.conTarjetaBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.imprimir = new System.Windows.Forms.Button();
            this.atras = new System.Windows.Forms.Button();
            this.efectivoBox.SuspendLayout();
            this.conTarjetaBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(417, 121);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(68, 19);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(100, 20);
            this.fecha.TabIndex = 2;
            // 
            // efectivoBox
            // 
            this.efectivoBox.Controls.Add(this.label2);
            this.efectivoBox.Controls.Add(this.label1);
            this.efectivoBox.Controls.Add(this.fecha);
            this.efectivoBox.Location = new System.Drawing.Point(28, 22);
            this.efectivoBox.Name = "efectivoBox";
            this.efectivoBox.Size = new System.Drawing.Size(417, 98);
            this.efectivoBox.TabIndex = 3;
            this.efectivoBox.TabStop = false;
            this.efectivoBox.Text = "Datos factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Forma de pago:   EFECTIVO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "$";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(359, 268);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 6;
            // 
            // conTarjetaBox
            // 
            this.conTarjetaBox.Controls.Add(this.textBox3);
            this.conTarjetaBox.Controls.Add(this.label7);
            this.conTarjetaBox.Controls.Add(this.label6);
            this.conTarjetaBox.Controls.Add(this.textBox2);
            this.conTarjetaBox.Controls.Add(this.label5);
            this.conTarjetaBox.Location = new System.Drawing.Point(494, 22);
            this.conTarjetaBox.Name = "conTarjetaBox";
            this.conTarjetaBox.Size = new System.Drawing.Size(417, 98);
            this.conTarjetaBox.TabIndex = 7;
            this.conTarjetaBox.TabStop = false;
            this.conTarjetaBox.Text = "Datos factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Forma de pago:   TARJETA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Nro. Tarjeta:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(285, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 6;
            // 
            // imprimir
            // 
            this.imprimir.Location = new System.Drawing.Point(259, 329);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(75, 23);
            this.imprimir.TabIndex = 8;
            this.imprimir.Text = "Imprimir";
            this.imprimir.UseVisualStyleBackColor = true;
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(343, 329);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 9;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            // 
            // FacturaGenerada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 382);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.conTarjetaBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.efectivoBox);
            this.Controls.Add(this.listBox1);
            this.Name = "FacturaGenerada";
            this.Text = "FacturaGenerada";
            this.efectivoBox.ResumeLayout(false);
            this.efectivoBox.PerformLayout();
            this.conTarjetaBox.ResumeLayout(false);
            this.conTarjetaBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fecha;
        private System.Windows.Forms.GroupBox efectivoBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox conTarjetaBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Button atras;
    }
}