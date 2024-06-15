using Microsoft.AspNetCore.Mvc;
using WebService.Controllers.Request;
using WebService.Data;
using WebService.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly PruebaContext dbcontext;
        public LibroController(PruebaContext context)
        {
            dbcontext = context;
        }
        [HttpPost]
        [Route("Prestar")]
        public IActionResult Post([FromBody] libroRequest libro)
        {

            Console.WriteLine("Hello world");
            bool disponibles = false;
            if (dbcontext.Prestamos.Count() > 0)
            {
                var cantidadPrestados = dbcontext.Prestamos.Count(x => x.Devuelto == 0);
                var cantidadDisponibles = dbcontext.Prestamos.Count(x => x.Devuelto == 1) - cantidadPrestados;
                if (cantidadDisponibles != 0 )
                {
                    disponibles = true;
                }
            }
            else
            {
                disponibles = true;
            }

           

            if (disponibles)
            {
                var libroAPrestar = dbcontext.Libros.FirstOrDefault(x => x.Titulo == libro.Titulo);

                if (libroAPrestar != null)
                {
                    var prestamo = dbcontext.Prestamos.FirstOrDefault(x => x.IdLibro == libroAPrestar.IdLibro && x.Devuelto == 0);
                    if (prestamo != null)
                    {
                        return NotFound("Libro en uso");
                    }
                }
                if (libroAPrestar != null && !dbcontext.Prestamos.Any(x => x.IdLibro == libroAPrestar.IdLibro && x.Devuelto == 0))
                {

                    var prestamo = new Data.Models.Prestamo();
                    prestamo.IdLibro = libroAPrestar.IdLibro;
                    prestamo.IdLector = (Int16) libro.IdLector;
                    prestamo.FechaPrestamo = libro.FechaPrestamo;
                    prestamo.Devuelto = 0;
                    dbcontext.Prestamos.Add(prestamo);
                    dbcontext.SaveChanges();
                    return Ok("Libro prestado");
                }
                else
                {
                    return NotFound("Libro en uso/No existente");
                }
            }
            else
            {
                return NotFound("Libros no disponibles, seleccione otra fecha");
            }
        }
        [Route("Devolver")]
        [HttpPost]
        public IActionResult Devolver([FromBody] libroRequest libro)
        {
          
            var libroADevolver = dbcontext.Libros.FirstOrDefault(x => x.Titulo == libro.Titulo);
            if (libroADevolver != null)
            {
                var prestamo = dbcontext.Prestamos.FirstOrDefault(x => x.IdLibro == libroADevolver.IdLibro && x.Devuelto == 0);
                
            

                if (prestamo != null)
                {
                    if (prestamo.IdLector != libro.IdLector)
                    {
                        return NotFound("Este libro no ha sido prestado por usted");
                    }
                    prestamo.FechaDevolucion = DateTime.Now;
                    prestamo.Devuelto = 1;
                    dbcontext.SaveChanges();
                    return Ok("Libro devuelto");
                }
                else
                {
                    return NotFound("Libro no encontrado o ya ha sido devuelto");
                }
            }
            else
            {
                return NotFound("Libro no encontrado");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("HEllo world");
            var libros = dbcontext.Libros.ToList();
            return Ok(libros);
        }   
    }
}
