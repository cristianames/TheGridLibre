using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Buscador : FormGrid
    {
        private string publicacion = "", filtroPalabra = "", filtroRubro = "";
        private int paginas = 0, paginaActual = 0, totalResultados = 0, tamanioPagina = 6;
        public Buscador(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(820, 396);
            ventanaAnterior = anterior;
            numericUpDown1.Value = tamanioPagina;
            actualizarGrilla();
            reiniciarBotonera();
        }

        private void actualizarGrilla()
        {
            string comando = "SELECT  top "+ ((paginaActual + 1)*tamanioPagina).ToString() +
                " p.Descripcion, " +  
                " (select top 1 x.Nombre from TG.Rubros_x_Publicacion y" + 
	            " inner join TG.Rubro x on (y.ID_Publicacion = p.ID_Publicacion"+
                " and x.ID_Rubro = y.ID_Rubro)) as 'Rubro Principal'," +
                " v.Nombre Visibilidad, p.Tipo_Publicacion, " +
                " p.Precio, p.Stock, p.ID_Publicacion " +
                " from TG.Publicacion p inner join TG.Visibilidad v"+ 
                " on (p.ID_Visibilidad = v.ID_Visibilidad) "+
                filtroRubro + "where Estado = 'Publicada' or Estado = 'Pausada'" + 
                filtroPalabra +
                " Order By v.Precio_por_Publicar desc";
            dataGridView1.DataSource = TG.consultaPaginada(paginaActual,tamanioPagina,comando);
            textBox1.Text = (paginaActual + 1).ToString();
            richTextBox1.Text = comando;

            this.Refresh();
            comando = "SELECT  top 1 count(*)"+
                " from TG.Publicacion p inner join TG.Visibilidad v" +
                " on (p.ID_Visibilidad = v.ID_Visibilidad) " +
                filtroRubro + "where Estado = 'Publicada' " +
                filtroPalabra;
            totalResultados = (int)TG.consultaEscalar(comando);
            paginas =  totalResultados/tamanioPagina;
            actualizarInfo();
        }

        private void actualizarInfo()
        {
            int limite = (paginaActual+1)*tamanioPagina;
            if (limite > totalResultados) limite = totalResultados;
            InfoLabel.Text = "Mostrando pagina ";
            InfoLabel.Text += (paginaActual * tamanioPagina + 1).ToString();
            InfoLabel.Text += " a ";
            InfoLabel.Text += limite.ToString();
            InfoLabel.Text += " de ";
            InfoLabel.Text += totalResultados.ToString();
            InfoLabel.Text += " resultados";
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            if (!String.IsNullOrEmpty(txtFiltro.Text))
                filtroPalabra = "and p.Descripcion like '%" + txtFiltro.Text + "%'";
            else filtroPalabra = "";
            if (!String.IsNullOrEmpty(txtRubros.Text))
            {
                filtroRubro = "inner join TG.Rubros_x_Publicacion r on((";
                int i = 0, cant = RubrosSeleccionados.rubros.Count;
                foreach (string rubro in RubrosSeleccionados.rubros)
                {
                    if (i > 0) filtroRubro += " or ";
                    string idRubro = RubrosSeleccionados.ObtenerRubro(rubro).ToString();
                    filtroRubro += "r.ID_Rubro = ";
                    filtroRubro += idRubro;
                    i++;
                }
                filtroRubro += ") and r.ID_Publicacion = p.ID_Publicacion)";
            }
            else filtroRubro = "";
            actualizarGrilla();
            reiniciarBotonera();
        }

        private void reiniciarBotonera()
        {
            botonPrev.Enabled = false;
            botonPrincipio.Enabled = false;
            botonFinal.Enabled = true;
            botonNext.Enabled = true;
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void botonPrincipio_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            botonPrincipio.Enabled = false;
            botonPrev.Enabled = false;
            botonNext.Enabled = true;
            botonFinal.Enabled = true;
            actualizarGrilla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int filaSeleccionada = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
            publicacion = dataGridView1.Rows[filaSeleccionada].Cells["ID_Publicacion"].Value.ToString();
        }

        private void botonNext_Click(object sender, EventArgs e)
        {
            if (paginaActual <= paginas) paginaActual++;
            else return;
            botonPrev.Enabled = true;
            botonPrincipio.Enabled = true;
            if (paginaActual == paginas)
            {
                botonFinal.Enabled = false;
                botonNext.Enabled = false;
            }
            actualizarGrilla();
        }

        private void botonPrev_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0) paginaActual--;
            else return;
            botonNext.Enabled = true;
            botonFinal.Enabled = true;
            if (paginaActual == 0)
            {
                botonPrev.Enabled = false;
                botonPrincipio.Enabled = false;
            }
            actualizarGrilla();
        }

        private void botonFinal_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            botonPrincipio.Enabled = true;
            botonPrev.Enabled = true;
            botonNext.Enabled = false;
            botonFinal.Enabled = false;
            actualizarGrilla();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            RubrosSeleccionados.rubros.Clear();
            txtFiltro.Text = "";
            txtRubros.Text = "";
            filtroRubro = "";
            filtroPalabra = "";
            paginaActual = 0;
            actualizarGrilla();
            reiniciarBotonera();
        }

        private void botonRubros_Click(object sender, EventArgs e)
        {
            new Comprar_Ofertar.FiltroRubros(this).Show();
            this.Enabled = false;
        }

        private void Buscador_EnabledChanged(object sender, EventArgs e)
        {
            txtRubros.Text = "";
            if (RubrosSeleccionados.rubros.Count > 0)
                foreach (string rubro in RubrosSeleccionados.rubros)
                {
                    txtRubros.Text = txtRubros.Text + "<" + rubro + ">";
                }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tamanioPagina = (int)numericUpDown1.Value;
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Publicacion(this, publicacion)).Show();
        }

        private void Buscador_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }
    }
}
