using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Login
{
    public partial class selectorRol : FormGrid
    {
        
        public selectorRol(FormGrid anterior)
        {
            InitializeComponent();
            this.ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(370, 170);
            string comando = "SELECT Nombre FROM TG.Rol R, TG.Roles_x_Usuario U" +
                " WHERE R.ID_Rol = U.ID_Rol AND U.Inhabilitado = 0 AND " +
                " U.ID_User = " + TG.usuario.ToString();
            comboBox1.DataSource = TG.ObtenerListado(comando);
        }

        private void selectorRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TG.ventanaEmergente(comboBox1.SelectedItem.ToString());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
