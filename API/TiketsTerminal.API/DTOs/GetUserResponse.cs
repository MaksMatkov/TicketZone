using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetUserResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime lastVisited { get; set; }
        public bool isApproved { get; set; }
    }
}
