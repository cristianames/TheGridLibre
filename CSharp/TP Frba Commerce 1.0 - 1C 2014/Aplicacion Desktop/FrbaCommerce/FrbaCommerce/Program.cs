using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce
{

    static class TG_Connect 
    {
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
    }
    // SqlConnection pepita = TG_Connect.conectar();


    public class FormGrid : Form
    {
        protected FormGrid()
        {
            this.ControlBox = false;
            this.MaximizeBox=false;
            this.MinimizeBox=false;
            this.ShowIcon=false;
            this.Dock = DockStyle.Fill;
        }

        protected void ventanaEmergente(string msg)
        {
            FrbaCommerce.VentanaError error = new VentanaError();
            error.escribirMsg(msg);
            error.Show();
        }

        private void ManejadorCierre(object sender, EventArgs e)
        {
            // Todas estas boludeces ocurren cuando se cierra un form de clase FromGrid
            ventanaEmergente("NO ME CIERRO NADA");
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
