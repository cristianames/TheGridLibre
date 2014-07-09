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
    public partial class resumenYFormaDePago : FormGrid
    {
        public resumenYFormaDePago(Form anterior, int cantPublicaciones)
        {
            InitializeComponent();
            //427; 150
            this.ClientSize = new System.Drawing.Size(451, 367);
            ventanaAnterior = anterior;
            efectivo_CheckedChanged(null, null);

            string comando =
               "select top " + cantPublicaciones.ToString() +
             @" p.ID_Publicacion COD, p.Descripcion, p.Precio,
                v.Precio_Por_Publicar, v.Porcentaje_Venta * 100 'Porcentaje_Venta', v.Nombre,
                cast(SUM(c.Item_Cantidad * c.Item_Monto) * v.Porcentaje_Venta as decimal(18,2)) 'Subtotal',
                cast(SUM(c.Item_Cantidad * c.Item_Monto) * v.Porcentaje_Venta + v.Precio_Por_Publicar as decimal(18,2)) 'Final',
                p.Fecha_Inicio Fecha
                from THE_GRID.Publicacion p inner join THE_GRID.Estado_Publicacion ep on 
                p.ID_Estado = ep.ID_Estado and ep.Nombre = 'Publicada' 
                and p.Facturada = 0 and p.ID_Vendedor = " + DatosUsuario.usuario +
             @" inner join THE_GRID.Visibilidad v on p.ID_Visibilidad = v.ID_Visibilidad 
                inner join THE_GRID.Compra c on p.ID_Publicacion = c.ID_Publicacion
                group by p.ID_Publicacion, p.Descripcion, p.Precio, v.Precio_Por_Publicar,
                v.Nombre, v.Porcentaje_Venta,p.Fecha_Inicio
                order by p.Fecha_Inicio";
            DataTable publicaciones = TG.realizarConsulta(comando), compras;
            int j;
            float montoFinal = 0;

            for (int i = 0; i < publicaciones.Rows.Count; i++)
            {
                richTextBox1.Text += "--Datos de la Publicación "+(i+1).ToString()+"--";
                richTextBox1.Text += "\n   . Publicacion Nro: ";
                richTextBox1.Text += publicaciones.Rows[i]["COD"].ToString();
                richTextBox1.Text += "\n   . Precio unitario/inicial: $";
                richTextBox1.Text += publicaciones.Rows[i]["Precio"].ToString();
                richTextBox1.Text += "\n   . Descripcion: ";
                richTextBox1.Text += publicaciones.Rows[i]["Descripcion"].ToString();
                richTextBox1.Text += "\n   . Fecha de inicio: ";
                richTextBox1.Text += publicaciones.Rows[i]["Fecha"].ToString();
                richTextBox1.Text += "\n   .";
                richTextBox1.Text += "\n--Visibilidad de la Publicación "+(i+1).ToString()+"--";
                richTextBox1.Text += "\n   . Tipo: ";
                richTextBox1.Text += publicaciones.Rows[i]["Nombre"].ToString();
                richTextBox1.Text += "\n   . Precio por publicar: $";
                richTextBox1.Text += publicaciones.Rows[i]["Precio_Por_Publicar"].ToString();
                richTextBox1.Text += "\n   . Comisión (porcentaje de cada venta): ";
                richTextBox1.Text += publicaciones.Rows[i]["Porcentaje_Venta"].ToString()+@"%";
                richTextBox1.Text += "\n   . ";
                richTextBox1.Text += "\n--Compras en la Publicación " + (i + 1).ToString() + "--";
                
                comando =
                @"select ID_Operacion, Item_Cantidad, Item_Monto, Fecha,
                cast(Item_Cantidad*Item_Monto*Porcentaje_Venta as decimal(18,2)) 'Subtotal'
                from THE_GRID.Compra c
                inner join THE_GRID.Publicacion p on p.ID_Publicacion = c.ID_Publicacion
                inner join THE_GRID.Visibilidad v on p.ID_Visibilidad = v.ID_Visibilidad 
                where p.ID_Publicacion = " + publicaciones.Rows[i]["COD"].ToString() +
                " order by 3";
                compras = TG.realizarConsulta(comando);
                for (j = 0; j < compras.Rows.Count; j++)
                {
                    richTextBox1.Text += "\n     [Datos de la compra "+(j+1).ToString()+"]";
                    richTextBox1.Text += "\n     . Compra Nro: ";
                    richTextBox1.Text += compras.Rows[j]["ID_Operacion"].ToString();
                    richTextBox1.Text += "\n     . Cantidad comprada: ";
                    richTextBox1.Text += compras.Rows[j]["Item_Cantidad"].ToString();
                    richTextBox1.Text += "\n     . Precio unitario: $";
                    richTextBox1.Text += compras.Rows[j]["Item_Monto"].ToString();
                    richTextBox1.Text += "\n     . Fecha de compra: ";
                    richTextBox1.Text += compras.Rows[j]["Fecha"].ToString();
                    richTextBox1.Text += "\n     . Comisión de la compra: $";
                    richTextBox1.Text += compras.Rows[j]["Subtotal"].ToString();
                    richTextBox1.Text += "\n";
                }
                richTextBox1.Text += "\n  Comisiones de todas las compras: $";
                richTextBox1.Text += publicaciones.Rows[i]["Subtotal"].ToString();
                richTextBox1.Text += "\n  Precio por publicar: $";
                richTextBox1.Text += publicaciones.Rows[i]["Precio_Por_Publicar"].ToString();
                richTextBox1.Text += "\n  Subtotal: $";
                richTextBox1.Text += publicaciones.Rows[i]["Final"].ToString();
                richTextBox1.Text += "\n\n  --------------------------------------\n\n";

                montoFinal += Validacion.ToFloat(publicaciones.Rows[i]["Final"].ToString());
            }
            monto.Text = "$" + montoFinal.ToString();
        }
        

        private void PublicacionesRendir_Load(object sender, EventArgs e)
        {

        }

        private void botonContinuar_Click(object sender, EventArgs e)
        {

        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void efectivo_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = !efectivo.Checked;
            if (efectivo.Checked) richTextBox1.Size = new System.Drawing.Size(427, 256);
            else richTextBox1.Size = new System.Drawing.Size(427, 150);
        }

    }
}
