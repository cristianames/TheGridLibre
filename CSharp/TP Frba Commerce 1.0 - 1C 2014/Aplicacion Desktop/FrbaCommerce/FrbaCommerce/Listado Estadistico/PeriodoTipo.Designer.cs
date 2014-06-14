namespace FrbaCommerce.Listado_Estadistico
{
    partial class PeriodoTipo
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
            this.label2 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.ComboBox();
            this.trimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.criterio = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.atras = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // anio
            // 
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(51, 26);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(75, 21);
            this.anio.TabIndex = 2;
            // 
            // trimestre
            // 
            this.trimestre.FormattingEnabled = true;
            this.trimestre.Location = new System.Drawing.Point(231, 26);
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(64, 21);
            this.trimestre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Criterio estadístico:";
            // 
            // criterio
            // 
            this.criterio.FormattingEnabled = true;
            this.criterio.Location = new System.Drawing.Point(119, 67);
            this.criterio.Name = "criterio";
            this.criterio.Size = new System.Drawing.Size(121, 21);
            this.criterio.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 141);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(350, 134);
            this.listBox1.TabIndex = 6;
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(279, 291);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 7;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.anio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.criterio);
            this.groupBox1.Controls.Add(this.trimestre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio";
            // 
            // PeriodoTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 329);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.listBox1);
            this.Name = "PeriodoTipo";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.ComboBox trimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox criterio;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}