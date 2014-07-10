using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Facturar_Publicaciones;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Facturas : FormGrid
    {
        private int filaSeleccionada;
        public Facturas(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(411, 335);
            sinResultados.Visible = false;
            ventanaAnterior = anterior;
            string comando = "select ID_Factura, Fecha, Total from THE_GRID.Factura "+
                "where ID_Vendedor = "+ DatosUsuario.usuario+" order by 1 desc";
            dataGridView1.DataSource = TG.realizarConsulta(comando);
            dataGridView1.Visible = seleccionar.Enabled = dataGridView1.RowCount != 0;
            sinResultados.Visible = dataGridView1.RowCount == 0;
        }
 
        private void atras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            string ID_Factura = dataGridView1["ID_Factura",filaSeleccionada].Value.ToString();
            (new Generada(this, ID_Factura)).Show();
            this.Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }
    }
}
