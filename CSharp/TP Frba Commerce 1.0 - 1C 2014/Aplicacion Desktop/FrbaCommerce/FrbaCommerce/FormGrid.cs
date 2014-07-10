using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FrbaCommerce
{
    public class FormGrid : Form
    {
        protected Form ventanaAnterior;
        protected FormGrid()
        {
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            
            this.Load += new System.EventHandler(cosasAlInicio);
            // Display the form as a modal dialog box.
            //this.ShowDialog();
        }

        private void cosasAlInicio(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Dock = DockStyle.Fill;

            //Carga el fondo
            this.BackgroundImage = Properties.Resources.Fondo_Azul;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //Ajusta la barra de titulo
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    ((Label)control).ForeColor = Color.Silver;
                    ((Label)control).BackColor = Color.Transparent;
                }
                if (control is RadioButton)
                {
                    ((RadioButton)control).BackColor = Color.Transparent;
                }
                if (control is GroupBox)
                {
                    ((GroupBox)control).ForeColor = Color.Silver;
                    ((GroupBox)control).BackColor = Color.Transparent;
                    foreach (Control subcontrol in ((GroupBox)control).Controls)
                    {
                        if (subcontrol is Button)
                            ((Button)subcontrol).ForeColor = Color.Black;
                        if (subcontrol is Button)
                        {
                            ((Button)subcontrol).BackgroundImage = Properties.Resources.Boton_Azul;
                            ((Button)subcontrol).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            ((Button)subcontrol).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        }
                    }
                }
                if (control is Button)
                {
                    ((Button)control).BackgroundImage = Properties.Resources.Boton_Azul;
                    ((Button)control).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    ((Button)control).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                }
                if (control is RichTextBox)
                {
                    ((RichTextBox)control).ForeColor = Color.Silver;
                    ((RichTextBox)control).BackColor = Color.SteelBlue;
                    ((RichTextBox)control).Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                if (control is ListBox)
                {
                    ((ListBox)control).BackColor = Color.LightSteelBlue;
                }
                if (control is ComboBox)
                {
                    ((ComboBox)control).BackColor = Color.LightSteelBlue;
                }
                if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).BackColor = Color.LightSteelBlue;
                }

            }
        }

        private void ManejadorCierre(object sender, EventArgs e)
        {
            // Todas estas boludeces ocurren cuando se cierra un form de clase FromGrid
            TG.ventanaEmergente("NO ME CIERRO NADA");
        }

        protected void volverAtras()
        {
            this.ventanaAnterior.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGrid
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGrid";
            this.Load += new System.EventHandler(this.FormGrid_Load);
            this.ResumeLayout(false);

        }

        private void FormGrid_Load(object sender, EventArgs e)
        {

        }
    }

    public class FormGridTerminal : FormGrid
    {
        protected FormGridTerminal()
        {
            this.FormClosed += ManejadorCierre;
            this.ControlBox = true;
        }

        private void ManejadorCierre(object sender, EventArgs e)
        {
            //Si me cierran, cierro todo.
            System.Environment.Exit(0);
        }
    }
}
