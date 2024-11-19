using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saladesport.Models
{
    public class Visitator
    {
        [Key]
        [ScaffoldColumn(false)]
        public int VisitatorId { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Visitator first name")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul prenumelui nu este indicat corect")]
        [Display(Name = "Visitator second name")]
        public int SecondName { get; set; }
        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Abonament name")]
        public required string AbonamentName { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de naștere")]
        public DateTime BirthDay { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Date then was bought abonament")]
        public DateTime GettingDate { get; set; }
        [Required(ErrorMessage = "Campul este onligatoriu")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail nu este valid")]
        public required string Mail { get; set; }

        [Required]
        public int AbonamentID { get; set; }
        public Abonament? Abonament { get; set; }

        public ICollection<Visitator>? Visitators { get; set; }
    }
}
