﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Login
{
    public partial class cambioPass : FormGrid
    {
        public cambioPass(FormGrid ventanaAnterior, bool primerIngreso)
        {
            InitializeComponent();
            this.ventanaAnterior = ventanaAnterior;
            this.ClientSize = new System.Drawing.Size(292, 266);
            if (primerIngreso) {
                textBoxOldPass.Enabled = false;
                textBoxOldPass.Text = "LOOOOOOL";
            }
        }

        private void cambioPass_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void submitActions() 
        {
            switch (checkPass())
            {
                case 0: 
                    SqlConnection myConnection = TG.conectar();
                    SqlCommand myCommand = new SqlCommand("update TG.Usuario set Pass='" +
                    TG.encriptar(textBoxPass1.Text) + "', Primer_Ingreso = 0"+
                    "where ID_User = " + DatosUsuario.usuario.ToString(), myConnection);
                    myCommand.ExecuteNonQuery();
                    FrbaCommerce.Login.selectorRol seleccionRol = new selectorRol(ventanaAnterior);
                    seleccionRol.Show();
                    TG.ventanaEmergente("Se cambió la contraseña exitosamente.");
                    DatosUsuario.actualizarTipoUsuario();
                    this.Close();
                    break;
                case 1: TG.ventanaEmergente("Ingrese una contraseña valida"); break;
                case 2: TG.ventanaEmergente("El password tiene que coincidir en ambos campos"); break;
                case 3: TG.ventanaEmergente("El password nuevo tiene que tener entre 8 y 10 caracteres"); break;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submitActions(); 
        }

        private int checkPass()
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand("select * from TG.Usuario where ID_User = " +
                DatosUsuario.usuario.ToString() + "and Pass ='" + TG.encriptar(textBoxOldPass.Text) + "'", myConnection);
            SqlDataReader consulta = null;
            consulta = myCommand.ExecuteReader();
            if (!consulta.HasRows && textBoxOldPass.Enabled) return 1;
            if (!string.Equals(textBoxPass1.Text, textBoxPass2.Text)) return 2;
            if (textBoxPass1.Text.Length < 8 || textBoxPass1.Text.Length > 10) return 3;
            return 0;
            
        }

        private void textBoxOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }

        private void textBoxPass1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }

        private void textBoxPass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) submitActions();
        }
    }
}
