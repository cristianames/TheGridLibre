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
    public partial class GenerarPublicacion : Form
    {
        DataTable datosConsultaVisibilidad;
        bool esSubasta;
        string estado = "";
        int cantGratuitas;
        DateTime fechaHoy, fechaVencimiento;
        Form ventanaAnterior;

        //Editar_Publicacion.EditarPublicacion ventanaAnterior;
        bool actualizar = false; 
        //boolean que me permite saber si estas insertando una nueva publicacion 
        //o modificando una existente
        bool esBorrador;
        DataTable datosPublicacionViejos;
        int IDAnterior;
        public GenerarPublicacion(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(451, 426);
            ventanaAnterior = anterior;
            string comando = @"select * from THE_GRID.Visibilidad where Inhabilitado=0 order by Precio_Por_Publicar desc";
            datosConsultaVisibilidad = TG.realizarConsulta(comando);
            esSubasta = false;
            preguntasComboBox.SelectedIndex = 1;
            comando = @"select COUNT(*) from THE_GRID.Publicacion p
inner join THE_GRID.Estado_Publicacion e on e.ID_Estado = p.ID_Estado and e.Nombre = 'Publicada'
inner join THE_GRID.Visibilidad v on v.ID_Visibilidad = p.ID_Visibilidad
and v.Precio_Por_Publicar = 0 and v.Porcentaje_Venta = 0 
where Facturada = 0 and ID_Vendedor = " + DatosUsuario.usuario;
            cantGratuitas = Convert.ToInt32(TG.consultaEscalar(comando).ToString());
            labelActivas.Text += cantGratuitas;
        }
        public GenerarPublicacion(Editar_Publicacion.EditarPublicacion anterior,string ID,bool valor)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            IDAnterior = Convert.ToInt32(anterior);
            esBorrador = valor;
            actualizar = true;
            string comando = @"select * from THE_GRID.Visibilidad where Inhabilitado=0 order by Precio_Por_Publicar desc";
            datosConsultaVisibilidad = TG.realizarConsulta(comando);
            esSubasta = false;
            comando = "select * from THE_GRID.Publicacion where ID_Publicacion ="+ID;
            datosPublicacionViejos = TG.realizarConsulta(comando);
            richTextBox1.Text = datosPublicacionViejos.Rows[0]["Descripcion"].ToString();
            numericUpDown1.Value = Convert.ToDecimal(datosPublicacionViejos.Rows[0]["Stock"].ToString());
            if (Convert.ToBoolean(datosPublicacionViejos.Rows[0]["Permitir_Preguntas"].ToString()))
                preguntasComboBox.SelectedIndex = preguntasComboBox.FindStringExact("SI");
            else
                preguntasComboBox.SelectedIndex = preguntasComboBox.FindStringExact("NO");
            
            
            if (!esBorrador)
            {
                radioCompra.Enabled = radioSubasta.Enabled = txtPrecio.Enabled= visibilidadComboBox1.Enabled = preguntasComboBox.Enabled = txtRubro.Enabled =  botonBorrador.Enabled= false;

            }
        }

        private void radioSubasta_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = 1;
            labelPrecio.Text = "Precio inicial:";
            esSubasta = true;
        }

        private void radioCompra_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            numericUpDown1.Enabled = true;
            labelPrecio.Text = "Precio unitario:";
            esSubasta = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // datosConsultaVisibilidad.Rows[2]["Nombre"].ToString();
            labelInicio.Text = "Fecha de inicio: " + TG.fechaDelSistema.ToString();
            //labelVencimiento.Text;
            fechaHoy =  TG.fechaDelSistema;          
            fechaVencimiento = fechaHoy.AddDays(Convert.ToDouble(datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Duracion"].ToString()));
            labelVencimiento.Text = "Fecha de vencimiento: " + fechaVencimiento.ToString();
            labelPrecioPublicar.Text = "Precio por publicar: $" + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Precio_Por_Publicar"].ToString();
            labelComision.Text = "Porcentaje de comision: " + datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Porcentaje_Venta"].ToString();
            //TG.ventanaEmergente(comboBox1.SelectedIndex.ToString());
            actualizarTotal();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            string comando = @"select Nombre from THE_GRID.Visibilidad 
                            where Inhabilitado = 0 order by Precio_Por_Publicar desc";
            visibilidadComboBox1.DataSource = TG.ObtenerListado(comando);
            if (actualizar)
            {
                foreach (string visibilidad in visibilidadComboBox1.Items) 
                {
                    if (visibilidadComboBox1.FindStringExact(visibilidad) != -1)
                    {
                        visibilidadComboBox1.SelectedIndex = visibilidadComboBox1.FindStringExact(visibilidad);
                        
                    }
                }
            } 
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
            //volverAtras();
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
            bool error = false;
            if(String.IsNullOrEmpty(txtPrecio.Text))
            {
                txtPrecio.BackColor = Color.LightYellow;
                error = true;
            } else txtPrecio.BackColor = Color.White;
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.BackColor = Color.LightYellow;
                error = true;
            } else richTextBox1.BackColor = Color.White;
            string visibilidad = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["ID_Visibilidad"].ToString();

            string comando = @"select COUNT(*) from THE_GRID.Visibilidad
where Inhabilitado = 0 and Precio_Por_Publicar = 0 and Porcentaje_Venta = 0 
and ID_Visibilidad = '"+visibilidad+"'";

            int resultado = Convert.ToInt32(TG.consultaEscalar(comando).ToString());
            if (cantGratuitas >= 3 && resultado > 0)
            {
                TG.ventanaEmergente("Ya tiene 3 publicaciones gratuitas activas. Está en el límite");
                error = true;
            }

            if (error) return;
            estado = "100"; //publicada
            guardar();
        }

        private void guardar()
        {
            if (!Validacion.esFloat(txtPrecio.Text))
            {
                txtPrecio.BackColor = Color.LightYellow;
                return;
            }
            txtPrecio.BackColor = Color.White;
            
            if (RubrosSeleccionados.rubros.Count == 0)
            {
                TG.ventanaEmergente("Si va a publicar o guardar, necesita al menos un rubro");
                return;
            }

            //Obtener el ultimo ID de publicacion
            string consulta = "select top 1 ID_Publicacion from THE_GRID.Publicacion order by ID_Publicacion desc";
            string ultimoID = TG.realizarConsulta(consulta).Rows[0]["ID_Publicacion"].ToString();

            //insertar nueva publacion
            string stock = numericUpDown1.Value.ToString();
            string preguntas = preguntasComboBox.SelectedIndex.ToString();
            string visibilidad = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["ID_Visibilidad"].ToString();
            string tipo;
            string descripcion = richTextBox1.Text;
            string precio = txtPrecio.Text;
            if (esSubasta) tipo = "101"; else tipo = "100";
            if (String.IsNullOrEmpty(richTextBox1.Text)) descripcion = "Sin Descripcion";
            if (String.IsNullOrEmpty(txtPrecio.Text)) precio = "0";
            consulta = "insert THE_GRID.Publicacion (ID_Publicacion,Descripcion," +
            "ID_Estado,Fecha_Inicio,Fecha_Vencimiento," +
            "ID_Vendedor,ID_Visibilidad,Permitir_Preguntas,Precio,Stock,ID_Tipo,Facturada)" +
            "VALUES ("+ (Convert.ToInt32(ultimoID) + 1).ToString() + ",'" + descripcion
                      + "','" + estado + "'"
                      + ",convert(datetime,'" + fechaHoy.ToString("yyyy-dd-MM hh:mm:ss")
                      + "'),convert(datetime,'" + fechaVencimiento.ToString("yyyy-dd-MM hh:mm:ss")
                      + "')," + DatosUsuario.usuario.ToString() + "," + visibilidad
                      + "," + preguntas + "," + precio + "," + stock + ",'" + tipo + "',0)";
            TG.realizarConsultaSinRetorno(consulta);

            //insertar rubros x publicacion
            foreach (string rubro in RubrosSeleccionados.rubros)
            {
                RubrosSeleccionados.ObtenerRubro(rubro);//le paso un nombre de un rubro, me devuelve el ID
                consulta = "insert THE_GRID.Rubros_x_Publicacion (ID_Rubro,ID_Publicacion) values ( " + 
                    RubrosSeleccionados.ObtenerRubro(rubro) + "," + 
                    (Convert.ToInt32(ultimoID) + 1).ToString() + ")"; //en este caso no le agrego +1 a ultimo rubro
                TG.realizarConsultaSinRetorno(consulta);
            }
            RubrosSeleccionados.rubros.Clear();
            ventanaAnterior.Show();
            TG.ventanaEmergente("Publicacion guardada");
            this.Close();
        }

        

        private void botonBorrador_Click(object sender, EventArgs e)
        {
            txtPrecio.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            estado = "101"; //borrador
            guardar();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            actualizarTotal();   
        }

        private void actualizarTotal()
        {
            if (String.IsNullOrEmpty(txtPrecio.Text) || !Validacion.esFloat(txtPrecio.Text))
            {
                total.Text = "...";
                total.Font = new Font("Microsoft Sans Serif", 8.25f);
            }
            else
            {
                float precio = Validacion.ToFloat(txtPrecio.Text);
                string stringPrecionPorPublicar = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Precio_Por_Publicar"].ToString();
                string stringPorcentajeComision = datosConsultaVisibilidad.Rows[visibilidadComboBox1.SelectedIndex]["Porcentaje_Venta"].ToString();
                float porcentajeComision = Validacion.ToFloat(stringPorcentajeComision);
                float precioPorPublicar = Validacion.ToFloat(stringPrecionPorPublicar);
                total.Text = "$"+(precio * (float)numericUpDown1.Value * porcentajeComision + precioPorPublicar).ToString();
                total.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            actualizarTotal();
        }
    }
}
