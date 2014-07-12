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
    public partial class Inhabilitacion : FormGrid
    {
        private string usuario;
        public Inhabilitacion(Form anterior, string usuario)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(366, 107);
            this.usuario = usuario;
            this.ventanaAnterior = anterior;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            botonConfirmar.Enabled = false;
            botonCancelar.Enabled = false;
            string comando = "update THE_GRID.Usuario set Inhabilitado = 1 where ID_User =" + usuario;
            TG.realizarConsultaSinRetorno(comando);
            volverAtras();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
