using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaCommerce
{
    public class FormGrid : Form
    {
        protected FormGrid ventanaAnterior;
        protected FormGrid()
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Dock = DockStyle.Fill;

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display the form as a modal dialog box.
            //this.ShowDialog();

        }

        private void ManejadorCierre(object sender, EventArgs e)
        {
            // Todas estas boludeces ocurren cuando se cierra un form de clase FromGrid
            TG.ventanaEmergente("NO ME CIERRO NADA");
        }

        protected void volverAtras()
        {
            this.ventanaAnterior.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGrid
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "FormGrid";
            this.Load += new System.EventHandler(this.FormGrid_Load);
            this.ResumeLayout(false);

        }

        private void FormGrid_Load(object sender, EventArgs e)
        {

        }
    }
    
    public class FormGridTerminal : FormGrid
    {
        protected FormGridTerminal()
        {
            this.FormClosed += ManejadorCierre;
            this.ControlBox = true;
        }

        private void ManejadorCierre(object sender, EventArgs e)
        {
            //Si me cierran, cierro todo.
            System.Environment.Exit(0);
        }
    }

    static class TG 
    {
        public static FormGrid elLogin;
        public static SqlConnection conectar()
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source=localhost\SQLSERVER2008;" +
                                      "user id=gd;" +
                                      "password=gd2014;" +
                                      "Initial Catalog=GD1C2014; " +
                                      "Integrated Security=True");
            Conexion.Open();
            return Conexion;
        }

        public static string encriptar(string input)
        {
            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(input);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha256Str += cryString[i].ToString("x2").ToLower();
            }
            return sha256Str;
        }

        public static List<string> ObtenerListado(string comando)
        {
            List<string> _lista = new List<string>();
            SqlConnection conexion = TG.conectar();
            SqlCommand _comando = new SqlCommand(comando, conexion);
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read()) _lista.Add(_reader.GetString(0));
            conexion.Close();
            return _lista;
        }

        public static void ventanaEmergente(string msg)
        {
            FrbaCommerce.VentanaError error = new VentanaError();
            error.escribirMsg(msg);
            error.Show();

        }

        public static DataTable realizarConsulta(string comando) //probar
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand(comando, myConnection);
            DataTable unDataTable = new DataTable();
            unDataTable.Load(myCommand.ExecuteReader());
            myConnection.Close();
            return unDataTable;
        }
        public static void realizarConsultaSinRetorno(string comando) 
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand(comando, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return;
        }

        public static bool esNumerico(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }

    static class DatosUsuario {
        public static int usuario = (-1); //variables globales o.O
        public static int codigoRol = (-1);
        public static string nombreRol = "";
        public static int tipoUsuario = (-1);
        public static int tipoUsuarioModif = (-1);
        public static int usuarioAux = (-1);

        public static void actualizarTipoUsuario() 
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand("select ID_Tipo from TG.Usuario " +
                "where ID_User = " + DatosUsuario.usuario.ToString(), myConnection);
            SqlDataReader consulta = myCommand.ExecuteReader();
            consulta.Read();
            DatosUsuario.tipoUsuario = Convert.ToInt32(consulta["ID_Tipo"]);
            myConnection.Close();
            return;
        }

        public static void resetearDatos() 
        {
            DatosUsuario.usuario = (-1);
            DatosUsuario.codigoRol = (-1);
            DatosUsuario.nombreRol = "";
            DatosUsuario.tipoUsuario = (-1);
        }

        public static void resetearDatosModif()
        {
            DatosUsuario.tipoUsuarioModif = (-1);
            DatosUsuario.usuario = DatosUsuario.usuarioAux;
            DatosUsuario.usuarioAux = (-1);
        }
       
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Portal());
        }

    }
}
