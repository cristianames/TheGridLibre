using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Escritorio : FormGrid
    {
        private string comandoFunciones;
        private bool mensajeSistema = false;
        public Escritorio(Form anterior)
        {
            InitializeComponent();
            this.ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(560, 342);
            label3.Text = "¡Bienvenido Grid_" + DatosUsuario.usuario.ToString() + "!";
            linkLabel3.Text = DatosUsuario.nombreRol;

            comandoFunciones = "SELECT Nombre FROM THE_GRID.Funcionalidad f inner join THE_GRID.Funcionalidades_x_Rol r "+
                "on(f.ID_Funcionalidad = r.ID_Funcionalidad and r.ID_Rol = " + DatosUsuario.codigoRol + ") "+
                "order by 1";
            listBox1.DataSource = TG.ObtenerListado(comandoFunciones);
            //verificarDatosUsuario();
        }

        private void verificarDatosUsuario()
        {
            mensajeSistema = false;
            richTextBox1.Text = "";
            DatosUsuario.actualizarBanderasUsuario();
            if (DatosUsuario.DatosCorrectos == "False")
            {
                listBox1.Enabled = button1.Enabled = false;
                mensajeSistema = true;
                richTextBox1.Text += "[Datos incorrectos] Revisar Configuración\n\n";
                //linkLabel1.LinkColor = Color.Red;
            }
            else listBox1.Enabled = button1.Enabled = true;

            string comando;
            if (DatosUsuario.tipoUsuario == "2")
            {
                comando = "select Calif_Estrellas from THE_GRID.Compra where " +
                    "Calif_Estrellas = 0 and ID_Comprador = " + DatosUsuario.usuario;

                List<string> temporal = TG.ObtenerListado(comandoFunciones);
                if (TG.realizarConsulta(comando).Rows.Count >= 5)
                {
                    if (temporal.Contains("Comprar - Ofertar"))
                        {
                            temporal.Remove("Comprar - Ofertar");
                        }
                    listBox1.DataSource = null;
                    mensajeSistema = true;
                    richTextBox1.Text += "Tiene demasiadas calificaciones pendientes, no podrá comprar/ofertar hasta que normalice su situación\n\n";
                }
                listBox1.DataSource = temporal;
            }
            comando = "select ISNULL(count(*),0) from THE_GRID.Publicacion "+
                    "where Facturada = 0 and Fecha_Vencimiento <= "+
                    "convert(datetime,'" + TG.fechaDelSistema.ToString("yyyy-dd-MM hh:mm:ss")+ 
                    "') and ID_Vendedor = " + DatosUsuario.usuario;
            int cantFacturas = Convert.ToInt32(TG.consultaEscalar(comando).ToString());
            if (cantFacturas > 7 && cantFacturas <= 10)
            {
                mensajeSistema = true;
                richTextBox1.Text += "Actualmente tiene " + cantFacturas.ToString();
                richTextBox1.Text += " sin facturar. Tenga cuidado de no pasarse de las 10 ";
                richTextBox1.Text += "o será penalizado\n\n";
            }
            
            if (cantFacturas > 10)
            {
                mensajeSistema = true;
                richTextBox1.Text += "Ha superado el límite de 10 publicaciones sin facturar. ";
                richTextBox1.Text += "Todas sus publicaciones fueron pausadas y su usuario fue Inhabilitado. ";
                richTextBox1.Text += "Si no normaliza esta situación no podrà volver a loggearse\n\n";
                comando = "update THE_GRID.Usuario set Inhabilitado = 1 where ID_User = "+ DatosUsuario.usuario;
                TG.realizarConsultaSinRetorno(comando);
            }
            DataTable anomalias;
            int i;
            switch (DatosUsuario.tipoUsuario)
            {
                case "1":
                    comando = "select * from THE_GRID.Anomalia where Detalle = 'CUIT'";
                    anomalias = TG.realizarConsulta(comando);
                    if (anomalias.Rows.Count > 0)
                    {
                        mensajeSistema = true;
                        for (i = 0; i < anomalias.Rows.Count; i++)
                            richTextBox1.Text += "[Anomalia] Intento de usuario de introducir " +
                                "CUIT ya existente. Propietario del CUIT: GRID_" +
                                anomalias.Rows[i]["ID_User"].ToString() + " Fecha del suceso: " +
                                anomalias.Rows[i]["Fecha"].ToString() + "\n\n";
                    }
                    comando = "select * from THE_GRID.Anomalia where Detalle = 'RazonSocial'";
                    anomalias = TG.realizarConsulta(comando);
                    if (anomalias.Rows.Count > 0)
                    {
                        mensajeSistema = true;
                        for (i = 0; i < anomalias.Rows.Count; i++)
                            richTextBox1.Text += "[Anomalia] Intento de usuario de introducir " +
                                "Razon Social ya existente. Propietario de la Razon Social: GRID_" +
                                anomalias.Rows[i]["ID_User"].ToString() + " Fecha del suceso: " +
                                anomalias.Rows[i]["Fecha"].ToString() + "\n\n";
                    }

                    comando = "select * from THE_GRID.Anomalia where Detalle = 'Documento'";
                    anomalias = TG.realizarConsulta(comando);
                    if (anomalias.Rows.Count > 0)
                    {
                        mensajeSistema = true;
                        for (i = 0; i < anomalias.Rows.Count; i++)
                            richTextBox1.Text += "[Anomalia] Intento de usuario de introducir " +
                                "Documento ya existente. Propietario del documento: GRID_" +
                                anomalias.Rows[i]["ID_User"].ToString() + " Fecha del suceso: " +
                                anomalias.Rows[i]["Fecha"].ToString() + "\n\n";
                    }

                    break;
                case "2":
                    comando = "select * from THE_GRID.Anomalia where Detalle = 'TelCliente' "+
                        "and ID_User = " + DatosUsuario.usuario;
                    anomalias = TG.realizarConsulta(comando);
                    if (anomalias.Rows.Count > 0)
                    {
                        mensajeSistema = true;
                        for (i = 0; i < anomalias.Rows.Count; i++)
                            richTextBox1.Text += "[Anomalia] Intento de usuario de introducir " +
                                "su telefono en la fecha " +
                                anomalias.Rows[i]["Fecha"].ToString() + 
                                ". Comuníquese con un administrador para mas información\n\n";
                    }
                    break;
                case "3":
                    comando = "select * from THE_GRID.Anomalia where Detalle = 'TelEmpresa' " +
                        "and ID_User = " + DatosUsuario.usuario;
                    anomalias = TG.realizarConsulta(comando);
                    if (anomalias.Rows.Count > 0)
                    {
                        mensajeSistema = true;
                        for (i = 0; i < anomalias.Rows.Count; i++)
                            richTextBox1.Text += "[Anomalia] Intento de usuario de introducir " +
                                "su telefono en la fecha " +
                                anomalias.Rows[i]["Fecha"].ToString() +
                                ". Comuníquese con un administrador para mas información\n\n";
                    }
                    break;
            }

            labelMensajeSistema.Visible = richTextBox1.Visible = mensajeSistema;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TG.elLogin.Show();
            DatosUsuario.resetearDatos();
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            volverAtras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1) {

                bool continuar = true;
                
                switch (listBox1.SelectedItem.ToString())
                {
                    case "ABM Usuario":
                        (new ABM_Usuario.ABM_Usuario(this)).Show();
                        break;
                    case "ABM Cliente":
                        (new ABM_Usuario.AbmCliente(this)).Show();
                        break;
                    case "ABM Empresa":
                        (new ABM_Usuario.AbmEmpresa(this)).Show();
                        break;
                    case "ABM Rol":
                        (new ABM_Usuario.AbmRol(this)).Show();
                        break;
                    case "ABM Visibilidad":
                        (new Abm_Visibilidad.ABMVisibilidad(this)).Show();
                        break;
                    case "Calificar Vendedor":
                        (new Calificar_Vendedor.SeleccionarUsuario(this)).Show();
                        break;
                    case "Comprar - Ofertar":
                        (new Comprar_Ofertar.Buscador(this)).Show();
                        break;
                    case "Editar Publicacion":
                        (new Editar_Publicacion.EditarPublicacion(this)).Show();
                        break;
                    case "Facturar Publicaciones":
                        (new Facturar_Publicaciones.PublicacionesRendir(this)).Show();
                        break;
                    case "Generar Publicacion":
                        (new Generar_Publicacion.GenerarPublicacion(this)).Show();
                        break;
                    case "Gestion De Preguntas":
                        (new Gestion_de_Preguntas.TipoPregunta(this)).Show();
                        break;
                    case "Historial del Cliente":
                        (new Historial_Cliente.Historial(this)).Show();
                        break;
                    case "Listado Estadistico":
                        (new Listado_Estadistico.PeriodoTipo(this)).Show();
                        break;
                    default:
                        TG.ventanaEmergente("Esta Funcionalidad todavia no está implementada");
                        continuar = false;
                        break;
                }
                if (continuar) this.Visible = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new FrbaCommerce.ABM_Usuario.Registro_de_Usuario(this)).Show();
            this.Visible = false;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }

        private void Escritorio_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Escritorio_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible) verificarDatosUsuario();
        }

        private void Escritorio_Load(object sender, EventArgs e)
        {

        }
    }
}

