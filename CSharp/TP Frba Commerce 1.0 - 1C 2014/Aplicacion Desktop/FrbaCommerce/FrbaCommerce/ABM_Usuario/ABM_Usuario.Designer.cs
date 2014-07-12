namespace FrbaCommerce.ABM_Usuario
{
    partial class ABM_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM_Usuario));
            this.atras = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sinResultados = new System.Windows.Forms.Label();
            this.botonUsuario = new System.Windows.Forms.Button();
            this.botonAdmin = new System.Windows.Forms.Button();
            this.botonRoles = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // atras
            // 
            this.atras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("atras.BackgroundImage")));
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            // botonUsuario
            // 
            this.botonUsuario.Location = new System.Drawing.Point(26, 300);
            this.botonUsuario.Name = "botonUsuario";
            this.botonUsuario.Size = new System.Drawing.Size(107, 23);
            this.botonUsuario.TabIndex = 24;
            this.botonUsuario.Text = "Nuevo Usuario";
            this.botonUsuario.UseVisualStyleBackColor = true;
            this.botonUsuario.Click += new System.EventHandler(this.botonUsuario_Click);
            // 
            // botonAdmin
            // 
            this.botonAdmin.Location = new System.Drawing.Point(155, 300);
            this.botonAdmin.Name = "botonAdmin";
            this.botonAdmin.Size = new System.Drawing.Size(107, 23);
            this.botonAdmin.TabIndex = 25;
            this.botonAdmin.Text = "Nuevo Admin";
            this.botonAdmin.UseVisualStyleBackColor = true;
            this.botonAdmin.Click += new System.EventHandler(this.botonAdmin_Click);
            // 
            // botonRoles
            // 
            this.botonRoles.Location = new System.Drawing.Point(155, 40);
            this.botonRoles.Name = "botonRoles";
            this.botonRoles.Size = new System.Drawing.Size(107, 23);
            this.botonRoles.TabIndex = 26;
            this.botonRoles.Text = "Modificar Roles";
            this.botonRoles.UseVisualStyleBackColor = true;
            this.botonRoles.Click += new System.EventHandler(this.botonRoles_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Location = new System.Drawing.Point(26, 40);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(107, 23);
            this.botonBaja.TabIndex = 27;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(285, 40);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(102, 23);
            this.botonModificar.TabIndex = 28;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // ABM_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.atras;
            this.ClientSize = new System.Drawing.Size(413, 348);
            this.ControlBox = false;
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.botonRoles);
            this.Controls.Add(this.botonAdmin);
            this.Controls.Add(this.botonUsuario);
            this.Controls.Add(this.sinResultados);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.atras);
            this.Name = "ABM_Usuario";
            this.Text = "AMB Usuario";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.VisibleChanged += new System.EventHandler(this.ABM_Usuario_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label sinResultados;
        private System.Windows.Forms.Button botonUsuario;
        private System.Windows.Forms.Button botonAdmin;
        private System.Windows.Forms.Button botonRoles;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonModificar;
    }
}