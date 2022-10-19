using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Enums
{
    public enum Role
    {
        None = 0,
        Client = 1,
        Admin = 2,   
    }

    public enum Status
    {
        Complete = 0,
        NeedReject = 1,
        Rejected = 3
    }
}
