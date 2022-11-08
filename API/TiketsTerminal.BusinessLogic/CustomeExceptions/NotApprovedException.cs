using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.CustomeExceptions
{
    [Serializable]
    public class NotApprovedException : Exception
    {
        public int UserId { get; set; }
        public NotApprovedException() : base()
        {
        }

        public NotApprovedException(string message, int userId)
            : base(message)
        {
            UserId = userId;
        }
    }
}
