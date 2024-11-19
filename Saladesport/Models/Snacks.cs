using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saladesport.Models
{
    public class Snacks
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SnacksId { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Snacks name")]
        public required string Name { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int SnacksPrice { get; set; }
        [Required]
        [Display(Name = "Durata")]
        public int Durata { get; set; }

        [Required]
        public int FilialeID{ get; set; }
        public Filiale? Filiales { get; set; }
    }
}