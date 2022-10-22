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
        public int FK_Film { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int FK_Room { get; set; }
    }
}
