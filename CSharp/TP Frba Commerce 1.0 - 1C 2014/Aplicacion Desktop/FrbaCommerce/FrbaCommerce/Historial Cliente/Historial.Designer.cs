namespace FrbaCommerce.Historial_Cliente
{
    partial class Historial
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.otorgadas = new System.Windows.Forms.RadioButton();
            this.recibidas = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.atras = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recibidas);
            this.groupBox1.Controls.Add(this.otorgadas);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criterio:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // otorgadas
            // 
            this.otorgadas.AutoSize = true;
            this.otorgadas.Location = new System.Drawing.Point(34, 78);
            this.otorgadas.Name = "otorgadas";
            this.otorgadas.Size = new System.Drawing.Size(74, 17);
            this.otorgadas.TabIndex = 3;
            this.otorgadas.TabStop = true;
            this.otorgadas.Text = "Otorgadas";
            this.otorgadas.UseVisualStyleBackColor = true;
            this.otorgadas.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // recibidas
            // 
            this.recibidas.AutoSize = true;
            this.recibidas.Location = new System.Drawing.Point(186, 78);
            this.recibidas.Name = "recibidas";
            this.recibidas.Size = new System.Drawing.Size(72, 17);
            this.recibidas.TabIndex = 4;
            this.recibidas.TabStop = true;
            this.recibidas.Text = "Recibidas";
            this.recibidas.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(24, 154);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(391, 121);
            this.listBox1.TabIndex = 5;
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(308, 297);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 6;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 335);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Historial";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton recibidas;
        private System.Windows.Forms.RadioButton otorgadas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button atras;
    }
}