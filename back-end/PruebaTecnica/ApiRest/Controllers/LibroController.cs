using CapaDatos;
using CapaDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        [Route("create-libro")]
        public ActionResult<List<Libro>> PostCrearLibro(Libro libro)
        {
            try
            {
                _libroService.CrearLibro(libro);
                return CreatedAtAction(nameof(GetLibrosPorAutor), new { autor = libro.Autor }, libro);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("get-by-autor")]
        public ActionResult<List<Libro>> GetLibrosPorAutor(string autor)
        {
            try
            {
                var result = _libroService.GetByAutor(autor);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }      
        }

        [HttpGet]
        [Route("get-by-title")]
        public ActionResult<List<Libro>> GetLibrosPorTitulo(string titulo)
        {
            try
            {
                var result = _libroService.GetByTitulo(titulo);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("get-by-publication-date")]
        public ActionResult<List<Libro>> GetLibrosPoFechaPublicacion(DateTime fecha)
        {
            try
            {
                var result = _libroService.GetByDate(fecha);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("get-by-editorial")]
        public ActionResult<List<Libro>> GetLibrosPorEditorial(string editorial)
        {
            try
            {
                var result = _libroService.GetByEditorial(editorial);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("get-by-autor-and-publication-date")]
        public ActionResult<List<Libro>> GetLibrosPorAutorYFechaPublicacion(string autor,DateTime fecha)
        {
            try
            {
                var result = _libroService.GetByAutorAndDate(autor, fecha);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        [Route("delete-by-autor")]
        public ActionResult<int> DeleteLibrosPorAutor(string autor)
        {
            try
            {
                var result = _libroService.DeleteByAutor(autor);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete]
        [Route("delete-by-editorial")]
        public ActionResult<int> DeleteLibrosPorEditorial(string editorial)
        {
            try
            {
                var result = _libroService.DeleteByEditorial(editorial);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
    }
}
