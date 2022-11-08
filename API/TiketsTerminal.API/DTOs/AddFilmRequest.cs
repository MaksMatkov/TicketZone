using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class AddFilmRequest
    {
        [Required]
        public string name { get; set; }
        public string description { get; set; }

        [Required]
        [Url]
        public string trailerUrl { get; set; }

        [Required]
        [Url]
        public string posterUrl { get; set; }
    }
}
