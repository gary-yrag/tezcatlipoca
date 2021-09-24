using System;
using System.Collections.Generic;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Cal1 { get; set; }
        public decimal? Cal2 { get; set; }
        public decimal? Cal3 { get; set; }
    }
}
