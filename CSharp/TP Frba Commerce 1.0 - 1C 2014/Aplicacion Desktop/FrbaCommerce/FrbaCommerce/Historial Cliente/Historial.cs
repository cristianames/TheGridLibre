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
    public partial class Historial : FormGrid
    {
        private int filaSeleccionada;
        private string comandoGrilla;
        public Historial(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(411, 335);
            ventanaAnterior = anterior;
            refrescar.Visible = false;
            sinResultados.Visible = botonFacturas.Visible = false;
            /* Calificaciones
             * Compras
             * Ofertas
             */
            List<String> lista = new List<String>();
            lista.Add("Calificaciones");

            if (DatosUsuario.codigoRol == "3")
            {
                otorgadas.Enabled = false;
                botonFacturas.Visible = true;
            }
            else
            {
                lista.Add("Compras");
                lista.Add("Ofertas");
            }

            comboBox1.DataSource = lista;
            comboBox1.SelectedIndex = 0;
            refrescar_Click(null, null);
        }

        private void Historial_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bandera = true;
            if (comboBox1.SelectedIndex != 0) bandera = false;
            recibidas.Visible = otorgadas.Visible = bandera;

            dataGridView1.Enabled = seleccionar.Enabled = false;
            refrescar.Visible = true;
        }

        private void refrescar_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) 
            {
                case 0: if (recibidas.Checked)
                        comandoGrilla = "select c.ID_Operacion COD, "+
                    "Calif_Estrellas Estrellas, Calif_Detalle Detalle, " +
                    "p.Fecha_Inicio 'Inicio Publicacion' " +
                    "from THE_GRID.Compra c inner join THE_GRID.Publicacion p on " +
                    "c.ID_Publicacion = p.ID_Publicacion and p.ID_Vendedor = " +
                    DatosUsuario.usuario.ToString()+" where Calif_Estrellas > 0 "+ 
                    "order by p.Fecha_Inicio desc";

                    else comandoGrilla = "select ID_Operacion COD, " +
                    "Calif_Estrellas Estrellas, Calif_Detalle Detalle, " +
                    "Fecha 'Fecha de Compra' " +
                    "from THE_GRID.Compra where ID_Comprador = " +
                    DatosUsuario.usuario.ToString() + " and Calif_Estrellas > 0 " +
                    "order by Fecha desc";
                    break;
                case 1: comandoGrilla = "select ID_Operacion COD, "+
                    "Item_Cantidad Cantidad, Item_Monto 'Precio Unitario',Fecha "+
                    "from THE_GRID.Compra where ID_Comprador ="+DatosUsuario.usuario.ToString()+
                    "order by Fecha desc";
                    break;
                case 2: comandoGrilla = "select ID_Oferta COD, "+
                    "Monto_Oferta 'Monto Ofertado', Fecha_Oferta Fecha, Concretada "+
                    "from THE_GRID.Oferta where ID_Ofertante ="+DatosUsuario.usuario.ToString()+
                    "order by Fecha_Oferta desc";
                    break;
            }
            refrescarGrilla();
            seleccionar.Enabled = true;
            refrescar.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void refrescarGrilla()
        {
            DataTable resultado = TG.realizarConsulta(comandoGrilla);
            dataGridView1.DataSource = resultado;
            bool bandera = resultado.Rows.Count == 0;
            dataGridView1.Visible = !bandera;
            sinResultados.Visible = bandera;
        }

        private void recibidas_CheckedChanged(object sender, EventArgs e)
        {
            refrescar_Click(null, null);
        }

        private void atras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            string COD = dataGridView1.Rows[filaSeleccionada].Cells["COD"].Value.ToString();
            switch (comboBox1.SelectedIndex)
            {
                case 0: 
                    (new detalleCalificacion(this, COD)).Show();
                    break;
                case 1:
                    (new detalleCompraOferta(this, COD, true)).Show();
                    break;
                case 2:
                    (new detalleCompraOferta(this, COD, false)).Show();
                    break;
            }
            this.Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void botonFacturas_Click(object sender, EventArgs e)
        {
            (new Facturas(this)).Show();
            this.Visible = false;
        }
    }
}
