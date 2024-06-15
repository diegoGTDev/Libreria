using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebService.Data;
using WebService.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly PruebaContext dbcontext;
        public EstudianteController(PruebaContext context)
        {
            dbcontext = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Estudiante estudiante)
        {
            Console.WriteLine(estudiante);
            Data.Models.Estudiante m_estudiante = dbcontext.Estudiantes.FirstOrDefault(x => x.Nombre == estudiante.Nombre);
            if (m_estudiante !=null)
            {
                return Ok(m_estudiante.IdLector);
            }
            else
            {
                return NotFound("No hay estudiantes");
            }
        }   
    }
}
