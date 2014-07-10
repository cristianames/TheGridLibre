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
    public partial class AltaVisibilidad : FormGrid
    {
        string IDBaja = "",nombreBaja= "",ID_Tipo;
        public AltaVisibilidad(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(260, 207);
            ventanaAnterior = anterior;
            string comando = "select max(ID_Tipo) + 1 from THE_GRID.Tipo_Visibilidad";
            ID_Tipo = TG.consultaEscalar(comando).ToString();
        }
        public AltaVisibilidad(FormGrid anterior,string ID)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(260, 207);
            ventanaAnterior = anterior;
            string consulta = "select * from THE_GRID.Visibilidad where ID_Visibilidad =" + ID;
            DataRow fila = TG.realizarConsulta(consulta).Rows[0];
            txtNombre.Text = fila["Nombre"].ToString();
            txtPrecio.Text = fila["Precio_Por_Publicar"].ToString();
            txtPorcentaje.Text = fila["Porcentaje_Venta"].ToString();
            txtDuracion.Text = fila["Duracion"].ToString();
            //labelAviso.Text = "Recuerde que si desea guardar los cambios, debera insertar otro codigo para la visibilidad y la actual sera dada de baja";
            IDBaja = ID;
            nombreBaja = fila["Nombre"].ToString();
            ID_Tipo = fila["ID_Tipo"].ToString();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = txtPorcentaje.Text = txtPrecio.Text = "";
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            botonCancelar.Enabled = false;
            botonGuardar.Enabled = false;
            if (txtPorcentaje.BackColor == Color.LightYellow || txtPrecio.BackColor == Color.LightYellow ||
                txtNombre.BackColor == Color.LightYellow || txtDuracion.BackColor == Color.LightYellow)
            {
                TG.ventanaEmergente("Corrija por favor los campos en amarillo antes de continuar");
                botonCancelar.Enabled = true;
                botonGuardar.Enabled = true;
                return;
            }

            string validacionNombreRepetido = "select Nombre from THE_GRID.Visibilidad " +
                    "where Inhabilitado = 0";

            if(!String.IsNullOrEmpty(IDBaja)) 
                validacionNombreRepetido +=" and ID_Visibilidad <> " + IDBaja;

            List<string> listaNombres = TG.ObtenerListado(validacionNombreRepetido);
            foreach (string nombre in listaNombres) //validacion nombre
            {
                if (nombre == txtNombre.Text)
                {
                    TG.ventanaEmergente("Nombre repetido, ingrese otro por favor");
                    txtNombre.BackColor = Color.LightYellow;
                    botonCancelar.Enabled = true;
                    botonGuardar.Enabled = true;
                    return;
                }
            }
            string comando;
            if (!String.IsNullOrEmpty(IDBaja))
                comando = "update THE_GRID.Visibilidad set Inhabilitado = 1 " +
                    "where ID_Visibilidad = " + IDBaja;
            else
                comando = "insert into THE_GRID.Tipo_Visibilidad values('"+
                    txtNombre.Text + "')";
            TG.realizarConsultaSinRetorno(comando);
            
            //como no me toma las comas, los convierto en puntos con Validacion.conComa
            string precio = Validacion.conComa(txtPrecio.Text);
            string porcentaje = Validacion.conComa(txtPorcentaje.Text);
            string consulta="INSERT INTO THE_GRID.Visibilidad (Nombre,Precio_Por_Publicar,"+
                "Porcentaje_Venta,Duracion,Inhabilitado,ID_Tipo)"+
            "VALUES ('" + txtNombre.Text + "'," + precio + "," + porcentaje + "," + 
            txtDuracion.Text + ",0,"+ID_Tipo+")";
            TG.realizarConsulta(consulta);
            volverAtras();
        }

        private void AltaVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            bool soloNumeros = Validacion.esFloat(txtPrecio.Text);

            if (!soloNumeros) txtPrecio.BackColor = Color.LightYellow;
            else txtPrecio.BackColor = Color.White;
            
            if (String.IsNullOrEmpty (txtPrecio.Text)) txtPrecio.BackColor = Color.LightYellow;
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            bool soloNumeros = Validacion.esFloat(txtPorcentaje.Text);

            if (!soloNumeros) txtPorcentaje.BackColor = Color.LightYellow;
            else txtPorcentaje.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtPorcentaje.Text)) txtPorcentaje.BackColor = Color.LightYellow;
        }
        

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text)) txtNombre.BackColor = Color.LightYellow;
            else txtNombre.BackColor = Color.White;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void txtDuracion_TextChanged(object sender, EventArgs e)
        {
            bool soloNumeros = Validacion.esNumero(txtDuracion.Text);

            if (!soloNumeros) txtDuracion.BackColor = Color.LightYellow;
            else txtDuracion.BackColor = Color.White;

            if (String.IsNullOrEmpty(txtDuracion.Text)) txtDuracion.BackColor = Color.LightYellow;
        }

    }
}