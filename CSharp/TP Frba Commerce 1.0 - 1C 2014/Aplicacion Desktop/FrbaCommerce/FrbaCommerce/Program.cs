using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaCommerce
{

    static class RubrosSeleccionados //clase que almacena los rubros seleccionados en la ventana FiltroRubros
    {
        public static List<string> rubros = new List<string>();

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
