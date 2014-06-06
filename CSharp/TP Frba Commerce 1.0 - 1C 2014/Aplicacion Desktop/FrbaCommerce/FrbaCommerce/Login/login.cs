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
            this.ClientSize = new System.Drawing.Size(340, 140);
        }

        private void submitActions() 
        {
            if (userTextbox.Text == "" || passTextBox.Text == "")
            {
                TG.ventanaEmergente("Campos incompletos");
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

                int protocol = Convert.ToInt32(protocolo.Value);

                     if (protocol == 1) TG.ventanaEmergente("Usuario NO Encontrado o pass incorrecto");// usuario no encontrado
                else if (protocol == 2) TG.ventanaEmergente("Usuario Inhabilitado!");
                else if (protocol == 3) TG.ventanaEmergente("Usuario NO Encontrado o pass incorrecto");// pass incorrecto
                else if (protocol == 4) TG.ventanaEmergente("Inhabilitado por poner mal el pass 3 veces!");
                else if (protocol == 5) TG.ventanaEmergente("No hay roles disponibles para este usuario");
                else if (primerIngreso(Convert.ToInt32(userTextbox.Text)))
                {
                    DatosUsuario.usuario = Convert.ToInt32(userTextbox.Text);
                    FrbaCommerce.Login.cambioPass cambioDePass = new cambioPass(this,true);
                    cambioDePass.Show();
                    this.Visible = false;
                }
                else
                {
                    DatosUsuario.usuario = Convert.ToInt32(userTextbox.Text);
                    DatosUsuario.actualizarTipoUsuario();
                    FrbaCommerce.Login.selectorRol seleccionRol = new selectorRol(this);
                    seleccionRol.Show();
                    this.Visible = false;
                }
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

        private void userTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaCommerce.Registro_de_Usuario.RegistroUsuario registro;
            registro = new Registro_de_Usuario.RegistroUsuario(this);
            registro.Show();
            this.Visible = false;
        }
    }
}

