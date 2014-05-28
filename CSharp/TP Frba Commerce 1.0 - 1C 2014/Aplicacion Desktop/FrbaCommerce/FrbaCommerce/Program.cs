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
