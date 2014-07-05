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
    public partial class TipoPregunta : FormGrid
    {
        private int filaSeleccionada = 0;
        private bool pendientes = true, consultarPreguntas = true;
        public TipoPregunta(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(444, 351);
            
            //dice si se llamó al form para ver las preguntas hechas, 
            //o responder preguntas que le hicieron
            if (DatosUsuario.codigoRol == 3)
            {
                consultarPreguntas = false;
                titulo.Text = "Preguntas que me hicieron";
            }
            sinPreguntas.Visible = false;
            ventanaAnterior = anterior;
            recagarGrilla();
        }

        private void recagarGrilla()
        {
            string fuente = "Vendedor";
            if (consultarPreguntas) fuente = "Comprador";
            
            string where = "Respuesta is null ";
            if (!pendientes) where = "Respuesta is not null ";
            
            string comando = "select ID_Pregunta Cod, ID_Publicacion Cod_Publ, Pregunta, Fecha_Pregunta Fecha " +
                "from THE_GRID.Pregunta where " + where +
                "and ID_"+fuente+" = " + DatosUsuario.usuario.ToString();
            DataTable resultado = TG.realizarConsulta(comando);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultado;
            dataGridView1.Visible = true;
            sinPreguntas.Visible = false;
            if (resultado.Rows.Count == 0) {
                dataGridView1.Visible = false;
                sinPreguntas.Visible = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void Pendientes_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pendientes = radioButton1.Checked;
            recagarGrilla();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pendientes = !radioButton2.Checked;
            recagarGrilla();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonSeleccionar_Click_1(object sender, EventArgs e)
        {
            string idPregunta = dataGridView1.Rows[filaSeleccionada].Cells["Cod"].Value.ToString();
            (new FormularioRespuesta(this, idPregunta)).Show();
            this.Visible = false;
        }

        private void TipoPregunta_VisibleChanged(object sender, EventArgs e)
        {
            recagarGrilla();
        }

    }
}
