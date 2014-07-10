using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FrbaCommerce
{
    partial class VentanaError : Form
    {
        public VentanaError()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.Boton_Advertencia_1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void escribirMsg(string msg)
        {
            label1.Text = msg;

            int anchoMensaje = label1.Width;
            if (label1.Width < button1.Width)
            {
                anchoMensaje = button1.Width;
                label1.Location = new System.Drawing.Point(25 + button1.Width/2 - label1.Width / 2, 25);
            }
            this.Size = new Size( anchoMensaje + 50, 90);
            button1.Location = new System.Drawing.Point(25 + anchoMensaje / 2 - button1.Width/2, 49);
        }

        private void VentanaError_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
