using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FormularioRespuesta : FormGrid
    {
        private bool estaRespondida;
        private DataRow datosPregunta;
        public FormularioRespuesta(FormGrid anterior, string pregunta)
        {
            InitializeComponent();
            botonResponder.Visible = false;
            infoRespuesta.Visible = false;
            this.ClientSize = new System.Drawing.Size(450, 265);
            ventanaAnterior = anterior;
            string comando = "select * from THE_GRID.Pregunta where ID_Pregunta = " + pregunta;
            datosPregunta = TG.realizarConsulta(comando).Rows[0];
            textoPregunta.Text = datosPregunta["Pregunta"].ToString();

            estaRespondida = !String.IsNullOrEmpty(datosPregunta["Fecha_Respuesta"].ToString());
            
            if (estaRespondida) textoRespuesta.Text = datosPregunta["Respuesta"].ToString();
            else
            {
                if (DatosUsuario.codigoRol == 3)
                {
                    botonResponder.Visible = true;
                    infoRespuesta.Visible = true;
                }
                else labelRespuesta.Text = "(Sin respuesta todavía)";
            }
            if (estaRespondida || DatosUsuario.codigoRol != 3) textoRespuesta.ReadOnly = true;
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void linkPublicacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            (new Publicacion(this,datosPregunta["ID_Publicacion"].ToString())).Show();

        }

        private void botonResponder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textoRespuesta.Text)) 
            {
                textoRespuesta.BackColor = Color.LightYellow;
                return;
            }
            string comando = "update THE_GRID.Pregunta set " +
                "Respuesta = '" + textoRespuesta.Text + "',"+
                "Fecha_Respuesta = convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss") + "') "+
                "where ID_Pregunta = " + datosPregunta["ID_Pregunta"].ToString();
            TG.realizarConsulta(comando);
            ventanaAnterior.Show();
            TG.ventanaEmergente("Respuesta enviada");
            this.Close();
        }
    }
}
