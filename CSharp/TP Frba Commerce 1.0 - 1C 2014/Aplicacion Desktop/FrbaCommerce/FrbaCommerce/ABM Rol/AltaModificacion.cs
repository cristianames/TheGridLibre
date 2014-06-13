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
    public partial class AltaModificacion : FormGrid

    {
        private int rol;
        public AltaModificacion(FormGrid anterior, int rol)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(186, 323);
            this.ventanaAnterior = anterior;
            this.rol = rol;
            ((ListBox)checkedListBox1).DataSource = TG.ObtenerListado("SELECT Nombre FROM TG.Funcionalidad");
            if (rol > 0) levantarDatos();
            if (rol == 1) botonCrear.Enabled = false;
        }

        private void levantarDatos()
        {
            string comando = "select Nombre from TG.Rol where ID_Rol =" + rol.ToString();
            txtNombre.Text = TG.realizarConsulta(comando).Rows[0]["Nombre"].ToString();
            botonCrear.Text = "Guardar";    
            comando = "SELECT f.ID_Funcionalidad FROM TG.Funcionalidad f " +
                "inner join TG.Funcionalidades_x_Rol r on(" +
                "f.ID_Funcionalidad = r.ID_Funcionalidad and " +
                "r.ID_Rol = "+rol.ToString() +")";
            DataTable originales = TG.realizarConsulta(comando);
            List<int> indices = new List<int>();
            foreach (DataRow row in originales.Rows)
            {
                indices.Add( Convert.ToInt32(row[0]) - 1);
            }
            foreach (int indice in indices)
            {
                checkedListBox1.SetItemChecked(indice, true);
            }            
        }

        private void AltaModificacion_Load(object sender, EventArgs e)
        {

        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void botonCrear_Click(object sender, EventArgs e)
        {
            bool error = validarDatos();
            if (error) 
            {
               txtNombre.BackColor = Color.LightYellow;
               return;
            }
            
            txtNombre.BackColor = Color.White;
            List<string> seleccionados = checkedListBox1.CheckedItems.Cast<string>().ToList<string>();
            
            botonCrear.Enabled = false;
            botonAtras.Enabled = false;
            botonCrear.Text = "Procesando";
            string comando;
            int id_Funcionalidad, i;
            string funcionalidad;
            if (rol == 0)
            {
                comando = "insert into TG.Rol(Nombre,Inhabilitado) values('" +
                    txtNombre.Text + "',0)";
                TG.realizarConsultaSinRetorno(comando);

                comando = "select ID_Rol from TG.Rol where " +
                    "Nombre = '" + txtNombre.Text + "'";
                rol = Convert.ToInt32(TG.realizarConsulta(comando).Rows[0]["ID_Rol"]);
            }
            else 
            {
                comando = "update TG.Rol set Nombre = '" + txtNombre.Text + "'" +
                    "where ID_Rol = " + rol.ToString();
                TG.realizarConsulta(comando);

                comando = "delete from TG.Funcionalidades_x_Rol where ID_Rol =" + rol.ToString();
                TG.realizarConsultaSinRetorno(comando);
   
            }
            
            for (i = 0; i < seleccionados.Count; i++)
            {
                funcionalidad = seleccionados.ElementAt(i).ToString();
                id_Funcionalidad = checkedListBox1.Items.IndexOf(funcionalidad) + 1;

                comando = "insert into TG.Funcionalidades_x_Rol values("
                    + rol.ToString() + "," + id_Funcionalidad.ToString() + ")";
                TG.realizarConsulta(comando);
            }
            volverAtras();
           
        }

        private bool validarDatos()
        {
            if (botonCrear.Text.Length == 0) return true;
            string comando = "select Nombre from TG.Rol where ID_Rol =" + rol.ToString();

            DataTable resultado = TG.realizarConsulta(comando);

            if (resultado.Rows.Count > 0)
            {
                string nombreRol = resultado.Rows[0]["Nombre"].ToString();
                if (!String.Equals(txtNombre.Text, nombreRol) && rol > 0)
                {
                    comando = "select * from TG.Rol where Nombre = '" + txtNombre.Text + "'";
                    if (TG.realizarConsulta(comando).Rows.Count > 0) return true;
                }
            }

            return false;
        }
    }
}
