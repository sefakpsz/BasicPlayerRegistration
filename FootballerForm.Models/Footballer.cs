using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballerForm.Models
{
    public class Footballer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Range(1, 150, ErrorMessage ="Invalid Age!")]
        public int Age { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid E-Mail Address!")]
        public string Email { get; set; }
    }
}