using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace Saladesport.Models
{
    public class Filiale
    {
        [Key]
        [ScaffoldColumn(false)]
        public int FilialeId { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Filiale name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Locatia")]
        public required string Locatia { get; set; }
       
        public ICollection<Snacks>? Snackses { get; set; }

    }
}
