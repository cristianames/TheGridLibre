using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FrbaCommerce
{

    static class RubrosSeleccionados //clase que almacena los rubros seleccionados en la ventana FiltroRubros
    {
        public static List<string> rubros = new List<string>();

        public static int ObtenerRubro(string rubro)
        {
            string comando = "select ID_Rubro from TG.Rubro where Nombre='" + rubro + "'";
            return Convert.ToInt32(TG.realizarConsulta(comando).Rows[0]["ID_Rubro"]);
        }

    }
    public class Validator
    {
        public Validator()
        {
        }
        public bool validar_numerico(string fuente)
        {
            long numero;
            bool ok = long.TryParse(fuente, out numero);
            return ok;
        }
        public bool validar_email(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0) return true;
                else return false;
            }
            else return false;
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
