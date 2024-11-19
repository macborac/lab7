using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saladesport.Models
{
    public class Abonament
    {
        [Key]
        [ScaffoldColumn(false)]
        public int AbonamentId { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Abonament name")]
        public required string Name { get; set; }
        [Required]
        [Display(Name = "Preț")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Durata")]
        public int Durata { get; set; }

        [Required]
        public int EquipmentID { get; set; }
        public Equipment? Equipment { get; set; }

        public ICollection<Visitator>? Vizitators { get; set; }
    }
}
