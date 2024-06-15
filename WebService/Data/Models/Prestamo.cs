using System;
using System.Collections.Generic;

namespace WebService.Data.Models
{
    public partial class Prestamo
    {
        public short IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public byte? Devuelto { get; set; }

        public virtual Estudiante IdLectorNavigation { get; set; } = null!;
        public virtual Libro IdLibroNavigation { get; set; } = null!;
    }
}
