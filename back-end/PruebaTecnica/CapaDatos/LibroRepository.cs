using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class LibroRepository : ConnectionDataBase,ILibroRepository
    {
        public int CrearLibro(Libro libro)
        {
            string queryString = "Crear_Libro";
            int result = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@autor", SqlDbType.NChar).Value = libro.Autor;
                command.Parameters.Add("@titulo_libro", SqlDbType.NChar).Value = libro.TituloLibro;
                command.Parameters.Add("@fecha_publicacion", SqlDbType.Date).Value = libro.FechaPublicacion;
                command.Parameters.Add("@editorial", SqlDbType.NChar).Value = libro.Editorial;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = 0;
                    throw;
                }
            }
            return result;
        }

        public List<Libro> ObtenerLibrosPorAutor(string autor)
        {
            string queryString = "Buscar_Libros_Por_Autor";
            var listaLibros = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@autor", SqlDbType.NChar).Value = autor;

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    listaLibros = GetReaderBookMapping(reader);

                }
                catch (Exception)
                {
                    listaLibros = null;
                }
   
            }
            return listaLibros;
        }

        public List<Libro> ObtenerLibrosPorTitulo(string titulo)
        {
            string queryString = "Buscar_Libros_Por_Titulo";
            var listaLibros = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@titulo", SqlDbType.NChar).Value = titulo;

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listaLibros = GetReaderBookMapping(reader);

                }
                catch (Exception)
                {
                    listaLibros = null;
                }

            }
            return listaLibros;
        }

        public List<Libro> ObtenerLibrosPoFechaPublicacion(DateTime fecha)
        {
            string queryString = "Buscar_Libros_Por_Fecha_Publicacion";
            var listaLibros = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Fecha_Publicacion", SqlDbType.Date).Value = fecha;

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    listaLibros = GetReaderBookMapping(reader);
                }
                catch (Exception)
                {
                    listaLibros = null;
                    throw;
                }

            }
            return listaLibros;
        }

        public List<Libro> ObtenerLibrosPoEditorial(string editorial)
        {
            string queryString = "Buscar_Libros_Por_Editorial";
            var listaLibros = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Editorial", SqlDbType.NChar).Value = editorial;

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    listaLibros = GetReaderBookMapping(reader);
                }
                catch (Exception)
                {
                    listaLibros = null;
                    throw;
                }

            }
            return listaLibros;
        }

        public List<Libro> ObtenerLibrosPorAutorYFechaPublicacion(string autor, DateTime fecha)
        {
            string queryString = "Buscar_libros_Por_Autor_Y_Fecha_Publicacion";
            var listaLibros = new List<Libro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Autor", SqlDbType.NChar).Value = autor;
                command.Parameters.Add("@Fecha_Publicacion", SqlDbType.Date).Value = fecha;

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    listaLibros = GetReaderBookMapping(reader);
                }
                catch (Exception)
                {
                    listaLibros = null;
                    throw;
                }

            }
            return listaLibros;
        }
        public int BorrarLibrosPorAutor(string autor)
        {
            string queryString = "Borrar_Libro_Por_Autor";
            int result = 1;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Autor", SqlDbType.NChar).Value = autor;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = 0;
                }

            }
            return result;
        }

        public int BorrarLibrosPorEditorial(string editorial)
        {
            string queryString = "Borrar_Libros_Por_Editorial";
            int result = 1;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Editorial", SqlDbType.NChar).Value = editorial;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = 0;
                }

            }
            return result;
        }

        public List<Libro> GetReaderBookMapping(SqlDataReader reader)
        {
            var listaLibros = new List<Libro>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var libro = new Libro
                    {
                        Autor = reader.GetString(1),
                        TituloLibro = reader.GetString(2),
                        FechaPublicacion = reader.GetDateTime(3),
                        Editorial = reader.GetString(4)
                    };
                    listaLibros.Add(libro);
                }
            }
            return listaLibros;
        }
    }
}
