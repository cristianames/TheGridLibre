using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    static class RubrosSeleccionados
    //clase que almacena los rubros seleccionados en la ventana FiltroRubros
    {
        public static List<string> rubros = new List<string>();

        public static int ObtenerRubro(string rubro)
        {
            string comando = "select ID_Rubro from THE_GRID.Rubro where Nombre='" + rubro + "'";
            return Convert.ToInt32(TG.realizarConsulta(comando).Rows[0]["ID_Rubro"]);
        }

    }

}
