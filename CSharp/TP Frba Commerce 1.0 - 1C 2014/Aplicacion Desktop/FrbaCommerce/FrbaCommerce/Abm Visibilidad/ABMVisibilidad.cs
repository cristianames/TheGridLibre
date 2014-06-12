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
    public partial class ABMVisibilidad : Form
    {

        string ID_Visibilidad;
        FormGrid ventanaAnterior;
        public ABMVisibilidad(FormGrid anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TG.ventanaEmergente("modificacion");
        }

        private void ABMVisibilidad_Load(object sender, EventArgs e)
        {
            string consulta = "select * from TG.Visibilidad";
            dataGridView1.DataSource = TG.realizarConsulta(consulta);
        }

        private void botonCrearVisibilidad_Click(object sender, EventArgs e)
        {
            (new FrbaCommerce.Abm_Visibilidad.AltaVisibilidad(this)).Show();
            this.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
           
            dataGridView1.CurrentCell.ToString();
            DataGridViewRow seleccion  =  dataGridView1.CurrentRow;

            if (!(e.RowIndex == -1) && !String.Equals(seleccion.Cells[0].Value.ToString(), ""))//no se selecciono el nombre de las columnas ni la ultima fila (la ultima fila tiene ID = caracter vacio)
            {


                botonModificar.Enabled = true;
                ID_Visibilidad = seleccion.Cells[0].Value.ToString();
                if (String.Equals(seleccion.Cells[4].Value.ToString(), "False")) 
                {
                    botonInhabilitar.Enabled = true;
                }
                else botonInhabilitar.Enabled = false;
            }
            else
            {
                dataGridView1.CurrentCell.Selected = false;
                botonModificar.Enabled = false;
                botonInhabilitar.Enabled = false;
            }
            
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            (new FrbaCommerce.Abm_Visibilidad.AltaVisibilidad(this, ID_Visibilidad)).Show();
            this.Enabled = false;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Show();
            this.Close();
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            string consulta = "update TG.Visibilidad set Inhabilitado='true' where ID_Visibilidad=" + ID_Visibilidad;
            TG.realizarConsultaSinRetorno(consulta);
            consulta = "select * from TG.Visibilidad";
            dataGridView1.DataSource = TG.realizarConsulta(consulta);
            
        }
        public void recargarGrid() 
        {
            string consulta = "select * from TG.Visibilidad";
            dataGridView1.DataSource = TG.realizarConsulta(consulta);
        }

        private void ABMVisibilidad_EnabledChanged(object sender, EventArgs e)
        {
            this.recargarGrid();
        }
        
    }
}
