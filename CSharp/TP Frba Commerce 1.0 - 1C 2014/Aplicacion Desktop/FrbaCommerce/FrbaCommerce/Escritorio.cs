﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Escritorio : FormGrid
    {
        public Escritorio(FormGrid anterior)
        {
            InitializeComponent();
            this.ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(167, 319);
            label3.Text = "¡Bienvenido Grid_" + DatosUsuario.usuario.ToString() + "!";
            linkLabel3.Text = DatosUsuario.nombreRol;

            string comando = "SELECT Nombre FROM TG.Funcionalidades_x_Rol WHERE ID_Rol = " +
                DatosUsuario.codigoRol.ToString();
            listBox1.DataSource = TG.ObtenerListado(comando);
        }

        private void Escrtorio_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TG.elLogin.Show();
            DatosUsuario.resetearDatos();
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            volverAtras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1) {

                bool continuar = true;
                
                switch (listBox1.SelectedItem.ToString())
                {
                    case "ABM Usuario":
                        //(new AbmUsuario.AbmUsuario(this)).Show();
                        break;
                    case "ABM Cliente":
                        (new AbmCliente.AbmCliente(this)).Show();
                        break;
                    case "ABM Empresa":
<<<<<<< HEAD
                        break;
                    case "ABM Rol": 
                        break;
                    case "ABM Visibilidad":
                        (new Abm_Visibilidad.ABMVisibilidad(this)).Show();// agregar this como parametro
=======
                        (new Abm_Empresa.AbmEmpresa(this)).Show();
                        break;
                    case "ABM Rol": 
                        break;
                    case "AMB Visibilidad": 
>>>>>>> 544c714f1ec7c87f631c811db269948942f7e196
                        break;
                    case "Calificar Vendedor":
                        break;
                    case "Comprar - Ofertar":
                        break;
                    case "Editar Publicacion":
                        break;
                    case "Facturar Publicaciones":
                        break;
                    case "Generar Publicacion":
                        break;
                    case "Gestion De Preguntas":
                        break;
                    case "Historial del Cliente":
                        break;
                    case "Listado Estadistico":
                        break;
                    default: 
                        TG.ventanaEmergente("Esta Funcionalidad todavia no está implementada");
                        continuar = false;
                        break;
                }
                if (continuar) this.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaCommerce.Registro_de_Usuario.Registro_de_Usuario registroFrm = new FrbaCommerce.Registro_de_Usuario.Registro_de_Usuario(this);
            registroFrm.Show();
            this.Visible = false;
        }
    }
}
