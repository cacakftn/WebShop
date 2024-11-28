using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Ime je obavezno.")]
        [StringLength(50, ErrorMessage = "Ime ne sme biti duze od 50 karaktera.")]

        public string? FrstName { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno.")]
        [StringLength(50, ErrorMessage = "Prezime ne sme biti duže od 50 karaktera.")]

        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna.")]
      

        public string? Email { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [MinLength(6, ErrorMessage = "Lozinka mora imati najmanje 6 karaktera.")]
        public string? PasswordHash { get; set; }
        public bool Satus { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Uloga korisnika je obavezna.")]
        public int IdRole { get; set; }
    }
}
