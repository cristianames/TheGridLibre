using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Login
{
    public partial class selectorRol : FormGrid
    {
        
        public selectorRol(FormGrid anterior)
        {
            InitializeComponent();
            this.ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(370, 170);
            string comando = "SELECT Nombre FROM THE_GRID.Rol R, THE_GRID.Roles_x_Usuario U" +
                " WHERE R.ID_Rol = U.ID_Rol AND U.Inhabilitado = 0 AND " +
                " U.ID_User = " + DatosUsuario.usuario.ToString();
            comboBox1.DataSource = TG.ObtenerListado(comando);
        }

        private void selectorRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosUsuario.nombreRol = comboBox1.SelectedItem.ToString();

            string comando = "select ID_Rol from THE_GRID.Rol " +
                "where Nombre = '" + comboBox1.SelectedItem.ToString() + "'";
            
            DataRow resultado = TG.realizarConsulta(comando).Rows[0];
            DatosUsuario.codigoRol = resultado["ID_Rol"].ToString();
            
            FrbaCommerce.Escritorio desk = new Escritorio(this);
            desk.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
