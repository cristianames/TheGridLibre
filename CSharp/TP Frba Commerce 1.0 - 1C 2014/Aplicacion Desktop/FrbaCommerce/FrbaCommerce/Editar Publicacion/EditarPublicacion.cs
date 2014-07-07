using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class EditarPublicacion : Form
    {
        Form ventanaAnterior;
        DataTable publicacionesUsuario;
        bool esBorrador;
        public EditarPublicacion(Form anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string consulta = "select ID_Publicacion, Descripcion,Estado ,Tipo_Publicacion from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string estado = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
            switch (estado) 
            {
                case "Borrador":
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled  = botonFinalizar.Enabled = true;
                    botonPausar.Enabled = false;
                    esBorrador = true;
                    break;
                case "Publicada":
                    botonPausar.Text = "Pausar";
                    botonPausar.Enabled = botonModificar.Enabled = botonFinalizar.Enabled = true;
                    esBorrador = false;
                    break;
                case "Pausada":
                    botonPausar.Text = "Reanudar";
                    botonPausar.Enabled = botonFinalizar.Enabled = true;
                    botonModificar.Enabled = false;
                    esBorrador = false;
                    break;
                case "Finalizada":
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled = botonPausar.Enabled = botonFinalizar.Enabled = false;
                    esBorrador = false;
                    break;
                
            }
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Show();
            this.Close();
        }

        private void botonPausar_Click(object sender, EventArgs e)
        {
            string estado = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
            string comando;
            if (estado == "Pausada")
            {
                comando = "update THE_GRID.Publicacion set Estado ='Publicada' where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
                botonPausar.Text = "Pausar";
            }
            else
            {
                comando = "update THE_GRID.Publicacion set Estado ='Pausada' where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
                botonPausar.Text = "Reanudar";
            }
            TG.realizarConsultaControladaSinRetorno(comando);
            string consulta = "select ID_Publicacion, Descripcion,Estado ,Tipo_Publicacion from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;   
        }

        private void botonFinalizar_Click(object sender, EventArgs e)
        {
            string comando = "update THE_GRID.Publicacion set Estado ='Finalizada' where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
            TG.realizarConsultaControladaSinRetorno(comando);
            botonModificar.Enabled = botonPausar.Enabled = botonFinalizar.Enabled = false;
            string consulta = "select ID_Publicacion, Descripcion,Estado ,Tipo_Publicacion from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;   
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            (new Generar_Publicacion.GenerarPublicacion(this, dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString(),esBorrador)).Show();
            this.Enabled = false;
        }
    }
}
