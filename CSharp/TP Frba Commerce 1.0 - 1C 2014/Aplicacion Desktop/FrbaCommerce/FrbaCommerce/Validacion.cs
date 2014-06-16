using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace FrbaCommerce
{
    public static class Validacion
    {
        public static bool esFloat(string campo) {
            for (int i = 0; i < campo.Length; i++)
            {
                if (!(campo[i] == '1' || campo[i] == '2' || campo[i] == '3' || campo[i] == '4' ||
                      campo[i] == '5' || campo[i] == '6' || campo[i] == '7' || campo[i] == '8' ||
                      campo[i] == '9' || campo[i] == '0' || campo[i] == ',')) return false;
                if (campo[i] == ',')
                {
                    if (!esNumero(campo.Substring(i + 1)) || !(campo.Substring(i + 1).Length == 2)) return false;
                }
            }
            return true;
        }

        public static bool esNumero(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!(a[i] == '1' || a[i] == '2' || a[i] == '3' || a[i] == '4' || a[i] == '5'|| 
                      a[i] == '6' || a[i] == '7' || a[i] == '8' || a[i] == '9' || a[i] == '0')) 
                    return false;
            }
            return true;
        }

        public static string conComa(string campo) 
        {
            int i;
            for (i = 0; i < campo.Length; i++) if(campo[i] == ',') break;
            char[] chars = campo.ToCharArray();
            if (i < campo.Length) chars[i] = '.';
            return new string(chars);
        }

        public static string tomarParteEntera(string numeroFloat)
        {
            string entero = "";
            for (int i = 0; i < numeroFloat.Length; i++)
            {
                if (numeroFloat[i] == ',') break;
                entero += numeroFloat[i];
            }
            return entero;
        }

        public static float ToFloat(string numeroFloat)
        {
            return Convert.ToSingle(conComa(numeroFloat), CultureInfo.InvariantCulture); 
            //return Convert.ToSingle(conComa(numeroFloat), CultureInfo.CreateSpecificCulture("es-ES"));
        }
    }
}
