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
            this.recibidas = new System.Windows.Forms.RadioButton();
            this.refrescar = new System.Windows.Forms.Button();
            this.otorgadas = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seleccionar = new System.Windows.Forms.Button();
            this.sinResultados = new System.Windows.Forms.Label();
            this.botonFacturas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.recibidas);
            this.groupBox1.Controls.Add(this.refrescar);
            this.groupBox1.Controls.Add(this.otorgadas);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial";
            // 
            // recibidas
            // 
            this.recibidas.AutoSize = true;
            this.recibidas.Checked = true;
            this.recibidas.Location = new System.Drawing.Point(281, 35);
            this.recibidas.Name = "recibidas";
            this.recibidas.Size = new System.Drawing.Size(86, 15);
            this.recibidas.TabIndex = 4;
            this.recibidas.TabStop = true;
            this.recibidas.Text = "Recibidas";
            this.recibidas.UseVisualStyleBackColor = true;
            this.recibidas.CheckedChanged += new System.EventHandler(this.recibidas_CheckedChanged);
            // 
            // refrescar
            // 
            this.refrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refrescar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refrescar.Location = new System.Drawing.Point(184, 21);
            this.refrescar.Name = "refrescar";
            this.refrescar.Size = new System.Drawing.Size(87, 23);
            this.refrescar.TabIndex = 9;
            this.refrescar.Text = "Refrescar";
            this.refrescar.UseVisualStyleBackColor = true;
            this.refrescar.Click += new System.EventHandler(this.refrescar_Click);
            // 
            // otorgadas
            // 
            this.otorgadas.AutoSize = true;
            this.otorgadas.Location = new System.Drawing.Point(281, 14);
            this.otorgadas.Name = "otorgadas";
            this.otorgadas.Size = new System.Drawing.Size(86, 15);
            this.otorgadas.TabIndex = 3;
            this.otorgadas.Text = "Otorgadas";
            this.otorgadas.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Calificaciones",
            "Compras",
            "Ofertas"});
            this.comboBox1.Location = new System.Drawing.Point(81, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 19);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 11);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criterio:";
            // 
            // atras
            // 
            this.atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.atras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.atras.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras.Location = new System.Drawing.Point(324, 300);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(75, 23);
            this.atras.TabIndex = 6;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 78);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(391, 216);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // seleccionar
            // 
            this.seleccionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.seleccionar.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionar.Location = new System.Drawing.Point(243, 300);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(75, 23);
            this.seleccionar.TabIndex = 8;
            this.seleccionar.Text = "Ver";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // sinResultados
            // 
            this.sinResultados.AutoSize = true;
            this.sinResultados.BackColor = System.Drawing.Color.Transparent;
            this.sinResultados.Font = new System.Drawing.Font("Lucida Console", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinResultados.Location = new System.Drawing.Point(34, 160);
            this.sinResultados.Name = "sinResultados";
            this.sinResultados.Size = new System.Drawing.Size(339, 37);
            this.sinResultados.TabIndex = 23;
            this.sinResultados.Text = "Sin Resultados";
            // 
            // botonFacturas
            // 
            this.botonFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonFacturas.Location = new System.Drawing.Point(19, 300);
            this.botonFacturas.Name = "botonFacturas";
            this.botonFacturas.Size = new System.Drawing.Size(107, 23);
            this.botonFacturas.TabIndex = 24;
            this.botonFacturas.Text = "Mis Facturas";
            this.botonFacturas.UseVisualStyleBackColor = true;
            this.botonFacturas.Click += new System.EventHandler(this.botonFacturas_Click);
            // 
            // Historial
            // 
            this.AcceptButton = this.seleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(844, 521);
            this.ControlBox = false;
            this.Controls.Add(this.botonFacturas);
            this.Controls.Add(this.sinResultados);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Historial";
            this.ShowIcon = false;
            this.Text = "Historial de Cliente";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton recibidas;
        private System.Windows.Forms.RadioButton otorgadas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Button refrescar;
        private System.Windows.Forms.Label sinResultados;
        private System.Windows.Forms.Button botonFacturas;
    }
}