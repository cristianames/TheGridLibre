using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Usuario
{
    public partial class Registro_de_Usuario : FormGrid
    {
        bool usuarioNuevo = false; //Uso este boolean para saber mas adelante si tengo que hacer un update o un inserte en la base de datos

        public Registro_de_Usuario(Form anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            grupoEmpresa.Location = new System.Drawing.Point(15, 47);
            grupoEmpresa.Visible = false;
            this.ClientSize = new System.Drawing.Size(487, 428);
            comboBox1.SelectedIndex = 0;
            label31.Text += DatosUsuario.usuario.ToString();
            dateTimePicker1.Value = TG.fechaDelSistema;
            dateTimePicker2.Value = TG.fechaDelSistema;
            
            switch (DatosUsuario.tipoUsuario) 
            {
                case 1:  //Administrador
                    switch (DatosUsuario.tipoUsuarioModif)
                    {
                        case 2: levantarDatosCliente(); break;
                        case 3: levantarDatosEmpresa(); break;
                        default: 
                            radioButton1.Enabled = false;
                            radioButton2.Enabled = false; 
                            grupoCliente.Enabled = false; 
                            break;
                    }
                    break;

                case 2:  //Cliente
                    label29.Text = "Por favor, mantenga sus datos actualizados";
                    levantarDatosCliente();
                    break;

                case 3:  //Empresa
                    label29.Text = "Por favor, mantenga sus datos actualizados";
                    levantarDatosEmpresa();
                    break;

                default: //usuario nuevo
                    linkLabel1.Visible = false;
                    label29.Visible = true;
                    label31.Visible = false;
                    usuarioNuevo = true; 
                    break; 
            }
        }

        private void levantarDatosEmpresa()
        {
            radioButton1.Enabled = false;
            radioButton2.Checked = true;
            button2.Text = "Guardar"; string comando = "select * from THE_GRID.Empresa where ID_User=" + DatosUsuario.usuario;
            DataRow consulta = TG.realizarConsulta(comando).Rows[0];

            //pasar los datos a los campos
            txtRazonSocial.Text = consulta["Razon_Social"].ToString();
            txtCuit.Text = consulta["CUIT"].ToString();
            txtEmailEmpresa.Text = consulta["Mail"].ToString();
            if (!String.Equals(consulta["Telefono"].ToString(), "0"))
                txtTelEmpresa.Text = consulta["Telefono"].ToString();
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
        }

        private void levantarDatosCliente()
        {
            radioButton2.Enabled = false;
            button1.Text = "Guardar";
            string comando = "select * from THE_GRID.Cliente where ID_User=" + DatosUsuario.usuario;
            DataRow consulta = TG.realizarConsulta(comando).Rows[0];

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
            if (DatosUsuario.tipoUsuario == 1 && DatosUsuario.tipoUsuarioModif != (-1))
            DatosUsuario.resetearDatosModif();
            volverAtras();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new Login.cambioPass(this, false)).Show();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private bool validarDatosCliente() 
        {
            DataTable resultado;
            string comando = "select * from THE_GRID.Cliente where ID_User =" + DatosUsuario.usuario;
            DataRow datosCliente = TG.realizarConsulta(comando).Rows[0];

            if (!String.Equals(datosCliente["Tipo_Documento"].ToString(), comboBox1.SelectedItem.ToString()) ||
                !String.Equals(datosCliente["Documento"].ToString(), txtDoc.Text))
            {
                comando = "select * from THE_GRID.Cliente where " +
                "Tipo_Documento = '" + comboBox1.SelectedItem.ToString() + "' and " +
                "Documento = " + txtDoc.Text;
                resultado = TG.realizarConsulta(comando);
                if (resultado.Rows.Count > 0)
                {
                    TG.ventanaEmergente("Documento ya existente");
                    //loggear anomalida
                    return true;
                }
            }

            if (!String.Equals(datosCliente["Telefono"].ToString(), txtTel.Text))
            {
                comando = "select * from THE_GRID.Cliente where Telefono = " + txtTel.Text;
                resultado = TG.realizarConsulta(comando);
                if (resultado.Rows.Count > 0)
                {
                    TG.ventanaEmergente("Telefono ya existente");
                    return true;
                }
            }
            return false;
        }

        private bool validarDatosEmpresa()
        {
            DataTable resultado;
            string comando = "select * from THE_GRID.Empresa where ID_User =" + DatosUsuario.usuario;
            DataRow datosEmpresa = TG.realizarConsulta(comando).Rows[0];

            if (!String.Equals(datosEmpresa["CUIT"].ToString(), txtCuit.Text))
            {
                comando = "select * from THE_GRID.Empresa where " +
                    "CUIT = '" + Convert.ToInt32(txtCuit.Text).ToString("#0-00000000-0") + "'";
                resultado = TG.realizarConsulta(comando);
                if (resultado.Rows.Count > 0)
                {
                    TG.ventanaEmergente("CUIT ya existente");
                    //loggear anomalida
                    return true;
                }
            }

            if (!String.Equals(datosEmpresa["Razon_Social"].ToString(), txtRazonSocial.Text))
            {
                comando = "select * from THE_GRID.Empresa where " +
                    "Razon_Social = '" + txtRazonSocial.Text + "'";
                resultado = TG.realizarConsulta(comando);
                if (resultado.Rows.Count > 0)
                {
                    TG.ventanaEmergente("Razon Social ya existente");
                    //loggear anomalia
                    return true;
                }
            }

            if (!String.Equals(datosEmpresa["Telefono"].ToString(), txtTel.Text))
            {
                comando = "select * from THE_GRID.Empresa where Telefono = " + txtTelEmpresa.Text;
                resultado = TG.realizarConsulta(comando);
                if (resultado.Rows.Count > 0)
                {
                    TG.ventanaEmergente("Telefono ya existente");
                    return true;
                }
            }

            return false;
        }

        private bool validacionPreviaCliente()
        {
            bool estado = true;
            Validator validador = new Validator();
            if (!validador.validar_numerico(txtTel.Text))
            {
                txtTel.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            if (!validador.validar_numerico(txtDoc.Text))
            {
                txtDoc.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            if (!validador.validar_email(txtEmail.Text))
            {
                txtEmail.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }            
            if (!validador.validar_numerico(txtNroCalle.Text))
            {
                txtNroCalle.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            if (txtNroTarjeta.Text != string.Empty)
            {
                if (!validador.validar_numerico(txtNroTarjeta.Text))
                {
                    txtNroTarjeta.BackColor = Color.FromArgb(255, 161, 161);
                    estado = false;
                }
            }
            if(!estado)Control1.Text = "Verificar datos";
            return estado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validacionPreviaCliente()) return;
            bool error = false;
            List<TextBox> camposOmitibles = new List<TextBox>();
            camposOmitibles.Add(txtNroTarjeta);
            camposOmitibles.Add(txtDep);
            camposOmitibles.Add(txtPiso);
            
            foreach (Control tb in grupoCliente.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text.Length == 0 && !camposOmitibles.Contains((TextBox)tb))
                    {
                        tb.BackColor = Color.LightYellow;
                        error = true;
                    }
                    else tb.BackColor = Color.White;
                }
            }
            if (error) return;

            error = validarDatosCliente();
            if (error) return;

            if (usuarioNuevo)
                {   // Nuevo usuario
                    string comandoInsertar = "INSERT INTO THE_GRID.Usuario(Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos,Primer_Ingreso)"+
                    "VALUES ('" + TG.encriptar("w23e") + "',0,0,2,0,1)";
                    TG.realizarConsultaSinRetorno(comandoInsertar);
                    
                    DataTable consultaUltimoUsuario = TG.realizarConsulta("select top 1 ID_User from THE_GRID.Usuario order by ID_User desc");
                    DatosUsuario.usuario = Convert.ToInt32( consultaUltimoUsuario.Rows[0]["ID_User"]);

                    TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Cliente (ID_User) VALUES("+ DatosUsuario.usuario.ToString() +")" );
                    TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) VALUES(" + DatosUsuario.usuario.ToString() + ",3,0)");
                    TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) VALUES(" + DatosUsuario.usuario.ToString() + ",2,0)");
                }

            string nroTarjeta = txtNroTarjeta.Text;
            string piso = txtPiso.Text;

            if (String.Equals(nroTarjeta, "")) nroTarjeta = "0";
            if (String.Equals(piso, "")) piso = "0";

            string actualizarCliente = @"UPDATE THE_GRID.Cliente set                     
                    Nombre ='" + txtNombre.Text + @"',
                    Apellido ='" + txtApellido.Text + @"',
                    Tipo_Documento ='" + comboBox1.Text + @"',
                    Documento = " + txtDoc.Text + @",
                    Mail ='" + txtEmail.Text + @"',
                    Telefono =" + txtTel.Text + @",
                    Fecha_Nacimiento = convert(datetime,'" + dateTimePicker1.Value.ToString("yyyy-dd-MM hh:mm:ss") + @"'),
                    Nro_Tarjeta = " + nroTarjeta + @",
                    Calle = '" + txtCalle.Text + @"',
                    Nro_Calle = " + txtNroCalle.Text + @",
                    Nro_Piso = " + piso + @",
                    Departamento = '" + txtDep.Text + @"',
                    Localidad = '" + txtLoc.Text + @"',
                    Cod_Postal = " + txtCodPos.Text + @",
                    Ciudad = '" + txtCiudad.Text + @"'
                    where ID_USER =" + DatosUsuario.usuario.ToString();
            TG.realizarConsultaSinRetorno(actualizarCliente);

            if(DatosUsuario.DatosCorrectos == 0) validarUsuario();

            if (usuarioNuevo) 
                TG.ventanaEmergente("Usuario creado. Su Username y Password se han enviado a su correo");
            if (DatosUsuario.tipoUsuario == 1) DatosUsuario.resetearDatosModif();
            volverAtras();
        }

        private bool validacionPreviaEmpresa()
        {
            bool estado = true;
            Validator validador = new Validator();
            if (!validador.validar_numerico(txtTelEmpresa.Text))
            {
                txtTelEmpresa.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            if (!validador.validar_email(txtEmailEmpresa.Text))
            {
                txtEmailEmpresa.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            if (!validador.validar_numerico(txtNroCalleEmpresa.Text))
            {
                txtNroCalleEmpresa.BackColor = Color.FromArgb(255, 161, 161);
                estado = false;
            }
            
            if (!estado) Control2.Text = "Verificar datos";
            return estado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validacionPreviaEmpresa()) return;
            bool error = false;
            List<TextBox> camposOmitibles = new List<TextBox>();
            camposOmitibles.Add(txtDepEmpresa);
            camposOmitibles.Add(txtPisoEmpresa);

            foreach (Control tb in grupoEmpresa.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text.Length == 0 && !camposOmitibles.Contains((TextBox)tb))
                    {
                        tb.BackColor = Color.LightYellow;
                        error = true;
                    }
                    else tb.BackColor = Color.White;
                }
            }
            if (error) return;

            error = validarDatosEmpresa();
            if (error) return;

            if (usuarioNuevo)
                {   // Nuevo usuario
                    string comandoInsertar = "INSERT INTO THE_GRID.Usuario(Pass,Inhabilitado,Antiguo,ID_Tipo,Intentos,Primer_Ingreso)" +
                    "VALUES ('" + TG.encriptar("w23e") + "',0,0,3,0,1)";
                    TG.realizarConsultaSinRetorno(comandoInsertar);

                    DataTable consultaUltimoUsuario = TG.realizarConsulta("select top 1 ID_User from THE_GRID.Usuario order by ID_User desc");
                    DatosUsuario.usuario = Convert.ToInt32(consultaUltimoUsuario.Rows[0]["ID_User"]);

                    TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Empresa (ID_User) VALUES(" + DatosUsuario.usuario.ToString() + ")");
                    TG.realizarConsultaSinRetorno("Insert INTO THE_GRID.Roles_x_Usuario (ID_User,ID_Rol,Inhabilitado) VALUES(" + DatosUsuario.usuario.ToString() + ",3,0)");
                }

            string piso = txtPiso.Text;
            if (String.Equals(piso, "")) piso = "0";

            string actualizarCliente = @"UPDATE THE_GRID.Empresa set                     
                    Razon_Social ='" + txtRazonSocial.Text + @"',
                    CUIT ='" + Convert.ToInt32(txtCuit.Text).ToString("#0-00000000-0") + @"',
                    Mail ='" + txtEmailEmpresa.Text + @"',
                    Telefono =" + txtTelEmpresa.Text + @",
                    Fecha_Creacion = convert(datetime,'" + dateTimePicker2.Value.ToString("yyyy-dd-MM hh:mm:ss") + @"'),
                    Nombre_Contacto = '" + txtNombreContacto.Text + @"',
                    Calle = '" + txtCalleEmpresa.Text + @"',
                    Nro_Calle = " + txtNroCalleEmpresa.Text + @",
                    Nro_Piso = " + piso + @",
                    Departamento = '" + txtDepEmpresa.Text + @"',
                    Localidad = '" + txtLocEmpresa.Text + @"',
                    Cod_Postal = " + txtCodPosEmpresa.Text + @",
                    Ciudad = '" + txtCiudadEmpresa.Text + @"'
                    where ID_USER =" + DatosUsuario.usuario.ToString();
            TG.realizarConsultaSinRetorno(actualizarCliente);
            
            if(DatosUsuario.DatosCorrectos == 0) validarUsuario();

            if (usuarioNuevo)
                TG.ventanaEmergente("Usuario creado. Su Username y Password se han enviado a su correo");
            if (DatosUsuario.tipoUsuario == 1) DatosUsuario.resetearDatosModif();
            volverAtras();
        }

        private void validarUsuario()
        {
            string comando = "update THE_GRID.Usuario set Datos_Correctos = 1 where ID_User = " + DatosUsuario.usuario.ToString();
            TG.realizarConsultaSinRetorno(comando);
        }

        private void txtDoc_TextChanged(object sender, EventArgs e)
        {
            txtDoc.BackColor = Color.FromArgb(255, 255, 255);
            Control1.Text = "";
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.FromArgb(255, 255, 255);
            Control1.Text = "";
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            txtTel.BackColor = Color.FromArgb(255, 255, 255);
            Control1.Text = "";
        }

        private void txtNroCalle_TextChanged(object sender, EventArgs e)
        {
            txtNroCalle.BackColor = Color.FromArgb(255, 255, 255);
            Control1.Text = "";
        }

        private void txtNroTarjeta_TextChanged(object sender, EventArgs e)
        {
            txtNroTarjeta.BackColor = Color.FromArgb(255, 255, 255);
            Control1.Text = "";
        }

        private void txtEmailEmpresa_TextChanged(object sender, EventArgs e)
        {
            txtEmailEmpresa.BackColor = Color.FromArgb(255, 255, 255);
            Control2.Text = "";
        }

        private void txtTelEmpresa_TextChanged(object sender, EventArgs e)
        {
            txtTelEmpresa.BackColor = Color.FromArgb(255, 255, 255);
            Control2.Text = "";
        }

        private void txtNroCalleEmpresa_TextChanged(object sender, EventArgs e)
        {
            txtNroCalleEmpresa.BackColor = Color.FromArgb(255, 255, 255);
            Control2.Text = "";
        }
    }
}

