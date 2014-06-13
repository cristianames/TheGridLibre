using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        DataTable datosConsultaVisibilidad;

        public GenerarPublicacion()
        {
            InitializeComponent();

        }

        private void radioSubasta_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = false;
            numericUpDown1.Enabled = false;
            labelPrecio.Text = "Precio incial:";
        }

        private void radioCompra_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            numericUpDown1.Enabled = true;
            labelPrecio.Text = "Precio:";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelInicio.Text = "Fecha de inicio:" + DateTime.Today.ToString();
            //labelVencimiento.Text;

            DateTime fechaVencimiento = DateTime.Today.AddDays(Convert.ToInt32(datosConsultaVisibilidad.Rows[comboBox1.SelectedIndex]["Duracion"].ToString()));
            labelVencimiento.Text = "Fecha de vencimiento:" + fechaVencimiento.ToString(); 
            
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            string comando = "select Nombre from TG.Visibilidad";
            comboBox1.DataSource = TG.ObtenerListado(comando);
            comando = @"select * from TG.Visibilidad where Inhabilitado=0";            
            datosConsultaVisibilidad = TG.realizarConsulta(comando);
            // datosConsultaVisibilidad.Rows[3]["Nombre"].ToString();
        }
    }
}
