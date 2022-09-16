using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BLL.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; private set; }

        public int ID { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Domain.Enums.Role FK_Role { get; private set; }
    }
}
