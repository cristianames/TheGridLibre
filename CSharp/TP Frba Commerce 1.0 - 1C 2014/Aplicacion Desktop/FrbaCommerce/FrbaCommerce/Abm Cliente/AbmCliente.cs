using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.AbmCliente
{
    
    public partial class AbmCliente : FormGrid
    {
        private string comandoFiltro = "select * from TG.Cliente";
        public AbmCliente(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(569, 355);
            this.ventanaAnterior = anterior;
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
            int cantActivos = 0;
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text.Length > 0)
                    {
                        cantActivos++;
                    }
                }
            }
            if (cantActivos > 0) this.comandoFiltro += " where ";
            int cantAfectados = cantActivos;
            
            if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
            if (txtApellido.Text.Length > 0) {
                this.comandoFiltro += " Apellido like %"+ txtApellido.Text +"% ";
                cantAfectados--;
            }
        }

        
    }
}
