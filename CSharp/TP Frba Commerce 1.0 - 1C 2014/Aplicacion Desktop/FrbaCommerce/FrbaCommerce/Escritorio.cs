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
        public Escritorio(FormGrid anterior)
        {
            InitializeComponent();
            this.ventanaAnterior = anterior;
            this.ClientSize = new System.Drawing.Size(205, 352);
            label3.Text = "¡Bienvenido Grid_" + DatosUsuario.usuario.ToString() + "!";
            linkLabel3.Text = DatosUsuario.nombreRol;

            string comando = "SELECT Nombre FROM THE_GRID.Funcionalidad f inner join THE_GRID.Funcionalidades_x_Rol r "+
                "on(f.ID_Funcionalidad = r.ID_Funcionalidad and r.ID_Rol = " + DatosUsuario.codigoRol.ToString() + ")";
            listBox1.DataSource = TG.ObtenerListado(comando);
        }

        private void Escrtorio_Load(object sender, EventArgs e)
        {
            verificarDatosUsuario();
        }

        private void verificarDatosUsuario()
        {
            DatosUsuario.actualizarBanderasUsuario();
            if (DatosUsuario.DatosCorrectos == 0)
            {
                listBox1.Enabled = false;
                button1.Enabled = false;
                linkLabel1.Text = "Configuración [Datos incorrectos]";
                linkLabel1.LinkColor = Color.Red;
            }
            else
            {
                listBox1.Enabled = true;
                button1.Enabled = true;
                linkLabel1.Text = "Configuración";
                linkLabel1.LinkColor = Color.Cyan;
            }
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
                        //(new AbmUsuario.AbmUsuario(this)).Show();
                        TG.ventanaEmergente("Esta Funcionalidad todavia no está implementada");
                        continuar = false;
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
            verificarDatosUsuario();
        }
    }
}

