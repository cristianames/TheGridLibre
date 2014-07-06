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
    public partial class detalleCompraOferta : FormGrid
    {
        private string idPublicacion;
        private string idCompra = "";
        public detalleCompraOferta(FormGrid anterior, string codigo, bool esCompra)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(411, 335);
            ventanaAnterior = anterior;
            string comando;

            if (esCompra)
                comando = "select c.ID_Publicacion, c.Item_Cantidad, "+
                    "c.Item_Monto Monto, c.Fecha, p.Descripcion " +
                    "from THE_GRID.Compra c inner join THE_GRID.Publicacion p "+
                    "on c.ID_Publicacion = p.ID_Publicacion and c.ID_Operacion =" + codigo;
            else
                comando = "select o.ID_Publicacion, o.Fecha_Oferta Fecha, " +
                    "o.Monto_Oferta Monto, o.Concretada, p.Descripcion " +
                    "from THE_GRID.Oferta o inner join THE_GRID.Publicacion p " +
                    "on o.ID_Publicacion = p.ID_Publicacion and o.ID_Oferta =" + codigo;

            DataRow datos = TG.realizarConsulta(comando).Rows[0];
            idPublicacion = datos["ID_Publicacion"].ToString();
            richTextBox1.Text = datos["Descripcion"].ToString();
            compraLink.Visible = false;
            calificacionLink.Visible = false;

            if (esCompra)
            {
                fecha.Text += "de Compra: ";
                precio.Text += "unitario: $";
                cantidad.Text += datos["Item_Cantidad"].ToString();
                gano.Visible = false;
                calificacionLink.Location = compraLink.Location;
                calificacionLink.Visible = true;
                idCompra = codigo;
            }
            else
            {
                fecha.Text += "de Oferta: ";
                precio.Text += "ofertado: $";
                cantidad.Visible = false;
                gano.Location = cantidad.Location;
                string YesOrNo = "NO";
                if (Convert.ToBoolean(datos["Concretada"]))
                {
                    YesOrNo = "SI";
                    compraLink.Visible = true;
                }
                gano.Text += YesOrNo;
            }
            fecha.Text += datos["Fecha"].ToString();
            precio.Text += datos["Monto"].ToString();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string comando = "select top 1 ID_Operacion from THE_GRID.Compra "+
                "where ID_Publicacion = " + idPublicacion;
            string idOperacion = (string)TG.consultaEscalar(comando).ToString();
            (new detalleCompraOferta(this, idOperacion, true)).Show();
            this.Visible = false;
        }

        private void calificacionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!String.IsNullOrEmpty(idCompra)) 
            {
                (new detalleCalificacion(this, idCompra)).Show();
                this.Visible = false;
            }
        }
    }
}
