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
        public int userId { get; set; }
        public int filmViewingTimeId { get; set; }
        public DateTime creationDate { get; set; }
        public Status status { get; set; }
    }
}
