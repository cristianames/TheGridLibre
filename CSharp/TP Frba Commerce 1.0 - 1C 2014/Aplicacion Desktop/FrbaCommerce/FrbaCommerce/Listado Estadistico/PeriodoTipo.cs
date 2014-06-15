using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class PeriodoTipo : FormGrid
    {
        private string nombreVista = "";
        private string criterioMaestro = "";
        private string comandoConsulta = "";
        public PeriodoTipo(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(614, 361);
            ventanaAnterior = anterior;

            string comando = "select distinct CONVERT ( nvarchar(5) , YEAR(Fecha_Inicio) ) from TG.Publicacion order by 1 asc";
            anio.DataSource = TG.ObtenerListado(comando);
            anio.SelectedIndex = 0;

            comando = "select distinct Visibilidad from TG.Estad_Productos";
            visibilidad.DataSource = TG.ObtenerListado(comando);
            visibilidad.SelectedIndex = 0;

            groupBox2.Visible = false;

            string[] trimestres = new string[4];
            trimestres[0] = "Enero-Febrero-Marzo";
            trimestres[1] = "Abril-Mayo-Junio";
            trimestres[2] = "Julio-Agosto-Septiembre";
            trimestres[3] = "Octubre-Noviembre-Diciembre";
            trimestre.DataSource = trimestres;
            trimestre.SelectedIndex = 0;

            string[] criterios = new string[4];
            criterios[0] = "Vendedores/+Articulos no vendidos";
            criterios[1] = "Vendedores/Mayor facturación";
            criterios[2] = "Vendedores/Mayores calificaciones";
            criterios[3] = "Clientes/+Publicaciones sin calificar";
            criterio.DataSource = criterios;
            criterio.SelectedIndex = 0;

            resetearComando();
            recargarGrilla();
        }

        void recargarGrilla() 
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TG.realizarConsulta(comandoConsulta);
        }

        private void criterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            label6.Text = "El TOP5 de ";
            
            switch (criterio.SelectedIndex) 
            {
                case 0:
                    nombreVista = "Estad_Productos";
                    criterioMaestro = "Mes, Precio_Visibilidad desc, Cantidad desc, Visibilidad";
                    label6.Text += "Vendedores con más Articulos no vendidos";
                    groupBox2.Visible = true;
                    break;
                case 1:
                    nombreVista = "Estad_Facturacion";
                    criterioMaestro = "Facturacion desc";
                    label6.Text += "Vendedores con mayor Facturación";
                    break;
                case 2:
                    nombreVista = "Estad_Calificaciones";
                    criterioMaestro = "Calificacion desc";
                    label6.Text += "Vendedores con mayores Calificaciones";
                    break;
                case 3:
                    nombreVista = "Estad_Calificar";
                    criterioMaestro = "Cantidad desc";
                    label6.Text += "Clientes con más Compras sin calificar";
                    break;
            }
            resetearComando();
        }

        void resetearComando() 
        {
            comandoConsulta = "select top 5 * from TG." + nombreVista + 
              " where Anio = " + anio.Text+ 
              " and Trimestre = "+ ((int)trimestre.SelectedIndex +1).ToString() +
              " order by " + criterioMaestro;
        }

        void resetearComandoFiltro() 
        {
            int mes = trimestre.SelectedIndex * 3 + mes_anio.SelectedIndex + 1;
            comandoConsulta = "select top 5 * from TG." + nombreVista +
            " where Anio = " + anio.Text + " and mes = " + mes.ToString() +
            " and Visibilidad = '" + visibilidad.SelectedItem.ToString() + "'" +
            " order by " + criterioMaestro;
        }

        void actualizarFiltros() 
        {
            string[] meses = new string[3];
            switch (trimestre.SelectedIndex) 
            { 
                case 0:
                meses[0] = "Enero - ";
                meses[1] = "Febrero - ";
                meses[2] = "Marzo - ";
                break;
                case 1:
                meses[0] = "Abril - ";
                meses[1] = "Mayo - ";
                meses[2] = "Junio - ";
                break;
                case 2:
                meses[0] = "Julio - ";
                meses[1] = "Agosto - ";
                meses[2] = "Septiembre - ";
                break;
                case 3:
                meses[0] = "Octubre - ";
                meses[1] = "Noviembre - ";
                meses[2] = "Diciembre - ";
                break;
            }
            for (int i = 0; i < 3; i++) meses[i] += anio.SelectedItem.ToString();
            mes_anio.DataSource = meses;
        }

        private void anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarFiltros();
        }

        private void trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarFiltros();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            resetearComando();
            recargarGrilla();
        }

        private void botonFiltrar_Click(object sender, EventArgs e)
        {
            resetearComandoFiltro();
            recargarGrilla();
        }
    }
}
