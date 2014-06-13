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
    public partial class AbmEmpresa : FormGrid
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
        private bool mostrarInhabilitados = false;
        public AbmEmpresa(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(922, 394);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
        }

        private void botonBorrar_Click(object sender, EventArgs e)
        {
            //borra todos los campos del grupo
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox) tb.Text = "";
            }
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select c.* from TG.Empresa c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User and u.Inhabilitado = 0)";
        }

        private void actualizarGrilla()
        {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
        }

        private void botonFiltrar_Click(object sender, EventArgs e)
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

            if (txtMail.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Mail like '%" + txtMail.Text + "%'";
                cantAfectados--;
            }

            if (txtRazonSocial.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Razon_Social like '%" + txtRazonSocial.Text + "%'";
                cantAfectados--;
            }

            if (txtMail.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " CUIT = '" + txtCuit.Text + "'";
                cantAfectados--;
            }
            actualizarGrilla();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            DatosUsuario.usuarioAux = DatosUsuario.usuario;
            DatosUsuario.usuario = Convert.ToInt32(dataGridView1["ID_User", filaSeleccionada].Value);
            DatosUsuario.tipoUsuarioModif = 3;
            (new FrbaCommerce.ABM_Usuario.Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int usuario = Convert.ToInt32(dataGridView1["ID_User", filaSeleccionada].Value);
            (new Baja(this, usuario)).Show();
            this.Visible = false;
        }

        private void botonTerminado_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void AbmEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void AbmEmpresa_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void botonMostrar_Click(object sender, EventArgs e)
        {
            if (mostrarInhabilitados)
            {
                mostrarInhabilitados = false;
                reiniciarComando();
                botonMostrar.Text = "Mostrar Inhabilitados";
            }
            else
            {
                mostrarInhabilitados = true;
                dataGridView1.DataSource = null;
                comandoFiltro = "select u.Inhabilitado, c.* from TG.Empresa c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User)";
                botonMostrar.Text = "Ocultar Inhabilitados";
            }
            actualizarGrilla();
        }
    }
}
