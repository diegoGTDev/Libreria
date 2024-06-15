using System;
using System.Collections.Generic;

namespace WebService.Data.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public short IdLector { get; set; }
        public string? Ci { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Carrera { get; set; }
        public byte? Edad { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
