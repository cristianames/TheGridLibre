using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Portal : FormGridTerminal
    {
        public Portal()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(285, 270);
        }
        private void cargarDatos()
        {
            SqlConnection con = TG.conectar();
            SqlDataAdapter daGrilla = new SqlDataAdapter("select top 10 * from gd_esquema.Maestra",con);
            DataSet dsGrilla = new DataSet();
            daGrilla.Fill(dsGrilla, "gd_esquema.Maestra");
            dgvGrilla.DataSource = dsGrilla.Tables[0];
            //dgvGrilla.DataMember = "gd_esquema.Maestra";
            //textBox1.Text = "SEP";
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
           FrbaCommerce.Login.login loginFrm = new FrbaCommerce.Login.login();
           loginFrm.Show();
           this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrbaCommerce.Registro_de_Usuario.RegistroUsuario registroFrm = new FrbaCommerce.Registro_de_Usuario.RegistroUsuario();
            registroFrm.Show();
            this.Visible = false;

        }     
    }

}
