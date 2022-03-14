using CapaDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public int DeleteByAutor(string autor)
        {
            if (!Reglas.ValidarCampo(autor))
            {
                throw new Exception("Parametro invalido");
            }
            if (_libroRepository.ObtenerLibrosPorAutor(autor).Count == 0)
            {
                throw new Exception("No existe libro");

            }
            return _libroRepository.BorrarLibrosPorAutor(autor);
        }

        public int DeleteByEditorial(string editorial)
        {
            if (!Reglas.ValidarCampo(editorial))
            {
                throw new Exception("Parametro invalido");
            }
            if (_libroRepository.ObtenerLibrosPoEditorial(editorial).Count == 0)
            {
                throw new Exception("No existe libro");
            }
            return _libroRepository.BorrarLibrosPorEditorial(editorial);
        }

        public Libro CrearLibro(Libro libro)
        {
            if (!Reglas.ValidarLibro(libro))
            {
                throw new Exception("Libro invalido");
            }
            if (_libroRepository.ObtenerLibrosPorTitulo(libro.TituloLibro).Count > 0)
            {
                throw new Exception("Ya existe un libro con el mismo titulo");
            }

            int result = _libroRepository.CrearLibro(libro);
            if (result == 0)
            {
                throw new Exception("Error al crear un libro");
            }

            return libro;
        }

        public List<Libro> GetByAutor(string autor)
        {
            if (!Reglas.ValidarCampo(autor))
            {
                throw new Exception("Parametro invalido");
            }
            return _libroRepository.ObtenerLibrosPorAutor(autor);
        }

        public List<Libro> GetByAutorAndDate(string autor, DateTime fecha)
        {
            if (!Reglas.ValidarCampo(autor))
            {
                throw new Exception("Parametro invalido");
            }
            return _libroRepository.ObtenerLibrosPorAutorYFechaPublicacion(autor,fecha);
        }

        public List<Libro> GetByDate(DateTime fecha)
        {
            if (!Reglas.ValidarFecha(fecha))
            {
                throw new Exception("Parametro invalido");
            }
            return _libroRepository.ObtenerLibrosPoFechaPublicacion(fecha);
        }

        public List<Libro> GetByEditorial(string editorial)
        {
            if (!Reglas.ValidarCampo(editorial))
            {
                throw new Exception("Parametro invalido");
            }
            return _libroRepository.ObtenerLibrosPoEditorial(editorial);
        }

        public List<Libro> GetByTitulo(string titulo)
        {
            if (!Reglas.ValidarCampo(titulo))
            {
                throw new Exception("Parametro invalido");
            }
            return _libroRepository.ObtenerLibrosPorTitulo(titulo);
        }
    }
}
