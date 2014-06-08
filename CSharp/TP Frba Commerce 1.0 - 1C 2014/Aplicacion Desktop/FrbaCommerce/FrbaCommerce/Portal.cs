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
            dgvGrilla.DataSource = TG.realizarConsulta("select top 10 * from gd_esquema.Maestra");
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Login.login loginFrm = new Login.login();
           loginFrm.Show();
           TG.elLogin = loginFrm;
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
            (new Registro_de_Usuario.txtTelEmpresa(this)).Show();
            this.Visible = false;
        }
     
    }

}
