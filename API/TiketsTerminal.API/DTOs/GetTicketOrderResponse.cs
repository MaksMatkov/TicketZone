using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.API.DTOs
{
    public class GetTicketOrderResponse
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int FilmViewingTimeId { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; }
    }
}
