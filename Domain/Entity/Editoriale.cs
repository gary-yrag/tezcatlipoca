using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
