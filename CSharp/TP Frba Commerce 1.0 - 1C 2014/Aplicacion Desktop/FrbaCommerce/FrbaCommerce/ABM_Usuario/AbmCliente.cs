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
    {
        private int filaSeleccionada = 0;
        private string comandoFiltro, comandoFiltroInhabilitados;
        private bool mostrarInhabilitados = false;

        public AbmCliente(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(922, 394);
            this.ventanaAnterior = anterior;
            reiniciarComando();
            actualizarGrilla();
            botonRehabilitar.Visible = botonVolverAlta.Visible = false;
            comandoFiltroInhabilitados = "select u.Inhabilitado, u.Eliminado, c.* from THE_GRID.Cliente c " +
                    "inner join THE_GRID.Usuario u on(c.ID_User = u.ID_User " +
                    "and (Inhabilitado = 1 or Eliminado = 1))";
        }

        private void reiniciarComando()
        {
            comandoFiltro = "select c.* from THE_GRID.Cliente c inner join THE_GRID.Usuario u " +
                "on(c.ID_User = u.ID_User and u.Inhabilitado = 0 and Eliminado = 0)";
            
        }

        private void actualizarGrilla() {

            dataGridView1.DataSource = TG.realizarConsulta(comandoFiltro);
            sinResultados.Visible = dataGridView1.RowCount == 0;
            dataGridView1.Visible = 
                botonEliminar.Enabled =
                BotonInhabilitar.Enabled = 
                botonModificar.Enabled = 
                botonVolverAlta.Enabled =
                botonRehabilitar.Enabled =
                dataGridView1.RowCount != 0;    
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
            if (mostrarInhabilitados) comandoFiltro = comandoFiltroInhabilitados;
            else reiniciarComando();
            
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
            DatosUsuario.usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            DatosUsuario.tipoUsuarioModif = "2";
            (new FrbaCommerce.ABM_Usuario.Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void AbmCliente_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            string usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
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
                botonVolverAlta.Visible = botonRehabilitar.Visible = false;
            }
            else
            {
                mostrarInhabilitados = true;
                dataGridView1.DataSource = null;
                comandoFiltro = comandoFiltroInhabilitados;
                botonVolverAlta.Visible = botonRehabilitar.Visible = true;
            }
            actualizarGrilla();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void botonRehabilitar_Click(object sender, EventArgs e)
        {
            bool eliminado = Convert.ToBoolean(dataGridView1["Eliminado",filaSeleccionada].Value);
           
            if (eliminado)
            {
                TG.ventanaEmergente("No puede rehabilitar un usuario eliminado. Utilice 'Volver a Dar de Alta'");
                return;
            }

            string comando = "update THE_GRID.Usuario set Inhabilitado = 0 where ID_User = "+
                dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            TG.ventanaEmergente("Usuario rehabilitado. Recuerde que sus publicaciones siguen pausadas");

        }

        private void botonVolverAlta_Click(object sender, EventArgs e)
        {
            bool eliminado = Convert.ToBoolean(dataGridView1["Eliminado", filaSeleccionada].Value);
            if (!eliminado)
            {
                TG.ventanaEmergente("Esta funcion es solo para usuarios eliminados");
                return;
            }
            string comando = "INSERT INTO THE_GRID.Usuario(Pass,Inhabilitado,Eliminado,ID_Tipo,Intentos,Primer_Ingreso)" +
                    "VALUES ('" + TG.encriptar("w23e") + "',0,0,2,0,1)";
            TG.realizarConsultaSinRetorno(comando);
            string usuario = TG.consultaEscalar("select max(ID_User) from THE_GRID.Usuario").ToString();
            TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) VALUES(" + usuario + ",3,0)");
            TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) VALUES(" + usuario + ",2,0)");
            comando = "insert into THE_GRID.Cliente "+
                "select "+usuario+", Nombre, Apellido, Tipo_Documento, Documento, Mail, Telefono, "+
                "Fecha_Nacimiento, Nro_Tarjeta, Calle, Nro_Calle, Nro_Piso, Departamento, "+
                "Localidad, Cod_Postal, Ciudad from THE_GRID.Cliente where ID_User = "+
                dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            TG.realizarConsultaSinRetorno(comando);
            TG.ventanaEmergente("Los datos del cliente han pasado a un nuevo usuario. Nuevo username: GRID_"+usuario);
        }

        private void BotonInhabilitar_Click(object sender, EventArgs e)
        {
            string usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            (new Inhabilitacion(this, usuario)).Show();
            this.Visible = false;
        }
    }
}
