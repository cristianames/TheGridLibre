using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Publicacion : FormGrid
    {
        private string idPublicacion;
        DataRow infoPublicacion;
        public Publicacion(FormGrid anterior, string _idPublicacion)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            this.idPublicacion = _idPublicacion;
            this.ClientSize = new System.Drawing.Size(601, 331);
            WarningLabel.Visible = false;
            string comando; 
                
            comando = @"select * from TG.Publicacion where ID_Publicacion = " + 
                      idPublicacion.ToString();

            infoPublicacion = TG.realizarConsulta(comando).Rows[0];

            comando = @"select v.Nombre from TG.Visibilidad v inner join TG.Publicacion p
                      on(p.ID_Visibilidad = v.ID_Visibilidad)";

            infoDescripcion.Text = "Descripcion: ";
            infoDescripcion.Text += infoPublicacion["Descripcion"].ToString();
            infoDescripcion.Text += "\n\r Stock: ";
            infoDescripcion.Text += infoPublicacion["Stock"].ToString();
            infoDescripcion.Text += "\n\r Publicación.Tipo: ";
            infoDescripcion.Text += (string)TG.consultaEscalar(comando);

            if( !(bool)infoPublicacion["Permitir_Preguntas"] )
            {
                infoDescripcion.Text += "\n\r No se ";
                campoPregunta.Enabled = false;
                botonPreguntar.Enabled = false;
            }
            else infoDescripcion.Text += "\n\r Se ";
            infoDescripcion.Text += "permiten preguntas";
            infoDescripcion.Text += "\n\r Publicado el ";
            infoDescripcion.Text += infoPublicacion["Fecha_Inicio"].ToString();

            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            if (String.Equals(tipoPubli, "Subasta"))
            {
                numericUpDown1.Enabled = false;
                botonComprar.Visible = false;
            }
            else 
            {
                montoOferta.Enabled = false;
                botonOfertar.Visible = false;
                numericUpDown1.Maximum = Convert.ToInt32(infoPublicacion["Stock"]);
            }

            string estado = infoPublicacion["Tipo_Publicacion"].ToString();
            if (String.Equals(estado,"Pausada")) bloquearTodo();

            DateTime fechaVencimiento = Convert.ToDateTime(infoPublicacion["Fecha_Vencimiento"]);
            if (fechaVencimiento < DateTime.Today) bloquearTodo();

            actualizarInfo();
        }

        private void bloquearTodo()
        {
            botonComprar.Visible = false;
            botonOfertar.Visible = false;
            botonPreguntar.Enabled = false;
            numericUpDown1.Enabled = false;
            montoOferta.Enabled = false;
            campoPregunta.Enabled = false;
            WarningLabel.Text = "Publicación no disponible";
            WarningLabel.Location = new System.Drawing.Point(372, 283);
            WarningLabel.Visible = true;
        }

        private void actualizarInfo()
        {
            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            string tipoPrecio = "Precio: $";
            if (String.Equals(tipoPubli, "Subasta")) tipoPrecio = "Precio Actual: $";
            infoPrecio.Text = "Tipo de publicacion : ";
            infoPrecio.Text += tipoPubli;
            infoPrecio.Text += ("\n\r "+ tipoPrecio);
            infoPrecio.Text += infoPublicacion["Precio"].ToString();
            infoPrecio.Text += "\n\r Total a pagar: ";
            infoPrecio.Text += calcularTotal();
        }

        private string calcularTotal()
        {
            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            if (String.Equals(tipoPubli, "Subasta") && !Validacion.esFloat(montoOferta.Text))
                return "...";

            string _precio = infoPublicacion["Precio"].ToString();
            if (String.Equals(tipoPubli, "Subasta")) _precio = montoOferta.Text;
            
            float precio = Validacion.ToFloat(_precio);
            return (precio * (float)numericUpDown1.Value).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(campoPregunta.Text))
            {
                campoPregunta.BackColor = Color.LightYellow;
                return;
            }
            string comando = "insert into TG.Pregunta(ID_Publicacion,Pregunta,Fecha_Pregunta)"+
                " values("+idPublicacion.ToString()+
                ",'"+campoPregunta.Text+
                ",convert(datetime,'" + DateTime.Today.ToString("yyyy-dd-MM hh:mm:ss")+ 
                "'))";
            TG.realizarConsultaSinRetorno(comando);
            TG.ventanaEmergente("Pregunta realizada");
            }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            actualizarInfo();
        }

        private void montoOferta_TextChanged(object sender, EventArgs e)
        {
            actualizarInfo();
        }

        private void botonOfertar_Click(object sender, EventArgs e)
        {
            if (!Validacion.esFloat(montoOferta.Text))
            {
                montoOferta.BackColor = Color.LightYellow;
                return;
            }
            montoOferta.BackColor = Color.White;
            string comando;
            comando = "insert into TG.Oferta(ID_Ofertante,ID_Publicacion,Concretada," +
            "Fecha_Oferta,Monto_Oferta) values("+
            DatosUsuario.usuario.ToString()+ "," +
            idPublicacion + ",0,"+
            "convert(datetime,'" + DateTime.Today.ToString("yyyy-dd-MM hh:mm:ss")+"'),"+
            Validacion.conComa( montoOferta.Text) + ")";
            TG.realizarConsultaSinRetorno(comando);

            ventanaAnterior.Visible = true;
            TG.ventanaEmergente("¡Haz ofertado por el artículo en subasta!");
            this.Close();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            string comando;

            comando = "select top 1 MAX(ID_Factura) + 1 from TG.Factura";
            string id_Factura = TG.consultaEscalar(comando).ToString();

            comando = "insert into TG.Factura(ID_Factura,ID_Publicacion) values("+
                id_Factura+","+idPublicacion+")";
            TG.realizarConsultaSinRetorno(comando);
            
            comando = "insert into TG.Compra(ID_Factura,ID_Publicacion,ID_Comprador," +
                "Item_Cantidad, Item_monto, Fecha, Pagada, Calif_Estrellas, Calif_Detalle) " +
                "values ("+id_Factura+","+idPublicacion+","+DatosUsuario.usuario.ToString()+
                ","+numericUpDown1.Value.ToString() + "," + 
                Validacion.conComa(infoPublicacion["Precio"].ToString()) +
                ",convert(datetime,'" + DateTime.Today.ToString("yyyy-dd-MM hh:mm:ss") +
                "'),0,0,'')";
            TG.realizarConsultaSinRetorno(comando);

            int stock = Convert.ToInt32(infoPublicacion["Stock"]) - (int)numericUpDown1.Value;
            comando = "update TG.Publicacion set Stock ="+ stock.ToString()+
                "where ID_Publicacion = " + idPublicacion;
            TG.realizarConsultaSinRetorno(comando);

            if (stock == 0) 
            {
                comando = "update TG.Publicacion set Estado = 'Finalizada' " +
                "where ID_Publicacion = " + idPublicacion;
                TG.realizarConsultaSinRetorno(comando);
            }

            ventanaAnterior.Visible = true;
            TG.ventanaEmergente("¡Haz comprado el artículo!");
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        
    }
}
