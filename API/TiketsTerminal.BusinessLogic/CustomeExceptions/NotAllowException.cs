using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.CustomeExceptions
{
    public class NotAllowException : Exception
    {
        public NotAllowException() : base()
        {
        }

        public NotAllowException(string message)
            : base(message)
        {
        }

        public NotAllowException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
