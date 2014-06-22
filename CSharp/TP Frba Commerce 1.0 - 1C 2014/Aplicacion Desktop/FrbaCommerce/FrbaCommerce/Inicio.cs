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
        private int repeticiones = 0;
        System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer(); 

        public Inicio()
        {
            InitializeComponent();
            MyTimer.Interval = 500;
            MyTimer.Tick += new EventHandler(this.DoWork);
            MyTimer.Enabled = true;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Login.login loginFrm = new Login.login();
           loginFrm.Show();
           TG.elLogin = loginFrm;
           this.Visible = false;
        }

        public void DoWork(object sender, EventArgs e) 
        {
            if (this.repeticiones<15)
            {
                int mod;
                mod= repeticiones % 4;
                if (mod == 0) label2.Text = "Cargando.";
                if (mod == 1) label2.Text = "Cargando..";
                if (mod == 2) label2.Text = "Cargando...";
                if (mod == 3) label2.Text = "Cargando";                    
                this.repeticiones++;
            }
            else
            {
                this.activar();
            }            
        }

        private void activar()
        {
            MyTimer.Enabled = false;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\Imagenes\TheGRID.jpg");
            label2.Visible = false;
            label1.Visible = true;
            button1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.activar();
        }

        private void Inicio_MouseClick(object sender, MouseEventArgs e)
        {
            this.activar();
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            this.activar();
        }

        private void cargarDatos()
        {
            //dgvGrilla.DataSource = TG.realizarConsulta("select top 10 * from gd_esquema.Maestra");
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

     

      
    }
}