using ApiRest.Controllers;
using CapaDatos;
using CapaDominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrearLibro()
        {
            var service = new LibroService(new LibroRepository());
            var libro = GetLibroFake();
           
            var result = service.CrearLibro(libro);

            Assert.AreEqual(result, libro);

            service.DeleteByAutor(result.Autor);

            try
            {
                var result2 = service.CrearLibro(libro);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Ya existe un libro con el mismo titulo");
            }

            libro.Autor = null;
            try
            {
                var result3 = service.CrearLibro(libro);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Libro invalido");
            }
        }

        [TestMethod]
        public void TestGetByAutor()
        {

            var service = new LibroService(new LibroRepository());
            var autorExpected = "Zygmunt Bauman";

            var listResult = service.GetByAutor(autorExpected);

            foreach (var libro in listResult)
            {
                Assert.AreEqual(libro.Autor.Trim(), autorExpected.Trim());
            }

            try
            {
                var listResult2 = service.GetByAutor(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.GetByAutor("  ");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

        }

        [TestMethod]
        public void TestGetByTitulo()
        {

            var service = new LibroService(new LibroRepository());
            var tituloExpected = "El corredor";

            var listResult = service.GetByTitulo(tituloExpected);
            var libroResult = listResult[0];

            Assert.AreEqual(listResult.Count, 1);

            Assert.AreEqual(libroResult.TituloLibro.Trim(), tituloExpected.Trim());

            try
            {
                var listResult2 = service.GetByTitulo(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.GetByTitulo("  ");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }
        }

        [TestMethod]
        public void TestGetByDate()
        {
            var service = new LibroService(new LibroRepository());
            var fecha = new DateTime(2022,09,03);

            var listResult = service.GetByDate(fecha);

            foreach (var libro in listResult)
            {
                Assert.AreEqual(libro.FechaPublicacion, fecha);
            }
        }

        [TestMethod]
        public void TestGetByEditorial()
        {
            var service = new LibroService(new LibroRepository());
            var editorialExpected = "Paidos México";

            var listResult = service.GetByEditorial(editorialExpected);

            foreach (var libro in listResult)
            {
                Assert.AreEqual(libro.Editorial.Trim(), editorialExpected.Trim());
            }

            try
            {
                var listResult2 = service.GetByEditorial(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.GetByEditorial("  ");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

        }

        [TestMethod]
        public void TestGetByAutorAndDate()
        {
            var service = new LibroService(new LibroRepository());
            var fecha = new DateTime(2022, 03, 09);
            var autorExpected = "Valentine Penrose";


            var listResult = service.GetByAutorAndDate(autorExpected,fecha);

            foreach (var libro in listResult)
            {
                Assert.AreEqual(libro.Autor.Trim(), autorExpected.Trim());
                Assert.AreEqual(libro.FechaPublicacion, fecha);
            }

            try
            {
                var listResult2 = service.GetByAutorAndDate(null,fecha);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.GetByAutorAndDate("  ",fecha);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

        }

        [TestMethod]
        public void TestBorrarLibrosPorAutor()
        {
            var service = new LibroService(new LibroRepository());
            var libroFake = GetLibroFake();
            var libroFakeSaved = service.CrearLibro(libroFake);

            var result = service.DeleteByAutor(libroFakeSaved.Autor);

            Assert.AreEqual(1, result);

            try
            {
                var result2 = service.DeleteByAutor("holexiste");

            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "No existe libro");
            }

            try
            {
                var listResult2 = service.DeleteByAutor(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.DeleteByAutor("  ");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

        }

        [TestMethod]
        public void DeleteByEditorial()
        {
            var service = new LibroService(new LibroRepository());
            var libroFake = GetLibroFake();
            var libroFakeSaved = service.CrearLibro(libroFake);

            var result = service.DeleteByEditorial(libroFakeSaved.Editorial);

            Assert.AreEqual(1, result);

            try
            {
                var result2 = service.DeleteByEditorial("holexiste");

            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "No existe libro");
            }

            try
            {
                var listResult2 = service.DeleteByEditorial(null);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }

            try
            {
                var listResult2 = service.DeleteByEditorial("  ");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Parametro invalido");
            }
        }

        [TestMethod]
        public void TestValidarCampo()
        {
            string text = "dfdsf";
            string text2 = "";
            string text3 = "   ";

            var result = Reglas.ValidarCampo(text);
            var result2 = Reglas.ValidarCampo(text2);
            var result3 = Reglas.ValidarCampo(text3);
            var result4 = Reglas.ValidarCampo(null);


            Assert.IsTrue(result);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);

        }

        [TestMethod]
        public void TestValidarFecha()
        {
            var fecha = "2022/09/03";
            var fecha2 = "2022/230/03";
            var fecha3 = "asdsadadads";

            var result = Reglas.ValidarFecha(fecha);
            var result2 = Reglas.ValidarFecha(fecha2);
            var result3 = Reglas.ValidarFecha(fecha3);
            var result4 = Reglas.ValidarFecha(null);


            Assert.IsTrue(result);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);

        }

        [TestMethod]
        public void TestValidarLibro()
        {

            var libro = GetLibroFake();
            var libro2 = new Libro();
            var libro3 = GetLibroFake();
            libro3.Autor = "  ";
            libro3.TituloLibro = null;

            var result = Reglas.ValidarLibro(libro);
            var result2 = Reglas.ValidarLibro(libro2);
            var result3 = Reglas.ValidarLibro(libro3);

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);

        }


        public Libro GetLibroFake()
        {
            Guid g    = Guid.NewGuid();
            var guid  = g.ToString();
            var libro = new Libro()
            {
                Autor            = "Autor Test",
                TituloLibro      = "Titulo Libro Test-" + guid,
                FechaPublicacion = DateTime.Now,
                Editorial        = "Editorial Test"

            };
            return libro;
        }

    }
}
