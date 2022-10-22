using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.API.DTOs
{
    public class AddUserRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Password lenght must be more 8 and less then 16 chars!", MinimumLength = 8)]
        public string Password { get; set; }

    }
}
