﻿using System;
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
            SqlDataReader consulta = null;
            SqlDataReader update = null;

            SqlConnection myConnection = new SqlConnection(@"Data Source=localhost\SQLSERVER2008;" +
                                      "user id=gd;" +
                                      "password=gd2014;" +
                                      "Initial Catalog=GD1C2014; " +
                                      "Integrated Security=True");
            myConnection.Open();
            
           SqlCommand myCommand = new SqlCommand("select ID_User,Inhabilitado,Intentos, case when Pass ='" 
               + encriptar(passTextBox.Text) +
               "' then 1 else 0 end as Pass_Correcto from TG.Usuario where 'Grid_' + convert(varchar,ID_User) = '" + 
               userTextbox.Text + "'",myConnection); 
           //Busca en la BD si existe ese Username y si puso bien el Pass

           consulta = myCommand.ExecuteReader();

           if (consulta.HasRows)    //Pregunta si la consulta devolvio algun resultado
            {
                consulta.Read();
                if (string.Equals(consulta["Pass_Correcto"].ToString(), "1"))//El usuario es valido y el pass tmb
                {

                    if (string.Equals(consulta["Inhabilitado"].ToString(), "False"))//Pregunta si el usuario esta inhabilitado
                    {
                        string Username = consulta["ID_User"].ToString();
                        myCommand = new SqlCommand(@"update TG.Usuario set Intentos_Fallidos=0 where ID_User ='" + Username + "'", myConnection);
                        consulta.Close();
                        update = myCommand.ExecuteReader();
                        ventanaEmergente("EXITO");
                    }
                    else ventanaEmergente("Usuario inhabilitado");
                }
                else  //Usuario valido pero contraseña invalida 
                {
                    ventanaEmergente("Nombre de Usuario inexistente o Contraseña equivocada");
                    myCommand.Parameters.Clear();
                    int intentosFallidos = Convert.ToInt32(consulta["Intentos"].ToString());
                    intentosFallidos++;


                    if (intentosFallidos >= 3) //Si este es su tercer intento fallido, actualiza el estado y bloquea al usuario,sino, solamenta suma uno a sus intentos fallidos
                    {

                        string Intentos_Fallidos = intentosFallidos.ToString();
                        string Username = consulta["ID_User"].ToString();
                        myCommand = new SqlCommand(@"update TG.Usuario set Intentos = " + Intentos_Fallidos + ", Inhabilitado='True' where ID_User = '" + Username + "'", myConnection);
                        consulta.Close();
                        update = myCommand.ExecuteReader();
                    }
                    else
                    {
                        string Intentos_Fallidos = intentosFallidos.ToString();
                        string Username = consulta["ID_User"].ToString();
                        myCommand = new SqlCommand(@"update TG.Usuario set Intentos = " + Intentos_Fallidos + " where ID_User = '" + Username + "'", myConnection);
                        consulta.Close();
                        update = myCommand.ExecuteReader();
                       
                    }
                    
                }
            }
            else ventanaEmergente("Nombre de Usuario inexistente o Contraseña equivocada");
            
            myConnection.Close();
        }
    }
}
