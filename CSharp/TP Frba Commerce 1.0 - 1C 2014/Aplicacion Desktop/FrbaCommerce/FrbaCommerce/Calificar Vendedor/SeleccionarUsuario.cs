using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class SeleccionarUsuario : FormGrid
    {
        private string ID_Publicacion;
        public SeleccionarUsuario(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(434, 273);

            ventanaAnterior = anterior;
            recargarGrilla();
            info.Visible = false;
        }

        private void recargarGrilla()
        {
            string comando = "select c.ID_Publicacion, p.Descripcion, " +
                   "p.ID_Vendedor from THE_GRID.Compra c, THE_GRID.Publicacion p where " +
                   "c.ID_Publicacion = p.ID_Publicacion and " +
                   "c.ID_Comprador = " + DatosUsuario.usuario.ToString() +
                   " and Calif_Estrellas = 0";
            dataGridView1.DataSource = TG.realizarConsulta(comando);

            botonSiguiente.Visible = dataGridView1.Visible = dataGridView1.RowCount != 0;
            info.Visible = dataGridView1.RowCount == 0;
        }

        private void SeleccionarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            (new Calificar_Vendedor.FormularioCalificacion(this,ID_Publicacion)).Show();
            this.Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int fila = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                fila = row.Index;
            }
            ID_Publicacion = dataGridView1.Rows[fila].Cells["ID_Publicacion"].Value.ToString();
        }

        private void SeleccionarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            recargarGrilla();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
