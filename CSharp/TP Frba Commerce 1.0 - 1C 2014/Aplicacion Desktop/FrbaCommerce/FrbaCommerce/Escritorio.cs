using System;
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
            /*
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.Size = new System.Drawing.Size(115, 20);
            int i;
            for (i = 0; i < 12; i++ ){
                this.tableLayoutPanel1.RowCount = this.tableLayoutPanel1.RowCount + 1;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(115, tableLayoutPanel1.Height + 20);
            }*/
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
                switch (listBox1.SelectedItem.ToString())
                {
                    case "Comprar": //do something
                        break;
                    case "Publicar": //do something
                        break;
                    case "Facturar": //do something
                        break;
                    default: TG.ventanaEmergente("Esta Funcionalidad todavia no está implementada");
                        break;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrbaCommerce.Registro_de_Usuario.RegistroUsuario registroFrm = new FrbaCommerce.Registro_de_Usuario.RegistroUsuario(this);
            registroFrm.Show();
            this.Visible = false;
        }
    }
}
