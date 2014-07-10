namespace FrbaCommerce.Historial_Cliente
{
    partial class Facturas
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
            this.atras = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seleccionar = new System.Windows.Forms.Button();
            this.sinResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // atras
            // 
            this.atras.BackgroundImage = global::FrbaCommerce.Properties.Resources.Boton_Azul;
            this.atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.atras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.dataGridView1.Location = new System.Drawing.Point(10, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(391, 282);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // seleccionar
            // 
            this.seleccionar.BackgroundImage = global::FrbaCommerce.Properties.Resources.Boton_Azul;
            this.seleccionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            // Facturas
            // 
            this.AcceptButton = this.seleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaCommerce.Properties.Resources.Fondo_Azul;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(844, 521);
            this.Controls.Add(this.sinResultados);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.atras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Facturas";
            this.Text = "Mis Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Label sinResultados;
    }
}