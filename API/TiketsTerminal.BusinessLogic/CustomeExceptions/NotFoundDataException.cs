using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BusinessLogic.CustomeExceptions
{
    [Serializable]
    public class NotFoundDataException : Exception
    {
        public NotFoundDataException() : base()
        {
        }

        public NotFoundDataException(string message)
            : base(message)
        {
        }

        public NotFoundDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
