using CapaDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio
{
    public interface ILibroService
    {
        public Libro CrearLibro(Libro libro);
        public List<Libro> GetByAutor(string autor);
        public List<Libro> GetByTitulo(string titulo);
        public List<Libro> GetByDate(DateTime fecha);
        public List<Libro> GetByEditorial(string editorial);
        public List<Libro> GetByAutorAndDate(string autor, DateTime fecha);
        public int DeleteByAutor(string autor);
        public int DeleteByEditorial(string editorial);
    }
}
