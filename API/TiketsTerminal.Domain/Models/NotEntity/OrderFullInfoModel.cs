using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.Domain.Models.NotEntity
{
    [Keyless]
    public class OrderFullInfoModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int filmViewingTimeId { get; set; }
        public string filmName { get; set; }
        public int roomNumber { get; set; }
        public string userEmail { get; set; }
        public DateTime creationDate { get; set; }
        public Status status { get; set; }
    }
}
