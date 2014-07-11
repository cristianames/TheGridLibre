using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Usuario
{
    public partial class AbmRol : FormGrid

    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
        private bool recuperacion = false;
        public AbmRol(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(328, 337);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
            botonRestaurar.Visible = false;
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select ID_Rol, Nombre from THE_GRID.Rol where Inhabilitado = 0";
        }

        private void actualizarGrilla()
        {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //borra todos los campos del grupo
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox) tb.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reiniciarComando();

            //Hace el filtro

            int cantActivos = 0;
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox && tb.Text.Length > 0) cantActivos++;
            }

            if (cantActivos > 0) this.comandoFiltro += " where ";
            int cantAfectados = cantActivos;

            if (txtNombre.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Nombre like '%" + txtNombre.Text + "%'";
                cantAfectados--;
            }

            actualizarGrilla();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new AltaModificacion(this,0)).Show();
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            int rol = Convert.ToInt32(dataGridView1["ID_Rol", filaSeleccionada].Value);
            (new AltaModificacion(this, rol)).Show();
            this.Visible = false;
        }

        private void AbmRol_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void botonEliminar_Click_1(object sender, EventArgs e)
        {
            if (esElAdmin()) return;
            botonEliminar.Enabled = false;
            string comando, idRol = dataGridView1["ID_Rol", filaSeleccionada].Value.ToString();

            comando = "update THE_GRID.Rol set Inhabilitado = 1 " +
                " where ID_Rol =" + dataGridView1["ID_Rol", filaSeleccionada].Value.ToString();
            TG.realizarConsultaSinRetorno(comando);
            actualizarGrilla();
            dataGridView1.Enabled = true;
            botonEliminar.Enabled = true;
        }

        private bool esElAdmin()
        {
            int idRol = Convert.ToInt32(dataGridView1["ID_Rol", filaSeleccionada].Value);
            if (idRol == 1) {
                TG.ventanaEmergente("No tiene permisos para hacer esta accion");
                return true; }
            return false;
        }

        private void botonRecuperacion_Click(object sender, EventArgs e)
        {
            if (recuperacion)
            {
                recuperacion = false;
                reiniciarComando();
                botonRestaurar.Visible = false;
                botonRecuperacion.Text = "Recuperación";
            }
            else
            {
                recuperacion = true;
                dataGridView1.DataSource = null;
                comandoFiltro = "select * from THE_GRID.Rol";
                botonRestaurar.Visible = true;
                botonRecuperacion.Text = "Normal";
            }
            actualizarGrilla();
        }

        private void botonRestaurar_Click(object sender, EventArgs e)
        {
            botonRestaurar.Enabled = false;
            string comando, idRol = dataGridView1["ID_Rol", filaSeleccionada].Value.ToString();
            comando = "update THE_GRID.Rol set Inhabilitado = 0 where ID_Rol = " + idRol;
            TG.realizarConsultaSinRetorno(comando);
            botonRestaurar.Enabled = true;
            actualizarGrilla();
        }
    }
}
