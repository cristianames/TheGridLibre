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
    public partial class PublicacionesRendir : FormGrid
    {
        public PublicacionesRendir(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(451, 367);
            ventanaAnterior = anterior;
            
            dataGridView1.Enabled = false;
            warningLabel.Visible = false;

            
            recargarGrilla();
        }

        private void recargarGrilla()
        {
            string comando =
              @"select p.ID_Publicacion COD, v.Precio_Por_Publicar 'Precio por publicar', 
                SUM(c.Item_Cantidad+c.Item_Monto)*v.Porcentaje_Venta 'Comision por ventas',
                isnull((select contador from THE_GRID.Contador_Visibilidad_x_Vendedor cv
where cv.ID_Tipo = v.ID_Tipo and cv.ID_Vendedor = p.ID_Vendedor),0) Contador, v.ID_Tipo Tipo,
p.Fecha_Inicio Fecha
                from THE_GRID.Publicacion p 
                inner join THE_GRID.Visibilidad v on p.ID_Visibilidad = v.ID_Visibilidad
                inner join THE_GRID.Compra c on p.ID_Publicacion = c.ID_Publicacion
                where p.Fecha_Vencimiento <= 
                      convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss") +
                     "') and p.Facturada = 0 and p.ID_Vendedor = " + DatosUsuario.usuario +
             @" group by p.ID_Publicacion, p.ID_Vendedor, v.ID_Tipo, v.Precio_Por_Publicar,
v.Porcentaje_Venta,p.Fecha_Inicio
                order by p.Fecha_Inicio";
            DataTable datos = TG.realizarConsulta(comando);
            numericUpDown1.Maximum = datos.Rows.Count;

            dataGridView1.Visible =
                numericUpDown1.Visible =
                botonContinuar.Enabled = (datos.Rows.Count != 0);

            warningLabel.Visible = (datos.Rows.Count == 0);
            dataGridView1.DataSource = datos;
        }

        private void PublicacionesRendir_Load(object sender, EventArgs e)
        {

        }

        private void botonContinuar_Click(object sender, EventArgs e)
        {
            (new resumenYFormaDePago(this, (int)numericUpDown1.Value)).Show();
            this.Visible = false;
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            for (int i = 0; i < numericUpDown1.Value; i++ )
                dataGridView1.Rows[i].Selected = true;
        }

        private void PublicacionesRendir_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) recargarGrilla();
        }
    }
}
