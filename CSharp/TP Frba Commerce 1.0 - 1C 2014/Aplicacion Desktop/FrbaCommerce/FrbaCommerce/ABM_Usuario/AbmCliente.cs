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
    public partial class AbmCliente : FormGrid
<<<<<<< HEAD
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
=======
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro;
>>>>>>> 840bb65adc572cfd7373f51f13c5e0b618948112
        private bool mostrarInhabilitados = false;

        public AbmCliente(FormGrid anterior)
        {
<<<<<<< HEAD
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(922, 394);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select c.* from TG.Cliente c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User and u.Inhabilitado = 0)";
            
        }

        private void actualizarGrilla() {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
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

        private void AbmCliente_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int usuario = Convert.ToInt32(dataGridView1["ID_User", filaSeleccionada].Value);
            (new Baja(this,usuario)).Show();
            this.Visible = false;
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
                comandoFiltro  = "select u.Inhabilitado, c.* from TG.Cliente c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User)";
                botonMostrar.Text = "Ocultar Inhabilitados";
            }
            actualizarGrilla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
=======
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(922, 394);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select c.* from TG.Cliente c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User and u.Inhabilitado = 0)";
            
        }

        private void actualizarGrilla() {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
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

        private void AbmCliente_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int usuario = Convert.ToInt32(dataGridView1["ID_User", filaSeleccionada].Value);
            (new Baja(this,usuario)).Show();
            this.Visible = false;
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
                comandoFiltro  = "select u.Inhabilitado, c.* from TG.Cliente c inner join TG.Usuario u " +
                "on(c.ID_User = u.ID_User)";
                botonMostrar.Text = "Ocultar Inhabilitados";
            }
            actualizarGrilla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
>>>>>>> 840bb65adc572cfd7373f51f13c5e0b618948112
        }

        
    }
}
