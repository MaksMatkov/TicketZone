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
        User = 1,
        Admin = 2,   
    }

    public enum Status
    {
        Complete = 0,
        Approved = 1,
        NeedApprove = 2, 
        NeedReject = 3,
        Rejected = 4,
        RejectedDeclined = 5
    }
}
