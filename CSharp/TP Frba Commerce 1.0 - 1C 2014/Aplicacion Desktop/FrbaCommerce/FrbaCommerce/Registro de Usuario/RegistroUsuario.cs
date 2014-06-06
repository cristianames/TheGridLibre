using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class RegistroUsuario : FormGrid
    {
        public RegistroUsuario(FormGrid anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            grupoEmpresa.Location = new System.Drawing.Point(15, 47);
            grupoEmpresa.Visible = false;
            this.ClientSize = new System.Drawing.Size(487, 428);
            comboBox1.SelectedIndex = 0;
            label31.Text += DatosUsuario.usuario.ToString();
            
            switch (DatosUsuario.tipoUsuario) 
            {
                case 1:  //Administrador
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    grupoCliente.Enabled = false;
                    label29.Text = "El Admin no tiene datos personales"; break;
                case 2:  //Cliente
                    radioButton2.Enabled = false;
                    button1.Text = "Guardar";
                    label29.Text = "Por favor, mantenga sus datos actualizados";
 
                    //levantar datos del cliente
                    using (SqlConnection myConnection = TG.conectar())
                    {
                        string comando = "select * from TG.Cliente where ID_User=" + DatosUsuario.usuario;
                        SqlCommand myCommand = new SqlCommand(comando, myConnection);
                        SqlDataReader consulta = myCommand.ExecuteReader();
                        consulta.Read();

                        //pasar los datos a los campos
                        textBox8.Text = consulta["Nombre"].ToString();
                        textBox7.Text = consulta["Apellido"].ToString();
                        switch (consulta["Tipo_Documento"].ToString())
                        {
                            case "DNI": comboBox1.SelectedIndex = 0; break;
                            case "LC": comboBox1.SelectedIndex = 1; break;
                            case "LE": comboBox1.SelectedIndex = 2; break;
                        }
                        textBox6.Text = consulta["Documento"].ToString();
                        textBox4.Text = consulta["Mail"].ToString();
                        if (!String.Equals(consulta["Telefono"].ToString(), "0"))
                            textBox5.Text = consulta["Telefono"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(consulta["Fecha_Nacimiento"]);
                        if (!String.Equals(consulta["Nro_Tarjeta"].ToString(), "0"))
                            textBox11.Text = consulta["Nro_Tarjeta"].ToString();
                        textBox1.Text = consulta["Calle"].ToString();
                        textBox2.Text = consulta["Nro_Calle"].ToString();
                        textBox3.Text = consulta["Nro_Piso"].ToString();
                        textBox10.Text = consulta["Departamento"].ToString();
                        if (!String.Equals(consulta["Localidad"].ToString(), "Sin_Localidad"))
                            textBox12.Text = consulta["Localidad"].ToString();
                        textBox9.Text = consulta["Cod_Postal"].ToString();
                        if (!String.Equals(consulta["Ciudad"].ToString(), "Sin_Ciudad"))
                            textBox13.Text = consulta["Ciudad"].ToString();
                        myConnection.Close();
                    }
                    break;
                case 3:  //Empresa
                    radioButton1.Enabled = false;
                    radioButton2.Checked = true;
                    button2.Text = "Guardar";
                    label29.Text = "Por favor, mantenga sus datos actualizados";

                    //levantar datos de la empresa
                    using (SqlConnection myConnection = TG.conectar())
                    {
                        string comando = "select * from TG.Empresa where ID_User=" + DatosUsuario.usuario;
                        SqlCommand myCommand = new SqlCommand(comando, myConnection);
                        SqlDataReader consulta = myCommand.ExecuteReader();
                        consulta.Read();
                        
                        //pasar los datos a los campos
                        textBox20.Text = consulta["Razon_Social"].ToString();
                        textBox19.Text = consulta["CUIT"].ToString();
                        textBox18.Text = consulta["Mail"].ToString();
                        if (!String.Equals(consulta["Telefono"].ToString(), "0"))
                        textBox17.Text = consulta["Telefono"].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(consulta["Fecha_Creacion"]);
                        if (!String.Equals(consulta["Nombre_Contacto"].ToString(), "Sin_Contacto"))
                        textBox16.Text = consulta["Nombre_Contacto"].ToString();
                        textBox25.Text = consulta["Calle"].ToString();
                        textBox24.Text = consulta["Nro_Calle"].ToString();
                        textBox23.Text = consulta["Nro_Piso"].ToString();
                        textBox21.Text = consulta["Departamento"].ToString();
                        if (!String.Equals(consulta["Localidad"].ToString(), "Sin_Localidad"))
                        textBox15.Text = consulta["Localidad"].ToString();
                        textBox22.Text = consulta["Cod_Postal"].ToString();
                        if (!String.Equals(consulta["Ciudad"].ToString(), "Sin_Ciudad"))
                        textBox14.Text = consulta["Ciudad"].ToString();
                        myConnection.Close();
                    }
                    break;
                default: //usuario nuevo
                    linkLabel1.Visible = false;
                    label29.Visible = true;
                    label31.Visible = false; break; 
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grupoCliente.Visible = true;
            grupoEmpresa.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            grupoEmpresa.Visible = true;
            grupoCliente.Visible = false;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaCommerce.Login.cambioPass cambioDePass = new FrbaCommerce.Login.cambioPass(this, false);
            cambioDePass.Show();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;
            foreach (Control tb in grupoCliente.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text.Length == 0 && !String.Equals(tb.Name,"textBox11"))
                    {
                        tb.BackColor = Color.LightYellow;
                        error = true;
                    }
                    else tb.BackColor = Color.White;
                }
            }
            if (!error) 
            {
                //update sql
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool error = false;
            foreach (Control tb in grupoEmpresa.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text.Length == 0)
                    {
                        tb.BackColor = Color.LightYellow;
                        error = true;
                    }
                    else tb.BackColor = Color.White;
                }
            }
            if (!error)
            {
                //update sql
            }
        }
    }
}
