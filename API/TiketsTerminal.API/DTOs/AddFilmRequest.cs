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
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Url]
        public string TrailerUrl { get; set; }

        [Required]
        [Url]
        public string PosterUrl { get; set; }
    }
}
