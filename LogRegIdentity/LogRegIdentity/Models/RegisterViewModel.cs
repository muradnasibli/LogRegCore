using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogRegIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
