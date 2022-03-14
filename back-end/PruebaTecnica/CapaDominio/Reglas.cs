using CapaDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio
{
    public class Reglas
    {
        public static bool ValidarLibro(Libro libro)
        {
            if (!ValidarCampo(libro.Autor) || !ValidarCampo(libro.TituloLibro) || !ValidarCampo(libro.Editorial))
            {
                return false;
            }
            if (!ValidarFecha(libro.FechaPublicacion))
            {
                return false;
            }
            return true;
        }

        public static bool ValidarCampo(string campo)
        {
            if (campo == null || campo.Trim().Length == 0)
            {
                return false;
            }
          
            return true;
        }

        public static bool ValidarFecha(object fecha)
        {
            bool result;
            try
            {
                DateTime myDT = DateTime.Parse(fecha.ToString());
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
