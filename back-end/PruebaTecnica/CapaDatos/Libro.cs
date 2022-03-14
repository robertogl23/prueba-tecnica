using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class Libro
    {
        public string   Autor            { get; set; }
        public string   TituloLibro      { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string   Editorial        { get; set; }

      
    }
}
