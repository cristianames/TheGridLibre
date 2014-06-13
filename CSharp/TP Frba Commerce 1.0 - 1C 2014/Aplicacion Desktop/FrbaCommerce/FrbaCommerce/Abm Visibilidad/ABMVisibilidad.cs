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
    public partial class ABMVisibilidad : FormGrid
    {

        string ID_Visibilidad, comandoConsulta;
        bool mostrarInhabilitados = false;
        public ABMVisibilidad(FormGrid anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(480, 379);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TG.ventanaEmergente("modificacion");
        }

        private void ABMVisibilidad_Load(object sender, EventArgs e)
        {
            resetearComando();
            recargarGrid();
        }

        private void botonCrearVisibilidad_Click(object sender, EventArgs e)
        {
            (new FrbaCommerce.Abm_Visibilidad.AltaVisibilidad(this)).Show();
            this.Enabled = false;
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            (new AltaVisibilidad(this, ID_Visibilidad)).Show();
            this.Visible = false;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonInhabilitar_Click(object sender, EventArgs e)
        {
            (new Baja(this, ID_Visibilidad)).Show();
            this.Visible = false;
            
        }
        public void recargarGrid() 
        {
            dataGridView1.DataSource = TG.realizarConsulta(comandoConsulta);
        }

        private void botonMostrar_Click(object sender, EventArgs e)
        {
            if (mostrarInhabilitados)
            {
                mostrarInhabilitados = false;
                botonMostrar.Text = "Mostrar Inhabilitados";
                resetearComando();
                dataGridView1.DataSource = null;
                recargarGrid();
            }
            else 
            {
                botonMostrar.Text = "Ocultar Inhabilitados";
                comandoConsulta = "select Inhabilitado,ID_visibilidad,Nombre,Precio_Por_Publicar,Porcentaje_Venta"+
                    " from TG.Visibilidad";
                dataGridView1.DataSource = null;
                recargarGrid();
                mostrarInhabilitados = true;
            }
        }

        private void resetearComando()
        {
            comandoConsulta = "select ID_visibilidad,Nombre,Precio_Por_Publicar,Porcentaje_Venta " +
                "from TG.Visibilidad where Inhabilitado = 0";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dataGridView1.CurrentRow;
            ID_Visibilidad = seleccion.Cells["ID_Visibilidad"].Value.ToString();
            botonModificar.Enabled = true;
            if (mostrarInhabilitados)
            {
                if (String.Equals(seleccion.Cells["Inhabilitado"].Value.ToString(), "True"))
                {
                    botonInhabilitar.Enabled = false;
                    botonModificar.Enabled = false;
                }
                else 
                { 
                    botonInhabilitar.Enabled = true;
                    botonModificar.Enabled = true;
                }
            }
        }

        private void ABMVisibilidad_VisibleChanged(object sender, EventArgs e)
        {
            this.recargarGrid();
        }
        
    }
}
