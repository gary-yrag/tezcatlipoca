using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class Libro
    {
        public int Isbn { get; set; }
        [Display(Name = "Editorial")]
        [Required]
        public int? EditorialesId { get; set; }
        [Display(Name = "Titulo del libro")]
        [Required]
        public string Titulo { get; set; }
        [Display(Name="Sinopsis del libro")]
        [Required]
        public string Sinopsis { get; set; }
         [Display(Name="Nro. de Paginas")]
        [Required]
        public string NPaginas { get; set; }

        public virtual Editoriale Editoriales { get; set; }
    }
}
