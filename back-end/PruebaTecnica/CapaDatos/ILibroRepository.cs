using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public interface ILibroRepository
    {
        public int CrearLibro(Libro libro);
        public List<Libro> ObtenerLibrosPorAutor(string autor);
        public List<Libro> ObtenerLibrosPorTitulo(string titulo);
        public List<Libro> ObtenerLibrosPoFechaPublicacion(DateTime fecha);
        public List<Libro> ObtenerLibrosPoEditorial(string editorial);
        public List<Libro> ObtenerLibrosPorAutorYFechaPublicacion(string autor, DateTime fecha);
        public int BorrarLibrosPorAutor(string autor);
        public int BorrarLibrosPorEditorial(string editorial);
        public List<Libro> GetReaderBookMapping(SqlDataReader reader);

    }
}
