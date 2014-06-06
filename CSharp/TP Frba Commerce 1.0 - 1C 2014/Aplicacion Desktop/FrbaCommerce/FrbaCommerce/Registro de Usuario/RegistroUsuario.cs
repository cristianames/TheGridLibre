using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                    grupoCliente.Enabled = false; break;
                case 2:  //Cliente
                    radioButton2.Enabled = false; break;
                case 3:  //Empresa
                    radioButton1.Enabled = false;
                    radioButton2.Checked = true; break;
                default: //usuario nuevo
                    linkLabel1.Visible = false;
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
    }
}
