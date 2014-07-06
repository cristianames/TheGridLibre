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
            sinResultados.Visible = false;
            if (DatosUsuario.tipoUsuario != 1) richTextBox1.Visible = false;
            actualizarGrilla();
            reiniciarBotonera();
        }

        private void actualizarGrilla()
        {
            string comando = "SELECT  top "+ ((paginaActual + 1)*tamanioPagina).ToString() +
                " p.Descripcion, " +  
                " (select top 1 x.Nombre from THE_GRID.Rubros_x_Publicacion y" + 
	            " inner join THE_GRID.Rubro x on (y.ID_Publicacion = p.ID_Publicacion"+
                " and x.ID_Rubro = y.ID_Rubro)) as 'Rubro Principal'," +
                " v.Nombre Visibilidad, t.Nombre 'Tipo de Publicación', " +
                " isnull( (select MAX(Monto_Oferta) from THE_GRID.Oferta o "+
                " where o.ID_Publicacion = p.ID_Publicacion) ,p.Precio) Precio, " +
                " p.Stock, p.ID_Publicacion " +
                " from THE_GRID.Publicacion p inner join THE_GRID.Visibilidad v"+ 
                " on (p.ID_Visibilidad = v.ID_Visibilidad) "+
                " inner join THE_GRID.Tipo_Publicacion t on t.ID_Tipo = p.ID_Tipo " +
                filtroRubro + "where (ID_Estado = 100 or ID_Estado = 102) " + //publicada o pausada 
                filtroPalabra +
                " Order By v.Precio_por_Publicar desc";
            dataGridView1.DataSource = TG.consultaPaginada(paginaActual,tamanioPagina,comando);
            textBox1.Text = (paginaActual + 1).ToString();
            richTextBox1.Text = comando;

            this.Refresh();
            comando = "SELECT  top 1 count(*)"+
                " from THE_GRID.Publicacion p inner join THE_GRID.Visibilidad v" +
                " on (p.ID_Visibilidad = v.ID_Visibilidad) " +
                filtroRubro + "where (ID_Estado = 100 or ID_Estado = 102) " +
                filtroPalabra;
            totalResultados = (int)TG.consultaEscalar(comando);
            paginas =  totalResultados/tamanioPagina;
            if (totalResultados % tamanioPagina == 0) paginas--;
            actualizarInfo();
        }

        private void actualizarInfo()
        {
            int limite = (paginaActual+1)*tamanioPagina, contador = 1;
            if (limite > totalResultados)limite = totalResultados;
            if (totalResultados == 0) contador = 0;
            InfoLabel.Text = "Mostrando pagina ";
            InfoLabel.Text += (paginaActual * tamanioPagina + contador).ToString();
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
                filtroRubro = "inner join THE_GRID.Rubros_x_Publicacion r on((";
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
            dataGridView1.Visible = true;
            sinResultados.Visible = false;
            if (totalResultados == 0) 
            {
                botonFinal.Enabled = false;
                botonNext.Enabled = false;
                dataGridView1.Visible = false;
                sinResultados.Visible = true;
            }
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubrosSeleccionados.rubros.Clear();
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
            (new Publicacion(this, publicacion)).Show();
            this.Visible = false;
        }

        private void Buscador_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) actualizarGrilla();
        }
    }
}
