using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class RegData
    {
        public RegData(Email email, Password pas, Role role, int id, string name)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (pas == null)
            {
                throw new ArgumentNullException(nameof(pas));
            }
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            ID = id;
            Email = email;
            Password = pas;
            Role = role;
            Name = name;
        }
        public int ID { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }
        public string Name { get; private set; }
    }
}
