using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class Autore
    {
        public Autore(){
            
        }
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
