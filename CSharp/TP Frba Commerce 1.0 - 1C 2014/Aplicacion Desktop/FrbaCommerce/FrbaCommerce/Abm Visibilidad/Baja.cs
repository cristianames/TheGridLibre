using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Baja : FormGrid
    {
        private string ID_Visibilidad;
        public Baja(Form anterior, string ID_Visibilidad)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(366, 107);
            this.ID_Visibilidad = ID_Visibilidad;
            this.ventanaAnterior = anterior;
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            botonCancelar.Enabled = false;
            botonConfirmar.Enabled = false;
            string consulta = "update THE_GRID.Visibilidad set Inhabilitado='true' where ID_Visibilidad=" + ID_Visibilidad;
            TG.realizarConsultaSinRetorno(consulta);
            volverAtras();
        }

        private void botonCancelar_Click_1(object sender, EventArgs e)
        {
            volverAtras();
        }
    }
}
