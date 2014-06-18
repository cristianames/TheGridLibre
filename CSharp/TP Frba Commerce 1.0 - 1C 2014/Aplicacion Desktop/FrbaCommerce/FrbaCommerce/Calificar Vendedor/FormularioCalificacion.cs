using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FormularioCalificacion : FormGrid
    {
        private string ID_Publicacion, descripcion = "";
        public FormularioCalificacion(FormGrid anterior, string Publicacion)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(285, 266);
            ID_Publicacion = Publicacion;

            ventanaAnterior = anterior;

            string[] opciones = new string[6];
            opciones[0] = "Excelente!";
            opciones[1] = "Buena Onda";
            opciones[2] = "Nada Raro";
            opciones[3] = "Regular";
            opciones[4] = "Dejó que desear";
            opciones[5] = "Pésimo, no lo recomiendo";
            comboBox1.DataSource = opciones;
            comboBox1.SelectedIndex = 0;

            comboBox1.Enabled = false;
        }

        private void FormularioCalificacion_Load(object sender, EventArgs e)
        {

        }

        private void actualizarDescripcion()
        {
            if (radioButton1.Checked) descripcion = richTextBox1.Text;
            else descripcion = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarDescripcion();
            if (String.IsNullOrEmpty(descripcion))
            {
                richTextBox1.BackColor = Color.LightYellow;
                return;
            }
            else
                richTextBox1.BackColor = Color.White;

            string comando = "update THE_GRID.Compra set" +
                " Calif_Estrellas = " + estrellas.Value.ToString() + "," +
                " Calif_Detalle = '" + descripcion + "' where" +
                " ID_Comprador = " + DatosUsuario.usuario.ToString() + " and" +
                " ID_Publicacion = " + ID_Publicacion;
            TG.realizarConsultaSinRetorno(comando);
            volverAtras();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                richTextBox1.Enabled = true;
                comboBox1.Enabled = false;
            }
            else
            {
                richTextBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                richTextBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
            else
            {
                richTextBox1.Enabled = true;
                comboBox1.Enabled = false;
            }
        }
    }
}
