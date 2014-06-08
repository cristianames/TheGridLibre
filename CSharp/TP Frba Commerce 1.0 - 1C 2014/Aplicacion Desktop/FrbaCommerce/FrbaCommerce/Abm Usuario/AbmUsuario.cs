using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    
    public partial class Form1 : FormGrid
    {
        private string comandoFiltro = "select * from TG.Usuario";
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(569, 355);
            actualizarGrilla();
        }

        private void actualizarGrilla() {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonTerminado_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonBorrar_Click(object sender, EventArgs e)
        {
            //borra todos los campos del grupo
        }

        private void botonFiltrar_Click(object sender, EventArgs e)
        {
            //Hace el filtro
        }

        
    }
}
