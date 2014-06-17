using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce
{
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

        public static bool realizarConsultaControladaSinRetorno(string comando)
        {

            SqlConnection myConnection = TG.conectar();
            SqlCommand myCommand = new SqlCommand(comando, myConnection);
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                myConnection.Close();
                return false;
            }
            myConnection.Close();
            return true;
        }

        public static DataTable consultaPaginada(int index, int pageSize, string comando)
        {
            SqlConnection myConection = TG.conectar();
            SqlDataAdapter adapter = new SqlDataAdapter(comando, myConection);
            DataTable data = new DataTable();
            adapter.Fill(index*pageSize,pageSize,data);
            myConection.Close();
            return data;
        }

        public static object consultaEscalar(string comando){
            SqlConnection myConection = TG.conectar();
            SqlCommand myCommand = new SqlCommand(comando,myConection);
            object resultado = myCommand.ExecuteScalar();
            myConection.Close();
            return resultado;
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
}
