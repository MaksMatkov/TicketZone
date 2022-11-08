using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.CustomeExceptions
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException() : base()
        {
        }

        public NotUniqueException(string message)
            : base(message)
        {
        }

        public NotUniqueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
