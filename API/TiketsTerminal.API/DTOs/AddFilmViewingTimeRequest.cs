using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class AddFilmViewingTimeRequest
    {
        [Required]
        public int filmId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int roomId { get; set; }
    }
}
