using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
  

namespace FrbaCommerce.Login
{
    public partial class login : FormGridTerminal
    {
        
        public login()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(340, 105);
        }



        private void seleccionarRol(int usuario)
        {
            FrbaCommerce.Login.selectorRol seleccionFrm = new selectorRol(usuario);
            seleccionFrm.Show();
            this.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void submitActions() 
        {
            if (userTextbox.Text == "" || passTextBox.Text == "")
            {
                ventanaEmergente("Campos incompletos");
                return;
            }
            
            SqlConnection myConnection = TG.conectar();
            using (SqlCommand cmd = new SqlCommand("TG.login", myConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user;
                user = new SqlParameter("@user", SqlDbType.Int);
                user.Value = Convert.ToInt32(userTextbox.Text);
                user.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(user);

                SqlParameter pass;
                pass = new SqlParameter("@pass", SqlDbType.NVarChar);
                pass.Value = TG.encriptar(passTextBox.Text);
                pass.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(pass);

                SqlParameter protocolo;
                protocolo = new SqlParameter("@protocolo", SqlDbType.Int);
                protocolo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(protocolo);

                cmd.ExecuteNonQuery();
                myConnection.Close();

                if (Convert.ToInt32(protocolo.Value) == 1) ventanaEmergente("Usuario NO Encontrado o pass incorrecto");// usuario no encontrado
                else if (Convert.ToInt32(protocolo.Value) == 2) ventanaEmergente("Usuario Inhabilitado!");
                else if (Convert.ToInt32(protocolo.Value) == 3) ventanaEmergente("Usuario NO Encontrado o pass incorrecto");// pass incorrecto
                else if (Convert.ToInt32(protocolo.Value) == 4) ventanaEmergente("Inhabilitado por poner mal el pass 3 veces!");
                else if (Convert.ToInt32(protocolo.Value) == 5) ventanaEmergente("No hay roles disponibles para este usuario");
                else if (primerIngreso(Convert.ToInt32(userTextbox.Text)))
                {
                    FrbaCommerce.Login.cambioPass cambioDePass = new cambioPass(this, Convert.ToInt32(userTextbox.Text));
                    cambioDePass.Show();
                    this.Visible = false;
                }
                else seleccionarRol(Convert.ToInt32(userTextbox.Text));

            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submitActions();           
        }

        private bool primerIngreso(int usuario)
        {           
           SqlConnection myConnection = TG.conectar();
           SqlCommand myCommand = new SqlCommand("select Primer_Ingreso from TG.Usuario where ID_User = "+ 
               usuario.ToString() ,myConnection);
           SqlDataReader consulta = consulta = myCommand.ExecuteReader();
           consulta.Read();
           bool resultado = Convert.ToBoolean(consulta["Primer_Ingreso"]);
           myConnection.Close();
           return resultado;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }
    }
}

