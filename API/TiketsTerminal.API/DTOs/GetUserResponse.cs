using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetUserResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsApproved { get; set; }
    }
}
