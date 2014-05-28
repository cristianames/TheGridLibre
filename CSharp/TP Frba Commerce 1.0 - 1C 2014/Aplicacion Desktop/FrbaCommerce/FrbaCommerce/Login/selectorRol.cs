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
    public partial class selectorRol : Form
    {

        public static List<string> ObtenerRoles(int usuario)
        {
            List<string> _lista = new List<string>();

            SqlConnection conexion = TG_Connect.conectar();
            SqlCommand _comando = new SqlCommand("SELECT Nombre FROM TG.Rol R, TG.Roles_x_Usuario U" +
                " WHERE R.ID_Rol = U.ID_Rol AND U.Inhabilitado = 0 AND " + 
                " U.ID_User = " + usuario.ToString(), conexion);
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                _lista.Add(_reader.GetString(0));
            }
            conexion.Close();
            return _lista;
        }
        
        public selectorRol(int usuario)
        {
            InitializeComponent();
            comboBox1.DataSource = ObtenerRoles(usuario);
        }

        private void selectorRol_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
