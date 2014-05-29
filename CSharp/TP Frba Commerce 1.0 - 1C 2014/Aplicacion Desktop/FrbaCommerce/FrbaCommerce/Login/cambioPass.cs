using System;
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
        private FormGrid ventanaAnterior;
        private int user;
        public cambioPass(FormGrid ventanaAnterior,int user)
        {
            InitializeComponent();
            this.ventanaAnterior = ventanaAnterior;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.user = user;
        }

        private void cambioPass_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ventanaAnterior.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (checkPass()) {
                case 0: ventanaEmergente("EXITO"); break;
                case 1: ventanaEmergente("Ingrese una contraseña valida");break;
                case 2: ventanaEmergente("El password tiene que coincidir en ambos campos"); break;
                case 3: ventanaEmergente("El password nuevo tiene que tener entre 8 y 10 caracteres"); break;
            }
            
            
        }

        private int checkPass() // si el password coincide para ese usuario devuelve True sino False
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand("select * from TG.Usuario where ID_User = " +
                this.user.ToString() + "and Pass ='" + TG.encriptar(textBoxOldPass.Text) + "'", myConnection);
            SqlDataReader consulta = null;
            consulta = myCommand.ExecuteReader();
            if (!consulta.HasRows) return 1;
            if (!string.Equals(textBoxPass1.Text, textBoxPass2.Text)) return 2;
            if (textBoxPass1.Text.Length < 8 || textBoxPass1.Text.Length > 10) return 3;
            return 0;
            
        }
    }
}
