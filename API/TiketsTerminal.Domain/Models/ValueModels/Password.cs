using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class Password
    {
        public Password(string password)
        {
            if (!IsValid(password))
                throw new ArgumentException("Password is not valid");
            Value = password;
        }

        private bool IsValid(string password)
        {
            if (String.IsNullOrWhiteSpace(password) || password.Length < 4)
                return false;
            return true;
        }

        public string Value { get; private set; }
    }
}
