using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class Generada : FormGrid
    {
        public Generada(Form anterior, string ID_Factura)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(451, 367);
            ventanaAnterior = anterior;

            string comando = @"select * from THE_GRID.Factura where ID_Factura = " + ID_Factura;
            DataRow datos = TG.realizarConsulta(comando).Rows[0];
            labelFecha.Text += datos["Fecha"].ToString();
            txtTotal.Text = datos["Total"].ToString();
            numTarjeta.Text = datos["Nro_Tarjeta"].ToString();

            if (datos["Nro_Tarjeta"].ToString() != "0") 
                labelFormaPago.Text = "Forma de Pago: TARJETA";
            else label7.Visible = numTarjeta.Visible = false;
            
            comando = "select Item_Cantidad, Item_Monto from THE_GRID.RenglonFactura "+
                "where ID_Factura = "+ ID_Factura;
            dataGridView1.DataSource = TG.realizarConsulta(comando);
        }

        private void botonContinuar_Click(object sender, EventArgs e)
        {

        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void Generada_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
