using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class AutoresHasLibro
    {
        [Display(Name = "Autor")]
        [Required]
        public int? AutoresId { get; set; }
        [Display(Name = "Libro")]
        [Required]
        public int? LibrosIsbn { get; set; }

        public virtual Autore Autores { get; set; }
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
