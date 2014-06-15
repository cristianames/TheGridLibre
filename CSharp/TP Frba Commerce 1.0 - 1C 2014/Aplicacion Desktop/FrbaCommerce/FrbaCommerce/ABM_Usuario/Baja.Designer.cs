namespace FrbaCommerce.ABM_Usuario
{
    partial class Baja
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
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Está a punto de dar de baja un usuario.";
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(71, 67);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botonConfirmar.TabIndex = 1;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.button1_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(197, 67);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 2;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Esta operaciòn no se puede deshacer. ¿Desea continuar?";
            // 
            // Baja
            // 
            this.AcceptButton = this.botonConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(842, 328);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.label1);
            this.Name = "Baja";
            this.Text = "Baja";
            this.Load += new System.EventHandler(this.Baja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label2;
    }
}