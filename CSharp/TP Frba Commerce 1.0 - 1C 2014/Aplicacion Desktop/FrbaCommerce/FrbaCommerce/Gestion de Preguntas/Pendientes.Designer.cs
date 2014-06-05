namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class Pendientes
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
            this.gridPendientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPendientes
            // 
            this.gridPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendientes.Location = new System.Drawing.Point(28, 95);
            this.gridPendientes.Name = "gridPendientes";
            this.gridPendientes.Size = new System.Drawing.Size(240, 150);
            this.gridPendientes.TabIndex = 0;
            // 
            // Pendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.gridPendientes);
            this.Name = "Pendientes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Pendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPendientes;

    }
}