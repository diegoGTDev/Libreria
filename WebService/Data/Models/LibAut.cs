using System;
using System.Collections.Generic;

namespace WebService.Data.Models
{
    public partial class LibAut
    {
        public short? IdAutor { get; set; }
        public int? IdLibro { get; set; }

        public virtual Autor? IdAutorNavigation { get; set; }
        public virtual Libro? IdLibroNavigation { get; set; }
    }
}
