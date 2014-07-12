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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodoTipo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.ComboBox();
            this.trimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.criterio = new System.Windows.Forms.ComboBox();
            this.atras = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botonFiltrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mes_anio = new System.Windows.Forms.ComboBox();
            this.visibilidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 11);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 11);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre:";
            // 
            // anio
            // 
            this.anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(36, 18);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(65, 19);
            this.anio.TabIndex = 2;
            this.anio.SelectedIndexChanged += new System.EventHandler(this.anio_SelectedIndexChanged);
            // 
            // trimestre
            // 
            this.trimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trimestre.FormattingEnabled = true;
            this.trimestre.Location = new System.Drawing.Point(190, 19);
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(137, 19);
            this.trimestre.TabIndex = 3;
            this.trimestre.SelectedIndexChanged += new System.EventHandler(this.trimestre_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 11);
            this.label3.TabIndex = 4;
            this.label3.Text = "Criterio estadístico:";
            // 
            // criterio
            // 
            this.criterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criterio.FormattingEnabled = true;
            this.criterio.Location = new System.Drawing.Point(153, 55);
            this.criterio.Name = "criterio";
            this.criterio.Size = new System.Drawing.Size(174, 19);
            this.criterio.TabIndex = 5;
            this.criterio.SelectedIndexChanged += new System.EventHandler(this.criterio_SelectedIndexChanged);
            // 
            // atras
            // 
            this.atras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("atras.BackgroundImage")));
            this.atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.atras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atras.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras.Location = new System.Drawing.Point(265, 316);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 7;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.botonConsultar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.anio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.criterio);
            this.groupBox1.Controls.Add(this.trimestre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio";
            // 
            // botonConsultar
            // 
            this.botonConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonConsultar.BackgroundImage")));
            this.botonConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonConsultar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultar.Location = new System.Drawing.Point(249, 88);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(75, 23);
            this.botonConsultar.TabIndex = 6;
            this.botonConsultar.Text = "Consultar";
            this.botonConsultar.UseVisualStyleBackColor = true;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 173);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(561, 135);
            this.dataGridView1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.botonFiltrar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.mes_anio);
            this.groupBox2.Controls.Add(this.visibilidad);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(362, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 117);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // botonFiltrar
            // 
            this.botonFiltrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonFiltrar.BackgroundImage")));
            this.botonFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonFiltrar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonFiltrar.Location = new System.Drawing.Point(150, 88);
            this.botonFiltrar.Name = "botonFiltrar";
            this.botonFiltrar.Size = new System.Drawing.Size(69, 23);
            this.botonFiltrar.TabIndex = 11;
            this.botonFiltrar.Text = "Filtrar";
            this.botonFiltrar.UseVisualStyleBackColor = true;
            this.botonFiltrar.Click += new System.EventHandler(this.botonFiltrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mes-Año:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 11);
            this.label4.TabIndex = 1;
            this.label4.Text = "Visibilidad:";
            // 
            // mes_anio
            // 
            this.mes_anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mes_anio.FormattingEnabled = true;
            this.mes_anio.Location = new System.Drawing.Point(108, 19);
            this.mes_anio.Name = "mes_anio";
            this.mes_anio.Size = new System.Drawing.Size(111, 19);
            this.mes_anio.TabIndex = 2;
            // 
            // visibilidad
            // 
            this.visibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visibilidad.FormattingEnabled = true;
            this.visibilidad.Location = new System.Drawing.Point(108, 55);
            this.visibilidad.Name = "visibilidad";
            this.visibilidad.Size = new System.Drawing.Size(111, 19);
            this.visibilidad.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 11);
            this.label6.TabIndex = 11;
            this.label6.Text = "El TOP5 de ";
            // 
            // PeriodoTipo
            // 
            this.AcceptButton = this.botonConsultar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(607, 343);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.atras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PeriodoTipo";
            this.Text = "Estadisticas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.ComboBox trimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox criterio;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mes_anio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox visibilidad;
        private System.Windows.Forms.Button botonFiltrar;
        private System.Windows.Forms.Label label6;
    }
}