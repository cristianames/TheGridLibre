using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class AbmEmpresa : FormGrid
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
        public AbmEmpresa(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(900, 355);
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
            comandoFiltro = "select u.Inhabilitado, c.* from TG.Empresa c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User)";
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
            (new FrbaCommerce.Registro_de_Usuario.Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            botonEliminar.Enabled = false;
            dataGridView1.Enabled = false;
            int inhabilitado;
            if (Convert.ToBoolean(dataGridView1["Inhabilitado", filaSeleccionada].Value))
                inhabilitado = 0;
            else inhabilitado = 1;

            string comando = "update TG.Usuario set Inhabilitado = " + inhabilitado.ToString() +
                " where ID_User =" + dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            TG.realizarConsultaSinRetorno(comando);
            actualizarGrilla();
            dataGridView1.Enabled = true;
            filaSeleccionada = 0;
            botonEliminar.Enabled = true;
        }

        private void botonTerminado_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
