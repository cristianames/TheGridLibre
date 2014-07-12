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
    public partial class EditarPublicacion : FormGrid
    {
        
        DataTable publicacionesUsuario;
        bool esBorrador;
        public EditarPublicacion(Form anterior)
        {
            
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(500, 350);
            ventanaAnterior = anterior;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string consulta = "select ID_Publicacion, Descripcion,ID_Estado ,ID_Tipo from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;        
        }

        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string estado = dataGridView1.CurrentRow.Cells["ID_Estado"].Value.ToString();
            switch (estado) 
            {
                case "101"://Borrador
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled  = botonFinalizar.Enabled = true;
                    botonPausar.Enabled = false;
                    esBorrador = true;
                    break;
                case "100"://Publicada
                    botonPausar.Text = "Pausar";
                    botonPausar.Enabled = botonModificar.Enabled = botonFinalizar.Enabled = true;
                    esBorrador = false;
                    break;
                case "102"://Pausada
                    botonPausar.Text = "Reanudar";
                    botonPausar.Enabled = botonFinalizar.Enabled = true;
                    botonModificar.Enabled = false;
                    esBorrador = false;
                    break;
                case "103"://Finalizada
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled = botonPausar.Enabled = botonFinalizar.Enabled = false;
                    esBorrador = false;
                    break;
                
            }
        }*/

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Show();
            this.Close();
        }

        private void botonPausar_Click(object sender, EventArgs e)
        {
            string estado = dataGridView1.CurrentRow.Cells["ID_Estado"].Value.ToString();
            string comando;
            if (estado == "102")
            {
                comando = "update THE_GRID.Publicacion set ID_Estado =100 where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
                botonPausar.Text = "Pausar";
            }
            else
            {
                comando = "update THE_GRID.Publicacion set ID_Estado =102 where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
                botonPausar.Text = "Reanudar";
            }
            TG.realizarConsultaControladaSinRetorno(comando);
            string consulta = "select ID_Publicacion, Descripcion,ID_Estado ,ID_Tipo from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;   
        }

        private void botonFinalizar_Click(object sender, EventArgs e)
        {
            string comando = "update THE_GRID.Publicacion set ID_Estado =103 where ID_Publicacion =" + dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString();
            TG.realizarConsultaControladaSinRetorno(comando);
            botonModificar.Enabled = botonPausar.Enabled = botonFinalizar.Enabled = false;
            string consulta = "select ID_Publicacion, Descripcion,ID_Estado ,ID_Tipo from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario;   
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            (new Generar_Publicacion.GenerarPublicacion(this, dataGridView1.CurrentRow.Cells["ID_Publicacion"].Value.ToString(),esBorrador)).Show();
            this.Enabled = false;
        }

        private void EditarPublicacion_EnabledChanged(object sender, EventArgs e)
        {
            string consulta = "select ID_Publicacion, Descripcion,ID_Estado ,ID_Tipo from THE_GRID.Publicacion where ID_Vendedor = " + DatosUsuario.usuario + " order by ID_Publicacion desc";
            publicacionesUsuario = TG.realizarConsulta(consulta);
            dataGridView1.DataSource = publicacionesUsuario; 
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int filaSeleccionada = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                filaSeleccionada = row.Index;
            }
                        
            string estado =  dataGridView1["ID_Estado",filaSeleccionada].Value.ToString();
            switch (estado)
            {
                case "101"://Borrador
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled = botonFinalizar.Enabled = true;
                    botonPausar.Enabled = false;
                    esBorrador = true;
                    break;
                case "100"://Publicada
                    botonPausar.Text = "Pausar";
                    botonPausar.Enabled = botonModificar.Enabled = botonFinalizar.Enabled = true;
                    esBorrador = false;
                    break;
                case "102"://Pausada
                    botonPausar.Text = "Reanudar";
                    botonPausar.Enabled = botonFinalizar.Enabled = true;
                    botonModificar.Enabled = false;
                    esBorrador = false;
                    break;
                case "103"://Finalizada
                    botonPausar.Text = "Pausar";
                    botonModificar.Enabled = botonPausar.Enabled = botonFinalizar.Enabled = false;
                    esBorrador = false;
                    break;
            }
        }
    }
}
