﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.ABM_Usuario;

namespace FrbaCommerce.Login
{
    public partial class cambioPass : FormGrid
    {
        private bool primerIngreso;
        public cambioPass(FormGrid ventanaAnterior, bool primerIngreso)
        {
            InitializeComponent();
            this.primerIngreso = primerIngreso;
            this.ventanaAnterior = ventanaAnterior;
            this.ClientSize = new System.Drawing.Size(365, 266);
            if (primerIngreso || DatosUsuario.usuarioAux != "-1")
            {
                textBoxOldPass.Enabled = false;
                textBoxOldPass.Text = "LOOOOOOL";
                DatosUsuario.actualizarBanderasUsuario();
            }
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
                    string comando = "update THE_GRID.Usuario set "+
                        "Pass='" + TG.encriptar(textBoxPass1.Text) + "',"+
                        "Primer_Ingreso = 0" +
                        "where ID_User = " + DatosUsuario.usuario.ToString();

                    TG.realizarConsultaSinRetorno(comando);
                    
                    if(this.primerIngreso){
                        (new FrbaCommerce.ABM_Usuario.Registro_de_Usuario(ventanaAnterior)).Show();
                    }
                    TG.ventanaEmergente("Se cambió la contraseña exitosamente.");
                    DatosUsuario.actualizarBanderasUsuario();
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
            string comando = "select * from THE_GRID.Usuario where ID_User = " +
                DatosUsuario.usuario + "and Pass ='" + 
                TG.encriptar(textBoxOldPass.Text) + "'";

            DataTable consulta = TG.realizarConsulta(comando);
            if (consulta.Rows.Count == 0 && textBoxOldPass.Enabled) return 1;
            if (textBoxPass1.Text != textBoxPass2.Text) return 2;
            if (textBoxPass1.Text.Length < 8 || textBoxPass1.Text.Length > 10) return 3;
            return 0;
            
        }

        private void cambioPass_Load(object sender, EventArgs e)
        {

        }
    }
}
