using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LevantarDatosSQL
    // es una hermosa aplicacion de consola
{

    public static class Globals
    {
        public static String s_Name = "Mike"; // Modifiable in Code
    }

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conexion = new SqlConnection(
                @"Data Source=localhost\SQLSERVER2008;" +
                "Initial Catalog=GD1C2014;" +
                "Integrated Security=True;" +
                "User Id=gd" +
                "Password=gd2014"
            );

            //////////////////////////
            //   USANDO UNA FUNCION
            /////////////////////////

            int unDNI;
            unDNI = 8064359;
            SqlCommand comandoSql = new SqlCommand("select TG.dameUserIDdni("+ unDNI +") as columnaCopada", conexion);
            // si, estoy usando una funcion en un select sin FROM, que tal?

            conexion.Open();
            comandoSql.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter(comandoSql); 
            DataSet dataSet = new DataSet();
            adaptador.Fill(dataSet);
            conexion.Close();
            // todo esto de arriba es burocracia, copy and paste

            System.Console.Out.WriteLine("ID: " + dataSet.Tables[0].Rows[0]["columnaCopada"]);

            //////////////////////////
            //   USANDO UN STORED PROCEDURE
            /////////////////////////

            /*
             * create procedure TG.duplicar @x int, @y int out as
             * set @y = 2*@x  
             */

            using (SqlCommand cmd = new SqlCommand("TG.duplicar", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter x; 
                x = new SqlParameter("@x", SqlDbType.Int);
                x.Value = 666; //mi numero favorito
                x.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(x);

                SqlParameter y;
                y = new SqlParameter("@y", SqlDbType.Int);
                y.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(y);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

                System.Console.Out.WriteLine("x=" + x.Value + " ; y=" + y.Value);
            }

            Globals.s_Name = "Holaaaa";
            System.Console.Out.WriteLine(Globals.s_Name);

        }
    }
}
