using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class GenerarPublicacion : FormGrid
    {
        DataTable datosConsultaVisibilidad;
        bool esSubasta;
        DateTime fechaHoy;
        DateTime fechaVencimiento;

        public GenerarPublicacion(FormGrid anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(389, 451);
            ventanaAnterior = anterior;
            string comando = @"select * from TG.Visibilidad where Inhabilitado=0 order by Precio_Por_Publicar desc";
            datosConsultaVisibilidad = TG.realizarConsulta(comando);
            esSubasta = false;
            preguntasComboBox.SelectedIndex = 0;
        }

        private void radioSubasta_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = 1;
            labelPrecio.Text = "Precio incial:";
            esSubasta = true;
        }

        private void radioCompra_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            numericUpDown1.Enabled = true;
            labelPrecio.Text = "Precio:";
            esSubasta = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // datosConsultaVisibilidad.Rows[2]["Nombre"].ToString();
            labelInicio.Text = "Fecha de inicio: " + DateTime.Today.ToString();
            //labelVencimiento.Text;
            fechaHoy =  DateTime.Today;          
            fechaVencimiento = fechaHoy.AddDays(Convert.ToDouble(datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Duracion"].ToString()));
            labelVencimiento.Text = "Fecha de vencimiento: " + fechaVencimiento.ToString();
            labelPrecioPublicar.Text = "Precio por publicar: $" + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Precio_Por_Publicar"].ToString();
            labelComision.Text = "Porcentaje de comision: " + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Porcentaje_Venta"].ToString();
            //TG.ventanaEmergente(comboBox1.SelectedIndex.ToString());
            actualizarTotal();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            string comando = "select Nombre from TG.Visibilidad order by Precio_Por_Publicar desc";
            visibilidadComboBox1.DataSource = TG.ObtenerListado(comando);
           // comando = @"select * from TG.Visibilidad where Inhabilitado=0";            
          // datosConsultaVisibilidad = TG.realizarConsulta(comando);
          //  TG.ventanaEmergente(datosConsultaVisibilidad.Rows[0]["Duracion"].ToString());
            // datosConsultaVisibilidad.Rows[3]["Nombre"].ToString();
        }

        private void txtRubro_Click(object sender, EventArgs e)
        {
            new Comprar_Ofertar.FiltroRubros(this).Show();
            this.Enabled = false;
        }

        private void botonRegresar_Click(object sender, EventArgs e)
        {
            ventanaAnterior.Show();
            this.Close();
        }
        

        private void GenerarPublicacion_EnabledChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (RubrosSeleccionados.rubros.Count > 0)
                foreach (string rubro in RubrosSeleccionados.rubros)
                {
                    textBox1.Text = textBox1.Text + "<" + rubro + ">";
                }
        }

        private void botonPublicar_Click(object sender, EventArgs e)
        {
            //Obtener el ultimo ID de publicacion
            string consulta = "select top 1 ID_Publicacion from TG.Publicacion order by ID_Publicacion desc";
            string ultimoID = TG.realizarConsulta(consulta).Rows[0]["ID_Publicacion"].ToString();
            //insertar nueva publacion
            string tipo;
            string stock;
            string preguntas;
            if (esSubasta)
            {
                tipo = "Subasta";
                stock = "1";

            }
            else
            {
                tipo = "Compra Inmediata";
                stock = numericUpDown1.Value.ToString();
            }
            if (String.Equals(preguntasComboBox.SelectedItem.ToString(), "SI"))
            {
                preguntas = "1";

            }
            else preguntas = "0";

            consulta = @"insert TG.Publicacion (ID_Publicacion,Descripcion,Estado,Fecha_Inicio,
            Fecha_Vencimiento,
            ID_Vendedor,ID_Visibilidad,Permitir_Preguntas,Precio,Stock,Tipo_Publicacion)
            VALUES (" + (Convert.ToInt32(ultimoID) + 1).ToString() + @",'" + richTextBox1.Text + @"','Publicada',convert(datetime,'" + fechaHoy.ToString("yyyy-dd-MM hh:mm:ss") + @"'),convert(datetime,'"
                      + fechaVencimiento.ToString("yyyy-dd-MM hh:mm:ss") + @"')," + DatosUsuario.usuario.ToString() + @"," + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["ID_Visibilidad"].ToString()
                      + @"," + preguntas + @"," + txtPrecio.Text + @"," + stock + @",'" + tipo + @"')";
            TG.realizarConsultaSinRetorno(consulta);
            
            //insertar rubros x publicacion
            foreach (string rubro in RubrosSeleccionados.rubros)
            {
                ObtenerRubro(rubro);//le paso un nombre de un rubro, me devuelve el ID
                consulta = "insert TG.Rubros_x_Publicacion (ID_Rubro,ID_Publicacion) values ( " + ObtenerRubro(rubro) + "," + (Convert.ToInt32(ultimoID) + 1).ToString() + ")"; //en este caso no le agrego +1 a ultimo rubro
                TG.realizarConsultaSinRetorno(consulta);
            }
            TG.ventanaEmergente("Publicacion cargada");


        }

        int ObtenerRubro(string rubro)
        {
            string comando = "select ID_Rubro from TG.Rubro where Nombre='"+rubro+"'";
            return Convert.ToInt32(TG.realizarConsulta(comando).Rows[0]["ID_Rubro"]);
        }

        private void botonBorrador_Click(object sender, EventArgs e)
        {
            //Obtener el ultimo ID de publicacion
            string consulta = "select top 1 ID_Publicacion from TG.Publicacion order by ID_Publicacion desc";
            string ultimoID = TG.realizarConsulta(consulta).Rows[0]["ID_Publicacion"].ToString();
            //insertar nueva publacion
            string tipo;
            string stock;
            string preguntas;
            if (esSubasta)
            {
                tipo = "Subasta";
                stock = "1";

            }
            else
            {
                tipo = "Compra Inmediata";
                stock = numericUpDown1.Value.ToString();
            }
            if (String.Equals(preguntasComboBox.SelectedItem.ToString(), "SI"))
            {
                preguntas = "1";

            }
            else preguntas = "0";

            consulta = @"insert TG.Publicacion (ID_Publicacion,Descripcion,Estado,Fecha_Inicio,
            Fecha_Vencimiento,
            ID_Vendedor,ID_Visibilidad,Permitir_Preguntas,Precio,Stock,Tipo_Publicacion)
            VALUES (" + (Convert.ToInt32(ultimoID) + 1).ToString() + @",'" + richTextBox1.Text + @"','Borrador',convert(datetime,'" + fechaHoy.ToString("yyyy-dd-MM hh:mm:ss") + @"'),convert(datetime,'"
                      + fechaVencimiento.ToString("yyyy-dd-MM hh:mm:ss") + @"')," + DatosUsuario.usuario.ToString() + @"," + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["ID_Visibilidad"].ToString()
                      + @"," + preguntas + @"," + txtPrecio.Text + @"," + stock + @",'" + tipo + @"')";
            TG.realizarConsultaSinRetorno(consulta);

            //insertar rubros x publicacion
            foreach (string rubro in RubrosSeleccionados.rubros)
            {
                ObtenerRubro(rubro);//le paso un nombre de un rubro, me devuelve el ID
                consulta = "insert TG.Rubros_x_Publicacion (ID_Rubro,ID_Publicacion) values ( " + ObtenerRubro(rubro) + "," + (Convert.ToInt32(ultimoID) + 1).ToString() + ")"; //en este caso no le agrego +1 a ultimo rubro
                TG.realizarConsultaSinRetorno(consulta);
            }
            TG.ventanaEmergente("Publicacion cargada");
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            actualizarTotal();   
        }

        private void actualizarTotal()
        {
            if (String.IsNullOrEmpty(txtPrecio.Text) || !Validacion.esFloat(txtPrecio.Text))
            {
                total.Text = "Calculando...";
                total.Font = new Font("Microsoft Sans Serif", 8.25f);
            }
            else
            {
                float precio = Validacion.ToFloat(txtPrecio.Text);
                string stringPrecionPorPublicar = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Precio_Por_Publicar"].ToString();
                string stringPorcentajeComision = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Porcentaje_Venta"].ToString();
                float porcentajeComision = Validacion.ToFloat(stringPorcentajeComision);
                float precioPorPublicar = Validacion.ToFloat(stringPrecionPorPublicar);
                if (porcentajeComision > 0) porcentajeComision =+ 1;
                total.Text = "$"+(precio * (float)numericUpDown1.Value * porcentajeComision + precioPorPublicar).ToString();
                //total.Text = porcentajeComision.ToString();
                total.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            actualizarTotal();
        }
    }
}
