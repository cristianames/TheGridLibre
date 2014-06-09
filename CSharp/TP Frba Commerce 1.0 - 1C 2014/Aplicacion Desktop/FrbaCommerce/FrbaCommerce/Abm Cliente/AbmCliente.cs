using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.AbmCliente
{
    public partial class AbmCliente : FormGrid
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
        public AbmCliente(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(900, 355);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select u.Inhabilitado, c.* from TG.Cliente c inner join TG.Usuario u "+
                "on(c.ID_User = u.ID_User)";
        }

        private void actualizarGrilla() {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonTerminado_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonBorrar_Click(object sender, EventArgs e)
        {
            //borra todos los campos del grupo
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox) tb.Text = "";
            }
        }

        private void botonFiltrar_Click(object sender, EventArgs e)
        {
            reiniciarComando();
            
            //Hace el filtro
            if (txtNroDoc.Text.Length > 0 && !TG.esNumerico(txtNroDoc.Text))
            {
                txtNroDoc.BackColor = Color.LightYellow;
                return;
            }
            else txtNroDoc.BackColor = Color.White;
            
            int cantActivos = 0;
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox && tb.Text.Length > 0) cantActivos++;
            }
            if (comboBox1.SelectedItem != null) cantActivos++;

            if (cantActivos > 0) this.comandoFiltro += " where ";
            int cantAfectados = cantActivos;
            
            if (txtApellido.Text.Length > 0) {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Apellido like '%"+ txtApellido.Text +"%'";
                cantAfectados--;
            }

            if (txtNombre.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Nombre like '%" + txtNombre.Text + "%'";
                cantAfectados--;
            }

            if (txtApellido.Text.Length > 0) {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Apellido like '%"+ txtApellido.Text +"%'";
                cantAfectados--;
            }

            if (txtMail.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Mail like '%" + txtMail.Text + "%'";
                cantAfectados--;
            }

            if (comboBox1.SelectedItem != null)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Tipo_Documento = '" + comboBox1.Text+"'";
                cantAfectados--;
            }

            if (txtNroDoc.Text.Length > 0)
            {
                if (cantActivos > cantAfectados) this.comandoFiltro += " and ";
                this.comandoFiltro += " Documento = " + txtNroDoc.Text;
                cantAfectados--;
            }
            actualizarGrilla();
            
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            DatosUsuario.usuarioAux = DatosUsuario.usuario;
            DatosUsuario.usuario = Convert.ToInt32(dataGridView1["ID_User", filaSeleccionada].Value);
            DatosUsuario.tipoUsuarioModif = 2;
            (new FrbaCommerce.Registro_de_Usuario.Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
        }

        private void AbmCliente_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int inhabilitado;
            if (Convert.ToBoolean(dataGridView1["Inhabilitado", filaSeleccionada].Value))
                inhabilitado = 0;
            else inhabilitado = 1;

            string comando = "update TG.Usuario set Inhabilitado = " + inhabilitado.ToString() +
                " where ID_User =" + dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            TG.realizarConsultaSinRetorno(comando);
            actualizarGrilla();
        }

        
    }
}
