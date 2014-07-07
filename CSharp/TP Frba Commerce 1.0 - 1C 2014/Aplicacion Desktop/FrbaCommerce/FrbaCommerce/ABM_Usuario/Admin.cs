using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Usuario
{
    public partial class Admin : FormGrid
    {
        private bool alta;
        public Admin(FormGrid anterior, bool alta)
        {
            InitializeComponent();
            //291; 121
            this.ClientSize = new System.Drawing.Size(291, 121);
            ventanaAnterior = anterior;
            this.alta = alta;

            if (!alta) 
            {
                string comando = "select Nombre from THE_GRID.Administrador "+
                    "where ID_User = " + DatosUsuario.usuario;
                textBox1.Text = TG.consultaEscalar(comando).ToString();
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) 
            {
                textBox1.BackColor = Color.LightYellow;
                return;
            }
            textBox1.BackColor = Color.White;

            string comando;
            if (alta)
            {
                comando = "insert into THE_GRID.Usuario(Pass,Inhabilitado,Antiguo,ID_Tipo,"+
                    "Intentos,Primer_Ingreso,Datos_Correctos) values" +
                    "('e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'," +
                    "0,0,1,1,0,1)";
                TG.realizarConsulta(comando);
                comando = "select max(ID_User) from THE_GRID.Usuario";
                string nuevoAdmin = TG.consultaEscalar(comando).ToString();
                comando = "insert into THE_GRID.Roles_x_Usuario values"+
                    "("+nuevoAdmin+",1,0)";
                TG.realizarConsulta(comando);
                comando = "insert into THE_GRID.Administrador values" +
                    "(" + nuevoAdmin + ",'" + textBox1.Text + "')";
            }
            else
                comando = "update THE_GRID.Administrador set Nombre = '" + textBox1.Text + "'" +
                    " where ID_User = " + DatosUsuario.usuario;
            TG.realizarConsulta(comando);
            DatosUsuario.resetearDatosModif();
            volverAtras();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
