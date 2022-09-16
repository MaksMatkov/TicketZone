using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class Email
    {
        public Email(string email)
        {
            if (!IsValid(email))
                throw new ArgumentException("Email is not valid");
            Value = email;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public string Value { get; private set; }
    }
}
