using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FrbaCommerce
{
    static class TG
    {
        public static FormGrid elLogin;
        private static string conexion = "";
        public static DateTime fechaDelSistema;
        public static SqlConnection conectar()
        {
            /*SqlConnection Conexion = new SqlConnection(@"Data Source=localhost\SQLSERVER2008;" +
                                      "user id=gd;" +
                                      "password=gd2014;" +
                                      "Initial Catalog=GD1C2014; " +
                                      "Integrated Security=True");
            
            */
            SqlConnection Conexion = new SqlConnection(@conexion);
            Conexion.Open();
            return Conexion;
        }

        public static void levantarConfig()
        {
            //tiene esa ruta porque el .exe se genera en la carpeta de debuggeo 
            StreamReader sr = File.OpenText(@"..\..\config.txt");
            conexion = sr.ReadLine();
            fechaDelSistema = Convert.ToDateTime( sr.ReadLine() );
            sr.Close();
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

        public static void procGenerarFactura(int top, string formaPago, string tarjeta) 
        {
            SqlConnection myConnection = TG.conectar();
            SqlCommand cmd = new SqlCommand("THE_GRID.GenerarFactura", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter _top = new SqlParameter("@top", SqlDbType.Int);
            _top.Value = top;
            _top.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(_top);
            SqlParameter _ID_Vendedor = new SqlParameter("@ID_Vendedor", SqlDbType.Int);
            _ID_Vendedor.Value = Convert.ToInt32(DatosUsuario.usuario);
            _ID_Vendedor.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(_ID_Vendedor);
            SqlParameter _fecha = new SqlParameter("@fecha", SqlDbType.Date);
            _fecha.Value = TG.fechaDelSistema;
            _fecha.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(_fecha);
            SqlParameter _FormaPago = new SqlParameter("@FormaPago", SqlDbType.NVarChar);
            _FormaPago.Value = formaPago;
            _FormaPago.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(_FormaPago);
            SqlParameter _tarjeta = new SqlParameter("@tarjeta", SqlDbType.Int);
            _tarjeta.Value = Convert.ToInt32(tarjeta);
            _tarjeta.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(_tarjeta);
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }

        internal static int procLogin(string usuario, string password)
        {
            
                SqlConnection myConnection = TG.conectar();
                SqlCommand cmd = new SqlCommand("THE_GRID.login", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user;
                user = new SqlParameter("@user", SqlDbType.Int);
                user.Value = Convert.ToInt32(usuario);
                user.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(user);

                SqlParameter pass;
                pass = new SqlParameter("@pass", SqlDbType.NVarChar);
                pass.Value = TG.encriptar(password);
                pass.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(pass);

                SqlParameter protocolo;
                protocolo = new SqlParameter("@protocolo", SqlDbType.Int);
                protocolo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(protocolo);

                cmd.ExecuteNonQuery();
                myConnection.Close();

                return Convert.ToInt32(protocolo.Value);
        }
    }
}
