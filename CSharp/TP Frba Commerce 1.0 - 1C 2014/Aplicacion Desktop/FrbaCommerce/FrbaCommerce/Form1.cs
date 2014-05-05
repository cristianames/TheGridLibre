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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
           /* SqlDataReader myReader = null;

            SqlConnection myConnection = new SqlConnection(@"Data Source=localhost\SQLSERVER2008;" +
                                      "user id=gd;" +
                                      "password=gd2014;" +
                                      "Initial Catalog=GD1C2014; " +
                                      "Integrated Security=True");
         myConnection.Open();
            SqlCommand myCommand = new SqlCommand("select top 10 Publ_Cli_Piso, Factura_Fecha, 3 as tres from gd_esquema.Maestra where Publ_Cli_Piso is not null and Factura_Fecha is not null;", myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                textBox1.Text = textBox1.Text+(myReader["Publ_Cli_Piso"].ToString() + " - " +
                                  myReader["Factura_Fecha"].ToString() + " - " +
                                  myReader["tres"].ToString() +
                                  "\r\n");
            
                 }
       //     myConnection.Close();


            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
           FrbaCommerce.Login.Form1 loginFrm = new FrbaCommerce.Login.Form1();
           loginFrm.Show();
           this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
    }

}
