namespace FrbaCommerce.Comprar_Ofertar
{
    partial class Buscador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscador));
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.botonSeleccionar = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonRubros = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRubros = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.botonPrincipio = new System.Windows.Forms.Button();
            this.botonPrev = new System.Windows.Forms.Button();
            this.botonNext = new System.Windows.Forms.Button();
            this.botonFinal = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.sinResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "¿Qué estás buscando?";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(170, 48);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(724, 21);
            this.txtFiltro.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(782, 297);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // botonSeleccionar
            // 
            this.botonSeleccionar.Location = new System.Drawing.Point(204, 342);
            this.botonSeleccionar.Name = "botonSeleccionar";
            this.botonSeleccionar.Size = new System.Drawing.Size(124, 32);
            this.botonSeleccionar.TabIndex = 6;
            this.botonSeleccionar.Text = "Seleccionar";
            this.botonSeleccionar.UseVisualStyleBackColor = true;
            this.botonSeleccionar.Click += new System.EventHandler(this.botonSeleccionar_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonAtras.Location = new System.Drawing.Point(35, 342);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(124, 32);
            this.botonAtras.TabIndex = 7;
            this.botonAtras.Text = "Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.button2_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(812, 96);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(124, 23);
            this.botonBuscar.TabIndex = 8;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonRubros
            // 
            this.botonRubros.Location = new System.Drawing.Point(10, 19);
            this.botonRubros.Name = "botonRubros";
            this.botonRubros.Size = new System.Drawing.Size(133, 23);
            this.botonRubros.TabIndex = 9;
            this.botonRubros.Text = "Rubros";
            this.botonRubros.UseVisualStyleBackColor = true;
            this.botonRubros.Click += new System.EventHandler(this.botonRubros_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRubros);
            this.groupBox1.Controls.Add(this.botonRubros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Location = new System.Drawing.Point(34, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            // 
            // txtRubros
            // 
            this.txtRubros.Location = new System.Drawing.Point(148, 20);
            this.txtRubros.Name = "txtRubros";
            this.txtRubros.ReadOnly = true;
            this.txtRubros.Size = new System.Drawing.Size(746, 21);
            this.txtRubros.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 125);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(902, 165);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // botonPrincipio
            // 
            this.botonPrincipio.Location = new System.Drawing.Point(35, 296);
            this.botonPrincipio.Name = "botonPrincipio";
            this.botonPrincipio.Size = new System.Drawing.Size(50, 23);
            this.botonPrincipio.TabIndex = 12;
            this.botonPrincipio.Text = "<<";
            this.botonPrincipio.UseVisualStyleBackColor = true;
            this.botonPrincipio.Click += new System.EventHandler(this.botonPrincipio_Click);
            // 
            // botonPrev
            // 
            this.botonPrev.Location = new System.Drawing.Point(92, 296);
            this.botonPrev.Name = "botonPrev";
            this.botonPrev.Size = new System.Drawing.Size(50, 23);
            this.botonPrev.TabIndex = 13;
            this.botonPrev.Text = "<";
            this.botonPrev.UseVisualStyleBackColor = true;
            this.botonPrev.Click += new System.EventHandler(this.botonPrev_Click);
            // 
            // botonNext
            // 
            this.botonNext.Location = new System.Drawing.Point(219, 296);
            this.botonNext.Name = "botonNext";
            this.botonNext.Size = new System.Drawing.Size(50, 23);
            this.botonNext.TabIndex = 14;
            this.botonNext.Text = ">";
            this.botonNext.UseVisualStyleBackColor = true;
            this.botonNext.Click += new System.EventHandler(this.botonNext_Click);
            // 
            // botonFinal
            // 
            this.botonFinal.Location = new System.Drawing.Point(278, 296);
            this.botonFinal.Name = "botonFinal";
            this.botonFinal.Size = new System.Drawing.Size(50, 23);
            this.botonFinal.TabIndex = 15;
            this.botonFinal.Text = ">>";
            this.botonFinal.UseVisualStyleBackColor = true;
            this.botonFinal.Click += new System.EventHandler(this.botonFinal_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 296);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(61, 21);
            this.textBox1.TabIndex = 16;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(665, 96);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(124, 23);
            this.botonLimpiar.TabIndex = 17;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(335, 296);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(439, 85);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(44, 99);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(225, 13);
            this.InfoLabel.TabIndex = 19;
            this.InfoLabel.Text = "Informacion del selector de pagina >:3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(371, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Resultados por página:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(534, 97);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // sinResultados
            // 
            this.sinResultados.AutoSize = true;
            this.sinResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinResultados.Location = new System.Drawing.Point(335, 174);
            this.sinResultados.Name = "sinResultados";
            this.sinResultados.Size = new System.Drawing.Size(284, 42);
            this.sinResultados.TabIndex = 22;
            this.sinResultados.Text = "Sin Resultados";
            // 
            // Buscador
            // 
            this.AcceptButton = this.botonSeleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.botonAtras;
            this.ClientSize = new System.Drawing.Size(1420, 688);
            this.Controls.Add(this.sinResultados);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.botonFinal);
            this.Controls.Add(this.botonNext);
            this.Controls.Add(this.botonPrev);
            this.Controls.Add(this.botonPrincipio);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonSeleccionar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Buscador";
            this.Text = "Buscador";
            this.Load += new System.EventHandler(this.Buscador_Load);
            this.EnabledChanged += new System.EventHandler(this.Buscador_EnabledChanged);
            this.VisibleChanged += new System.EventHandler(this.Buscador_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button botonSeleccionar;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonRubros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRubros;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button botonPrincipio;
        private System.Windows.Forms.Button botonPrev;
        private System.Windows.Forms.Button botonNext;
        private System.Windows.Forms.Button botonFinal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label sinResultados;
    }
}