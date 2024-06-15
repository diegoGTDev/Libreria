using System;
using System.Collections.Generic;

namespace WebService.Data.Models
{
    public partial class Autor
    {
        public Autor()
        {
            IdLibros = new HashSet<Libro>();
        }

        public short IdAutor { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Nacionalidad { get; set; }

        public virtual ICollection<Libro> IdLibros { get; set; }
    }
}
