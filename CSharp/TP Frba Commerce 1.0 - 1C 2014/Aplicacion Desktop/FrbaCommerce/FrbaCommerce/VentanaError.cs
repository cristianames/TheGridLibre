using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FrbaCommerce
{
    partial class VentanaError : FormGrid
    {
        public VentanaError()
        {
            InitializeComponent();  
        }

        public void escribirMsg(string msg)
        {
            label1.Text = msg;
            this.Size = new Size( label1.Width + 50, 130);
            button1.Location = new System.Drawing.Point( (label1.Width + 50)/2 - 39 , 49);
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
