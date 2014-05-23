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
          
        }

       public void escribirMsg(string msg)
        {
            label1.Text = msg;
        }

        private void VentanaError_Load(object sender, EventArgs e)
        {

        }
    }
}
