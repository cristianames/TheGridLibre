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
        private DataRow infoPublicacion;
        public Publicacion(FormGrid anterior, string _idPublicacion)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            this.idPublicacion = _idPublicacion;
            this.ClientSize = new System.Drawing.Size(601, 331);
            WarningLabel.Visible = false;
            string comando; 
                
            comando = @"select p.*, e.Nombre Estado, t.Nombre Tipo_Publicacion from THE_GRID.Publicacion p "+
                "inner join THE_GRID.Estado_Publicacion e on p.ID_Tipo = e.ID_Estado "+
                "inner join THE_GRID.Tipo_Publicacion t on p.ID_Tipo = t.ID_Tipo "+
                "where ID_Publicacion = " + idPublicacion;

            infoPublicacion = TG.realizarConsulta(comando).Rows[0];

            comando = @"select v.Nombre from THE_GRID.Visibilidad v inner join THE_GRID.Publicacion p
                      on(p.ID_Visibilidad = v.ID_Visibilidad)";

            infoDescripcion.Text = " Descripcion: ";
            infoDescripcion.Text += infoPublicacion["Descripcion"].ToString();
            infoDescripcion.Text += "\n\r Stock: ";
            infoDescripcion.Text += infoPublicacion["Stock"].ToString();
            infoDescripcion.Text += "\n Publicación.Tipo: ";
            infoDescripcion.Text += (string)TG.consultaEscalar(comando);

            if( !(bool)infoPublicacion["Permitir_Preguntas"] )
            {
                infoDescripcion.Text += "\n No se ";
                campoPregunta.Enabled = false;
                botonPreguntar.Enabled = false;
            }
            else infoDescripcion.Text += "\n Se ";
            infoDescripcion.Text += "permiten preguntas";
            infoDescripcion.Text += "\n Publicado el ";
            infoDescripcion.Text += infoPublicacion["Fecha_Inicio"].ToString();
            infoDescripcion.Text += "\n\r Rubros: ";
            comando = "select distinct r.Nombre from THE_GRID.Rubro r "+
                "inner join THE_GRID.Rubros_x_Publicacion rp on rp.ID_Rubro = r.ID_Rubro "+
                "and rp.ID_Publicacion = " + idPublicacion + " order by 1";
            List<string> rubros = TG.ObtenerListado(comando);
            foreach (string rubrito in rubros)
            {
                infoDescripcion.Text += "\n "+rubrito;
            }

            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            if (tipoPubli == "Subasta")
            {
                numericUpDown1.Visible = false;
                labelUnidades.Visible = false;
                botonComprar.Visible = false;
            }
            else 
            {
                montoOferta.Visible = false;
                botonOfertar.Visible = false;
                labelMonto.Visible = false;
                numericUpDown1.Maximum = Convert.ToInt32(infoPublicacion["Stock"]);
            }

            string estado = infoPublicacion["Estado"].ToString();
            if (estado == "Pausada") bloquearTodo();

            DateTime fechaVencimiento = Convert.ToDateTime(infoPublicacion["Fecha_Vencimiento"]);
            if (fechaVencimiento < TG.fechaDelSistema) bloquearTodo();

            actualizarInfo();
        }

        private void bloquearTodo()
        {
            botonComprar.Visible = false;
            botonOfertar.Visible = false;
            botonPreguntar.Enabled = false;
            numericUpDown1.Visible = false;
            montoOferta.Visible = false;
            labelMonto.Visible = false;
            labelUnidades.Visible = false;
            campoPregunta.Enabled = false;
            WarningLabel.Text = "Publicación no disponible";
            WarningLabel.Location = new System.Drawing.Point(372, 283);
            WarningLabel.Visible = true;
        }

        private void actualizarInfo()
        {
            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            string tipoPrecio = "Precio: $";
            string precio = infoPublicacion["Precio"].ToString();
            if (tipoPubli == "Subasta")
            {
                tipoPrecio = "Mejor precio hasta ahora: $";
                string comando = "select ISNULL( MAX(Monto_Oferta),'Sin ofertas') " +
                    "from THE_GRID.Oferta where ID_Publicacion = " + idPublicacion;
                if(TG.consultaEscalar(comando).ToString() != "Sin ofertas")
                precio = TG.consultaEscalar(comando).ToString();
            }
            infoPrecio.Text = " Tipo de publicacion : ";
            infoPrecio.Text += tipoPubli;
            infoPrecio.Text += ("\n\r "+ tipoPrecio);
            infoPrecio.Text += precio;
            infoPrecio.Text += "\n Total a pagar: ";
            infoPrecio.Text += calcularTotal();
        }

        private string calcularTotal()
        {
            string tipoPubli = infoPublicacion["Tipo_Publicacion"].ToString();
            if (tipoPubli == "Subasta" && !Validacion.esFloat(montoOferta.Text))
                return "...";

            string _precio = infoPublicacion["Precio"].ToString();
            if (tipoPubli == "Subasta") _precio = montoOferta.Text;
            
            float precio = Validacion.ToFloat(_precio);
            return (precio * (float)numericUpDown1.Value).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verificarSiEsElMismo()) return;
            
            if (String.IsNullOrEmpty(campoPregunta.Text))
            {
                campoPregunta.BackColor = Color.LightYellow;
                return;
            }
            string comando = "insert into THE_GRID.Pregunta" +
                "(ID_Publicacion,Pregunta,Fecha_Pregunta,ID_Comprador,ID_Vendedor)" +
                " values(" + idPublicacion.ToString() +
                ",'" + campoPregunta.Text + "'" +
                ",convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss") + "')" +
                "," + DatosUsuario.usuario.ToString() +
                "," + infoPublicacion["ID_Vendedor"] + ")";
            TG.realizarConsultaSinRetorno(comando);
            TG.ventanaEmergente("Pregunta realizada");
        }

        private bool verificarSiEsElMismo()
        {
            string idVendedor = infoPublicacion["ID_Vendedor"].ToString();
            string idComprador = DatosUsuario.usuario.ToString();
            if (idComprador == idVendedor)
            {
                TG.ventanaEmergente("No se puede realizar esta operación en tu propia publicación");
                return true;
            }
            return false;
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
            if (verificarSiEsElMismo()) return;
            if (!Validacion.esFloat(montoOferta.Text))
            {
                montoOferta.BackColor = Color.LightYellow;
                return;
            }
            montoOferta.BackColor = Color.White;
            string comando;
            comando = "insert into THE_GRID.Oferta(ID_Ofertante,ID_Publicacion,Concretada," +
            "Fecha_Oferta,Monto_Oferta) values("+
            DatosUsuario.usuario.ToString()+ "," +
            idPublicacion + ",0,"+
            "convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss")+"'),"+
            Validacion.conComa( montoOferta.Text) + ")";
            TG.realizarConsultaSinRetorno(comando);

            ventanaAnterior.Visible = true;
            TG.ventanaEmergente("¡Haz ofertado por el artículo en subasta!");
            this.Close();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            if (verificarSiEsElMismo()) return;
            string comando;
            /***********************************************************************
            comando = "select top 1 MAX(ID_Factura) + 1 from THE_GRID.Factura";
            string id_Factura = TG.consultaEscalar(comando).ToString();

            comando = "insert into THE_GRID.Factura(ID_Factura,ID_Publicacion) values("+
                id_Factura+","+idPublicacion+")";
            TG.realizarConsultaSinRetorno(comando);
            *******************************************************/
            comando = "insert into THE_GRID.Compra(ID_Publicacion,ID_Comprador," +
                "Item_Cantidad, Item_monto, Fecha, Pagada, Calif_Estrellas, Calif_Detalle) " +
                "values ("+idPublicacion+","+DatosUsuario.usuario.ToString()+
                ","+numericUpDown1.Value.ToString() + "," + 
                Validacion.conComa(infoPublicacion["Precio"].ToString()) +
                ",convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss") +
                "'),0,0,'')";
            TG.realizarConsultaSinRetorno(comando);

            int stock = Convert.ToInt32(infoPublicacion["Stock"]) - (int)numericUpDown1.Value;
            comando = "update THE_GRID.Publicacion set Stock ="+ stock.ToString()+
                "where ID_Publicacion = " + idPublicacion;
            TG.realizarConsultaSinRetorno(comando);

            if (stock == 0) 
            {
                comando = "update THE_GRID.Publicacion set ID_Estado = 103 " +
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

        private void Publicacion_Load(object sender, EventArgs e)
        {

        }

        
    }
}
