using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saladesport.Models
{
    public class Equipment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EquipmentId { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Equipment name")]
        public required string Name { get; set; }
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Exercise name")]
        public required string ExerciseName { get; set; }

        public ICollection<Abonament>? Abonament { get; set; }

        [Required]
        public int Vizitator { get; set; }
        public Visitator? Vizitators { get; set; }
    }
}