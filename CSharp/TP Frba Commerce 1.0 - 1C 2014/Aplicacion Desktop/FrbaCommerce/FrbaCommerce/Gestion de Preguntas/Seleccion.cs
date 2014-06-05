using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class Seleccion : FormGrid
    {
        public Seleccion()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(202, 150);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrbaCommerce.Gestion_de_Preguntas.Pendientes pendientes = new Pendientes();
            pendientes.Visible = true;
            this.Close(); 
            //volver inacesible el formulario de funcionalidades
        }
    }
}
