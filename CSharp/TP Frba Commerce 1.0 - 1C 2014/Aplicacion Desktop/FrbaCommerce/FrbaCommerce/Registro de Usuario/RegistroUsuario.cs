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
    public partial class txtTelEmpresa : FormGrid
    {
        bool usuarioNuevo = false; //Uso este boolean para saber mas adelante si tengo que hacer un update o un inserte en la base de datos

        public txtTelEmpresa(FormGrid anterior)
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
                        txtNombre.Text = consulta["Nombre"].ToString();
                        txtApellido.Text = consulta["Apellido"].ToString();
                        switch (consulta["Tipo_Documento"].ToString())
                        {
                            case "DNI": comboBox1.SelectedIndex = 0; break;
                            case "LC": comboBox1.SelectedIndex = 1; break;
                            case "LE": comboBox1.SelectedIndex = 2; break;
                        }
                        txtDoc.Text = consulta["Documento"].ToString();
                        txtEmail.Text = consulta["Mail"].ToString();
                        if (!String.Equals(consulta["Telefono"].ToString(), "0"))
                            txtTel.Text = consulta["Telefono"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(consulta["Fecha_Nacimiento"]);
                        if (!String.Equals(consulta["Nro_Tarjeta"].ToString(), "0"))
                            txtNroTarjeta.Text = consulta["Nro_Tarjeta"].ToString();
                        txtCalle.Text = consulta["Calle"].ToString();
                        txtNroCalle.Text = consulta["Nro_Calle"].ToString();
                        txtPiso.Text = consulta["Nro_Piso"].ToString();
                        txtDep.Text = consulta["Departamento"].ToString();
                        if (!String.Equals(consulta["Localidad"].ToString(), "Sin_Localidad"))
                            txtLoc.Text = consulta["Localidad"].ToString();
                        txtCodPos.Text = consulta["Cod_Postal"].ToString();
                        if (!String.Equals(consulta["Ciudad"].ToString(), "Sin_Ciudad"))
                            txtCiudad.Text = consulta["Ciudad"].ToString();
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
                        txtRazonSocial.Text = consulta["Razon_Social"].ToString();
                        txtCuit.Text = consulta["CUIT"].ToString();
                        txtEmailEmpresa.Text = consulta["Mail"].ToString();
                        if (!String.Equals(consulta["Telefono"].ToString(), "0"))
                        textBox17.Text = consulta["Telefono"].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(consulta["Fecha_Creacion"]);
                        if (!String.Equals(consulta["Nombre_Contacto"].ToString(), "Sin_Contacto"))
                        txtNombreContacto.Text = consulta["Nombre_Contacto"].ToString();
                        txtCalleEmpresa.Text = consulta["Calle"].ToString();
                        txtNroCalleEmpresa.Text = consulta["Nro_Calle"].ToString();
                        txtPisoEmpresa.Text = consulta["Nro_Piso"].ToString();
                        txtDepEmpresa.Text = consulta["Departamento"].ToString();
                        if (!String.Equals(consulta["Localidad"].ToString(), "Sin_Localidad"))
                        txtLocEmpresa.Text = consulta["Localidad"].ToString();
                        txtCodPosEmpresa.Text = consulta["Cod_Postal"].ToString();
                        if (!String.Equals(consulta["Ciudad"].ToString(), "Sin_Ciudad"))
                        txtCiudadEmpresa.Text = consulta["Ciudad"].ToString();
                        myConnection.Close();
                    }
                    break;
                default: //usuario nuevo
                    linkLabel1.Visible = false;
                    label29.Visible = true;
                    label31.Visible = false;
                    usuarioNuevo = true; break; 
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
                    if (tb.Text.Length == 0 && (!String.Equals(tb.Name, "txtNroTarjeta") && !String.Equals(tb.Name, "txtDep") && !String.Equals(tb.Name,"txtPiso")))//Nro de tarjeta es opcional?
                    {
                        tb.BackColor = Color.LightYellow;
                        error = true;
                    }
                    else tb.BackColor = Color.White;
                }
            }
            if (!error) 
            {
                if (usuarioNuevo)
                {   // Nuevo usuario
                    string comandoInsertar = "INSERT INTO TG.Usuario(Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos,Primer_Ingreso)"+
                    "VALUES ('" + TG.encriptar("w23e") + "',0,0,2,0,1)";
                    TG.realizarConsultaSinRetorno(comandoInsertar);
                    
                    DataTable consultaUltimoUsuario = TG.realizarConsulta("select top 1 ID_User from TG.Usuario order by ID_User desc");
                    DatosUsuario.usuario = Convert.ToInt32( consultaUltimoUsuario.Rows[0]["ID_User"]);

                    TG.realizarConsultaSinRetorno( "Insert INTO TG.Cliente (ID_User) VALUES("+ DatosUsuario.usuario.ToString() +")" );               
                }

                string actualizarCliente = @"UPDATE TG.Cliente  set                     
                    Nombre ='" + txtNombre.Text + @"',
                    Apellido ='" + txtApellido.Text + @"',
                    Tipo_Documento ='" + comboBox1.Text + @"',
                    Documento = " + txtDoc.Text + @",
                    Mail ='" + txtEmail.Text + @"',
                    Telefono =" + txtTel.Text + @",
                    Fecha_Nacimiento = convert(datetime,'" + dateTimePicker1.Value.ToString("yyyy-dd-MM hh:mm:ss") + @"'),
                    Nro_Tarjeta = " + txtNroTarjeta.Text + @",
                    Calle = '" + txtCalle.Text + @"',
                    Nro_Calle = " + txtNroCalle.Text + @",
                    Nro_Piso = " + txtPiso.Text + @",
                    Departamento = '" + txtDep.Text + @"',
                    Localidad = '" + txtLoc.Text + @"',
                    Cod_Postal = " + txtCodPos.Text + @",
                    Ciudad = '" + txtCiudad.Text + @"'
                    where ID_USER =" + DatosUsuario.usuario.ToString();
                TG.realizarConsultaSinRetorno(actualizarCliente);
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
                if (usuarioNuevo)
                {   // Nuevo usuario
                    string comandoInsertar = "INSERT INTO TG.Usuario(Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos,Primer_Ingreso)" +
                    "VALUES ('" + TG.encriptar("w23e") + "',0,0,3,0,1)";
                    TG.realizarConsultaSinRetorno(comandoInsertar);

                    DataTable consultaUltimoUsuario = TG.realizarConsulta("select top 1 ID_User from TG.Usuario order by ID_User desc");
                    DatosUsuario.usuario = Convert.ToInt32(consultaUltimoUsuario.Rows[0]["ID_User"]);

                    TG.realizarConsultaSinRetorno("Insert INTO TG.Empresa (ID_User) VALUES(" + DatosUsuario.usuario.ToString() + ")");
                }

                string actualizarCliente = @"UPDATE TG.Empresa  set                     
                    Razon_Social ='" + txtRazonSocial.Text + @"',
                    CUIT ='" + txtCuit.Text + @"',
                    Mail ='" + txtEmailEmpresa.Text + @"',
                    Telefono =" + textBox17.Text + @",
                    Fecha_Creacion = convert(datetime,'" + dateTimePicker2.Value.ToString("yyyy-dd-MM hh:mm:ss") + @"'),
                    Nombre_Contacto = '" + txtNombreContacto.Text + @"',
                    Calle = '" + txtCalleEmpresa.Text + @"',
                    Nro_Calle = " + txtNroCalleEmpresa.Text + @",
                    Nro_Piso = " + txtPisoEmpresa.Text + @",
                    Departamento = '" + txtDepEmpresa.Text + @"',
                    Localidad = '" + txtLocEmpresa.Text + @"',
                    Cod_Postal = " + txtCodPosEmpresa.Text + @",
                    Ciudad = '" + txtCiudadEmpresa.Text + @"'
                    where ID_USER =" + DatosUsuario.usuario.ToString();
                TG.realizarConsultaSinRetorno(actualizarCliente);
               }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        
       

        

        
    }
}

