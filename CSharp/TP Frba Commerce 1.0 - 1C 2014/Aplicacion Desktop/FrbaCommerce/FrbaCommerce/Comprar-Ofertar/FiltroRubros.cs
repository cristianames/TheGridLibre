using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FiltroRubros : FormGrid
    {
        public FiltroRubros(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(521, 366);
            ventanaAnterior = anterior;
        }

        private void FiltroRubros_Load(object sender, EventArgs e)
        {
            string comando = "select Nombre from TG.Rubro order by Nombre";
            List<string> listaNombres = TG.ObtenerListado(comando);
            string [] nombres = listaNombres.ToArray();
            foreach (string nombre in TG.ObtenerListado(comando)) 
            {
                if (!RubrosSeleccionados.rubros.Contains(nombre))
                    listBox1.Items.Add(nombre);
                else
                    listBox2.Items.Add(nombre);
            }
            button1.Enabled = button2.Enabled = false;

                       
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
            button1.Enabled = false;
            //faltaria hacer un re ordenamiento alfabetico en las listboxs cada vez q se modifican
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.Remove(listBox2.SelectedItem);
            button2.Enabled = false;
            

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Enabled = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RubrosSeleccionados.rubros.Clear();
            foreach (string nombre in listBox2.Items)
            {
                RubrosSeleccionados.rubros.Add(nombre);
            }
            ventanaAnterior.Enabled = true;
            this.Close();
        }
       
    }
}
