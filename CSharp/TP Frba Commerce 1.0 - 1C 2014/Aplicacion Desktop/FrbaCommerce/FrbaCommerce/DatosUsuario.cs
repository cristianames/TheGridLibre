using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce
{
    static class DatosUsuario
    {
        public static int usuario = (-1); //variables globales o.O
        public static int codigoRol = (-1);
        public static string nombreRol = "";
        public static int tipoUsuario = (-1);
        public static int tipoUsuarioModif = (-1);
        public static int usuarioAux = (-1);
        public static int DatosCorrectos = -1;

        public static void actualizarBanderasUsuario()
        {
            string comando = "select ID_Tipo, Datos_Correctos from THE_GRID.Usuario " +
                "where ID_User = " + DatosUsuario.usuario.ToString();
            DataRow consulta = TG.realizarConsulta(comando).Rows[0];
            DatosUsuario.tipoUsuario = Convert.ToInt32(consulta["ID_Tipo"]);
            DatosUsuario.DatosCorrectos = Convert.ToInt32(consulta["Datos_Correctos"]);
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
}
