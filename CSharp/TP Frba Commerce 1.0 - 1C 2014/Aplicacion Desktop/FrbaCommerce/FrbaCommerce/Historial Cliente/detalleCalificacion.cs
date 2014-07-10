using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class detalleCalificacion : FormGrid
    {
        private string idPublicacion;
        public detalleCalificacion(Form anterior, string idCompra)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(411, 335);
            ventanaAnterior = anterior;
            string comando = "select ID_Publicacion, ID_Comprador, Calif_Estrellas, "+
                "Calif_Detalle from THE_GRID.Compra where ID_Operacion ="+idCompra;
            DataRow datos = TG.realizarConsulta(comando).Rows[0];
            calificador.Text += datos["ID_Comprador"].ToString();
            estrellas.Text += datos["Calif_estrellas"].ToString();
            idPublicacion = datos["ID_Publicacion"].ToString();
            richTextBox1.Text = datos["Calif_Detalle"].ToString();
        }

        private void detalleCalificacion_Load(object sender, EventArgs e)
        {

        }

        private void atras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void linkPublicacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            (new Publicacion(this, idPublicacion)).Show();
        }
    }
}
