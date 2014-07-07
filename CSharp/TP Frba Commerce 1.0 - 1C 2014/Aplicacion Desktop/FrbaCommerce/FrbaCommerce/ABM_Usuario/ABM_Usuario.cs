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
    public partial class ABM_Usuario : FormGrid
    {
        private int filaSeleccionada;
        private string comandoGrilla, tipoUsuario = DatosUsuario.tipoUsuario;
        public ABM_Usuario(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(411, 335);
            ventanaAnterior = anterior;
            comandoGrilla = "select ID_User, 'GRID_'+ltrim(str(ID_User)) Username, isnull("+
                "(select top 1 r.Nombre from THE_GRID.Rol r inner join THE_GRID.Roles_x_Usuario rs "+
                "on rs.ID_Rol = r.ID_Rol and rs.ID_User = u.ID_User),'Sin rol') 'Rol principal', "+
                "t.Nombre Tipo, " +
                "Inhabilitado, Intentos, Primer_Ingreso, Datos_Correctos " +
                "from THE_GRID.Usuario u inner join THE_GRID.Tipo_Usuario t "+
                "on t.ID_Tipo = u.ID_Tipo order by 1 desc";
            refrescarGrilla();
        }

        private void Historial_Load(object sender, EventArgs e)
        {

        }


        private void refrescarGrilla()
        {
            DataTable resultado = TG.realizarConsulta(comandoGrilla);
            dataGridView1.DataSource = resultado;
            bool bandera = resultado.Rows.Count == 0;
            dataGridView1.Visible = !bandera;
            sinResultados.Visible = bandera;
        }


        private void atras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            string usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            (new Baja(this, usuario)).Show();
            this.Visible = false;
        }

        private void botonUsuario_Click(object sender, EventArgs e)
        {
            tipoUsuario = DatosUsuario.tipoUsuario;
            DatosUsuario.tipoUsuario = "0";
            (new Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void ABM_Usuario_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                DatosUsuario.tipoUsuario = tipoUsuario;
                refrescarGrilla();
            }
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            DatosUsuario.usuarioAux = DatosUsuario.usuario;
            DatosUsuario.usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            tipoUsuario = DatosUsuario.tipoUsuario;
            
            this.Visible = false;

            switch (dataGridView1["Tipo", filaSeleccionada].Value.ToString()) 
            {
                case "Cliente": DatosUsuario.tipoUsuario = "2";
                    break;
                case "Empresa": DatosUsuario.tipoUsuario = "3";
                    break;
                default:
                    (new Admin(this, false)).Show();
                    return;
            }
            (new Registro_de_Usuario(this)).Show();
            
        }

        private void botonAdmin_Click(object sender, EventArgs e)
        {
            DatosUsuario.usuarioAux = DatosUsuario.usuario;
            DatosUsuario.usuario = dataGridView1["ID_User", filaSeleccionada].Value.ToString();
            (new Admin(this, true)).Show();
            this.Visible = false;
        }
    }
}
