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
    public partial class FormularioRespuesta : FormGrid
    {
        private DataRow datosPregunta;
        public FormularioRespuesta(FormGrid anterior, string pregunta)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(589, 308);
            ventanaAnterior = anterior;
            string comando = "select * from THE_GRID.Pregunta where ID_Pregunta = "+pregunta;
            datosPregunta = TG.realizarConsulta(comando).Rows[0];
            textoPregunta.Text = datosPregunta["Pregunta"].ToString();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
