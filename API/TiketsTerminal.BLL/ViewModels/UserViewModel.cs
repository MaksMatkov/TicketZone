using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BLL.ViewModels
{
    public class UserViewModel
    {
        public string Name { get;  set; }

        public int ID { get;  set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Domain.Enums.Role FK_Role { get; set; }
    }
}
