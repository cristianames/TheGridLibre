﻿namespace FrbaCommerce.ABM_Usuario
{
    partial class AbmEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmEmpresa));
            this.botonTerminado = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.botonFiltrar = new System.Windows.Forms.Button();
            this.botonBorrar = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botonMostrar = new System.Windows.Forms.Button();
            this.sinResultados = new System.Windows.Forms.Label();
            this.BotonInhabilitar = new System.Windows.Forms.Button();
            this.botonVolverAlta = new System.Windows.Forms.Button();
            this.botonRehabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonTerminado
            // 
            this.botonTerminado.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonTerminado.Location = new System.Drawing.Point(621, 359);
            this.botonTerminado.Name = "botonTerminado";
            this.botonTerminado.Size = new System.Drawing.Size(92, 23);
            this.botonTerminado.TabIndex = 23;
            this.botonTerminado.Text = "Terminado";
            this.botonTerminado.UseVisualStyleBackColor = true;
            this.botonTerminado.Click += new System.EventHandler(this.botonTerminado_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(880, 241);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCuit);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 47);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Herramientas de Filtro";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(178, 19);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(161, 20);
            this.txtRazonSocial.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "E-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Razon Social";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(550, 19);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(165, 20);
            this.txtMail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "CUIT";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(382, 19);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(120, 20);
            this.txtCuit.TabIndex = 8;
            // 
            // botonFiltrar
            // 
            this.botonFiltrar.Location = new System.Drawing.Point(817, 72);
            this.botonFiltrar.Name = "botonFiltrar";
            this.botonFiltrar.Size = new System.Drawing.Size(75, 23);
            this.botonFiltrar.TabIndex = 16;
            this.botonFiltrar.Text = "Filtrar";
            this.botonFiltrar.UseVisualStyleBackColor = true;
            this.botonFiltrar.Click += new System.EventHandler(this.botonFiltrar_Click);
            // 
            // botonBorrar
            // 
            this.botonBorrar.Location = new System.Drawing.Point(740, 73);
            this.botonBorrar.Name = "botonBorrar";
            this.botonBorrar.Size = new System.Drawing.Size(75, 23);
            this.botonBorrar.TabIndex = 15;
            this.botonBorrar.Text = "Borrar";
            this.botonBorrar.UseVisualStyleBackColor = true;
            this.botonBorrar.Click += new System.EventHandler(this.botonBorrar_Click);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(349, 359);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(92, 23);
            this.botonEliminar.TabIndex = 20;
            this.botonEliminar.Text = "Dar de Baja";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(216, 359);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(92, 23);
            this.botonModificar.TabIndex = 19;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Seleccione un usuario:";
            // 
            // botonMostrar
            // 
            this.botonMostrar.Location = new System.Drawing.Point(343, 73);
            this.botonMostrar.Name = "botonMostrar";
            this.botonMostrar.Size = new System.Drawing.Size(216, 23);
            this.botonMostrar.TabIndex = 24;
            this.botonMostrar.Text = "Mostrar Inhabilitados";
            this.botonMostrar.UseVisualStyleBackColor = true;
            this.botonMostrar.Click += new System.EventHandler(this.botonMostrar_Click);
            // 
            // sinResultados
            // 
            this.sinResultados.AutoSize = true;
            this.sinResultados.Font = new System.Drawing.Font("Lucida Console", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinResultados.Location = new System.Drawing.Point(278, 189);
            this.sinResultados.Name = "sinResultados";
            this.sinResultados.Size = new System.Drawing.Size(339, 37);
            this.sinResultados.TabIndex = 28;
            this.sinResultados.Text = "Sin Resultados";
            // 
            // BotonInhabilitar
            // 
            this.BotonInhabilitar.Location = new System.Drawing.Point(485, 359);
            this.BotonInhabilitar.Name = "BotonInhabilitar";
            this.BotonInhabilitar.Size = new System.Drawing.Size(92, 23);
            this.BotonInhabilitar.TabIndex = 27;
            this.BotonInhabilitar.Text = "Inhabilitar";
            this.BotonInhabilitar.UseVisualStyleBackColor = true;
            this.BotonInhabilitar.Click += new System.EventHandler(this.BotonInhabilitar_Click);
            // 
            // botonVolverAlta
            // 
            this.botonVolverAlta.Location = new System.Drawing.Point(761, 359);
            this.botonVolverAlta.Name = "botonVolverAlta";
            this.botonVolverAlta.Size = new System.Drawing.Size(140, 23);
            this.botonVolverAlta.TabIndex = 26;
            this.botonVolverAlta.Text = "Volver a Dar de Alta";
            this.botonVolverAlta.UseVisualStyleBackColor = true;
            this.botonVolverAlta.Click += new System.EventHandler(this.botonVolverAlta_Click);
            // 
            // botonRehabilitar
            // 
            this.botonRehabilitar.Location = new System.Drawing.Point(21, 359);
            this.botonRehabilitar.Name = "botonRehabilitar";
            this.botonRehabilitar.Size = new System.Drawing.Size(140, 23);
            this.botonRehabilitar.TabIndex = 25;
            this.botonRehabilitar.Text = "Rehabilitar";
            this.botonRehabilitar.UseVisualStyleBackColor = true;
            this.botonRehabilitar.Click += new System.EventHandler(this.botonRehabilitar_Click);
            // 
            // AbmEmpresa
            // 
            this.AcceptButton = this.botonModificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.botonTerminado;
            this.ClientSize = new System.Drawing.Size(941, 407);
            this.ControlBox = false;
            this.Controls.Add(this.sinResultados);
            this.Controls.Add(this.BotonInhabilitar);
            this.Controls.Add(this.botonVolverAlta);
            this.Controls.Add(this.botonRehabilitar);
            this.Controls.Add(this.botonMostrar);
            this.Controls.Add(this.botonFiltrar);
            this.Controls.Add(this.botonTerminado);
            this.Controls.Add(this.botonBorrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AbmEmpresa";
            this.Text = "ABM Empresa";
            this.Load += new System.EventHandler(this.AbmEmpresa_Load);
            this.VisibleChanged += new System.EventHandler(this.AbmEmpresa_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonTerminado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonFiltrar;
        private System.Windows.Forms.Button botonBorrar;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonMostrar;
        private System.Windows.Forms.Label sinResultados;
        private System.Windows.Forms.Button BotonInhabilitar;
        private System.Windows.Forms.Button botonVolverAlta;
        private System.Windows.Forms.Button botonRehabilitar;
    }
}