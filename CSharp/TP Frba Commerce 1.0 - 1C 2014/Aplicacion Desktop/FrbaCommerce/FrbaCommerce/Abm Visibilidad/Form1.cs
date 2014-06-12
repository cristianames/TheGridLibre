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
    public partial class AltaVisibilidad : Form
    {
        Form ventanaAnterior;
        bool darBaja = false;
        string IDBaja;
        string nombreBaja= "";
        public AltaVisibilidad(Form anterior)
        
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            txtNombre.BackColor = Color.Yellow;
            txtPrecio.BackColor = Color.Yellow;
            txtCod.BackColor = Color.Yellow;
            txtPorcentaje.BackColor = Color.Yellow;

            
        }
        public AltaVisibilidad(Form anterior,string ID)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            DataTable datosVisibilidad;
            string consulta = "select ID_Visibilidad,Nombre,Precio_Por_Publicar,Porcentaje_Venta,Inhabilitado from TG.Visibilidad where ID_Visibilidad =" + ID;
            datosVisibilidad = TG.realizarConsulta(consulta);
            DataRow fila = datosVisibilidad.Rows[0];
            txtCod.Text = fila["ID_VIsibilidad"].ToString();
            txtNombre.Text = fila["Nombre"].ToString();
            txtPrecio.Text = fila["Precio_Por_Publicar"].ToString();
            txtPorcentaje.Text = fila["Porcentaje_Venta"].ToString();            
            labelAviso.Text = "Recuerde que si desea guardar los cambios, debera insertar otro codigo para la visibilidad y la actual sera dada de baja";
            darBaja = true;
            IDBaja = ID;
            nombreBaja = fila["Nombre"].ToString();
           
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtCod.Text = txtNombre.Text = txtPorcentaje.Text = txtPrecio.Text = "";

        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (txtCod.BackColor == Color.Yellow || txtPorcentaje.BackColor == Color.Yellow || txtPrecio.BackColor == Color.Yellow || txtNombre.BackColor == Color.Yellow)
            {
                TG.ventanaEmergente("Corrija por favor los campos en amarillo antes de continuar");
                return;
            }


            string validacionNombreRepetido = "select Nombre from TG.Visibilidad where Inhabilitado = 'false' ";
            List<string> listaNombres = TG.ObtenerListado(validacionNombreRepetido);
            foreach (string nombre in listaNombres) //validacion nombre
            {
                if (String.Equals(nombre, txtNombre.Text)) 
                {
                    if(!darBaja || !String.Equals(txtNombre.Text,nombreBaja))
                    TG.ventanaEmergente("Nombre repetido, ingrese otro por favor");
                    return;
                }
            }
            string consulta=@"INSERT INTO TG.Visibilidad (ID_Visibilidad,Nombre,Precio_Por_Publicar,Porcentaje_Venta,Inhabilitado)
            VALUES ("+Convert.ToInt32(txtCod.Text)+@",'"+txtNombre.Text+@"',"+txtPrecio.Text+@","+txtPorcentaje.Text+@",'false')";
            if (TG.realizarConsultaControladaSinRetorno(consulta))
            {
                //aca antes hacia algo
            }
            else
            {
                TG.ventanaEmergente("Codigo de Visibilidad ya existente, por favor ingrese otro");
                return;
            }
            if (darBaja) 
            {
                consulta="UPDATE TG.Visibilidad set Inhabilitado='true' where ID_Visibilidad="+IDBaja;
                TG.realizarConsultaSinRetorno(consulta);
            }

            ventanaAnterior.Enabled = true; ;
            this.Close();

            

        }

        private void AltaVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            //if (this.Text.Length == 0) txtCod.BackColor = Color.Yellow;
            bool soloNumeros = true;
            char[] letras = txtCod.Text.ToCharArray();          
            foreach (char a in letras) 
            {
                if (!(a == '1' || a == '2' || a == '3' || a == '4' || a == '5' || a == '6' || a == '7' || a == '8' || a == '9' || a == '0')) soloNumeros = false;
            }
            if (!soloNumeros) 
            {
                txtCod.BackColor = Color.Yellow;
            }
            else 
            {
                txtCod.BackColor = Color.White;
            }
            if (String.IsNullOrEmpty(txtCod.Text)) txtCod.BackColor = Color.Yellow;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            
            bool soloNumeros = true;
            char[] letras = txtPrecio.Text.ToCharArray();
            for (int i = 0; i < txtPrecio.Text.Length; i++)
            {
                if (!(txtPrecio.Text[i] == '1' || txtPrecio.Text[i] == '2' || txtPrecio.Text[i] == '3' || txtPrecio.Text[i] == '4' || txtPrecio.Text[i] == '5'
                    || txtPrecio.Text[i] == '6' || txtPrecio.Text[i] == '7' || txtPrecio.Text[i] == '8' || txtPrecio.Text[i] == '9' || txtPrecio.Text[i] == '0' || txtPrecio.Text[i] == '.')) soloNumeros = false;
                if (txtPrecio.Text[i] == '.')
                {
                    if (!esNumero(txtPrecio.Text.Substring(i + 1)) || !(txtPrecio.Text.Substring(i + 1).Length == 2)) soloNumeros = false;
                }
            }


            if (!soloNumeros)
            {
                txtPrecio.BackColor = Color.Yellow;
            }
            else
            {
                txtPrecio.BackColor = Color.White;
            }
            if (String.IsNullOrEmpty (txtPrecio.Text)) txtPrecio.BackColor = Color.Yellow;
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            //if (this.Text.Length == 0) txtCod.BackColor = Color.Yellow;
            bool soloNumeros = true;
            char[] letras = txtPorcentaje.Text.ToCharArray();
            for (int i=0; i < txtPorcentaje.Text.Length; i++)
            {
                if (!(txtPorcentaje.Text[i] == '1' || txtPorcentaje.Text[i] == '2' || txtPorcentaje.Text[i] == '3' || txtPorcentaje.Text[i] == '4' || txtPorcentaje.Text[i] == '5'
                    || txtPorcentaje.Text[i] == '6' || txtPorcentaje.Text[i] == '7' || txtPorcentaje.Text[i] == '8' || txtPorcentaje.Text[i] == '9' || txtPorcentaje.Text[i] == '0' || txtPorcentaje.Text[i] == '.')) soloNumeros = false;
                if (txtPorcentaje.Text[i] == '.') 
                {
                    if(!esNumero(txtPorcentaje.Text.Substring(i+1))||!(txtPorcentaje.Text.Substring(i+1).Length==2))soloNumeros = false;
                }
            }
            
           
            if (!soloNumeros)
            {
                txtPorcentaje.BackColor = Color.Yellow;
            }
            else
            {
                txtPorcentaje.BackColor = Color.White;
            }
            if (String.IsNullOrEmpty(txtPorcentaje.Text)) txtPorcentaje.BackColor = Color.Yellow;
        }
        bool esNumero(string a) 
        {
          
            char[] letras = a.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (!(a[i] == '1' || a[i] == '2' || a[i] == '3' || a[i] == '4' || a[i] == '5'
                    || a[i] == '6' || a[i] == '7' || a[i] == '8' || a[i] == '9' || a[i] == '0')) return false;
                
            }
            return true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text)) txtNombre.BackColor = Color.Yellow;
            else txtNombre.BackColor = Color.White;
        }

    }
}