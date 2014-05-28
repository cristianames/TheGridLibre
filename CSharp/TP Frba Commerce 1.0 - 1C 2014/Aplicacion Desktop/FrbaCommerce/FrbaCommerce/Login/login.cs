using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;  

namespace FrbaCommerce.Login
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

      /*private string encriptar(string input)
        {                   
                    SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();  
  
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);  
                    byte[] hashedBytes = provider.ComputeHash(inputBytes);  

                    StringBuilder output = new StringBuilder();  
  
                    for (int i = 0; i < hashedBytes.Length; i++)  
                    output.Append(hashedBytes[i].ToString("x2").ToLower());  
  
                    return output.ToString();  
                  
        }*//////// Esta version de la funcion no anda en WinXP weon

        static string encriptar(string input)
        {
            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(input);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha256Str += cryString[i].ToString("x2").ToLower();
            }
            return sha256Str;
        }


        private void ventanaEmergente(string msg)
        {
            FrbaCommerce.VentanaError error = new VentanaError();
            error.escribirMsg(msg);
            error.Show();
           
        }

        private void seleccionarRol(int usuario)
        {
            FrbaCommerce.Login.selectorRol seleccionFrm = new selectorRol(usuario);
            seleccionFrm.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection myConnection = TG_Connect.conectar();

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
                pass.Value = encriptar(passTextBox.Text);
                pass.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(pass);

                SqlParameter protocolo;
                protocolo = new SqlParameter("@protocolo", SqlDbType.Int);
                protocolo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(protocolo);

                cmd.ExecuteNonQuery();
                myConnection.Close();

                if (Convert.ToInt32(protocolo.Value) == 1) ventanaEmergente("Usuario NO Encontrado!");
                else if (Convert.ToInt32(protocolo.Value) == 2) ventanaEmergente("Usuario Inhabilitado!");
                else if (Convert.ToInt32(protocolo.Value) == 3) ventanaEmergente("Pass Incorrecto!");
                else if (Convert.ToInt32(protocolo.Value) == 4) ventanaEmergente("Inhabilitado por poner mal el pass mas de 2 veces!");
                else if (Convert.ToInt32(protocolo.Value) == 5) ventanaEmergente("No hay roles disponibles para este usuario");
                else seleccionarRol( Convert.ToInt32(userTextbox.Text) );
            
            }
            
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
