using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Rubro
{
    public partial class ABMRubro : Form
    {
        public ABMRubro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listaRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();

            SqlConnection conexion = TG.conectar();
            SqlCommand comando = new SqlCommand("SELECT Nombre FROM TG.Rubro", conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader.GetString(0));
            }
            conexion.Close();
            return lista;
        }
    }
}
