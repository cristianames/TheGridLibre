using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;


namespace FrbaCommerce
{
    public partial class Inicio : Form
    {
        private bool fst = true;

        public Inicio()
        {
            InitializeComponent();
        }
        private void activar()
        {
            pictureBox1.Image = FrbaCommerce.Properties.Resources.TheGRID1;
            label1.Visible = true;
            button1.Visible = true;
            pictureBox2.Visible = false;
        }
        private void correrLogin()
        {
            Login.login loginFrm = new Login.login();
            loginFrm.Show();
            TG.elLogin = loginFrm;
            this.Visible = false;
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (fst)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    fst = false;
                    activar();
                }
            }
            else correrLogin();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            correrLogin();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fst = false;
            this.activar();
        }

    }
}