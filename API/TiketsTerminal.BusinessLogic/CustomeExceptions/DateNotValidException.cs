using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.CustomeExceptions
{
    public class DateNotValidException : Exception
    {
        public DateNotValidException() : base()
        {
        }

        public DateNotValidException(string message)
            : base(message)
        {
        }

        public DateNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
