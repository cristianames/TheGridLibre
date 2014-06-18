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
    public partial class Baja : FormGrid
    {
        private int usuario;
        public Baja(FormGrid anterior, int usuario)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(366, 107);
            this.usuario = usuario;
            this.ventanaAnterior = anterior;
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            botonConfirmar.Enabled = false;
            botonCancelar.Enabled = false;
            string comando = "update THE_GRID.Usuario set Inhabilitado = 1 where ID_User =" + usuario.ToString();
            TG.realizarConsultaSinRetorno(comando);
            volverAtras();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
