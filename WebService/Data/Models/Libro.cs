using System;
using System.Collections.Generic;

namespace WebService.Data.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
            IdAutors = new HashSet<Autor>();
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string Area { get; set; } = null!;

        public virtual ICollection<Prestamo> Prestamos { get; set; }

        public virtual ICollection<Autor> IdAutors { get; set; }
    }
}
